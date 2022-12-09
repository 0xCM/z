//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public abstract class ApiServer : AppService
    {
        public static A shell<A>(bool catalog, params string[] args)
            where A : IAppShell, new()
        {
            var wf = ApiRuntime.create(catalog, args);
            var app = new A();
            app.Init(wf);
            return app;
        }

        public static A shell<A,C>(bool catalog, string[] args, Func<IWfRuntime,ReadOnlySeq<IApiCmdProvider>> factory)
            where A : IAppShell, new()
            where C : IApiService<C>, new()
        {
            var wf = ApiRuntime.create(catalog, args);
            var channel = wf.Channel;
            var flow = channel.Running($"Creating api server");
            var app = new A();
            var providers = factory(wf);
            app.Init(wf, context<C>(wf, channel, providers));
            channel.Ran(flow, $"Created {providers.Length} command providers");
            return app;
        }

        public static IApiContext<C> context<C>(IWfRuntime wf, Func<ReadOnlySeq<IApiCmdProvider>> factory)
            where C : IApiService<C>, new()
        {
            var running = wf.Running($"Creating command providers");
            var providers = factory();
            wf.Ran(running, $"Created {providers.Length} command providers");
            return context<C>(wf, wf.Channel, providers);
        }

        static IApiContext<C> context<C>(IWfRuntime wf, IWfChannel channel, ReadOnlySeq<IApiCmdProvider> providers)
            where C : IApiService<C>, new()
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
            var dst = dict<string,ApiEffector>();
            iter(effectors(service), r => dst.TryAdd(r.CmdName, r));
            iter(providers, p => iter(effectors(p), r => dst.TryAdd(r.CmdName, r)));
            var dispatcher = new ApiDispatcher(channel, new ApiEffectors(dst));
            AppData.Value(nameof(IApiDispatcher), dispatcher);
            return dispatcher;
        }    

        [Op]
        static ReadOnlySeq<ApiEffector> effectors(object host)
        {
            var src = host.GetType().DeclaredInstanceMethods().Tagged<CmdOpAttribute>();
            var dst = alloc<ApiEffector>(src.Length);
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var mi = ref skip(src,i);
                var tag = mi.Tag<CmdOpAttribute>().Require();
                seek(dst,i) = new ApiEffector(tag.Name, classify(mi),  mi, host);
            }
            return dst;
        }

        static CmdActorKind classify(MethodInfo src)
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


        public static ConstLookup<Name,ApiEffector> effectors(IApiDispatcher src)
        {
            ref readonly var defs = ref src.Commands.Defs;
            var dst = dict<Name,ApiEffector>();
            iter(defs.View, def => dst.Add(def.CmdName, def));
            return dst;
        }
    }
}