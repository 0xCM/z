//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Linq;

public class ApiCmdMethods : IDisposable
{
    readonly Dictionary<ApiCmdRoute,ApiCmdMethod> Complete;

    readonly Dictionary<ApiCmdRoute,ApiCmdMethod> Partial;

    readonly ReadOnlySeq<ApiCmdMethod> CmdDefs;

    readonly ReadOnlySeq<IApiService> Services;

    public ApiCmdMethods(ReadOnlySeq<IApiService> services, Dictionary<ApiCmdRoute,ApiCmdMethod> src)
    {
        Complete = src.Keys.Where(route => !route.IsPartial).Select(route => (route, src[route])).ToDictionary();
        Partial = src.Keys.Where(route => route.IsPartial).Select(route => (route.Complete(), src[route])).ToDictionary();
        Services = services;
        CmdDefs = src.Values.ToSeq();
    }

    public bool Find(ApiCmdRoute route, out ApiCmdMethod runner)
    {
        var result = Complete.TryGetValue(route, out runner);
        if(!result)
            result = Partial.TryGetValue(route, out runner);
        return result;
    }

    public void Dispose()
    {
        foreach(var svc in Services)
        {
            try
            {
                svc.Dispose();
            }
            catch(Exception e)
            {
                term.error(e);
            }
        }
    }

    public ref readonly ReadOnlySeq<ApiCmdMethod> Defs
    {
        [MethodImpl(Inline)]
        get => ref CmdDefs;
    }
}
