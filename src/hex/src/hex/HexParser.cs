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
                if(!Hex.parse8u(cell, out seek(target,i)))
                    return false;
            }
            dst = buffer;
            return true;
        }

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
        public static bool parse(string src, out Hex2 dst)
        {
            var outcome = Hex.parse8u(src, out var x);
            dst = new Hex2((Hex2Kind)(x & 0b11));
            return outcome;
        }

        public static bool parse(ReadOnlySpan<char> src, out Hex2 dst)
            => Hex2.parse(src, out dst);

        public static bool parse(string src, out Hex3 dst)
            => Hex3.parse(src, out dst);

        public static bool parse(ReadOnlySpan<char> src, out Hex3 dst)
            => Hex3.parse(src, out dst);

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

        public static bool parse(string src, out Hex8 dst)
            => Hex8.parse(src, out dst);

        public static bool parse(ReadOnlySpan<char> src, out Hex8 dst)
            => Hex8.parse(src, out dst);

        public static bool parse(ReadOnlySpan<char> src, out Hex12 dst)
            => Hex12.parse(src, out dst);

        public static bool parse(ReadOnlySpan<char> src, out Hex14 dst)
            => Hex14.parse(src, out dst);
        public static bool parse(string src, out Hex16 dst)
            => Hex16.parse(src, out dst);

        public static bool parse(ReadOnlySpan<char> src, out Hex16 dst)
            => Hex16.parse(src, out dst);

        public static bool parse(string src, out Hex32 dst)
            => Hex32.parse(src, out dst);

        public static bool parse(ReadOnlySpan<char> src, out Hex32 dst)
            => Hex32.parse(src, out dst);

        public static bool parse(string src, out Hex64 dst)
            => Hex64.parse(src, out dst);

        public static bool parse(ReadOnlySpan<char> src, out Hex64 dst)
            => Hex64.parse(src, out dst);

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
    }
}