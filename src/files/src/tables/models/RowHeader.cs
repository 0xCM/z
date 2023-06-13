//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text;

    using static sys;

    public readonly struct RowHeader : IIndex<HeaderCell>, ITextual
    {
        public Index<HeaderCell> Cells {get;}

        public string Delimiter {get;}

        [MethodImpl(Inline)]
        public RowHeader(HeaderCell[] data, string delimiter)
        {
            require(data != null, () => "Null header cells");
            Cells = data;
            Delimiter = delimiter;
        }

        [MethodImpl(Inline)]
        public RowHeader(HeaderCell[] data, char delimiter)
        {
            require(data != null, () => "Null header cells");
            Cells = data;
            Delimiter = delimiter.ToString();
        }

        public HeaderCell[] Storage
        {
            [MethodImpl(Inline)]
            get => Cells;
        }

        public ref HeaderCell this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Cells[index];
        }

        public ref HeaderCell this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Cells[index];
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Cells.Length;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Cells.Length;
        }

        public uint CellCount
        {
            [MethodImpl(Inline)]
            get => (uint)Cells.Length;
        }

        public string Format()
        {
            var dst = new StringBuilder();
            for(var i=0; i<Count; i++)
            {
                if(i != 0)
                    dst.Append(Delimiter);

                dst.Append(this[i].Format());
            }
            return dst.ToString();
        }

        public override string ToString()
            => Format();

        public static RowHeader Empty
            => new RowHeader(sys.empty<HeaderCell>(), EmptyString);
    }
}