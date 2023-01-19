//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ToolCatalog
    {
        SortedLookup<ToolKey,LocatedTool> Lookup;

        public ToolCatalog(Dictionary<ToolKey,LocatedTool> src)
        {
            Lookup = src;
        }

        public ReadOnlySpan<LocatedTool> Tools 
            => Lookup.Values;
        
        public ReadOnlySpan<ToolKey> Keys 
            => Lookup.Keys;

        public bool Find(ToolKey key, out LocatedTool tool)
            => Lookup.Find(key, out tool);
    }
}