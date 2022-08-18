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
        /// Computes the material implication, x | ~y for vectors x and y
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Impl]
        public static Vector128<sbyte> vimpl(Vector128<sbyte> x, Vector128<sbyte> y)
            => Or(x,vnot(y));

        /// <summary>
        /// Computes the material implication, x | ~y for vectors x and y
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Impl]
        public static Vector128<byte> vimpl(Vector128<byte> x, Vector128<byte> y)
            => Or(x,vnot(y));

        /// <summary>
        /// Computes the material implication, x | ~y for vectors x and y
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Impl]
        public static Vector128<short> vimpl(Vector128<short> x, Vector128<short> y)
            => Or(x,vnot(y));

        /// <summary>
        /// Computes the material implication, x | ~y for vectors x and y
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Impl]
        public static Vector128<ushort> vimpl(Vector128<ushort> x, Vector128<ushort> y)
            => Or(x,vnot(y));

        /// <summary>
        /// Computes the material implication, x | ~y for vectors x and y
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Impl]
        public static Vector128<int> vimpl(Vector128<int> x, Vector128<int> y)
            => Or(x,vnot(y));

        /// <summary>
        /// Computes the material implication, x | ~y for vectors x and y
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Impl]
        public static Vector128<uint> vimpl(Vector128<uint> x, Vector128<uint> y)
            => Or(x,vnot(y));

        /// <summary>
        /// Computes the material implication, x | ~y for vectors x and y
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Impl]
        public static Vector128<long> vimpl(Vector128<long> x, Vector128<long> y)
            => Or(x,vnot(y));

        /// <summary>
        /// Computes the material implication, x | ~y for vectors x and y
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Impl]
        public static Vector128<ulong> vimpl(Vector128<ulong> x, Vector128<ulong> y)
            => Or(x,vnot(y));

        /// <summary>
        /// Computes the material implication, x | ~y for vectors x and y
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Impl]
        public static Vector256<sbyte> vimpl(Vector256<sbyte> x, Vector256<sbyte> y)
            => Or(x,vnot(y));

        /// <summary>
        /// Computes the material implication, x | ~y for vectors x and y
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Impl]
        public static Vector256<byte> vimpl(Vector256<byte> x, Vector256<byte> y)
            => Or(x,vnot(y));

        /// <summary>
        /// Computes the material implication, x | ~y for vectors x and y
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Impl]
        public static Vector256<short> vimpl(Vector256<short> x, Vector256<short> y)
            => Or(x,vnot(y));

        /// <summary>
        /// Computes the material implication, x | ~y for vectors x and y
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Impl]
        public static Vector256<ushort> vimpl(Vector256<ushort> x, Vector256<ushort> y)
            => Or(x,vnot(y));

        /// <summary>
        /// Computes the material implication, x | ~y for vectors x and y
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Impl]
        public static Vector256<int> vimpl(Vector256<int> x, Vector256<int> y)
            => Or(x,vnot(y));

        /// <summary>
        /// Computes the material implication, x | ~y for vectors x and y
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Impl]
        public static Vector256<uint> vimpl(Vector256<uint> x, Vector256<uint> y)
            => Or(x,vnot(y));

        /// <summary>
        /// Computes the material implication, x | ~y for vectors x and y
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Impl]
        public static Vector256<long> vimpl(Vector256<long> x, Vector256<long> y)
            => Or(x,vnot(y));

        /// <summary>
        /// Computes the material implication, x | ~y for vectors x and y
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Impl]
        public static Vector256<ulong> vimpl(Vector256<ulong> x, Vector256<ulong> y)
            => Or(x,vnot(y));
    }
}