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
        [MethodImpl(Inline), Op]
        public static Vector256<sbyte> vmerge(Vector128<sbyte> x, Vector128<sbyte> y)
            => vconcat(vmergelo(x,y), vmergehi(x,y));

        [MethodImpl(Inline), Op]
        public static Vector256<byte> vmerge(Vector128<byte> x, Vector128<byte> y)
            => vconcat(vmergelo(x,y), vmergehi(x,y));

        [MethodImpl(Inline), Op]
        public static Vector256<short> vmerge(Vector128<short> x, Vector128<short> y)
            => vconcat(vmergelo(x,y), vmergehi(x,y));

        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vmerge(Vector128<ushort> x, Vector128<ushort> y)
            => vconcat(vmergelo(x,y), vmergehi(x,y));

        [MethodImpl(Inline), Op]
        public static Vector256<int> vmerge(Vector128<int> x, Vector128<int> y)
            => vconcat(vmergelo(x,y), vmergehi(x,y));

        [MethodImpl(Inline), Op]
        public static Vector256<uint> vmerge(Vector128<uint> x, Vector128<uint> y)
            => vconcat(vmergelo(x,y), vmergehi(x,y));

        [MethodImpl(Inline), Op]
        public static Vector256<long> vmerge(Vector128<long> x, Vector128<long> y)
            => vconcat(vmergelo(x,y),vmergehi(x,y));

        [MethodImpl(Inline), Op]
        public static Vector256<ulong> vmerge(Vector128<ulong> x, Vector128<ulong> y)
            => vconcat(vmergelo(x,y), vmergehi(x,y));

        /// <summary>
        /// [A,B,C,D] x [E,F,G,H] -> [A,E,B,F,C,G,D,H]
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector512<sbyte> vmerge(Vector256<sbyte> x, Vector256<sbyte> y)
        {
            var a = UnpackLow(x,y);
            var b = UnpackHigh(x,y);
            var c = vperm2x128(a,b, Perm2x4.AC);
            var d = vperm2x128(a,b, Perm2x4.BD);
            return (c,d);
        }

        /// <summary>
        /// [A,B,C,D] x [E,F,G,H] -> [A,E,B,F,C,G,D,H]
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector512<byte> vmerge(Vector256<byte> x, Vector256<byte> y)
        {
            var a = UnpackLow(x,y);
            var b = UnpackHigh(x,y);
            var c = vperm2x128(a,b, Perm2x4.AC);
            var d = vperm2x128(a,b, Perm2x4.BD);
            return (c,d);
        }

        /// <summary>
        /// [A,B,C,D] x [E,F,G,H] -> [A,E,B,F,C,G,D,H]
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector512<short> vmerge(Vector256<short> x, Vector256<short> y)
        {
            var a = UnpackLow(x,y);
            var b = UnpackHigh(x,y);
            var c = vperm2x128(a,b, Perm2x4.AC);
            var d = vperm2x128(a,b, Perm2x4.BD);
            return (c,d);
        }

        /// <summary>
        /// [A,B,C,D] x [E,F,G,H] -> [A,E,B,F,C,G,D,H]
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector512<ushort> vmerge(Vector256<ushort> x, Vector256<ushort> y)
        {
            var a = UnpackLow(x,y);
            var b = UnpackHigh(x,y);
            var c = vperm2x128(a,b, Perm2x4.AC);
            var d = vperm2x128(a,b, Perm2x4.BD);
            return (c,d);
        }

        /// <summary>
        /// [A,B,C,D] x [E,F,G,H] -> [A,E,B,F,C,G,D,H]
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector512<int> vmerge(Vector256<int> x, Vector256<int> y)
        {
            var a = UnpackLow(x,y);
            var b = UnpackHigh(x,y);
            var c = vperm2x128(a,b, Perm2x4.AC);
            var d = vperm2x128(a,b, Perm2x4.BD);
            return (c,d);
        }

        /// <summary>
        /// [A,B,C,D] x [E,F,G,H] -> [A,E,B,F,C,G,D,H]
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector512<uint> vmerge(Vector256<uint> x, Vector256<uint> y)
        {
            var a = UnpackLow(x,y);
            var b = UnpackHigh(x,y);
            var c = vperm2x128(a,b, Perm2x4.AC);
            var d = vperm2x128(a,b, Perm2x4.BD);
            return (c,d);
        }

        /// <summary>
        /// [A,B,C,D] x [E,F,G,H] -> [A,E,B,F,C,G,D,H]
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector512<long> vmerge(Vector256<long> x, Vector256<long> y)
        {
            var a = UnpackLow(x,y);
            var b = UnpackHigh(x,y);
            var c = vperm2x128(a,b, Perm2x4.AC);
            var d = vperm2x128(a,b, Perm2x4.BD);
            return (c,d);
        }

        /// <summary>
        /// [A,B,C,D] x [E,F,G,H] -> [A,E,B,F,C,G,D,H]
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector512<ulong> vmerge(Vector256<ulong> x, Vector256<ulong> y)
        {
            var a = UnpackLow(x,y);
            var b = UnpackHigh(x,y);
            var c = vperm2x128(a,b, Perm2x4.AC);
            var d = vperm2x128(a,b, Perm2x4.BD);
            return (c,d);
        }
    }
}