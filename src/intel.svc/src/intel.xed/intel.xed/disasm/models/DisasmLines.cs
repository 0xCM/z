//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDisasmModels
    {
        public readonly record struct DisasmLines : IComparable<DisasmLines>
        {
            public readonly DisasmBlock Block;

            public readonly XedDisasmRow Row;

            [MethodImpl(Inline)]
            public DisasmLines(DisasmBlock lines, XedDisasmRow summary)
            {
                Block = lines;
                Row = summary;
            }

            public int CompareTo(DisasmLines src)
                => Row.CompareTo(src.Row);

            public static DisasmLines Empty => new (DisasmBlock.Empty, XedDisasmRow.Empty);
        }
    }
}