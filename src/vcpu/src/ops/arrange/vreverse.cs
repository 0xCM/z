//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class vcpu
    {
        /// <summary>
        /// Reverses the source vector components
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<byte> vreverse(Vector128<byte> src)
            => vshuf16x8(src, vdec<byte>(w128));

        /// <summary>
        /// Reverses the source vector components
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<sbyte> vreverse(Vector128<sbyte> src)
            => vshuf16x8(src, vdec<sbyte>(w128));

        /// <summary>
        /// Reverses the source vector components
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<short> vreverse(Vector128<short> src)
            => vswaphl(vshuf4x16(src, Arrange4L.DCBA, Arrange4L.DCBA));

        /// <summary>
        /// Reverses the source vector components
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ushort> vreverse(Vector128<ushort> src)
            => vswaphl(vshuf4x16(src, Arrange4L.DCBA, Arrange4L.DCBA));

        /// <summary>
        /// Reverses the source vector components
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<int> vreverse(Vector128<int> src)
            => vperm4x32(src, Perm4L.DCBA);

        /// <summary>
        /// Reverses the source vector components
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<uint> vreverse(Vector128<uint> src)
            => vperm4x32(src, Perm4L.DCBA);

        [MethodImpl(Inline), Op]
        public static Vector128<long> vreverse(Vector128<long> src)
            => vswaphl(src);

        /// <summary>
        /// Reverses the source vector components
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ulong> vreverse(Vector128<ulong> src)
            => vswaphl(src);

        /// <summary>
        /// Reverses the source vector components
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<byte> vreverse(Vector256<byte> src)
            => vshuf32x8(src, vdec<byte>(n256));

        /// <summary>
        /// Reverses the source vector components
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<sbyte> vreverse(Vector256<sbyte> src)
            => vconcat(vreverse(vhi(src)), vreverse(vlo(src)));

        /// <summary>
        /// Reverses the source vector components
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<short> vreverse(Vector256<short> src)
            => vconcat(vreverse(vhi(src)), vreverse(vlo(src)));

        /// <summary>
        /// Reverses the source vector components
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vreverse(Vector256<ushort> src)
            => vconcat(vreverse(vhi(src)), vreverse(vlo(src)));

        /// <summary>
        /// Reverses the source vector components
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<int> vreverse(Vector256<int> src)
            => vperm8x32(src, MRev256u32);

        /// <summary>
        /// Reverses the source vector components
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<uint> vreverse(Vector256<uint> src)
            => vperm8x32(src,MRev256u32);

        /// <summary>
        /// Reverses the source vector components
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<long> vreverse(Vector256<long> src)
            => vperm4x64(src,Perm4L.DCBA);

        /// <summary>
        /// Reverses the source vector components
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ulong> vreverse(Vector256<ulong> src)
            => vperm4x64(src,Perm4L.DCBA);

        [MethodImpl(Inline), Op]
        public static Vector256<float> vreverse(Vector256<float> src)
            => vperm8x32(src,MRev256f32);

        static Vector256<int> MRev256f32
        {
            [MethodImpl(Inline), Op]
            get => vparts(w256i, 7, 6, 5, 4, 3, 2, 1, 0);
        }

        static Vector256<uint> MRev256u32
        {
            [MethodImpl(Inline), Op]
            get => v32u(vload(n256, MRev256u32Data));
        }

        static ReadOnlySpan<byte> MRev256u32Data => new byte[32]
        {
            0x07, 0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00,
            0x05, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00,
            0x03, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00,
            0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        };
    }
}