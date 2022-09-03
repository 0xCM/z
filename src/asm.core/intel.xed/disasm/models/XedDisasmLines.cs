//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedDisasm;

    partial class XedDisasmModels
    {
        public readonly record struct XedDisasmLines : IComparable<XedDisasmLines>
        {
            public readonly DisasmBlock Block;

            public readonly XedDisasmRow Row;

            [MethodImpl(Inline)]
            public XedDisasmLines(DisasmBlock lines, XedDisasmRow summary)
            {
                Block = lines;
                Row = summary;
            }

            public int CompareTo(XedDisasmLines src)
                => Row.CompareTo(src.Row);

            public static XedDisasmLines Empty => new (DisasmBlock.Empty, XedDisasmRow.Empty);
        }
    }
}