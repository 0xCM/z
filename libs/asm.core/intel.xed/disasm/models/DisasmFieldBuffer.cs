//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedDisasmModels;

    partial class XedDisasm
    {
        public ref struct DisasmFieldBuffer
        {
            public static DisasmFieldBuffer allocate()
                => new DisasmFieldBuffer(Fields.allocate());

            [MethodImpl(Inline)]
            DisasmFieldBuffer(Fields fields)
            {
                Fields = fields;
                State = OperandState.Empty;
                Summary = XedDisasmRow.Empty;
                Lines = DisasmBlock.Empty;
                Asm = AsmInfo.Empty;
                Props = InstFieldValues.Empty;
                Encoding = EncodingExtract.Empty;
                Selected = default;
                Detail = DetailBlockRow.Empty;
            }

            public void Clear()
            {
                Fields.Clear();
                State = OperandState.Empty;
                Summary = XedDisasmRow.Empty;
                Lines = DisasmBlock.Empty;
                Asm = AsmInfo.Empty;
                Props = InstFieldValues.Empty;
                Encoding = EncodingExtract.Empty;
                Selected = default;
                Detail = DetailBlockRow.Empty;
            }

            public readonly Fields Fields;

            public DetailBlockRow Detail;

            public DisasmBlock Lines;

            public XedDisasmRow Summary;

            public AsmInfo Asm;

            public InstFieldValues Props;

            public OperandState State;

            public EncodingExtract Encoding;

            public ReadOnlySpan<FieldKind> Selected;
        }
    }
}