//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class gbits
    {
        /// <summary>
        /// Partitions the source value into two parts predicated on an index
        /// [1010 11111 0011] |> split 4 = [1010 1111] [0011]
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="index">The index that partitions the source</param>
        /// <param name="x0">The lo partition</param>
        /// <param name="x1">The hi partition</param>
        [MethodImpl(Inline), Split, Closures(Closure)]
        public static void split<T>(T src, int index, out T x0, out T x1)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
            {
                bits.split(uint8(src), index, out var y0, out var y1);
                x0 = generic<T>(y0);
                x1 = generic<T>(y1);
            }
            else if(typeof(T) == typeof(ushort))
            {
                bits.split(uint16(src), index, out var y0, out var y1);
                x0 = generic<T>(y0);
                x1 = generic<T>(y1);
            }
            else if(typeof(T) == typeof(uint))
            {
                bits.split(uint32(src), index, out var y0, out var y1);
                x0 = generic<T>(y0);
                x1 = generic<T>(y1);
            }
            else if(typeof(T) == typeof(ulong))
            {
                bits.split(uint64(src), index, out var y0, out var y1);
                x0 = generic<T>(y0);
                x1 = generic<T>(y1);
            }
            else
                throw no<T>();
        }
    }
}