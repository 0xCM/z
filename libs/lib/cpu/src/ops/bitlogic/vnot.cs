//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;
    using System.Runtime.Intrinsics.X86;

    using static System.Runtime.Intrinsics.X86.Sse;
    using static System.Runtime.Intrinsics.X86.Sse2;
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static System.Runtime.Intrinsics.X86.Avx;
    using static System.Runtime.Intrinsics.X86.Sse41;
    using static Root;

    partial struct cpu
    {
        /// <summary>
        /// Computes the bitwise negation of the source vector
        /// </summary>
        /// <param name="a">The source vector</param>
        [MethodImpl(Inline), Not]
        public static Vector128<sbyte> vnot(Vector128<sbyte> a)
            => Xor(a, CompareEqual(a, a));

        /// <summary>
        /// Computes the bitwise negation of the source vector
        /// </summary>
        /// <param name="a">The source vector</param>
        [MethodImpl(Inline), Not]
        public static Vector128<byte> vnot(Vector128<byte> a)
            => Xor(a, CompareEqual(a, a));

        /// <summary>
        /// Computes the bitwise negation of the source vector
        /// </summary>
        /// <param name="a">The source vector</param>
        [MethodImpl(Inline), Not]
        public static Vector128<short> vnot(Vector128<short> a)
            => Xor(a, CompareEqual(a, a));

        /// <summary>
        /// Computes the bitwise negation of the source vector
        /// </summary>
        /// <param name="a">The source vector</param>
        [MethodImpl(Inline), Not]
        public static Vector128<ushort> vnot(Vector128<ushort> a)
            => Xor(a, CompareEqual(a, a));

        /// <summary>
        /// Computes the bitwise negation of the source vector
        /// </summary>
        /// <param name="a">The source vector</param>
        [MethodImpl(Inline), Not]
        public static Vector128<int> vnot(Vector128<int> a)
            => Xor(a, CompareEqual(a, a));

        /// <summary>
        /// Computes the bitwise negation of the source vector
        /// </summary>
        /// <param name="a">The source vector</param>
        [MethodImpl(Inline), Not]
        public static Vector128<uint> vnot(Vector128<uint> a)
            => Xor(a, CompareEqual(a, a));

        /// <summary>
        /// Computes the bitwise negation of the source vector
        /// </summary>
        /// <param name="a">The source vector</param>
        [MethodImpl(Inline), Not]
        public static Vector128<long> vnot(Vector128<long> a)
            => vnot(a.AsUInt32()).AsInt64();

        /// <summary>
        /// Computes the bitwise negation of the source vector
        /// </summary>
        /// <param name="a">The source vector</param>
        [MethodImpl(Inline), Not]
        public static Vector128<ulong> vnot(Vector128<ulong> a)
            => vnot(a.AsUInt32()).AsUInt64();

        /// <summary>
        /// Computes the bitwise negation of the source vector
        /// </summary>
        /// <param name="a">The source vector</param>
        [MethodImpl(Inline), Not]
        public static Vector256<sbyte> vnot(Vector256<sbyte> a)
            => Xor(a, CompareEqual(a, a));

        /// <summary>
        /// Computes the bitwise negation of the source vector
        /// </summary>
        /// <param name="a">The source vector</param>
        [MethodImpl(Inline), Not]
        public static Vector256<byte> vnot(Vector256<byte> a)
            => Xor(a, CompareEqual(a, a));

        /// <summary>
        /// Computes the bitwise negation of the source vector
        /// </summary>
        /// <param name="a">The source vector</param>
        [MethodImpl(Inline), Not]
        public static Vector256<short> vnot(Vector256<short> a)
            => Xor(a, CompareEqual(a, a));

        /// <summary>
        /// Computes the bitwise negation of the source vector
        /// </summary>
        /// <param name="a">The source vector</param>
        [MethodImpl(Inline), Not]
        public static Vector256<ushort> vnot(Vector256<ushort> a)
            => Xor(a, CompareEqual(a, a));

        /// <summary>
        /// Computes the bitwise negation of the source vector
        /// </summary>
        /// <param name="a">The source vector</param>
        [MethodImpl(Inline), Not]
        public static Vector256<int> vnot(Vector256<int> a)
            => Xor(a, CompareEqual(a, a));

        /// <summary>
        /// Computes the bitwise negation of the source vector
        /// </summary>
        /// <param name="a">The source vector</param>
        [MethodImpl(Inline), Not]
        public static Vector256<uint> vnot(Vector256<uint> a)
            => Xor(a, CompareEqual(a, a));

        /// <summary>
        /// Computes the bitwise negation of the source vector
        /// </summary>
        /// <param name="a">The source vector</param>
        [MethodImpl(Inline), Not]
        public static Vector256<long> vnot(Vector256<long> a)
            => Xor(a, CompareEqual(a, a));

        /// <summary>
        /// Computes the bitwise negation of the source vector
        /// </summary>
        /// <param name="a">The source vector</param>
        [MethodImpl(Inline), Not]
        public static Vector256<ulong> vnot(Vector256<ulong> a)
            => Xor(a, CompareEqual(a, a));

        [MethodImpl(Inline), Op]
        public static Vector128<float> vnot(Vector128<float> a)
            => Xor(a, CompareEqual(a, a));

        [MethodImpl(Inline), Op]
        public static Vector128<double> vnot(Vector128<double> a)
            => Xor(a, CompareEqual(a, a));

        [MethodImpl(Inline), Op]
        public static Vector256<float> vnot(Vector256<float> a)
            => Xor(a, Compare(a, a, FloatComparisonMode.OrderedEqualNonSignaling));

        [MethodImpl(Inline), Op]
        public static Vector256<double> vnot(Vector256<double> a)
            => Xor(a, Compare(a, a, FloatComparisonMode.OrderedEqualNonSignaling));
    }
}