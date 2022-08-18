//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct HeaderCell : ITextual, IComparable<HeaderCell>
    {
        public readonly uint Index;

        public readonly NameOld Name;

        public readonly RenderWidth Width;

        public readonly CellFormatSpec CellFormat;

        [MethodImpl(Inline)]
        public HeaderCell(uint index, string name, RenderWidth width)
        {
            Index = index;
            Name = name ?? "!null!";
            Width = width;
            CellFormat = new CellFormatSpec("{0}", width);
        }

        [MethodImpl(Inline)]
        public string Format()
            => RpOps.rpad(Name, Width);

        [MethodImpl(Inline)]
        public int CompareTo(HeaderCell src)
            => Index.CompareTo(src.Index);

        public static HeaderCell Empty
            => new HeaderCell(0, EmptyString, 0);
    }
}