//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static System.Runtime.Intrinsics.X86.Sse;
    using static System.Runtime.Intrinsics.X86.Sse2;
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static System.Runtime.Intrinsics.X86.Avx;
    using static Root;

    partial struct cpu
    {
        /// <summary>
        /// Computes ~ (x ^ y) for vectors x and y
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Xnor]
        public static Vector128<sbyte> vxnor(Vector128<sbyte> x, Vector128<sbyte> y)
            => vnot(Xor(x, y));

        /// <summary>
        /// Computes ~ (x ^ y) for vectors x and y
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Xnor]
        public static Vector128<byte> vxnor(Vector128<byte> x, Vector128<byte> y)
            => vnot(Xor(x, y));

        /// <summary>
        /// Computes ~ (x ^ y) for vectors x and y
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Xnor]
        public static Vector128<short> vxnor(Vector128<short> x, Vector128<short> y)
            => vnot(Xor(x, y));

        /// <summary>
        /// Computes ~ (x ^ y) for vectors x and y
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Xnor]
        public static Vector128<ushort> vxnor(Vector128<ushort> x, Vector128<ushort> y)
            => vnot(Xor(x, y));

        /// <summary>
        /// Computes ~ (x ^ y) for vectors x and y
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Xnor]
        public static Vector128<int> vxnor(Vector128<int> x, Vector128<int> y)
            => vnot(Xor(x, y));

        /// <summary>
        /// Computes ~ (x ^ y) for vectors x and y
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Xnor]
        public static Vector128<uint> vxnor(Vector128<uint> x, Vector128<uint> y)
            => vnot(Xor(x, y));

        /// <summary>
        /// Computes ~ (x ^ y) for vectors x and y
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Xnor]
        public static Vector128<long> vxnor(Vector128<long> x, Vector128<long> y)
            => vnot(Xor(x, y));

        /// <summary>
        /// Computes ~ (x ^ y) for vectors x and y
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Xnor]
        public static Vector128<ulong> vxnor(Vector128<ulong> x, Vector128<ulong> y)
            => vnot(Xor(x, y));

        /// <summary>
        /// Computes ~ (x ^ y) for vectors x and y
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Xnor]
        public static Vector256<byte> vxnor(Vector256<byte> x, Vector256<byte> y)
            => vnot(Xor(x, y));

        /// <summary>
        /// Computes ~ (x ^ y) for vectors x and y
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Xnor]
        public static Vector256<short> vxnor(Vector256<short> x, Vector256<short> y)
            => vnot(Xor(x, y));

        /// <summary>
        /// Computes ~ (x ^ y) for vectors x and y
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Xnor]
        public static Vector256<sbyte> vxnor(Vector256<sbyte> x, Vector256<sbyte> y)
            => vnot(Xor(x, y));

        /// <summary>
        /// Computes the bitwise XOR between operands
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Xnor]
        public static Vector256<ushort> vxnor(Vector256<ushort> x, Vector256<ushort> y)
            => vnot(Xor(x, y));

        /// <summary>
        /// Computes ~ (x ^ y) for vectors x and y
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Xnor]
        public static Vector256<int> vxnor(Vector256<int> x, Vector256<int> y)
            => vnot(Xor(x, y));

        /// <summary>
        /// Computes ~ (x ^ y) for vectors x and y
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Xnor]
        public static Vector256<uint> vxnor(Vector256<uint> x, Vector256<uint> y)
            => vnot(Xor(x, y));

        /// <summary>
        /// Computes ~ (x ^ y) for vectors x and y
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Xnor]
        public static Vector256<long> vxnor(Vector256<long> x, Vector256<long> y)
            => vnot(Xor(x, y));

        /// <summary>
        /// Computes ~ (x ^ y) for vectors x and y
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Xnor]
        public static Vector256<ulong> vxnor(Vector256<ulong> x, Vector256<ulong> y)
            => vnot(Xor(x, y));

        /// <summary>
        /// Computes the bitwise XOR between operands
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vxnor(Vector128<float> x, Vector128<float> y)
            => vnot(Xor(x, y));

        /// <summary>
        /// Computes the bitwise XOR between operands
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Op]
        public static Vector128<double> vxnor(Vector128<double> x, Vector128<double> y)
            => vnot(Xor(x, y));

        /// <summary>
        /// Computes the bitwise XOR between operands
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Op]
        public static Vector256<float> vxnor(Vector256<float> x, Vector256<float> y)
            => vnot(Xor(x, y));

        /// <summary>
        /// Computes the bitwise XOR between operands
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Op]
        public static Vector256<double> vxnor(Vector256<double> x, Vector256<double> y)
            => vnot(Xor(x, y));

    }
}