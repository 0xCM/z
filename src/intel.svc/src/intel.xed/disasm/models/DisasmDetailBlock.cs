//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;
    using static XedModels;

    partial class XedDisasmModels
    {
        public class DisasmDetailBlock : IComparable<DisasmDetailBlock>
        {
            public DisasmDetailBlockRow DetailRow;

            public readonly DisasmLines SummaryLines;

            public readonly Instruction Instruction;

            [MethodImpl(Inline)]
            public DisasmDetailBlock(DisasmDetailBlockRow row, in DisasmLines lines, in Instruction inst)
            {
                DetailRow = row;
                SummaryLines = lines;
                Instruction = inst;
            }

            [MethodImpl(Inline)]
            public DisasmDetailBlock WithRow(in DisasmDetailBlockRow src)
                => new DisasmDetailBlock(src, SummaryLines, Instruction);

            public ref readonly OpDetails Ops
            {
                [MethodImpl(Inline)]
                get => ref DetailRow.Ops;
            }

            public ref readonly XedDisasmRow SummaryRow
            {
                [MethodImpl(Inline)]
                get => ref SummaryLines.Row;
            }

            public ref readonly DisasmBlock Lines
            {
                [MethodImpl(Inline)]
                get => ref SummaryLines.Block;
            }

            public SizeOverride SZOV
            {
                [MethodImpl(Inline)]
                get => DetailRow.SZOV;
            }

            public ref readonly NativeSize EASZ
            {
                [MethodImpl(Inline)]
                get => ref DetailRow.EASZ;
            }

            public ref readonly NativeSize EOSZ
            {
                [MethodImpl(Inline)]
                get => ref DetailRow.EOSZ;
            }

            public ref readonly AsmExpr Asm
            {
                [MethodImpl(Inline)]
                get => ref DetailRow.Asm;
            }

            public ref readonly MemoryAddress IP
            {
                [MethodImpl(Inline)]
                get => ref DetailRow.IP;
            }

            public ref readonly AsmHexCode Encoded
            {
                [MethodImpl(Inline)]
                get => ref DetailRow.Encoded;
            }

            public ref readonly EncodingOffsets Offsets
            {
                [MethodImpl(Inline)]
                get => ref DetailRow.Offsets;
            }

            public ref readonly AsmInstClass InstClass
            {
                [MethodImpl(Inline)]
                get => ref DetailRow.Instruction;
            }

            public ref readonly InstForm InstForm
            {
                [MethodImpl(Inline)]
                get => ref DetailRow.Form;
            }

            public ref readonly byte Size
            {
                [MethodImpl(Inline)]
                get => ref SummaryRow.Size;
            }

            public ref readonly Hex8 OpCode
            {
                [MethodImpl(Inline)]
                get => ref DetailRow.OpCode;
            }

            public ref readonly byte PSZ
            {
                [MethodImpl(Inline)]
                get => ref DetailRow.PSZ;
            }

            public ref readonly RexPrefix Rex
            {
                [MethodImpl(Inline)]
                get => ref DetailRow.Rex;
            }

            public ref readonly VexPrefix Vex
            {
                [MethodImpl(Inline)]
                get => ref DetailRow.Vex;
            }

            public ref readonly EvexPrefix Evex
            {
                [MethodImpl(Inline)]
                get => ref DetailRow.Evex;
            }

            public int CompareTo(DisasmDetailBlock src)
                => DetailRow.CompareTo(src.DetailRow);

            public static DisasmDetailBlock Empty => new DisasmDetailBlock(DisasmDetailBlockRow.Empty, DisasmLines.Empty, Instruction.Empty);
        }
    }
}