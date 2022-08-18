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
        /// Computes ~(x | y) for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Nor]
        public static Vector128<sbyte> vnor(Vector128<sbyte> x, Vector128<sbyte> y)
            => vnot(Or(x, y));

        /// <summary>
        /// Computes ~(x | y) for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Nor]
        public static Vector128<byte> vnor(Vector128<byte> x, Vector128<byte> y)
            => vnot(Or(x, y));

        /// <summary>
        /// Computes ~(x | y) for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Nor]
        public static Vector128<short> vnor(Vector128<short> x, Vector128<short> y)
            => vnot(Or(x, y));

        /// <summary>
        /// Computes ~(x | y) for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Nor]
        public static Vector128<ushort> vnor(Vector128<ushort> x, Vector128<ushort> y)
            => vnot(Or(x, y));

        /// <summary>
        /// Computes ~(x | y) for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Nor]
        public static Vector128<int> vnor(Vector128<int> x, Vector128<int> y)
            => vnot(Or(x, y));

        /// <summary>
        /// Computes ~(x | y) for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Nor]
        public static Vector128<uint> vnor(Vector128<uint> x, Vector128<uint> y)
            => vnot(Or(x, y));

        /// <summary>
        /// Computes ~(x | y) for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Nor]
        public static Vector128<long> vnor(Vector128<long> x, Vector128<long> y)
            => vnot(Or(x, y));

        /// <summary>
        /// Computes ~(x | y) for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Nor]
        public static Vector128<ulong> vnor(Vector128<ulong> x, Vector128<ulong> y)
            => vnot(Or(x, y));

        /// <summary>
        /// Computes ~(x | y) for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Nor]
        public static Vector128<float> vnor(Vector128<float> x, Vector128<float> y)
            => vnot(Or(x, y));

        /// <summary>
        /// Computes ~(x | y) for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Nor]
        public static Vector128<double> vnor(Vector128<double> x, Vector128<double> y)
            => vnot(Or(x, y));

        /// <summary>
        /// Computes ~(x | y) for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Nor]
        public static Vector256<byte> vnor(Vector256<byte> x, Vector256<byte> y)
            => vnot(Or(x, y));

        /// <summary>
        /// Computes ~(x | y) for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Nor]
        public static Vector256<short> vnor(Vector256<short> x, Vector256<short> y)
            => vnot(Or(x, y));

        /// <summary>
        /// Computes ~(x | y) for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Nor]
        public static Vector256<sbyte> vnor(Vector256<sbyte> x, Vector256<sbyte> y)
            => vnot(Or(x, y));

        /// <summary>
        /// Computes ~(x | y) for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Nor]
        public static Vector256<ushort> vnor(Vector256<ushort> x, Vector256<ushort> y)
            => vnot(Or(x, y));

        /// <summary>
        /// Computes ~(x | y) for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Nor]
        public static Vector256<int> vnor(Vector256<int> x, Vector256<int> y)
            => vnot(Or(x, y));

        /// <summary>
        /// Computes ~(x | y) for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Nor]
        public static Vector256<uint> vnor(Vector256<uint> x, Vector256<uint> y)
            => vnot(Or(x, y));

        /// <summary>
        /// Computes ~(x | y) for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Nor]
        public static Vector256<long> vnor(Vector256<long> x, Vector256<long> y)
            => vnot(Or(x, y));

        /// <summary>
        /// Computes ~(x | y) for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Nor]
        public static Vector256<ulong> vnor(Vector256<ulong> x, Vector256<ulong> y)
            => vnot(Or(x, y));

        /// <summary>
        /// Computes ~(x | y) for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Nor]
        public static Vector256<float> vnor(Vector256<float> x, Vector256<float> y)
            => vnot(Or(x, y));

        /// <summary>
        /// Computes ~(x | y) for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Nor]
        public static Vector256<double> vnor(Vector256<double> x, Vector256<double> y)
            => vnot(Or(x, y));
    }
}