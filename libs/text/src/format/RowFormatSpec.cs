//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines formatting specifications for each cell in a row
    /// </summary>
    public readonly struct RowFormatSpec
    {
        public readonly RowHeader Header;

        public readonly Index<CellFormatSpec> Cells;

        public readonly string Pattern;

        public readonly ushort RowPad;

        public readonly ushort MaxCellWidth;

        public readonly char Delimiter;

        public readonly RecordFormatKind FormatKind;

        [MethodImpl(Inline)]
        public RowFormatSpec(RowHeader header, CellFormatSpec[] src, string pattern, ushort rowpad, char sep, RecordFormatKind fk)
        {
            Header = header;
            Cells = src;
            Pattern = pattern;
            RowPad = rowpad;
            MaxCellWidth = src.Select(x => x.Width.Value).Max();
            Delimiter = sep;
            FormatKind = fk;
        }

        public uint CellCount
        {
            [MethodImpl(Inline)]
            get => Cells.Count;
        }

        public ref readonly CellFormatSpec this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Cells[index];
        }

        public ref readonly CellFormatSpec this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Cells[index];
        }
    }
}