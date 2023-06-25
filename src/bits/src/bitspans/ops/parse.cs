//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class BitSpans
    {
        /// <summary>
        /// Creates a bitspan from text encoding of a binary number
        /// </summary>
        /// <param name="src">The bit source</param>
        [Op]
        public static BitSpan parse(ReadOnlySpan<char> src)
        {
            var count = src.Length;
            var dst = load(span<bit>(count));
            parse(src, dst);
            return dst;
        }

        public static Outcome parse(string src, out BitSpan dst)
        {
            dst = alloc<bit>(src.Length);
            return parse(src,dst);
        }

        /// <summary>
        /// Creates a bitspan from text encoding of a binary number
        /// </summary>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Op]
        public static bool parse(ReadOnlySpan<char> src, BitSpan dst)
        {
            var result = true;
            ref var target = ref dst.First;
            var input = src;
            var count = min(input.Length, dst.BitCount);
            var lastix = count - 1;
            for(var i=0; i<=lastix; i++)
            {
                ref readonly var c = ref skip(input,i);
                if(c == bit.Zero)
                    seek(target, lastix - i) = bit.Off;
                else if(c == bit.One)
                    seek(target, lastix - i) = bit.On;
                else
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
    }
}