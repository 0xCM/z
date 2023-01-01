//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ServiceCache]
    public abstract class AppServices<T>
        where T : AppServices<T>, new()
    {
       public static T Instance = new();

        static ConcurrentDictionary<string,object> Lookup = new();

        static object ServiceLock = new();

        protected static string svcid(Type host)
            => host.DisplayName();

        protected static string svcid(Type host, string name)
            => svcid(host) + $".{name}";

        protected static string svcid<S>()
            => svcid(typeof(S));

        protected static string svcid<S>(string name)
            => svcid(typeof(S), name);

        [MethodImpl(Inline)]
        public static S inject<S>(S svc)
        {
            lock(ServiceLock)
                return (S)Lookup.GetOrAdd(svcid<S>(), svc);
        }

        [MethodImpl(Inline)]
        public static S injected<S>()
            => (S)Lookup[svcid<S>()];

        [MethodImpl(Inline)]
        public static S service<S>()
            where S : new()
        {
            lock(ServiceLock)
              return (S)Lookup.GetOrAdd(svcid<S>(), new S());
        }

        public static S service<S>(IWfRuntime wf, string name)
            where S : IAppService, new()
        {
            lock(ServiceLock)
                return (S)Lookup.GetOrAdd(svcid<S>(name), _ => {
                    var service = new S();
                    service.Init(wf);
                    return service;
                });
        }

        public static IAppService service(IWfRuntime wf, Type host, string name)
        {
            lock(ServiceLock)
                return (IAppService)Lookup.GetOrAdd(svcid(host, name), _ => {
                    var service = (IAppService)Activator.CreateInstance(host);
                    service.Init(wf);
                    return service;
                });
        }

        public static S service<S>(IWfRuntime wf, string name, Func<IWfRuntime,S> factory)
            where S : IAppService, new()
        {
            lock(ServiceLock)
                return (S)Lookup.GetOrAdd(svcid<S>(name), _ => factory(wf));
        }

        public static S service<S>(IWfRuntime wf)
            where S : IAppService, new()
        {
            lock(ServiceLock)
                return (S)Lookup.GetOrAdd(svcid<S>(), _ => {
                    var service = new S();
                    service.Init(wf);
                    return service;
                });
        }


        public IAppService Service(IWfRuntime wf, Type host, string name)
            => service(wf, host, name);

        public S Service<S>(IWfRuntime wf, string name)
            where S : IAppService, new()
                => service<S>(wf, name);

        public S Service<S>(IWfRuntime wf)
            where S : IAppService, new()
                => service<S>(wf);

        public S Service<S>(IWfRuntime wf, string name, Func<IWfRuntime,S> factory)
            where S : IAppService, new()
                => service(wf,name,factory);

        public S Inject<S>(S svc)
            => inject(svc);

        public S Injected<S>()
            => injected<S>();               
   }
}