//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class vcpu
    {
        /// <summary>
        /// Swaps the source vectors' hi/lo 128-bit lanes
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<byte> vswaphl(Vector256<byte> x)
            => vperm2x128(x,x, Perm2x4.DA);

        /// <summary>
        /// Swaps hi/lo 128-bit lanes
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<sbyte> vswaphl(Vector256<sbyte> x)
            => vperm2x128(x,x, Perm2x4.DA);

        /// <summary>
        /// Swaps hi/lo 128-bit lanes
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<short> vswaphl(Vector256<short> x)
            => vperm2x128(x,x, Perm2x4.DA);

        /// <summary>
        /// Swaps hi/lo 128-bit lanes
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vswaphl(Vector256<ushort> x)
            => vperm2x128(x,x, Perm2x4.DA);

        /// <summary>
        /// Swaps hi/lo 128-bit lanes
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<int> vswaphl(Vector256<int> x)
            => vperm2x128(x,x, Perm2x4.DA);

        /// <summary>
        /// Swaps hi/lo 128-bit lanes
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<uint> vswaphl(Vector256<uint> x)
            => vperm2x128(x,x, Perm2x4.DA);

        /// <summary>
        /// Swaps hi/lo 128-bit lanes
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<long> vswaphl(Vector256<long> x)
            => vperm2x128(x,x, Perm2x4.DA);

        /// <summary>
        /// Swaps hi/lo 128-bit lanes
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ulong> vswaphl(Vector256<ulong> x)
            => vperm2x128(x,x, Perm2x4.DA);


        /// <summary>
        /// Swaps 64-bit hi/lo segments of the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<short> vswaphl(Vector128<short> x)
            => v16i(Shuffle(v32u(x), (byte)Arrange2L.BA));

        /// <summary>
        /// Swaps 64-bit hi/lo segments of the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline)]
        public static Vector128<ushort> vswaphl(Vector128<ushort> x)
            => v16u(Shuffle(v32u(x), (byte)Arrange2L.BA));

        /// <summary>
        /// Swaps 64-bit hi/lo segments of the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<int> vswaphl(Vector128<int> x)
            => Shuffle(x,  (byte)Arrange2L.BA);

        /// <summary>
        /// Swaps 64-bit hi/lo segments of the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<uint> vswaphl(Vector128<uint> x)
            => Shuffle(x, (byte)Arrange2L.BA);

        /// <summary>
        /// Swaps 64-bit hi/lo segments of the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ulong> vswaphl(Vector128<ulong> x)
            => v64u(Shuffle(v32u(x), (byte)Arrange2L.BA));

        /// <summary>
        /// Swaps 64-bit hi/lo segments of the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<long> vswaphl(Vector128<long> x)
            => v64i(Shuffle(v32u(x), (byte)Arrange2L.BA));    
    }
}