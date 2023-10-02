//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static XedModels;

    partial class XedRules
    {
        public class XedRuleTables
        {
            Index<TableCriteria> _Criteria;

            TableSpecs _Specs;

            [MethodImpl(Inline)]
            internal ref readonly Index<TableCriteria> Criteria()
                => ref _Criteria;

            [MethodImpl(Inline)]
            public ref readonly TableSpecs Specs()
                => ref _Specs;

            public XedRuleTables()
            {
                _Criteria = sys.empty<TableCriteria>();
                _Specs = TableSpecs.Empty;
            }

            public static XedRuleTables Empty
                => new XedRuleTables();

            public XedRuleTables(Index<TableCriteria> criteria, TableSpecs specs)
            {
                _Criteria = criteria;
                _Specs = specs;
            }

        }
    }
}