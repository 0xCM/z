//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Globalization;

    using static sys;

    partial struct Hex
    {
        public static Outcome<uint> parse(string src, out HexArray16 dst)
        {
            dst = HexArray16.Empty;
            return hexbytes(src, dst.Bytes);
        }

        [MethodImpl(Inline), Op]
        public static byte combine(HexDigitValue lo, HexDigitValue hi)
            => (byte)((byte)hi << 4 | (byte)lo);

        public static bool parse64u(string src, out ulong dst)
            => ulong.TryParse(HexParser.clear(src), NumberStyles.HexNumber, null,  out dst);

        public static bool parse32u(string src, out uint dst)
            => uint.TryParse(HexParser.clear(src), NumberStyles.HexNumber, null,  out dst);

        public static bool parse16u(string src, out ushort dst)
            => ushort.TryParse(HexParser.clear(src), NumberStyles.HexNumber, null, out dst);

        public static bool parse8u(string src, out byte dst)
            => byte.TryParse(HexParser.clear(src), NumberStyles.HexNumber, null, out dst);

        public static bool parse8i(string src, out sbyte dst)
            => sbyte.TryParse(HexParser.clear(src), NumberStyles.HexNumber, null, out dst);

        public static bool parse16i(string src, out short dst)
            => short.TryParse(HexParser.clear(src), NumberStyles.HexNumber, null, out dst);

        public static bool parse32i(string src, out int dst)
            => int.TryParse(HexParser.clear(src), NumberStyles.HexNumber, null, out dst);

        public static bool parse64i(string src, out long dst)
            => long.TryParse(HexParser.clear(src), NumberStyles.HexNumber, null, out dst);

        public static bool parse8u(ReadOnlySpan<char> src, out byte dst)
            => byte.TryParse(HexParser.clear(src), NumberStyles.HexNumber, null,  out dst);

        public static bool parse16u(ReadOnlySpan<char> src, out ushort dst)
            => ushort.TryParse(HexParser.clear(src), NumberStyles.HexNumber, null,  out dst);

        public static bool parse32u(ReadOnlySpan<char> src, out uint dst)
            => uint.TryParse(HexParser.clear(src), NumberStyles.HexNumber, null,  out dst);

        public static bool parse64u(ReadOnlySpan<char> src, out ulong dst)
            => ulong.TryParse(HexParser.clear(src), NumberStyles.HexNumber, null,  out dst);

        static MsgPattern<string> UnevenNibbles
            => "An even number of nibbles was not provided in the source text '{0}'";

        public static Outcome parse(string src, out BinaryCode dst)
        {
            var result = Outcome.Success;
            var count = text.length(src);
            dst = BinaryCode.Empty;
            if(count % 2 != 0)
                return (false, UnevenNibbles.Format(src));
            var size = count/2;
            var buffer = alloc<byte>(size);
            var input = span(src);
            for(int i=0, j=0; i<count; i+=2, j++)
            {
                result = parse(skip(input,i), skip(input, i+1), out seek(buffer, j));
                if(result.Fail)
                {
                    dst = BinaryCode.Empty;
                    return result;
                }
            }

            dst = buffer;
            return true;
        }

        /// <summary>
        /// Parses a nibble
        /// </summary>
        /// <param name="src">The source character</param>
        [MethodImpl(Inline), Op]
        public static bool parse(char src, out byte dst)
            => parse((AsciCode)src, out dst);

        [MethodImpl(Inline), Op]
        public static bool parse(char c0, char c1, out byte dst)
        {
            if(parse(c0, out byte d0) && parse(c1, out byte d1))
            {
                dst = (byte)((d0 << 4) | d1);
                return true;
            }
            dst = 0;
            return false;
        }

        [Op]
        public static Outcome<uint> parse(ReadOnlySpan<char> src, Span<byte> dst)
        {
            var counter = 0u;
            var input = src;

            var j = text.index(src, Chars.x);
            var k = text.index(src, Chars.h);

            if(j > 0)
                input = right(input,j);
            if(k > 0)
                input = left(input, k);

            var hi = byte.MaxValue;
            for(var i=0; i<input.Length; i++)
            {
                ref readonly var c = ref skip(input,i);
                if(whitespace(c) || fence(c) || separator(c))
                    continue;

                if(parse(c, out HexDigitValue d))
                {
                    if(hi == byte.MaxValue)
                        hi = (byte)d;
                    else
                    {
                        var lo = (byte)d;
                        seek(dst, counter++) = Bytes.or(Bytes.sll(hi,4), lo);
                        hi = byte.MaxValue;
                    }
                }
                else
                    return false;
            }
            return (true,counter);
        }

        [MethodImpl(Inline)]
        static bool whitespace(char src)
            => whitespace((AsciCode)src);

        [MethodImpl(Inline)]
        static bool separator(char src)
            => src == Chars.Comma;

        [MethodImpl(Inline), Op]
        public static bool parse(char src, out HexDigitValue dst)
            => parse((AsciCode)src, out dst);

        [MethodImpl(Inline), Op]
        public static bool parse(LowerCased @case, char c, out HexDigitValue dst)
            => parse(@case, (AsciCode)c, out dst);

        [MethodImpl(Inline), Op]
        public static bool parse(UpperCased @case, char c, out HexDigitValue dst)
            => parse(@case, (AsciCode)c, out dst);

        /// <summary>
        /// Parses a nibble
        /// </summary>
        /// <param name="c">The source character</param>
        [MethodImpl(Inline), Op]
        public static bool parse(UpperCased @case, char c, out byte dst)
            => parse(@case, (AsciCode)c, out dst);

        /// <summary>
        /// Parses a nibble
        /// </summary>
        /// <param name="c">The source character</param>
        [MethodImpl(Inline), Op]
        public static bool parse(LowerCased @case, char c, out byte dst)
            => parse(@case, (AsciCode)c, out dst);

        [MethodImpl(Inline), Op]
        public static bool parse(UpperCased @case, char c0, char c1, out byte dst)
        {
            var result = parse(@case, c0, out byte d0);
            result &= parse(@case, c1, out byte d1);
            if(result)
                dst = (byte)((d0 << 4) | d1);
            else
                dst = 0;
            return result;
        }

        [MethodImpl(Inline), Op]
        public static bool parse(LowerCased @case, char c0, char c1, out byte dst)
        {
            var result = parse(@case, c0, out byte d0);
            result &= parse(@case, c1, out byte d1);
            if(result)
                dst = (byte)((d0 << 4) | d1);
            else
                dst = 0;
            return result;
        }

        [Op]
        public static bool parse(UpperCased @case, ReadOnlySpan<char> src, out BinaryCode dst)
        {
            var result = true;
            var count = src.Length;
            dst = BinaryCode.Empty;
            var size = count/2;
            if(count % 2 != 0)
                return false;
            var buffer = alloc<byte>(size);
            for(int i=0, j=0; i<count; i+=2, j++)
            {
                result = parse(@case, skip(src,i), skip(src, i+1), out seek(buffer, j));
                if(!result)
                    break;
            }

            dst = buffer;
            return result;
        }

        [Op]
        public static bool parse(LowerCased @case, ReadOnlySpan<char> src, out BinaryCode dst)
        {
            var result = true;
            var count = src.Length;
            dst = BinaryCode.Empty;
            var size = count/2;
            if(count % 2 != 0)
                return false;
            var buffer = alloc<byte>(size);
            for(int i=0, j=0; i<count; i+=2, j++)
            {
                result = parse(@case, skip(src,i), skip(src, i+1), out seek(buffer, j));
                if(!result)
                    break;
            }

            dst = buffer;
            return result;
        }

        [Parser]
        public static bool parse(string src, out HexArray dst)
        {
            dst = HexArray.Empty;
            var l = text.index(src, Chars.LBracket);
            var r = text.index(src, Chars.RBracket);
            var i0 = 0;
            var i1 = 0;
            if(l < 0 || r < 0 || r <= l)
            {
                i0 = 0;
                i1 = src.Length - 1;
            }
            else
            {
                i0 = l + 1;
                i1 = r - 1;
            }

            var data =  text.segment(src, i0, i1);
            var cells = data.SplitClean(Chars.Comma).ToReadOnlySpan();
            var count = cells.Length;
            var buffer = alloc<byte>(count);
            ref var target = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var cell = ref skip(cells,i);
                if(!parse8u(cell, out seek(target,i)))
                    return false;
            }
            dst = buffer;
            return true;
        }

        [Op]
        public static uint data(ReadOnlySpan<char> src, uint offset, Span<byte> dst)
        {
            var counter = offset;
            var count = (uint)src.Length;
            ref var target = ref first(dst);
            var hi = byte.MaxValue;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(whitespace(c) || fence(c) || separator(c))
                    continue;

                if(parse(c, out HexDigitValue d))
                {
                    if(hi == byte.MaxValue)
                        hi = (byte)d;
                    else
                    {
                        var lo = (byte)d;
                        seek(target, counter++) = Bytes.or(Bytes.sll(hi,4), lo);
                        hi = byte.MaxValue;
                    }
                }
                else
                {
                    count = 0;
                    break;
                }
            }
            return offset - counter;
        }

        /// <summary>
        /// Parses a sequence of hex bytes, delimited by a space or comma
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="dst">The target</param>
        [Op]
        public static Outcome hexbytes(string src, out BinaryCode dst)
        {
            dst = BinaryCode.Empty;
            var result = Outcome.Success;
            if(empty(src))
                return result;

            var sep = delimiter(src);
            var parts = src.Replace(CharText.EOL, CharText.Space).SplitClean(sep).ToReadOnlySpan();
            var count = parts.Length;
            var buffer = alloc<byte>(count);
            ref var target = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var part = ref skip(parts,i);
                result = parse8u(part, out seek(target,i));
                if(result.Fail)
                {
                    result = (false, HexParseFailure.Format(part));
                    return result;
                }
            }
            dst = buffer;
            return result;
        }

        public static MsgPattern<string> HexParseFailure
            => "The value '{0}' could not be parsed as a hex number";

        [Op]
        public static Outcome<uint> hexbytes(string src, Span<byte> dst)
        {
            var size = 0u;
            var limit = (uint)dst.Length;
            var result = Outcome.Success;
            if(empty(src))
                return size;
            var sep = delimiter(src);
            var parts = src.Replace(CharText.EOL, CharText.Space).SplitClean(sep).ToReadOnlySpan();
            var count = src.Length;
            for(var i=0u; i<count && i<limit; i++)
            {
                ref readonly var part = ref skip(parts,i);
                result = parse8u(part, out seek(dst,i));
                if(result.Fail)
                    return (false,size);
                else
                    size++;
            }
            return size;
        }

        /// <summary>
        /// Parses a space-delimited sequence of hex text
        /// </summary>
        /// <param name="src">The space-delimited hex</param>
        [Op]
        public static Outcome hexdata(string src, out byte[] dst)
        {
            try
            {
                dst = src.Trim().Split(Chars.Space).Select(x => byte.Parse(x, NumberStyles.HexNumber));
                return true;
            }
            catch(Exception e)
            {
                dst = sys.empty<byte>();
                return (e,$"Input:{src}");
            }
        }

        [Op]
        public static bool code(string src, out BinaryCode dst)
        {
            var result = false;
            if(hexdata(src, out var code))
            {
                dst = code;
                result = true;
            }
            else
            {
                dst = BinaryCode.Empty;
            }
            return result;
        }       
    }
}