//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitBlocks
    {
        /// <summary>
        /// Sets a bit value in a T-sequence predicated on a linear index
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="index">The linear index of the target bit, relative to the sequence head</param>
        /// <typeparam name="T">The sequence type</typeparam>
        [MethodImpl(Inline), SetBit, Closures(Closure)]
        public static void setbit<T>(in SpanBlock256<T> src, int index, bit value)
            where T : unmanaged
        {
            var loc = gbits.bitpos<T>((uint)index);
            src[loc.CellIndex] = gbits.setbit(src[loc.CellIndex], (byte)loc.BitOffset, value);
        }
    }
}