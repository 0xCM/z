//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct cpu
    {
        /// <summary>
        /// Returns 1 if the left vector is identical to the right vector and 0 otherwise
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Same]
        public static bit vsame(Vector128<byte> x, Vector128<byte> y)
            => vtestc(veq(x,y));

        /// <summary>
        /// Returns 1 if the left vector is identical to the right vector and 0 otherwise
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Same]
        public static bit vsame(Vector128<sbyte> x, Vector128<sbyte> y)
            => vtestc(veq(x,y));

        /// <summary>
        /// Returns 1 if the left vector is identical to the right vector and 0 otherwise
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Same]
        public static bit vsame(Vector128<short> x, Vector128<short> y)
            => vtestc(veq(x,y));

        /// <summary>
        /// Returns 1 if the left vector is identical to the right vector and 0 otherwise
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Same]
        public static bit vsame(Vector128<ushort> x, Vector128<ushort> y)
            => vtestc(veq(x,y));

        /// <summary>
        /// Returns 1 if the left vector is identical to the right vector and 0 otherwise
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Same]
        public static bit vsame(Vector128<int> x, Vector128<int> y)
            => vtestc(veq(x,y));

        /// <summary>
        /// Returns 1 if the left vector is identical to the right vector and 0 otherwise
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Same]
        public static bit vsame(Vector128<uint> x, Vector128<uint> y)
            => vtestc(veq(x,y));

        /// <summary>
        /// Returns 1 if the left vector is identical to the right vector and 0 otherwise
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Same]
        public static bit vsame(Vector128<long> x, Vector128<long> y)
            => vtestc(veq(x,y));

        /// <summary>
        /// Returns 1 if the left vector is identical to the right vector and 0 otherwise
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Same]
        public static bit vsame(Vector128<ulong> x, Vector128<ulong> y)
            => vtestc(veq(x,y));

        /// <summary>
        /// Returns 1 if the left vector is identical to the right vector and 0 otherwise
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Same]
        public static bit vsame(Vector128<float> x, Vector128<float> y)
            => vtestc(veq(x,y));

        /// <summary>
        /// Returns 1 if the left vector is identical to the right vector and 0 otherwise
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Same]
        public static bit vsame(Vector128<double> x, Vector128<double> y)
            => vtestc(veq(x,y));

        /// <summary>
        /// Returns 1 if the left vector is identical to the right vector and 0 otherwise
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Same]
        public static bit vsame(Vector256<byte> x, Vector256<byte> y)
            => vtestc(veq(x,y));

        /// <summary>
        /// Returns 1 if the left vector is identical to the right vector and 0 otherwise
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Same]
        public static bit vsame(Vector256<sbyte> x, Vector256<sbyte> y)
            => vtestc(veq(x,y));

        /// <summary>
        /// Returns 1 if the left vector is identical to the right vector and 0 otherwise
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Same]
        public static bit vsame(Vector256<short> x, Vector256<short> y)
            => vtestc(veq(x,y));

        /// <summary>
        /// Returns 1 if the left vector is identical to the right vector and 0 otherwise
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Same]
        public static bit vsame(Vector256<ushort> x, Vector256<ushort> y)
            => vtestc(veq(x,y));

        /// <summary>
        /// Returns 1 if the left vector is identical to the right vector and 0 otherwise
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Same]
        public static bit vsame(Vector256<int> x, Vector256<int> y)
            => vtestc(veq(x,y));

        /// <summary>
        /// Returns 1 if the left vector is identical to the right vector and 0 otherwise
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Same]
        public static bit vsame(Vector256<uint> x, Vector256<uint> y)
            => vtestc(veq(x,y));

        /// <summary>
        /// Returns 1 if the left vector is identical to the right vector and 0 otherwise
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Same]
        public static bit vsame(Vector256<long> x, Vector256<long> y)
            => vtestc(veq(x,y));

        /// <summary>
        /// Returns 1 if the left vector is identical to the right vector and 0 otherwise
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Same]
        public static bit vsame(Vector256<ulong> x, Vector256<ulong> y)
            => vtestc(veq(x,y));

        /// <summary>
        /// Returns 1 if the left vector is identical to the right vector and 0 otherwise
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Same]
        public static bit vsame(Vector256<float> x, Vector256<float> y)
            => vtestc(veq(x,y));

        /// <summary>
        /// Returns 1 if the left vector is identical to the right vector and 0 otherwise
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Same]
        public static bit vsame(Vector256<double> x, Vector256<double> y)
            => vtestc(veq(x,y));
    }
}