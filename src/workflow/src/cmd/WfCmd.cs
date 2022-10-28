//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class WfCmd
    {
        static AppDb AppDb => AppDb.Service;
        
        public static Task<ExecToken> redirect(IWfChannel channel, CmdArgs args)
        {
            ExecToken Run()
            {
                var running = channel.Running("cmd/redirect");
                var outAPath = AppDb.AppData().Path("a", FileKind.Log);
                var outBPath = AppDb.AppData().Path("b", FileKind.Log);
                using var outA = outAPath.Utf8Writer();
                using var outB = outBPath.Utf8Writer();

                void OnA(string msg)
                {
                    channel.Row(msg, FlairKind.Data);
                    outA.WriteLine(msg);
                }

                void OnB(string msg)
                {
                    channel.Row(msg, FlairKind.StatusData);
                    outB.WriteLine(msg);
                }

                ProcessControl.start(channel, new SysIO(OnA,OnB), args).Wait();
                return channel.Ran(running, outA);
            }
            return sys.start(Run);
        }

        public static WfContext<C> context<C>(IWfRuntime wf, Func<ReadOnlySeq<ICmdProvider>> factory)
            where C : IAppCmdSvc, new()
        {
            var running = wf.Running($"Creating command providers");
            var providers = factory();
            wf.Ran(running, $"Created {providers.Length} command providers");
            return context<C>(wf, providers);
        }

        public static WfContext<C> context<C>(IWfRuntime wf, ReadOnlySeq<ICmdProvider> providers)
            where C : IAppCmdSvc, new()
        {
            var emitter = Require.notnull(wf.Emitter);
            var name = $"clr:://z0/{typeof(C).Assembly.GetSimpleName()}/{typeof(C).DisplayName()}";
            var msg = $"Creating {name}";
            var service = new C();            
            var running = emitter.Running(msg);
            service.Init(wf);
            var context = new WfContext<C>(service, wf.Channel, wf, dispatcher(service, wf.Emitter, providers));
            wf.Ran(running, $"Created {name}");
            return context;
        }

        static IWfDispatcher dispatcher<T>(T service, IWfChannel channel, ReadOnlySeq<ICmdProvider> providers)
        {
            var flow = channel.Running($"Discovering {service} dispatchers");
            var dst = dict<string,IWfCmdRunner>();
            iter(runners(service), r => dst.TryAdd(r.Def.CmdName, r));
            iter(providers, p => iter(runners(p), r => dst.TryAdd(r.Def.CmdName, r)));
            var dispatcher = new WfCmdRouter(channel, providers, new AppCommands(dst));
            install(dispatcher, providers);
            return dispatcher;
        }        

        public static CmdActorKind classify(MethodInfo src)
        {
            var dst = CmdActorKind.None;
            var arity = src.ArityValue();
            var @void = src.HasVoidReturn();
            switch(arity)
            {
                case 0:
                    switch(@void)
                    {
                        case false:
                            dst = CmdActorKind.Pure;
                        break;
                        case true:
                            dst = CmdActorKind.Emitter;
                        break;
                    }
                break;
                case 1:
                    switch(@void)
                    {
                        case true:
                            dst = CmdActorKind.Receiver;
                        break;
                        case false:
                            dst = CmdActorKind.Func;
                        break;
                    }
                break;
            }
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static CmdUri uri(CmdKind kind, string? part, string? host, string? name)
            => new CmdUri(kind, part, host, name);

        [Op]
        public static CmdUri uri(MethodInfo src)
        {
            var kind = CmdKind.App;
            var host = src.DeclaringType;
            var part = host.Assembly.PartName().Format();
            var attrib = src.Tag<CmdOpAttribute>();
            var name = attrib.MapValueOrElse(a => a.Name, () => src.DisplayName());
            return uri(kind,part, host.DisplayName(), name);        
        }

        [Op]
        public static bool parse(ReadOnlySpan<char> src, out AppCmdSpec dst)
        {
            var i = SQ.index(src, Chars.Space);
            if(i < 0)
                dst = new AppCmdSpec(@string(src), CmdArgs.Empty);
            else
            {
                var name = sys.@string(SQ.left(src,i));
                var _args = sys.@string(SQ.right(src,i)).Split(Chars.Space);
                dst = new AppCmdSpec(name, Cmd.args(_args));
            }
            return true;
        }

        [Op]
        public static WfCmdRunner runner(string name, object host, MethodInfo method)
            => new WfCmdRunner(name, host, method);

        public static ConstLookup<Name,WfCmdMethod> defs(IWfDispatcher src)
        {
            ref readonly var defs = ref src.Commands.Defs;
            var dst = dict<Name,WfCmdMethod>();
            iter(defs.View, def => dst.Add(def.CmdName, def));
            return dst;
        }

        public static WfCmdMethod def(object host, MethodInfo method)
        {
            var attrib = method.Tag<CmdOpAttribute>().Require();
            return new WfCmdMethod(attrib.Name, WfCmd.classify(method), method, host);
        }

        [Op]
        public static ReadOnlySeq<WfCmdRunner> runners(object host)
        {
            var methods = host.GetType().DeclaredInstanceMethods().Tagged<CmdOpAttribute>();
            var dst = alloc<WfCmdRunner>(methods.Length);
            runners(host, methods, dst);
            return dst;
        }

        static void runners(object host, ReadOnlySpan<MethodInfo> src, Span<WfCmdRunner> dst)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var method = ref skip(src,i);
                var tag = method.Tag<CmdOpAttribute>().Require();
                seek(dst,i) = runner(tag.Name, host, method);
            }
        }

        static void install(IWfDispatcher dispatcher, ReadOnlySeq<ICmdProvider> src)
            => Z0.AppData.get().Value(nameof(IWfDispatcher), dispatcher);

        public static AppCommands distill(IAppCommands[] src)
        {
            var dst = dict<string,IWfCmdRunner>();
            foreach(var a in src)
                iter(a.Invokers,  a => dst.TryAdd(a.CmdName, a));
            return new AppCommands(dst);
        }

        public static void emit(IWfChannel channel, CmdCatalog src, FilePath dst)
        {
            var data = src.Values;
            iter(data, x => channel.Row(x.Uri.Name));
            Tables.emit(channel, data, dst);
        }

        public static CmdCatalog catalog(ReadOnlySeq<WfCmdMethod> src)
        {
            var count = src.Count;
            var dst = alloc<CmdUri>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = src[i].Uri;
            return new CmdCatalog(entries(dst));
        }

        public static CmdCatalog catalog(IWfDispatcher src)
        {
            ref readonly var defs = ref src.Commands.Defs;
            var count = defs.Count;
            var dst = alloc<CmdUri>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = defs[i].Uri;
            return new CmdCatalog(entries(dst));
        }

        static ReadOnlySeq<CmdCatalogEntry> entries(CmdUriSeq src)    
        {
            var entries = alloc<CmdCatalogEntry>(src.Count);
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var uri = ref src[i];
                ref var entry = ref seek(entries,i);
                entry.Uri = uri;
                entry.Hash = uri.Hash;
                entry.Name = uri.Name;
            }
            return entries.Sort().Resequence();        
        }        
    }
}