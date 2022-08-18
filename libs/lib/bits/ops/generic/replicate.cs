//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Numeric;

    partial class gbits
    {
        /// <summary>
        /// Replicates an index-defined bitpattern a specified number of times
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="i0">The index of the first bit to include in the pattern</param>
        /// <param name="i1">The index of the last bit to include in the pattern</param>
        /// <param name="count">The number of times to repeat the pattern</param>
        /// <typeparam name="T">The source/target type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T replicate<T>(T src, byte i0, byte i1, byte count)
            where T : unmanaged
                => force<T>(bits.replicate(force<T,ulong>(src), i0, i1, count));

        /// <summary>
        /// [000...000101] -> [101101...101101]
        /// Replicates a source bit pattern, determined by the most significant enabled bit,  throughout the range of the type
        /// </summary>
        /// <param name="src">The value defining the pattern to replicate</param>
        /// <typeparam name="T">The source/target type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T replicate<T>(T src)
            where T : unmanaged
        {
            var index = msb(src);
            var count = (byte)((int)width<T>() / (index + 1) +  1);
            var replicated = bits.replicate(force<T,ulong>(src), 0, index, count);
            return force<T>(replicated);
        }

        /// <summary>
        /// Replicates the bit pattern defined by a byte either 2,4 or 8 times as determined by the primal target type
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="t">A target type representative</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T replicate<T>(byte src)
            where T : unmanaged
                => force<T>(bits.replicate((ulong)src, 0, 7, (byte)(width<T>()/8)));
    }
}