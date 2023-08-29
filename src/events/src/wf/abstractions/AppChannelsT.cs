//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public abstract class AppChannels<T>
    where T : AppChannels<T>, new()
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

    public static S service<S>(IWfChannel channel)
        where S : IChanneled, new()
    {
        lock(ServiceLock)
            return (S)Lookup.GetOrAdd(svcid<S>(), _ => {
                var service = new S();
                service.Init(channel);
                return service;
            });
    }
}
