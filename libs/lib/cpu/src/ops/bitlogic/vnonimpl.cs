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
    using static System.Runtime.Intrinsics.X86.Avx;
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static Root;

    partial struct cpu
    {
        /// <summary>
        /// Computes the material nomimplication, ~x & y for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), NonImpl]
        public static Vector128<sbyte> vnonimpl(Vector128<sbyte> x, Vector128<sbyte> y)
            => AndNot(x, y);

        /// <summary>
        /// Computes the material nomimplication, ~x & y for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), NonImpl]
        public static Vector128<byte> vnonimpl(Vector128<byte> x, Vector128<byte> y)
            => AndNot(x, y);

        /// <summary>
        /// Computes the material nomimplication, ~x & y for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), NonImpl]
        public static Vector128<short> vnonimpl(Vector128<short> x, Vector128<short> y)
            => AndNot(x, y);

        /// <summary>
        /// Computes the material nomimplication, ~x & y for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), NonImpl]
        public static Vector128<ushort> vnonimpl(Vector128<ushort> x, Vector128<ushort> y)
            => AndNot(x, y);

        /// <summary>
        /// Computes the material nomimplication, ~x & y for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), NonImpl]
        public static Vector128<int> vnonimpl(Vector128<int> x, Vector128<int> y)
            => AndNot(x, y);

        /// <summary>
        /// Computes the material nomimplication, ~x & y for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), NonImpl]
        public static Vector128<uint> vnonimpl(Vector128<uint> x, Vector128<uint> y)
            => AndNot(x, y);

        /// <summary>
        /// Computes the material nomimplication, ~x & y for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), NonImpl]
        public static Vector128<long> vnonimpl(Vector128<long> x, Vector128<long> y)
            => AndNot(x, y);

        /// <summary>
        /// Computes the material nomimplication, ~x & y for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), NonImpl]
        public static Vector128<ulong> vnonimpl(Vector128<ulong> x, Vector128<ulong> y)
            => AndNot(x, y);

        /// <summary>
        /// Computes the material nomimplication, ~x & y for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), NonImpl]
        public static Vector256<sbyte> vnonimpl(Vector256<sbyte> x, Vector256<sbyte> y)
            => AndNot(x, y);

        /// <summary>
        /// Computes the material nomimplication, ~x & y for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), NonImpl]
        public static Vector256<byte> vnonimpl(Vector256<byte> x, Vector256<byte> y)
            => AndNot(x, y);

        /// <summary>
        /// Computes the material nomimplication, ~x & y for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), NonImpl]
        public static Vector256<short> vnonimpl(Vector256<short> x, Vector256<short> y)
            => AndNot(x, y);

        /// <summary>
        /// Computes the material nomimplication, ~x & y for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), NonImpl]
        public static Vector256<ushort> vnonimpl(Vector256<ushort> x, Vector256<ushort> y)
            => AndNot(x, y);

        /// <summary>
        /// Computes the material nomimplication, ~x & y for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), NonImpl]
        public static Vector256<int> vnonimpl(Vector256<int> x, Vector256<int> y)
            => AndNot(x, y);

        /// <summary>
        /// Computes the material nomimplication, ~x & y for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), NonImpl]
        public static Vector256<uint> vnonimpl(Vector256<uint> x, Vector256<uint> y)
            => AndNot(x, y);

        /// <summary>
        /// Computes the material nomimplication, ~x & y for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), NonImpl]
        public static Vector256<long> vnonimpl(Vector256<long> x, Vector256<long> y)
            => AndNot(x, y);

        /// <summary>
        /// Computes the material nomimplication, ~x & y for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), NonImpl]
        public static Vector256<ulong> vnonimpl(Vector256<ulong> x, Vector256<ulong> y)
            => AndNot(x, y);
    }
}