//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public class TableSpecs : SortedLookup<RuleSig,TableSpec>
        {
            public readonly uint TableCount;

            public readonly uint RowCount;

            public TableSpecs(Dictionary<RuleSig,TableSpec> src)
                : base(src)
            {
                TableCount = (uint)src.Count;
                RowCount = src.Values.Map(x => x.RowCount).Sum();
            }

            public new static TableSpecs Empty
                => new TableSpecs(sys.dict<RuleSig,TableSpec>());

            public static implicit operator TableSpecs(Dictionary<RuleSig,TableSpec> src)
                => new TableSpecs(src);
        }
    }
}