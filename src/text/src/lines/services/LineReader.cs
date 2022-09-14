//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XTend
    {
        public static Index<string> ReadLines(this FileUri src, bool skipBlank = false)
            => Z0.LineReader.read(src, TextEncodingKind.Utf8, skipBlank);
    }

    public struct LineReader : IDisposable
    {
        public static Index<string> read(FileUri src, TextEncodingKind encoding, bool skipBlank = false)
        {
            using var reader = FileUriOps.reader(src,encoding);
            var buffer = list<string>();
            var content = reader.ReadLine();
            while(content != null)
            {
                if(skipBlank)
                {
                    if(!text.blank(content))
                        buffer.Add(content);
                }
                else
                    buffer.Add(content);

                content = reader.ReadLine();
            }

            return buffer.ToArray();
        }

        [Op]
        public static Outcome number(ReadOnlySpan<char> src, out uint j, out LineNumber dst)
        {
            j = 0;
            dst = default;
            var i = text.index(src,Chars.Colon);
            if(i == NotFound)
                return false;

            if(uint.TryParse(slice(src,0, i), out var n))
            {
                j = (uint)(i + 1);
                dst = n;
                return true;
            }

            return false;
        }

        readonly StreamReader Source;

        uint Consumed;

        [MethodImpl(Inline)]
        public LineReader(StreamReader src)
        {
            Source = src;
            Consumed = 0;
        }

        public void Dispose()
        {
            Source?.Dispose();
        }

        public bool Next(out TextLine dst)
        {
            dst = TextLine.Empty;
            var line = Source.ReadLine();
            if(line == null)
                return false;

            Consumed++;

            var data = span(line);
            if(number(data, out var length, out var n))
                dst = new TextLine(n, line.Substring((int)length));
            else
                dst = new TextLine(Consumed, line);

            return true;
        }

        public bool Skip(uint count, out TextLine dst)
        {
            bool result = true;
            dst = default;
            for(var i=0; i<count; i++)
            {
                if(!Next(out dst))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        public uint Read(Span<TextLine> dst)
        {
            var i=0u;
            while(i < dst.Length && Next(out var line))
                seek(dst, i++) = line;
            return i;
        }

        public ReadOnlySpan<TextLine> ReadAll()
        {
            var dst = list<TextLine>();
            while(Next(out var line))
                dst.Add(line);
            return dst.ViewDeposited();
        }
    }
}