//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public struct UnicodeLine : IComparable<UnicodeLine>
    {
        [Op]
        public static string format(in UnicodeLine src)
            => string.Format("{0}:{1}", src.LineNumber, new string(src.View));

        [MethodImpl(Inline), Op]
        public static void convert(in AsciLineCover src, uint line, Span<char> buffer, out UnicodeLine dst)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
                seek(buffer, i) = (char)skip(src.Codes,i);
            dst = new UnicodeLine(line, text.format(buffer));
        }

        [MethodImpl(Inline), Op]
        public static bool empty(ReadOnlySpan<char> src, uint offset)
        {
            var last = src.Length - 1;
            if(offset < last - 1)
                return SQ.eol(skip(src, offset), skip(src, offset + 1));
            return true;
        }

        /// <summary>
        /// Reads a <see cref='UnicodeLine'/> from the data source
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="number">The current line count</param>
        /// <param name="i">The source-relative offset</param>
        /// <param name="dst">The target</param>
        [Op]
        public static uint line(string src, ref uint number, ref uint i, out UnicodeLine dst)
        {
            var i0 = i;
            dst = UnicodeLine.Empty;
            var max = src.Length;
            var length = 0u;
            var data = span(src);
            if(empty(src,i))
            {
                dst = new UnicodeLine(++number, EmptyString);
                i+=2;
            }
            else
            {
                while(i++ < max - 1)
                {
                    if(SQ.eol(skip(data, i), skip(data, i + 1)))
                    {
                        length = i - i0;
                        dst = new UnicodeLine(++number, text.slice(src, i0, length));
                        i+=2;
                        break;
                    }
                }
            }
            return length;
        }

        public readonly LineNumber LineNumber;

        public readonly string Content;

        [MethodImpl(Inline)]
        public UnicodeLine(uint number, string src)
        {
            LineNumber = number;
            Content = src;
        }

        public ReadOnlySpan<char> View
        {
            [MethodImpl(Inline)]
            get => Content;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Content.Length;
        }

        public int RenderLength
        {
            [MethodImpl(Inline)]
            get => LineNumber.RenderLength + Content.Length;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Length == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Length != 0;
        }

        public string Format()
            => format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(UnicodeLine other)
            => LineNumber.CompareTo(other.LineNumber);

        public static UnicodeLine Empty
        {
            [MethodImpl(Inline)]
            get => new UnicodeLine(0,EmptyString);
        }
    }
}