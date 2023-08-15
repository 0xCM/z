//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Services<T>
        where T : Services<T>, new()
    {
        public static T Instance = new();

        static ConcurrentDictionary<string,object> Lookup = new();

        static object ServiceLock = new();

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

        public static S service<S>(IWfChannel channel, string name)
            where S : IChanneled<S>, new()
        {
            lock(ServiceLock)
                return (S)Lookup.GetOrAdd(svcid<S>(name), _ => new S().Factory(channel));
        }

        public static S service<S>(IWfChannel channel, string name, Func<IWfChannel,S> factory)
            where S : IChanneled<S>, new()
        {
            lock(ServiceLock)
                return (S)Lookup.GetOrAdd(svcid<S>(name), _ => factory(channel));
        }

        public static S service<S>(IWfChannel channel)
            where S : IChanneled<S>, new()
        {
            lock(ServiceLock)
                return (S)Lookup.GetOrAdd(svcid<S>(), _ => new S().Factory(channel));
        }

        protected static string svcid(Type host)
            => host.DisplayName();

        protected static string svcid(Type host, string name)
            => svcid(host) + $".{name}";

        protected static string svcid<S>()
            => svcid(typeof(S));

        protected static string svcid<S>(string name)
            => svcid(typeof(S), name);

        protected Services()
        {
        }

        public S Inject<S>(S svc)
            => inject(svc);

        public S Injected<S>()
            => injected<S>();

        public S Service<S>()
            where S : new()
                => service<S>();
    }
}