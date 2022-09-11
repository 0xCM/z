//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines a row of text parttioned into a sequence of cells
    /// </summary>
    public readonly struct TextRow
    {
        readonly Index<TextBlock> Data;

        [MethodImpl(Inline)]
        public TextRow(params TextBlock[] src)
            => Data = src;

        public readonly ReadOnlySpan<TextBlock> Cells
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public string RowText
            => string.Concat(Data.Map(x => x.Format()));

        public int CellCount
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public ref readonly TextBlock this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        [MethodImpl(Inline)]
        public ref readonly TextBlock Cell<T>(T index)
            where T : unmanaged
                =>  ref Data[bw32(index)];

        static string ColSep(char? delimiter)
            => string.Concat(Chars.Space, delimiter ?? Chars.Pipe, Chars.Space);

        /// <summary>
        /// Joins the enclosed cells to produce a line of text
        /// </summary>
        /// <param name="delimiter">The separator to apply to delimit the cell data in the line </param>
        public string Format(char? delimiter = null, int? pad = null)
            => string.Join(ColSep(delimiter),  Data.Select(x => x.Format(pad)));

        public override string ToString()
            => Format();

        public static TextRow Empty
        {
            [MethodImpl(Inline)]
            get => new TextRow(array<TextBlock>());
        }

        [MethodImpl(Inline)]
        public static implicit operator TextRow(TextBlock[] src)
            => new TextRow(src);
    }
}