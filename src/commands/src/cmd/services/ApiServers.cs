
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class ApiServers : AppService
    {
        public override Type HostType 
            => typeof(ApiServers);

        public static A shell<A>(string[] args, IWfRuntime wf, IApiContext context, bool verbose = false)
            where A : IAppShell, new()
        {            
            var app = new A();
            app.Init(wf, context);
            return app;
        }

        public static A shell<A>(bool catalog, params string[] args)
            where A : IAppShell, new()
        {
            var wf = ApiRuntime.create(args);
            var app = new A();
            app.Init(wf);
            return app;
        }

        public static A shell<A,C>(bool catalog, string[] args, Func<IWfRuntime,ReadOnlySeq<IApiCmdProvider>> factory, bool verbose = false)
            where A : IAppShell, new()
            where C : IApiService, new()
        {
            var wf = ApiRuntime.create(args);
            var channel = wf.Channel;
            if(verbose)
                channel.Babble("Creating api server");

            var app = new A();
            var providers = factory(wf);
            app.Init(wf, context<C>(wf, channel, providers));

            if(verbose)
                channel.Babble($"Created {providers.Length} command providers");
            return app;
        }

        public static IApiContext context<C>(IWfRuntime wf, Func<ReadOnlySeq<IApiCmdProvider>> factory, bool verbose = false)
            where C : IApiService, new()
                => context<C>(wf, wf.Channel, factory(), verbose);

        static IApiContext context<C>(IWfRuntime wf, IWfChannel channel, ReadOnlySeq<IApiCmdProvider> providers, bool verbose = false)
            where C : IApiService, new()
        {
            var service = new C();                        
            service.Init(wf);
            return new ApiContext(service, channel, dispatcher(service, channel, providers, verbose));            
        }

        static ICmdDispatcher dispatcher<T>(T service, IWfChannel channel, ReadOnlySeq<IApiCmdProvider> providers, bool verbose = false)
        {
            if(verbose)
                channel.Babble($"Discovering {service} dispatchers");

            var dst = dict<string,CmdMethod>();
            iter(effectors(service), r => dst.TryAdd(r.CmdName, r));
            iter(providers, p => iter(effectors(p), r => dst.TryAdd(r.CmdName, r)));
            var dispatcher = new ApiDispatcher(channel, new CmdMethods(dst));
            AppData.Value(nameof(ICmdDispatcher), dispatcher);
            return dispatcher;
        }    

        [Op]
        static ReadOnlySeq<CmdMethod> effectors(object host)
        {
            var src = host.GetType().DeclaredInstanceMethods().Tagged<CmdOpAttribute>();
            var dst = alloc<CmdMethod>(src.Length);
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var mi = ref skip(src,i);
                var tag = mi.Tag<CmdOpAttribute>().Require();
                seek(dst,i) = new CmdMethod(tag.Name, classify(mi),  mi, host);
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
    }
}