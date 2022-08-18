//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class text
    {
        /// <summary>
        /// Produces the literal '{<paramref name='index'/>}
        /// </summary>
        /// <param name="index">The slot index value</param>
        [MethodImpl(Inline), Op]
        public static string slot(byte index)
            => string.Concat("{", index, "}");

        /// <summary>
        /// Produces the literal '{<paramref name='index'/>,<paramref name='pad'/>}
        /// </summary>
        /// <param name="index">The slot index value</param>
        [MethodImpl(Inline), Op]
        public static string slot(byte index, short pad)
            => string.Concat("{", index, ",", pad, "}");

        /// <summary>
        /// Produces the literal '{<paramref name='index'/>}
        /// </summary>
        /// <param name="index">The slot index value</param>
        [MethodImpl(Inline), Op]
        public static string slot(uint index)
            => string.Concat("{", index, "}");

        /// <summary>
        /// Produces the literal '{<paramref name='index'/>,<paramref name='pad'/>}
        /// </summary>
        /// <param name="index">The slot index value</param>
        [MethodImpl(Inline), Op]
        public static string slot(uint index, short pad)
            => string.Concat("{", index, ",", pad, "}");

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> slot(ReadOnlySpan<byte> widths, byte index)
            => slot(index, (sbyte)(-(sbyte)skip(widths, index)));

        [Op]
        public static uint slot(ReadOnlySpan<byte> widths, char sep, Span<char> dst)
        {
            var k = 0u;
            var count = widths.Length;
            var last = count - 1;
            for(byte i=0; i<count; i++)
            {
                var s = slot(widths, i);
                var len = s.Length;

                for(var j=0; j<len; j++)
                    seek(dst,k++) = skip(s,j);

                if(i != last)
                {
                    seek(dst, k++) = Chars.Space;
                    seek(dst, k++) = sep;
                    seek(dst, k++) = Chars.Space;
                }
            }

            return k;
        }
    }
}