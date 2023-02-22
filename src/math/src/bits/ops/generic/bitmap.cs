//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class gbits
    {
        /// <summary>
        /// Maps bits from a source segment src[0..(count-1)] to a target segment dst[index..(index+count)]
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="dst">The target</param>
        /// <param name="count">The number bits to read from the source an replace in the target</param>
        /// <param name="offset">The target-relative index at which to begin the overwrite</param>
        /// <typeparam name="T">The primal scalar type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T bitmap<T>(T src, T dst, byte offset, byte count)
            where T : unmanaged
        {
            var a = trim(dst, offset, count);
            var b = gmath.sll(and(BitMasks.lo<T>(count), src), offset);
            return or(a, b);
        }
    }
}