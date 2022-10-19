//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class AppCmd
    {
        public static T service<T>(IWfRuntime wf, ReadOnlySeq<ICmdProvider> providers)
            where T : ICmdService, new()
        {
            var emitter = Require.notnull(wf.Emitter);
            var name = $"clr:://z0/{typeof(T).Assembly.GetSimpleName()}/{typeof(T).DisplayName()}";
            var msg = $"Creating {name}";
            var service = new T();            
            var running = emitter.Running(msg);
            service.Init(wf);
            dispatcher(service, wf.Emitter, providers);
            wf.Ran(running, $"Created {name}");
            return service;
        }

        static IAppCmdDispatcher dispatcher<T>(T service, IWfChannel channel, ReadOnlySeq<ICmdProvider> providers)
        {
            var flow = channel.Running($"Discovering {service} dispatchers");
            var dst = dict<string,IAppCmdRunner>();
            iter(runners(service), r => dst.TryAdd(r.Def.CmdName, r));
            iter(providers, p => iter(runners(p), r => dst.TryAdd(r.Def.CmdName, r)));
            var dispatcher = new AppCmdDispatcher(channel, providers, new AppCommands(dst));
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

        public static CmdUriSeq uri<S>(IAppCmdDispatcher src)
        {
            ref readonly var defs = ref src.Commands.Defs;
            var part = src.Controller;
            var count = defs.Count;
            var dst = alloc<CmdUri>(count);
            for(var i=0; i<defs.Count; i++)
                seek(dst,i) = defs[i].Uri;
            return dst;            
        }

        [Op]
        public static AppCmdRunner runner(string name, object host, MethodInfo method)
            => new AppCmdRunner(name, host, method);

        public static ConstLookup<Name,AppCmdMethod> defs(IAppCmdDispatcher src)
        {
            ref readonly var defs = ref src.Commands.Defs;
            var dst = dict<Name,AppCmdMethod>();
            iter(defs.View, def => dst.Add(def.CmdName, def));
            return dst;
        }

        public static AppCmdMethod def(object host, MethodInfo method)
        {
            var attrib = method.Tag<CmdOpAttribute>().Require();
            return new AppCmdMethod(attrib.Name, AppCmd.classify(method), method, host);
        }

        [Op]
        public static ReadOnlySeq<AppCmdRunner> runners(object host)
        {
            var methods = host.GetType().DeclaredInstanceMethods().Tagged<CmdOpAttribute>();
            var dst = alloc<AppCmdRunner>(methods.Length);
            runners(host, methods, dst);
            return dst;
        }

        static void runners(object host, ReadOnlySpan<MethodInfo> src, Span<AppCmdRunner> dst)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var method = ref skip(src,i);
                var tag = method.Tag<CmdOpAttribute>().Require();
                seek(dst,i) = runner(tag.Name, host, method);
            }
        }

        static void install(IAppCmdDispatcher dispatcher, ReadOnlySeq<ICmdProvider> src)
            => Z0.AppData.get().Value(nameof(IAppCmdDispatcher), dispatcher);


        public static AppCommands distill(IAppCommands[] src)
        {
            var dst = dict<string,IAppCmdRunner>();
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

        public static CmdCatalog catalog(ReadOnlySeq<AppCmdMethod> src)
        {
            var count = src.Count;
            var dst = alloc<CmdUri>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = src[i].Uri;
            return new CmdCatalog(entries(dst));
        }

        public static CmdCatalog catalog(IAppCmdDispatcher src)
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

        [ApiComplete("api.files")]
        public class files
        {
            [Api]
            public static Copy copy(FolderPath src, FolderPath dst)
                => new (src,dst);

            [Api]
            public static Zip zip(FolderPath src, FilePath dst)
                => new (src,dst);

            [Cmd("files/copy")]
            public struct Copy : ICmd<Copy>
            {
                public Copy(FolderPath src, FolderPath dst)
                {
                    Source = src;
                    Target = dst;
                }

                public FolderPath Source;

                public FolderPath Target;
            }

            [Cmd("files/copy")]
            public struct Zip : ICmd<Zip>
            {
                public Zip(FolderPath src, FilePath dst)
                {
                    Source = src;
                    Target = dst;
                }

                public FolderPath Source;

                public FilePath Target;
            }
        }
    }
}