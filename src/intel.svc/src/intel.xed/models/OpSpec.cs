//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedRules;
using static XedRender;

partial class XedModels
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public record struct OpSpec
    {
        public byte Index;

        public OpName Name;

        public OpKind Kind;

        public OpAction Action;

        public Visibility Visibility;

        public WidthCode WidthCode;

        public ushort BitWidth;

        public ElementType ElementType;

        public ushort ElementWidth;

        public byte ElementCount;

        public BitSegType SegType;

        public OpType OpType;

        public Nonterminal Rule;

        public Register Reg;

        public const string RenderPattern = "{0} | {1,-6} | {2,-4} | {3,-4} | {4,-4} | {5,-16} | {6}";

        public string Format()
        {
            return string.Format(RenderPattern,
                    Index,
                    format(Name),
                    format(Action),
                    format(WidthCode),
                    Visibility.Code(),
                    format(OpType),
                    Rule.IsNonEmpty
                    ? string.Format("{0} => {1}", Rule, XedPaths.RuleTable(new RuleSig(RuleTableKind.DEC, Rule.Name)))
                    : OpType == OpType.IMM_CONST ? "1"
                    : Reg.IsNonEmpty ? Reg.Format()
                    : EmptyString
                );
        }

        public override string ToString()
            => Format();
    }
}
