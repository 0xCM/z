//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public sealed class TextDoc
    {
        public FS.FilePath Location {get;}

        Index<TextLine> Data;

        public ReadOnlySpan<TextLine> Lines
        {
            get => Data;
        }

        public TextDoc()
        {
            Location = FS.FilePath.Empty;
            Data = sys.empty<TextLine>();
        }

        public TextDoc(TextBlock src)
        {
            Location = FS.FilePath.Empty;
            var lines = text.split(src.Text, Chars.NL).Select(x => x.Trim());
            var count = lines.Length;
            Data = alloc<TextLine>(count);
            for(var i=0u; i<count; i++)
                Data[i] = (i+1, skip(lines,i));
        }

        public TextDoc(FS.FilePath src)
        {
            Location = src;
            Data = sys.empty<TextLine>();
        }

        public TextDoc(FS.FilePath src, TextLine[] data)
        {
            Location = src;
            Data = data;
        }

        public TextDoc Load(TextEncodingKind encoding = TextEncodingKind.Utf8)
            => new TextDoc(Location, Location.ReadNumberedLines(encoding));
    }
}