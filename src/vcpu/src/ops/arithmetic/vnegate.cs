//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class vcpu
    {
        /// <summary>
        /// Negates the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Negate]
        public static Vector128<sbyte> vnegate(Vector128<sbyte> src)
            => vsub(default, src);

        /// <summary>
        /// Negates the source vector (Two's complement)
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Negate]
        public static Vector128<byte> vnegate(Vector128<byte> src)
            => vsub(vnot(src), vones<byte>(w128));

        /// <summary>
        /// Negates the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Negate]
        public static Vector128<short> vnegate(Vector128<short> src)
            => vsub(default, src);

        /// <summary>
        /// Negates the source vector (Two's complement)
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Negate]
        public static Vector128<ushort> vnegate(Vector128<ushort> src)
            => vsub(vnot(src), vones<ushort>(w128));

        /// <summary>
        /// Negates the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Negate]
        public static Vector128<int> vnegate(Vector128<int> src)
            => vsub(default, src);

        /// <summary>
        /// Negates the source vector (Two's complement)
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Negate]
        public static Vector128<uint> vnegate(Vector128<uint> src)
            => vsub(vnot(src), vones<uint>(w128));

        /// <summary>
        /// Negates the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Negate]
        public static Vector128<long> vnegate(Vector128<long> src)
            => vsub(default, src);

        /// <summary>
        /// Negates the source vector (Two's complement)
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Negate]
        public static Vector128<ulong> vnegate(Vector128<ulong> src)
            => vsub(vnot(src), vones<ulong>(w128));

        /// <summary>
        /// Negates the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Negate]
        public static Vector256<sbyte> vnegate(Vector256<sbyte> src)
            => vsub(default, src);

        /// <summary>
        /// Negates the source vector (Two's complement)
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Negate]
        public static Vector256<byte> vnegate(Vector256<byte> src)
            => vsub(vnot(src), vones<byte>(w256));

        /// <summary>
        /// Negates the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Negate]
        public static Vector256<short> vnegate(Vector256<short> src)
            => vsub(default, src);

        /// <summary>
        /// Negates the source vector (Two's complement)
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Negate]
        public static Vector256<ushort> vnegate(Vector256<ushort> src)
            => vsub(vnot(src), vones<ushort>(w256));

        /// <summary>
        /// Negates the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Negate]
        public static Vector256<int> vnegate(Vector256<int> src)
            => vsub(default, src);

        /// <summary>
        /// Negates the source vector (Two's complement)
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Negate]
        public static Vector256<uint> vnegate(Vector256<uint> src)
            => vsub(vnot(src), vones<uint>(w256));

        /// <summary>
        /// Negates the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Negate]
        public static Vector256<long> vnegate(Vector256<long> src)
            => vsub(default, src);

        /// <summary>
        /// Negates the source vector (Two's complement)
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Negate]
        public static Vector256<ulong> vnegate(Vector256<ulong> src)
            => vsub(vnot(src), vones<ulong>(w256));

        /// <summary>
        /// Negates each source vector component
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vnegate(Vector128<float> x)
            => vsub(default, x);

        /// <summary>
        /// Negates each source vector component
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<double> vnegate(Vector128<double> x)
            => vsub(default, x);

        /// <summary>
        /// Negates each source vector component
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<float> vnegate(Vector256<float> x)
            => vsub(default, x);

        /// <summary>
        /// Negates each source vector component
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<double> vnegate(Vector256<double> x)
            => vsub(default, x);
    }
}