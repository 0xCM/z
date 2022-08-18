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
        /// Fills a caller-supplied target span with asci codes corresponding to characters in a source span
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The data target</param>
        [MethodImpl(Inline), Op]
        public static int encode(ReadOnlySpan<char> src, Span<AsciCode> dst)
        {
            var count = min(src.Length, dst.Length);
            for(var i=0u; i<count; i++)
                seek(dst,i) = (AsciCode)skip(src,i);
            return count;
        }

        /// <summary>
        /// Encodes a specified number of source characters
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <param name="dst">The data target</param>
        [MethodImpl(Inline), Op]
        public static uint encode(ReadOnlySpan<char> src, uint offset, uint count, Span<AsciCode> dst)
        {
            ref readonly var input = ref skip(src, offset);
            ref var target = ref first(dst);
            for(var i=0u; i<count; i++)
                seek(target, i) = (AsciCode)skip(input,i);
            return count;
        }
    }
}