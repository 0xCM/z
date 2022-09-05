//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Globalization;
    using static sys;

    using C = AsciCode;

    public class HexParser
    {
        /// <summary>
        /// Removes leading or trailing hex specifiers
        /// </summary>
        /// <param name="src">The source string</param>
        public static string clear(string src)
            => src.Remove("0x").RemoveAny('h');

        /// <summary>
        /// Removes leading or trailing hex specifiers
        /// </summary>
        /// <param name="src">The source string</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> clear(ReadOnlySpan<char> src)
        {
            var output = src;
            if(src.Length >= 2)
            {
                ref readonly var c0 = ref skip(src,0);
                ref readonly var c1 = ref skip(src,1);
                if(c0 == '0' & c1 == 'x')
                    output = slice(src,2);
                else
                {
                    ref readonly var c = ref skip(src,src.Length-1);
                    if(c == 'h')
                        output = slice(src,0, src.Length - 1);
                }
            }
            return output;
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<C> clear(ReadOnlySpan<C> src)
        {
            var output = src;
            if(src.Length >= 2)
            {
                ref readonly var c0 = ref skip(src,0);
                ref readonly var c1 = ref skip(src,1);
                if(c0 == C.d0 & c1 == C.x)
                    output = slice(src,2);
                else
                {
                    ref readonly var c = ref skip(src,src.Length-1);
                    if(c == C.h)
                        output = slice(src,0, src.Length - 1);
                }
            }
            return output;
        }

        [Parser]
        public static bool parse(string src, out Hex4 dst)
        {
            var outcome = parse(src, out byte x);
            dst = new Hex4((Hex4Kind)(x & 0b1111));
            return outcome;
        }

        [Parser]
        public static bool parse(ReadOnlySpan<char> src, out Hex4 dst)
        {
            var outcome = parse(src, out byte x);
            dst = new Hex4((Hex4Kind)(x & 0b1111));
            return outcome;
        }

        [Parser]
        public static bool parse(string src, out Hex8 dst)
        {
            var outcome = parse(src, out byte x);
            dst = x;
            return outcome;
        }

        [Parser]
        public static bool parse(ReadOnlySpan<char> src, out Hex8 dst)
        {
            var outcome = parse(src, out byte x);
            dst = x;
            return outcome;
        }

        [Parser]
        public static bool parse(string src, out Hex16 dst)
        {
            var outcome = parse(src, out ushort x);
            dst = x;
            return outcome;
        }

        [Parser]
        public static bool parse(ReadOnlySpan<char> src, out Hex16 dst)
        {
            var outcome = parse(src, out ushort x);
            dst = x;
            return outcome;
        }

        [Parser]
        public static bool parse(string src, out Hex32 dst)
        {
            var outcome = parse(src, out uint x);
            dst = x;
            return outcome;
        }

        [Parser]
        public static bool parse(ReadOnlySpan<char> src, out Hex32 dst)
        {
            var outcome = parse(src, out uint x);
            dst = x;
            return outcome;
        }

        [Parser]
        public static bool parse(string src, out Hex64 dst)
        {
            var outcome = parse(src, out ulong x);
            dst = x;
            return outcome;
        }

        [Parser]
        public static bool parse(ReadOnlySpan<char> src, out Hex64 dst)
        {
            var outcome = parse(src, out ulong x);
            dst = x;
            return outcome;
        }

        [Parser]
        public static bool parse(string src, out sbyte dst)
            => sbyte.TryParse(clear(src), NumberStyles.HexNumber, null, out dst);

        [Parser]
        public static bool parse(ReadOnlySpan<char> src, out sbyte dst)
            => sbyte.TryParse(clear(src), NumberStyles.HexNumber, null,  out dst);

        [Parser]
        public static bool parse(string src, out byte dst)
            => byte.TryParse(clear(src), NumberStyles.HexNumber, null, out dst);

        [Parser]
        public static bool parse(ReadOnlySpan<char> src, out byte dst)
            => byte.TryParse(clear(src), NumberStyles.HexNumber, null,  out dst);

        [Parser]
        public static bool parse(string src, out ulong dst)
            => ulong.TryParse(clear(src), NumberStyles.HexNumber, null,  out dst);

        [Parser]
        public static bool parse(string src, out uint dst)
            => uint.TryParse(clear(src), NumberStyles.HexNumber, null,  out dst);

        [Parser]
        public static bool parse(ReadOnlySpan<char> src, out uint dst)
            => uint.TryParse(clear(src), NumberStyles.HexNumber, null,  out dst);

        [Parser]
        public static bool parse(ReadOnlySpan<char> src, out ulong dst)
            => ulong.TryParse(clear(src), NumberStyles.HexNumber, null,  out dst);

        [Parser]
        public static bool parse(string src, out ushort dst)
            => ushort.TryParse(clear(src), NumberStyles.HexNumber, null, out dst);

        [Parser]
        public static bool parse(ReadOnlySpan<char> src, out ushort dst)
            => ushort.TryParse(clear(src), NumberStyles.HexNumber, null,  out dst);

        [Parser]
        public static bool parse(string src, out short dst)
            => short.TryParse(clear(src), NumberStyles.HexNumber, null, out dst);

        [Parser]
        public static bool parse(string src, out int dst)
            => int.TryParse(clear(src), NumberStyles.HexNumber, null, out dst);

        [Parser]
        public static bool parse(string src, out long dst)
            => long.TryParse(clear(src), NumberStyles.HexNumber, null, out dst);

        [Parser]
        public static bool parse32u(ReadOnlySpan<char> src, out uint dst)
            => uint.TryParse(clear(src), NumberStyles.HexNumber, null,  out dst);

        [Parser]
        public static bool parse64u(ReadOnlySpan<char> src, out ulong dst)
            => ulong.TryParse(clear(src), NumberStyles.HexNumber, null,  out dst);

        [Parser]
        public static bool parse(ReadOnlySpan<char> src, out Hex14 dst)
        {
            dst = Hex14.Zero;
            var storage = z32;
            var buffer = bytes(storage);
            var result = Hex.parse(src, buffer);
            if(result && storage <= Hex14.MaxValue)
                dst = (Hex14)storage;
            return result;
        }

    }
}