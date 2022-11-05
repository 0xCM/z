//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class WfServices : WfSvc<WfServices>, IWfServices
    {
        public static ConstLookup<Name,WfOp> defs(IWfDispatcher src)
        {
            ref readonly var defs = ref src.Commands.Defs;
            var dst = dict<Name,WfOp>();
            iter(defs.View, def => dst.Add(def.CmdName, def));
            return dst;
        }


        // static WfContext<C> context<C>(IWfRuntime wf, ReadOnlySeq<ICmdProvider> providers)
        //     where C : IAppCmdSvc, new()
        // {
        //     var emitter = Require.notnull(wf.Emitter);
        //     var name = $"clr:://z0/{typeof(C).Assembly.GetSimpleName()}/{typeof(C).DisplayName()}";
        //     var msg = $"Creating {name}";
        //     var service = new C();            
        //     var running = emitter.Running(msg);
        //     service.Init(wf);
        //     var context = new WfContext<C>(service, wf.Channel, wf, dispatcher(service, wf.Emitter, providers));
        //     wf.Ran(running, $"Created {name}");
        //     return context;
        // }

        // static IWfDispatcher dispatcher<T>(T service, IWfChannel channel, ReadOnlySeq<ICmdProvider> providers)
        // {
        //     var flow = channel.Running($"Discovering {service} dispatchers");
        //     var dst = dict<string,IWfCmdRunner>();
        //     iter(runners(service), r => dst.TryAdd(r.Def.CmdName, r));
        //     iter(providers, p => iter(runners(p), r => dst.TryAdd(r.Def.CmdName, r)));
        //     var dispatcher = new WfCmdRouter(channel, providers, new AppCommands(dst));
        //     install(dispatcher, providers);
        //     return dispatcher;
        // }        

        // [Op]
        // static ReadOnlySeq<WfCmdRunner> runners(object host)
        // {
        //     var methods = host.GetType().DeclaredInstanceMethods().Tagged<CmdOpAttribute>();
        //     var dst = alloc<WfCmdRunner>(methods.Length);
        //     runners(host, methods, dst);
        //     return dst;
        // }

        // static void runners(object host, ReadOnlySpan<MethodInfo> src, Span<WfCmdRunner> dst)
        // {
        //     var count = src.Length;
        //     for(var i=0; i<count; i++)
        //     {
        //         ref readonly var method = ref skip(src,i);
        //         var tag = method.Tag<CmdOpAttribute>().Require();
        //         seek(dst,i) = runner(tag.Name, host, method);
        //     }
        // }

        // [Op]
        // static WfCmdRunner runner(string name, object host, MethodInfo method)
        //     => new WfCmdRunner(name, host, method);

        // static void install(IWfDispatcher dispatcher, ReadOnlySeq<ICmdProvider> src)
        //     => Z0.AppData.get().Value(nameof(IWfDispatcher), dispatcher);

        public JsonDocument Serialize<A>(A src)
            where A : IWfAction<A>, new()
                => JsonData.document(src);

        public A Materialize<A>(JsonText src)
            where A : IWfAction<A>, new()
                => JsonData.materialize<A>(src);
    }
}