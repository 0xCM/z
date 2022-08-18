//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    using static core;

    partial class XTend
    {
        [Op]
        public static LineReader Utf8LineReader(this FS.FilePath src)
            => new LineReader(src.Utf8Reader());

        [MethodImpl(Inline), Op]
        public static LineReader ToLineReader(this StreamReader src)
            => new LineReader(src);

        [Op]
        public static LineReader LineReader(this FS.FilePath src, TextEncodingKind encoding)
            => src.Reader(encoding).ToLineReader();
    }

    public struct LineReader : IDisposable
    {
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