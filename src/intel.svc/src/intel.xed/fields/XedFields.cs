//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    using CK = XedRules.RuleCellKind;

    [ApiHost]
    public partial class XedFields
    {
        const string xed = nameof(xed);

        public static FieldRender render()
            => new ();

        static readonly FieldDefs _Defs;

        public static DataSize size(FieldKind fk, RuleCellKind ck)
        {
            var dst = field(fk).Size;
            switch(ck)
            {
                case CK.Keyword:
                    dst = RuleKeyword.DataSize;
                break;
                case CK.NtCall:
                    dst = Nonterminal.DataSize;
                break;
                case CK.Operator:
                    dst = RuleOperator.DataSize;
                break;
            }
            return dst;
        }

        [MethodImpl(Inline)]
        public static ref readonly FieldDef field(FieldKind kind)
            => ref _Defs[kind];

        public static ref readonly FieldDefs Defs
        {
            [MethodImpl(Inline)]
            get => ref _Defs;
        }

        static XedFields()
        {
            _Defs = CalcFieldDefs();            
        }
    }
}