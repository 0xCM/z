//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Handlers;

public class CmdHandlers
{
    readonly Dictionary<ApiCmdRoute, ICmdHandler> Lookup;
    
    readonly ICmdHandler Empty;

    public CmdHandlers(Dictionary<ApiCmdRoute, ICmdHandler> lookup)
    {
        Lookup = lookup;
        Empty = Lookup[DevNul.Route];
    }

    public bool Handler(ApiCmdRoute name, out ICmdHandler dst)
    {
        dst = Empty;
        return Lookup.TryGetValue(name, out dst);
    }

    public ICollection<ApiCmdRoute> Routes 
        => Lookup.Keys;
}
