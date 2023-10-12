//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedRules
{
    public class XedRuleTables
    {
        Seq<TableCriteria> _Criteria;

        TableSpecs _Specs;

        [MethodImpl(Inline)]
        internal ref readonly Seq<TableCriteria> Criteria()
            => ref _Criteria;

        [MethodImpl(Inline)]
        public ref readonly TableSpecs Specs()
            => ref _Specs;

        public XedRuleTables()
        {
            _Criteria = sys.empty<TableCriteria>();
            _Specs = TableSpecs.Empty;
        }

        public XedRuleTables(Seq<TableCriteria> criteria, TableSpecs specs)
        {
            _Criteria = criteria;
            _Specs = specs;
        }

        public static XedRuleTables Empty
            => new XedRuleTables();
    }
}
