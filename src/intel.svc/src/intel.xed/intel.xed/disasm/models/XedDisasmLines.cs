//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

public readonly record struct XedDisasmLines : IComparable<XedDisasmLines>
{
    public readonly XedDisasmBlock Block;

    public readonly XedDisasmRow Row;

    [MethodImpl(Inline)]
    public XedDisasmLines(XedDisasmBlock lines, XedDisasmRow summary)
    {
        Block = lines;
        Row = summary;
    }

    public int CompareTo(XedDisasmLines src)
        => Row.CompareTo(src.Row);

    public static XedDisasmLines Empty => new (XedDisasmBlock.Empty, XedDisasmRow.Empty);
}

