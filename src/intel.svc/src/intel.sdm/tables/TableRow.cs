//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct TableRow
    {
        public uint Seq;

        readonly TableCell[] _Cells;

        [MethodImpl(Inline)]
        public TableRow(uint index, TableCell[] cells)
        {
            Seq = index;
            _Cells = cells ?? new TableCell[]{};
        }

        public string Format()
            => text.join(" | ", _Cells);

        public override string ToString()
            => Format();

        public uint ColCount
        {
            [MethodImpl(Inline)]
            get => (uint)_Cells.Length;
        }

        public ref TableCell this[int i]
        {
            [MethodImpl(Inline)]
            get => ref sys.seek(_Cells,i);
        }

        public Seq<TableCell> Cells
        {
            [MethodImpl(Inline)]
            get => _Cells;
        }

        public static TableRow Empty
            => new TableRow(0, new TableCell[0]{});
    }
}