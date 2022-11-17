
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class ApiCmd : AppService<ApiCmd>, IApiCmdSvc
    {
        public static CmdUriSeq uris(IApiDispatcher src)
        {
            ref readonly var defs = ref src.Commands.Defs;
            var part = src.Controller;
            var count = defs.Count;
            var dst = alloc<CmdUri>(count);
            for(var i=0; i<defs.Count; i++)
                seek(dst,i) = defs[i].Uri;
            return dst;            
        }

        public static ApiCmdCatalog catalog(ReadOnlySeq<ApiOp> src)
        {
            var count = src.Count;
            var dst = alloc<CmdUri>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = src[i].Uri;
            return new ApiCmdCatalog(entries(dst));
        }

        public static ApiCmdCatalog catalog(IApiDispatcher src)
        {
            ref readonly var defs = ref src.Commands.Defs;
            var count = defs.Count;
            var dst = alloc<CmdUri>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = defs[i].Uri;
            return new ApiCmdCatalog(entries(dst));
        }

        [Op]
        public static CmdUri uri(MethodInfo src)
        {
            var kind = CmdKind.App;
            var host = src.DeclaringType;
            var part = host.Assembly.PartName().Format();
            var attrib = src.Tag<CmdOpAttribute>();
            var name = attrib.MapValueOrElse(a => a.Name, () => src.DisplayName());
            return Cmd.uri(kind,part, host.DisplayName(), name);        
        }

        public static WfOps distill(IApiOps[] src)
        {
            var dst = dict<string,IApiCmdMethod>();
            foreach(var a in src)
                iter(a.Invokers,  a => dst.TryAdd(a.CmdName, a));
            return new WfOps(dst);
        }

        public static IApiDispatcher Dispatcher 
            => AppData.Value<IApiDispatcher>(nameof(IApiDispatcher));

        IApiDispatcher IApiCmdSvc.Dispatcher 
            => Dispatcher;

        public void RunCmd(string name, CmdArgs args)
            => ApiCmd.Dispatcher.Dispatch(name, args);

        string Prompt()
            => string.Format("{0}> ", "cmd");

        ApiCmdSpec Next()
        {
            var input = term.prompt(Prompt());
            if(ApiCmd.parse(input, out ApiCmdSpec cmd))
            {
                return cmd;
            }
            else
            {
                Channel.Error($"ParseFailure:{input}");
                return ApiCmdSpec.Empty;
            }
        }

        public void Loop()
        {
            var input = Next();
            while(input.Name != ".exit")
            {
                if(input.IsNonEmpty)
                    RunCmd(input);
                input = Next();
            }
        }
            
        public void RunCmd(string name)
        {
            var result = Dispatcher.Dispatch(name);
            if(result.Fail)
                Channel.Error(result.Message);
        }

        public void RunCmd(ApiCmdSpec cmd)
        {
            try
            {
                Dispatcher.Dispatch(cmd.Name, cmd.Args);
            }
            catch(Exception e)
            {
                Channel.Error(e);
            }
        }

        public void RunCmdScript(FilePath src)
        {
            if(src.Missing)
            {
                Channel.Error(AppMsg.FileMissing.Format(src));
            }
            else
            {
                var lines = src.ReadNumberedLines(true);
                var count = lines.Count;
                for(var i=0; i<count; i++)
                {
                    ref readonly var content = ref lines[i].Content;
                    if(ApiCmd.parse(content, out ApiCmdSpec spec))
                        RunCmd(spec);
                    else
                    {
                        Error($"ParseFailure:'{content}'");
                        break;
                    }
                }
            }
        }

        static ReadOnlySeq<ApiCmdInfo> entries(CmdUriSeq src)    
        {
            var entries = alloc<ApiCmdInfo>(src.Count);
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

        public static ConstLookup<Name,ApiOp> defs(IApiDispatcher src)
        {
            ref readonly var defs = ref src.Commands.Defs;
            var dst = dict<Name,ApiOp>();
            iter(defs.View, def => dst.Add(def.CmdName, def));
            return dst;
        }

        public ConstLookup<Name,ApiOp> CmdDefs()
            => defs(Dispatcher);

        public CmdUriSeq CmdUris()
            => uris(Dispatcher);

        public static void emit(IWfChannel channel, ApiCmdCatalog src, FilePath dst)
        {
            var data = src.Values;
            iter(data, x => channel.Row(x.Uri.Name));
            CsvChannels.emit(channel, data, dst);
        }

        [Op]
        public static bool parse(ReadOnlySpan<char> src, out ApiCmdSpec dst)
        {
            var i = SQ.index(src, Chars.Space);
            if(i < 0)
                dst = new ApiCmdSpec(@string(src), CmdArgs.Empty);
            else
            {
                var name = sys.@string(SQ.left(src,i));
                var _args = sys.@string(SQ.right(src,i)).Split(Chars.Space);
                dst = new ApiCmdSpec(name, CmdArgs.args(_args));
            }
            return true;
        }

        public static ApiContext<C> context<C>(IWfRuntime wf, Func<ReadOnlySeq<IApiCmdProvider>> factory)
            where C : IApiCmdSvc, new()
        {
            var running = wf.Running($"Creating command providers");
            var providers = factory();
            wf.Ran(running, $"Created {providers.Length} command providers");
            return context<C>(wf, providers);
        }

        static ApiContext<C> context<C>(IWfRuntime wf, ReadOnlySeq<IApiCmdProvider> providers)
            where C : IApiCmdSvc, new()
        {
            var emitter = Require.notnull(wf.Emitter);
            var name = $"clr:://z0/{typeof(C).Assembly.GetSimpleName()}/{typeof(C).DisplayName()}";
            var msg = $"Creating {name}";
            var service = new C();            
            var running = emitter.Running(msg);
            service.Init(wf);
            var context = new ApiContext<C>(service, wf.Channel, wf, dispatcher(service, wf.Emitter, providers));
            wf.Ran(running, $"Created {name}");
            return context;
        }

        static IApiDispatcher dispatcher<T>(T service, IWfChannel channel, ReadOnlySeq<IApiCmdProvider> providers)
        {
            var flow = channel.Running($"Discovering {service} dispatchers");
            var dst = dict<string,IApiCmdMethod>();
            iter(runners(service), r => dst.TryAdd(r.Op.CmdName, r));
            iter(providers, p => iter(runners(p), r => dst.TryAdd(r.Op.CmdName, r)));
            var dispatcher = new ApiDispatcher(channel, providers, new WfOps(dst));
            install(dispatcher, providers);
            return dispatcher;
        }        

        [Op]
        static ReadOnlySeq<ApiCmdMethod> runners(object host)
        {
            var methods = host.GetType().DeclaredInstanceMethods().Tagged<CmdOpAttribute>();
            var dst = alloc<ApiCmdMethod>(methods.Length);
            runners(host, methods, dst);
            return dst;
        }

        static void runners(object host, ReadOnlySpan<MethodInfo> src, Span<ApiCmdMethod> dst)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var method = ref skip(src,i);
                var tag = method.Tag<CmdOpAttribute>().Require();
                seek(dst,i) = runner(tag.Name, host, method);
            }
        }

        [Op]
        static ApiCmdMethod runner(string name, object host, MethodInfo method)
            => new ApiCmdMethod(name, host, method);

        static void install(IApiDispatcher dispatcher, ReadOnlySeq<IApiCmdProvider> src)
            => Z0.AppData.get().Value(nameof(IApiDispatcher), dispatcher);


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

        public static void dispatch(IWfContext context, FilePath defs)
        {
            if(defs.Missing)
            {
                context.Channel.Error(AppMsg.FileMissing.Format(defs));
            }
            else
            {
                var lines = defs.ReadNumberedLines(true);
                var count = lines.Count;
                for(var i=0; i<count; i++)
                {
                    ref readonly var content = ref lines[i].Content;
                    if(parse(content, out ApiCmdSpec spec))
                    {
                        context.Dispatcher.Dispatch(spec.Name, spec.Args);
                    }
                    else
                    {
                        context.Channel.Error($"ParseFailure:'{content}'");
                        break;
                    }
                }
            }
        }
    }
}