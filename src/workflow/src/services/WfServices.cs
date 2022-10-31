//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class WfServices : WfSvc<WfServices>, IWfServices
    {
        public static ExecResult exec<C>(IWfContext context, C cmd, Func<IWfContext,C,Outcome> actor)
            where C : ICmd<C>, new()
        {
            var result = ExecResult.Empty;
            var outcome = Outcome.Success;
            var running = context.Channel.Running($"{cmd.CmdId}");
            try
            {
                outcome = actor(context,cmd);
            }
            catch(Exception e)
            {
                outcome = e;
            }

            return new(context.Channel.Ran(running, result),outcome);
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
                    if(WfCmd.parse(content, out AppCmdSpec spec))
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

        public static CmdUriSeq commands<S>(IWfDispatcher src)
        {
            ref readonly var defs = ref src.Commands.Defs;
            var part = src.Controller;
            var count = defs.Count;
            var dst = alloc<CmdUri>(count);
            for(var i=0; i<defs.Count; i++)
                seek(dst,i) = defs[i].Uri;
            return dst;            
        }

        public static ConstLookup<Name,WfOp> defs(IWfDispatcher src)
        {
            ref readonly var defs = ref src.Commands.Defs;
            var dst = dict<Name,WfOp>();
            iter(defs.View, def => dst.Add(def.CmdName, def));
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

        internal static CmdActorKind classify(MethodInfo src)
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

        public static WfContext<C> context<C>(IWfRuntime wf, Func<ReadOnlySeq<ICmdProvider>> factory)
            where C : IAppCmdSvc, new()
        {
            var running = wf.Running($"Creating command providers");
            var providers = factory();
            wf.Ran(running, $"Created {providers.Length} command providers");
            return context<C>(wf, providers);
        }

        static WfContext<C> context<C>(IWfRuntime wf, ReadOnlySeq<ICmdProvider> providers)
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

        [Op]
        static ReadOnlySeq<WfCmdRunner> runners(object host)
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

        [Op]
        static WfCmdRunner runner(string name, object host, MethodInfo method)
            => new WfCmdRunner(name, host, method);

        static void install(IWfDispatcher dispatcher, ReadOnlySeq<ICmdProvider> src)
            => Z0.AppData.get().Value(nameof(IWfDispatcher), dispatcher);

        public JsonDocument Serialize<A>(A src)
            where A : IWfAction<A>, new()
                => JsonData.document(src);

        public A Materialize<A>(JsonText src)
            where A : IWfAction<A>, new()
                => JsonData.materialize<A>(src);
    }
}