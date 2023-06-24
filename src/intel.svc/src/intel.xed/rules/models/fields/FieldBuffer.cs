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
        public ref struct FieldBuffer
        {
            public static FieldBuffer allocate()
                => new FieldBuffer(Fields.allocate());

            [MethodImpl(Inline)]
            FieldBuffer(Fields fields)
            {
                Fields = fields;
                State = XedOperandState.Empty;
                Asm = AsmInfo.Empty;
                Props = InstFieldValues.Empty;
                Selected = default;
            }

            public readonly Fields Fields;

            public AsmInfo Asm;

            public InstFieldValues Props;

            public XedOperandState State;

            public ReadOnlySpan<FieldKind> Selected;

            public XedInstClass Instruction
            {
                [MethodImpl(Inline)]
                get => Props.InstClass;
            }

            public XedInstForm Form
            {
                [MethodImpl(Inline)]
                get => Props.InstForm;
            }
        }
    }
}