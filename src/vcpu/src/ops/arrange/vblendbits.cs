//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class vcpu
    {
        /// <summary>
        /// Blends the left and right vectors at the bit-level as specified by the mask operand.
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="mask">The selection mask</param>
        /// <remarks>Equivalent to select</remarks>
        [MethodImpl(Inline), Op]
        public static Vector128<byte> vblendbits(Vector128<byte> x, Vector128<byte> y, Vector128<byte> mask)
            => vxor(x, vand(vxor(x,y), mask));

        /// <summary>
        /// Blends the left and right vectors at the bit-level as specified by the mask operand.
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="mask">The selection mask</param>
        /// <remarks>Equivalent to select</remarks>
        [MethodImpl(Inline), Op]
        public static Vector128<ushort> vblendbits(Vector128<ushort> x, Vector128<ushort> y, Vector128<ushort> mask)
            => vxor(x, vand(vxor(x,y), mask));

        /// <summary>
        /// Blends the left and right vectors at the bit-level as specified by the mask operand.
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="mask">The selection mask</param>
        /// <remarks>Equivalent to select</remarks>
        [MethodImpl(Inline), Op]
        public static Vector128<uint> vblendbits(Vector128<uint> x, Vector128<uint> y, Vector128<uint> mask)
            => vxor(x, vand(vxor(x,y), mask));

        /// <summary>
        /// Blends the left and right vectors at the bit-level as specified by the mask operand.
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="mask">The selection mask</param>
        /// <remarks>Equivalent to select</remarks>
        [MethodImpl(Inline), Op]
        public static Vector128<ulong> vblendbits(Vector128<ulong> x, Vector128<ulong> y, Vector128<ulong> mask)
            => vxor(x, vand(vxor(x,y), mask));

        /// <summary>
        /// Blends the left and right vectors at the bit-level as specified by the mask operand.
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="mask">The selection mask</param>
        /// <remarks>Equivalent to select</remarks>
        [MethodImpl(Inline), Op]
        public static Vector256<byte> vblendbits(Vector256<byte> x, Vector256<byte> y, Vector256<byte> mask)
            => vxor(x, vand(vxor(x,y), mask));

        /// <summary>
        /// Blends the left and right vectors at the bit-level as specified by the mask operand.
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="mask">The selection mask</param>
        /// <remarks>Equivalent to select</remarks>
        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vblendbits(Vector256<ushort> x, Vector256<ushort> y, Vector256<ushort> mask)
            => vxor(x, vand(vxor(x,y), mask));

        /// <summary>
        /// Blends the left and right vectors at the bit-level as specified by the mask operand.
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="mask">The selection mask</param>
        /// <remarks>Equivalent to select</remarks>
        [MethodImpl(Inline), Op]
        public static Vector256<uint> vblendbits(Vector256<uint> x, Vector256<uint> y, Vector256<uint> mask)
            => vxor(x, vand(vxor(x,y), mask));

        /// <summary>
        /// Blends the left and right vectors at the bit-level as specified by the mask operand.
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="mask">The selection mask</param>
        /// <remarks>Equivalent to select</remarks>
        [MethodImpl(Inline), Op]
        public static Vector256<ulong> vblendbits(Vector256<ulong> x, Vector256<ulong> y, Vector256<ulong> mask)
            => vxor(x, vand(vxor(x,y), mask));

    }
}