//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XedRules
    {
        public class RuleCalls
        {
            ConcurrentDictionary<RuleCaller, HashSet<RuleSig>> Data;

            public static RuleCalls init(CellTables cells)
                => new RuleCalls(cells);

            RuleCalls(CellTables cells)
            {
                Data = new();
                ref readonly var sigs = ref cells.Sigs;
                for(var i=0; i<sigs.Count; i++)
                    Data[sigs[i]] = new();
            }

            public void Include(RuleCaller src, RuleSig dst)
            {
                Data.AddOrUpdate(src, c => hashset<RuleSig>(), (k,v) =>  {
                    v.Add(dst);
                    return v;
                });
            }
        }
    }
}