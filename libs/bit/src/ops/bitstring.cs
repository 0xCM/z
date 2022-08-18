//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct bit
    {
        /// <summary>
        /// Creates a bitspan from the text encoding of a binary number
        /// </summary>
        /// <param name="src">The bit source</param>
        public static Span<bit> bitstring(string src)
        {
            var count = src.Length;
            var dst = span<bit>(count);
            var actual = bitstring(src, dst);
            return slice(dst,0, actual);
        }

        [Op]
        public static uint bitstring(string src, Span<bit> buffer)
        {
            var chars = span(src);
            var count = min(chars.Length, buffer.Length);
            var j=0u;
            for(uint i=0u; i<count; i++)
            {
                ref readonly var c = ref skip(chars, i);
                if(c == bit.One)
                    seek(buffer, j++) = bit.On;
                else if(c == bit.Zero)
                    seek(buffer, j++) = bit.Off;
            }
            return j;
        }
    }
}