//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;


    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public record struct OpSpec
        {
            public static string specifier(in OpSpec src)
            {
                const string OpSepSlot = "/{0}";
                const sbyte Pad = -XedFields.FieldRender.ColWidth;

                var dst = text.buffer();
                dst.AppendFormat(RpOps.slot(0, Pad), src.Index);
                dst.Append(" | ");
                dst.AppendFormat("{0,-4}", XedRender.format(src.Name));
                dst.AppendFormat(OpSepSlot, XedRender.format(src.Action));
                dst.AppendFormat(OpSepSlot, XedRender.format(src.WidthCode));
                dst.AppendFormat(OpSepSlot, XedRender.format(src.Visibility));
                dst.AppendFormat(OpSepSlot, XedRender.format(src.OpType));
                if(src.Rule.IsNonEmpty)
                    dst.AppendFormat(OpSepSlot, src.Rule.Name.ToString().ToUpper());
                else if(src.ElementType.IsNumber)
                    dst.AppendFormat(OpSepSlot, src.ElementType);

                return dst.Emit();
            }

            public byte Index;

            public OpName Name;

            public OpKind Kind;

            public OpAction Action;

            public Visibility Visibility;

            public OpWidthCode WidthCode;

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
                        XedRender.format(Name),
                        XedRender.format(Action),
                        XedRender.format(WidthCode),
                        Visibility.Code(),
                        XedRender.format(OpType),
                        Rule.IsNonEmpty
                        ? string.Format("{0} => {1}", Rule, XedPaths.Service.RulePage(new RuleSig(RuleTableKind.DEC, Rule.Name)))
                        : OpType == OpType.IMM_CONST ? "1"
                        : Reg.IsNonEmpty ? Reg.Format()
                        : EmptyString
                    );
            }

            public override string ToString()
                => Format();
        }
    }
}