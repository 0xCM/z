
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class ApiCmd
    {
        public static IApiContext<C> context<C>(IWfRuntime wf, Func<ReadOnlySeq<IApiCmdProvider>> factory)
            where C : IApiCmdSvc<C>, new()
        {
            var running = wf.Running($"Creating command providers");
            var providers = factory();
            wf.Ran(running, $"Created {providers.Length} command providers");
            return context<C>(wf, wf.Channel, providers);
        }

        static IApiContext<C> context<C>(IWfRuntime wf, IWfChannel channel, ReadOnlySeq<IApiCmdProvider> providers)
            where C : IApiCmdSvc<C>, new()
        {
            var name = $"clr:://z0/{typeof(C).Assembly.GetSimpleName()}/{typeof(C).DisplayName()}";
            var msg = $"Creating {name}";
            var service = new C();            
            var running = channel.Running(msg);
            service.Init(wf);
            var context = new ApiContext<C>(service, channel, dispatcher(service, channel, providers));
            channel.Ran(running, $"Created {name}");
            return context;
        }

        static IApiDispatcher dispatcher<T>(T service, IWfChannel channel, ReadOnlySeq<IApiCmdProvider> providers)
        {
            var flow = channel.Running($"Discovering {service} dispatchers");
            var dst = dict<string,ApiOp>();
            iter(methods(service), r => dst.TryAdd(r.CmdName, r));
            iter(providers, p => iter(methods(p), r => dst.TryAdd(r.CmdName, r)));
            var dispatcher = new ApiDispatcher(channel, providers, new ApiOps(dst));
            install(dispatcher, providers);
            return dispatcher;
        }    

        [Op]
        static ReadOnlySeq<ApiOp> methods(object host)
        {
            var src = host.GetType().DeclaredInstanceMethods().Tagged<CmdOpAttribute>();
            var dst = alloc<ApiOp>(src.Length);
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var mi = ref skip(src,i);
                var tag = mi.Tag<CmdOpAttribute>().Require();
                seek(dst,i) = new ApiOp(tag.Name, Cmd.classify(mi),  mi, host);
            }
            return dst;
        }

        static void install(IApiDispatcher dispatcher, ReadOnlySeq<IApiCmdProvider> src)
            => AppData.Value(nameof(IApiDispatcher), dispatcher);
    }
}