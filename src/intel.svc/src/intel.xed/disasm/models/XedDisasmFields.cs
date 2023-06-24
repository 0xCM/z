//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedRules;
using static XedModels;

public ref struct XedDisasmFields
{
    public static XedDisasmFields allocate()
        => new XedDisasmFields(Fields.allocate());

    [MethodImpl(Inline)]
    XedDisasmFields(Fields fields)
    {
        Fields = fields;
        State = XedOperandState.Empty;
        Summary = XedDisasmRow.Empty;
        Lines = XedDisasmBlock.Empty;
        Asm = AsmInfo.Empty;
        Props = InstFieldValues.Empty;
        Encoding = EncodingExtract.Empty;
        Selected = default;
        Detail = XedDisasmDetailRow.Empty;
    }

    public void Clear()
    {
        Fields.Clear();
        State = XedOperandState.Empty;
        Summary = XedDisasmRow.Empty;
        Lines = XedDisasmBlock.Empty;
        Asm = AsmInfo.Empty;
        Props = InstFieldValues.Empty;
        Encoding = EncodingExtract.Empty;
        Selected = default;
        Detail = XedDisasmDetailRow.Empty;
    }

    public readonly Fields Fields;

    public XedDisasmDetailRow Detail;

    public XedDisasmBlock Lines;

    public XedDisasmRow Summary;

    public AsmInfo Asm;

    public InstFieldValues Props;

    public XedOperandState State;

    public EncodingExtract Encoding;

    public ReadOnlySpan<FieldKind> Selected;
}
