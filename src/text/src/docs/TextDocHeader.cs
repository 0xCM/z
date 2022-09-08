//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XTend
    {
        [Op]
        public static RowHeader ToRowHeader(this TextDocHeader src, string delimiter, ReadOnlySpan<byte> widths)
            => TextDocHeader.header(src, delimiter, widths);
    }

    /// <summary>
    /// Defines header content in a text data file
    /// </summary>
    public readonly struct TextDocHeader
    {
        [Op]
        public static RowHeader header(TextDocHeader src, string delimiter, ReadOnlySpan<byte> widths)
        {
            var labels = src.Labels.View;
            var count = min(labels.Length, widths.Length);
            var cells = new HeaderCell[count];
            ref var dst = ref first(cells);
            for(var i=0u; i<count; i++)
                seek(dst,i) = new HeaderCell(i, skip(labels,i), skip(widths,i));
            return new RowHeader(cells, delimiter);
        }

        public readonly Index<string> Labels;

        [MethodImpl(Inline)]
        public TextDocHeader(string[] src)
            => Labels = src;

        public string Format(char? sep = null)
            => string.Join(sep ?? Chars.Pipe, Labels);

        public override string ToString()
            => Format();

        public uint CellCount
        {
            [MethodImpl(Inline)]
            get => Labels.Count;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Labels.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !Labels.IsEmpty;
        }

        public static TextDocHeader Empty
            => new TextDocHeader(sys.empty<string>());
    }
}