//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedRules
{
    public class TableSpecs : SortedLookup<RuleIdentity,TableSpec>
    {
        public readonly uint TableCount;

        public readonly uint RowCount;

        public TableSpecs(Dictionary<RuleIdentity,TableSpec> src)
            : base(src)
        {
            TableCount = (uint)src.Count;
            RowCount = src.Values.Map(x => x.RowCount).Sum();
        }

        public static implicit operator TableSpecs(Dictionary<RuleIdentity,TableSpec> src)
            => new (src);

        public new static TableSpecs Empty
            => new (sys.dict<RuleIdentity,TableSpec>());
    }
}
