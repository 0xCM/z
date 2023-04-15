//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public sealed class TextDoc
    {
        [Op]
        public static TextRow row(string src, char delimiter)
            => !string.IsNullOrEmpty(src) ? src.SplitClean(delimiter).Select(x => new TextBlock(x)) : TextRow.Empty;

        public FileUri Location {get;}

        Index<TextLine> Data;

        public ReadOnlySpan<TextLine> Lines
        {
            get => Data;
        }

        public TextDoc()
        {
            Location = FileUri.Empty;
            Data = sys.empty<TextLine>();
        }

        public TextDoc(TextBlock src)
        {
            Location = FileUri.Empty;
            var lines = text.split(src.Text, Chars.NL).Select(x => x.Trim());
            var count = lines.Length;
            Data = alloc<TextLine>(count);
            for(var i=0u; i<count; i++)
                Data[i] = (i+1, skip(lines,i));
        }

        public TextDoc(FileUri src)
        {
            Location = src;
            Data = sys.empty<TextLine>();
        }

        public TextDoc(FileUri src, TextLine[] data)
        {
            Location = src;
            Data = data;
        }

    }
}