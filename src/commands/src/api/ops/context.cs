
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class ApiCmd
    {
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
    }
}