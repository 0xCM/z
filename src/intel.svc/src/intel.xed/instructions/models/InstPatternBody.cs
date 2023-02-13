//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    
    partial class XedModels
    {
        public readonly struct InstPatternBody : IIndex<CellValue>
        {
            public readonly InstCells Cells;

            [MethodImpl(Inline)]
            public InstPatternBody(CellValue[] src)
            {
                Cells = new InstCells(src,0);
            }

            [MethodImpl(Inline)]
            public InstPatternBody(InstCells fields)
            {
                Cells = fields;
            }

            public CellValue[] Storage
            {
                [MethodImpl(Inline)]
                get => Cells.Storage;
            }

            public uint CellCount
            {
                [MethodImpl(Inline)]
                get => Cells.Count;
            }

            public byte ExprCount
            {
                [MethodImpl(Inline)]
                get => Cells.ExprCount;
            }

            public byte LayoutCount
            {
                [MethodImpl(Inline)]
                get => Cells.LayoutCount;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Cells.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Cells.IsNonEmpty;
            }

            public ref CellValue this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Cells[i];
            }

            public ref CellValue this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Cells[i];
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator InstPatternBody(CellValue[] src)
                => new InstPatternBody(src);

            [MethodImpl(Inline)]
            public static implicit operator InstPatternBody(Index<CellValue> src)
                => new InstPatternBody(src);
        }
    }
}