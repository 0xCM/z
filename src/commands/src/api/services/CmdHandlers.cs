//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Handlers;
    
    public class CmdHandlers
    {
        readonly Dictionary<CmdRoute, ICmdHandler> Lookup;
        
        readonly ICmdHandler Empty;

        public CmdHandlers(Dictionary<CmdRoute, ICmdHandler> lookup)
        {
            Lookup = lookup;
            Empty = Lookup[DevNul.Route];
        }

        public bool Handler(CmdRoute name, out ICmdHandler dst)
        {
            dst = Empty;
            return Lookup.TryGetValue(name, out dst);
        }

        public ICollection<CmdRoute> Routes 
            => Lookup.Keys;
    }
}