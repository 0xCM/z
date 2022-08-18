//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;

    partial struct cpu
    {
        /// <summary>
        /// Increments each component by 1
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Inc]
        public static Vector128<sbyte> vinc(Vector128<sbyte> src)
            => vadd(src, gcpu.vunits<sbyte>(w128));

        /// <summary>
        /// Increments each component by 1
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Inc]
        public static Vector128<byte> vinc(Vector128<byte> src)
            => vadd(src, gcpu.vunits<byte>(w128));

        /// <summary>
        /// Increments each component by 1
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Inc]
        public static Vector128<short> vinc(Vector128<short> src)
            => vadd(src, gcpu.vunits<short>(w128));

        /// <summary>
        /// Increments each component by 1
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Inc]
        public static Vector128<ushort> vinc(Vector128<ushort> src)
            => vadd(src, gcpu.vunits<ushort>(w128));

        /// <summary>
        /// Increments each component by 1
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Inc]
        public static Vector128<int> vinc(Vector128<int> src)
            => vadd(src, gcpu.vunits<int>(w128));

        /// <summary>
        /// Increments each component by 1
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Inc]
        public static Vector128<uint> vinc(Vector128<uint> src)
            => vadd(src, gcpu.vunits<uint>(w128));

        /// <summary>
        /// Increments each component by 1
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Inc]
        public static Vector128<long> vinc(Vector128<long> src)
            => vadd(src, gcpu.vunits<long>(w128));

        /// <summary>
        /// Increments each component by 1
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Inc]
        public static Vector128<ulong> vinc(Vector128<ulong> src)
            => vadd(src, gcpu.vunits<ulong>(w128));

        /// <summary>
        /// Increments each component by 1
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Inc]
        public static Vector256<sbyte> vinc(Vector256<sbyte> src)
            => vadd(src, gcpu.vunits<sbyte>(w256));

        /// <summary>
        /// Increments each component by 1
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Inc]
        public static Vector256<byte> vinc(Vector256<byte> src)
            => vadd(src, gcpu.vunits<byte>(w256));

        /// <summary>
        /// Increments each component by 1
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Inc]
        public static Vector256<short> vinc(Vector256<short> src)
            => vadd(src, gcpu.vunits<short>(w256));

        /// <summary>
        /// Increments each component by 1
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Inc]
        public static Vector256<ushort> vinc(Vector256<ushort> src)
            => vadd(src, gcpu.vunits<ushort>(w256));

        /// <summary>
        /// Increments each component by 1
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Inc]
        public static Vector256<int> vinc(Vector256<int> src)
            => vadd(src, gcpu.vunits<int>(w256));

        /// <summary>
        /// Increments each component by 1
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Inc]
        public static Vector256<uint> vinc(Vector256<uint> src)
            => vadd(src, gcpu.vunits<uint>(w256));

        /// <summary>
        /// Increments each component by 1
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Inc]
        public static Vector256<long> vinc(Vector256<long> src)
            => vadd(src, gcpu.vunits<long>(w256));

        /// <summary>
        /// Increments each component by 1
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Inc]
        public static Vector256<ulong> vinc(Vector256<ulong> src)
            => vadd(src, gcpu.vunits<ulong>(w256));
    }
}