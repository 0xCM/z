//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static FormatDelegates;

    public readonly ref struct DelimitedSpan<T>
    {
        public readonly ReadOnlySpan<T> Data;

        public readonly char Delimiter;

        public readonly int CellPad;

        readonly FormatCells<T> Render;

        [MethodImpl(Inline)]
        public DelimitedSpan(ReadOnlySpan<T> src, char delimiter = Chars.Pipe, int pad = 0)
        {
            Data = src;
            Delimiter = delimiter;
            Render = Delimiting.delimit;
            CellPad = pad;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Render(Data, Delimiter, CellPad);

        public override string ToString()
            => Format();
    }
}