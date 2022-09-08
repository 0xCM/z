//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class gbits
    {
        /// <summary>
        /// Disables a sequence of bits starting at a specified index
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="index">The index at which to begin clearing bits</param>
        /// <param name="count">The number of bits to clear</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static T trim<T>(T src, byte index, byte count)
            where T : unmanaged
        {
            if(size<T>() == 1)
                return generic<T>(bits.trim(uint8(src), index, count));
            else if (size<T>() == 2)
                return generic<T>(bits.trim(uint16(src), index, count));
            else if (size<T>() == 4)
                return generic<T>(bits.trim(uint32(src), index, count));
            else
                return generic<T>(bits.trim(uint64(src), index, count));
        }
    }
}