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

    partial struct core
    {
        /// <summary>
        /// Reinterprets the source vector as a vector over parametric T-cells
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The target type</typeparam>
        /// <remarks>This operation should be dissolved when the method is closed over a concrete type
        /// and should not impact instruction generation</remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector128<T> generic<T>(in Vector128<sbyte> src)
            where T : unmanaged
                => ref @as<Vector128<sbyte>,Vector128<T>>(src);

        /// <summary>
        /// Reinterprets the source vector as a vector over parametric T-cells
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The target type</typeparam>
        /// <remarks>This operation should be dissolved when the method is closed over a concrete type
        /// and should not impact instruction generation</remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector128<T> generic<T>(in Vector128<byte> src)
            where T : unmanaged
                => ref @as<Vector128<byte>,Vector128<T>>(src);

        /// <summary>
        /// Reinterprets the source vector as a vector over parametric T-cells
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The target type</typeparam>
        /// <remarks>This operation should be dissolved when the method is closed over a concrete type
        /// and should not impact instruction generation</remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector128<T> generic<T>(in Vector128<short> src)
            where T : unmanaged
                => ref @as<Vector128<short>,Vector128<T>>(src);

        /// <summary>
        /// Reinterprets the source vector as a vector over parametric T-cells
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The target type</typeparam>
        /// <remarks>This operation should be dissolved when the method is closed over a concrete type
        /// and should not impact instruction generation</remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector128<T> generic<T>(in Vector128<ushort> src)
            where T : unmanaged
                => ref @as<Vector128<ushort>,Vector128<T>>(src);

        /// <summary>
        /// Reinterprets the source vector as a vector over parametric T-cells
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The target type</typeparam>
        /// <remarks>This operation should be dissolved when the method is closed over a concrete type
        /// and should not impact instruction generation</remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector128<T> generic<T>(in Vector128<int> src)
            where T : unmanaged
                => ref @as<Vector128<int>,Vector128<T>>(src);

        /// <summary>
        /// Reinterprets the source vector as a vector over parametric T-cells
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The target type</typeparam>
        /// <remarks>This operation should be dissolved when the method is closed over a concrete type
        /// and should not impact instruction generation</remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector128<T> generic<T>(in Vector128<uint> src)
            where T : unmanaged
                => ref @as<Vector128<uint>,Vector128<T>>(src);

        /// <summary>
        /// Reinterprets the source vector as a vector over parametric T-cells
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The target type</typeparam>
        /// <remarks>This operation should be dissolved when the method is closed over a concrete type
        /// and should not impact instruction generation</remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector128<T> generic<T>(in Vector128<long> src)
            where T : unmanaged
                => ref @as<Vector128<long>,Vector128<T>>(src);

        /// <summary>
        /// Reinterprets the source vector as a vector over parametric T-cells
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The target type</typeparam>
        /// <remarks>This operation should be dissolved when the method is closed over a concrete type
        /// and should not impact instruction generation</remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector128<T> generic<T>(in Vector128<ulong> src)
            where T : unmanaged
                => ref @as<Vector128<ulong>,Vector128<T>>(src);

        /// <summary>
        /// Reinterprets the source vector as a vector over parametric T-cells
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The target type</typeparam>
        /// <remarks>This operation should be dissolved when the method is closed over a concrete type
        /// and should not impact instruction generation</remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector128<T> generic<T>(in Vector128<float> src)
            where T : unmanaged
                => ref @as<Vector128<float>,Vector128<T>>(src);

        /// <summary>
        /// Reinterprets the source vector as a vector over parametric T-cells
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The target type</typeparam>
        /// <remarks>This operation should be dissolved when the method is closed over a concrete type
        /// and should not impact instruction generation</remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector128<T> generic<T>(in Vector128<double> src)
            where T : unmanaged
                => ref @as<Vector128<double>,Vector128<T>>(src);

        /// <summary>
        /// Reinterprets the source vector as a vector over parametric T-cells
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The target type</typeparam>
        /// <remarks>This operation should be dissolved when the method is closed over a concrete type
        /// and should not impact instruction generation</remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector256<T> generic<T>(in Vector256<sbyte> src)
            where T : unmanaged
                => ref @as<Vector256<sbyte>,Vector256<T>>(edit(src));

        /// <summary>
        /// Reinterprets the source vector as a vector over parametric T-cells
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The target type</typeparam>
        /// <remarks>This operation should be dissolved when the method is closed over a concrete type
        /// and should not impact instruction generation</remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector256<T> generic<T>(in Vector256<byte> src)
            where T : unmanaged
                => ref @as<Vector256<byte>,Vector256<T>>(edit(src));

        /// <summary>
        /// Reinterprets the source vector as a vector over parametric T-cells
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The target type</typeparam>
        /// <remarks>This operation should be dissolved when the method is closed over a concrete type
        /// and should not impact instruction generation</remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector256<T> generic<T>(in Vector256<short> src)
            where T : unmanaged
                => ref @as<Vector256<short>,Vector256<T>>(edit(src));

        /// <summary>
        /// Reinterprets the source vector as a vector over parametric T-cells
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The target type</typeparam>
        /// <remarks>This operation should be dissolved when the method is closed over a concrete type
        /// and should not impact instruction generation</remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector256<T> generic<T>(in Vector256<ushort> src)
            where T : unmanaged
                => ref @as<Vector256<ushort>,Vector256<T>>(edit(src));

        /// <summary>
        /// Reinterprets the source vector as a vector over parametric T-cells
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The target type</typeparam>
        /// <remarks>This operation should be dissolved when the method is closed over a concrete type
        /// and should not impact instruction generation</remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector256<T> generic<T>(in Vector256<int> src)
            where T : unmanaged
                => ref @as<Vector256<int>,Vector256<T>>(edit(src));

        /// <summary>
        /// Reinterprets the source vector as a vector over parametric T-cells
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The target type</typeparam>
        /// <remarks>This operation should be dissolved when the method is closed over a concrete type
        /// and should not impact instruction generation</remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector256<T> generic<T>(in Vector256<uint> src)
            where T : unmanaged
                => ref @as<Vector256<uint>,Vector256<T>>(edit(src));

        /// <summary>
        /// Reinterprets the source vector as a vector over parametric T-cells
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The target type</typeparam>
        /// <remarks>This operation should be dissolved when the method is closed over a concrete type
        /// and should not impact instruction generation</remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector256<T> generic<T>(in Vector256<long> src)
            where T : unmanaged
                => ref @as<Vector256<long>,Vector256<T>>(edit(src));

        /// <summary>
        /// Reinterprets the source vector as a vector over parametric T-cells
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The target type</typeparam>
        /// <remarks>This operation should be dissolved when the method is closed over a concrete type
        /// and should not impact instruction generation</remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector256<T> generic<T>(in Vector256<ulong> src)
            where T : unmanaged
                => ref @as<Vector256<ulong>,Vector256<T>>(edit(src));

        /// <summary>
        /// Reinterprets the source vector as a vector over parametric T-cells
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The target type</typeparam>
        /// <remarks>This operation should be dissolved when the method is closed over a concrete type
        /// and should not impact instruction generation</remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector256<T> generic<T>(in Vector256<float> src)
            where T : unmanaged
                => ref @as<Vector256<float>,Vector256<T>>(edit(src));

        /// <summary>
        /// Reinterprets the source vector as a vector over parametric T-cells
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The target type</typeparam>
        /// <remarks>This operation should be dissolved when the method is closed over a concrete type
        /// and should not impact instruction generation</remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector256<T> generic<T>(in Vector256<double> src)
            where T : unmanaged
                => ref @as<Vector256<double>,Vector256<T>>(edit(src));

        /// <summary>
        /// Reinterprets the source vector as a vector over parametric T-cells
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The target type</typeparam>
        /// <remarks>This operation should be dissolved when the method is closed over a concrete type
        /// and should not impact instruction generation</remarks>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector512<T> generic<T>(in Vector512<sbyte> src)
            where T : unmanaged
                => ref @as<Vector512<sbyte>,Vector512<T>>(edit(src));

        /// <summary>
        /// Reinterprets the source vector as a vector over parametric T-cells
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The target type</typeparam>
        /// <remarks>This operation should be dissolved when the method is closed over a concrete type
        /// and should not impact instruction generation</remarks>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector512<T> generic<T>(in Vector512<byte> src)
            where T : unmanaged
                => ref @as<Vector512<byte>,Vector512<T>>(edit(src));

        /// <summary>
        /// Reinterprets the source vector as a vector over parametric T-cells
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The target type</typeparam>
        /// <remarks>This operation should be dissolved when the method is closed over a concrete type
        /// and should not impact instruction generation</remarks>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector512<T> generic<T>(in Vector512<short> src)
            where T : unmanaged
                => ref @as<Vector512<short>,Vector512<T>>(edit(src));

        /// <summary>
        /// Reinterprets the source vector as a vector over parametric T-cells
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The target type</typeparam>
        /// <remarks>This operation should be dissolved when the method is closed over a concrete type
        /// and should not impact instruction generation</remarks>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector512<T> generic<T>(in Vector512<ushort> src)
            where T : unmanaged
                => ref @as<Vector512<ushort>,Vector512<T>>(edit(src));

        /// <summary>
        /// Reinterprets the source vector as a vector over parametric T-cells
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The target type</typeparam>
        /// <remarks>This operation should be dissolved when the method is closed over a concrete type
        /// and should not impact instruction generation</remarks>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector512<T> generic<T>(in Vector512<int> src)
            where T : unmanaged
                => ref @as<Vector512<int>,Vector512<T>>(edit(src));

        /// <summary>
        /// Reinterprets the source vector as a vector over parametric T-cells
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The target type</typeparam>
        /// <remarks>This operation should be dissolved when the method is closed over a concrete type
        /// and should not impact instruction generation</remarks>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector512<T> generic<T>(in Vector512<uint> src)
            where T : unmanaged
                => ref @as<Vector512<uint>,Vector512<T>>(edit(src));

        /// <summary>
        /// Reinterprets the source vector as a vector over parametric T-cells
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The target type</typeparam>
        /// <remarks>This operation should be dissolved when the method is closed over a concrete type
        /// and should not impact instruction generation</remarks>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector512<T> generic<T>(in Vector512<long> src)
            where T : unmanaged
               => ref @as<Vector512<long>,Vector512<T>>(edit(src));

        /// <summary>
        /// Reinterprets the source vector as a vector over parametric T-cells
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The target type</typeparam>
        /// <remarks>This operation should be dissolved when the method is closed over a concrete type
        /// and should not impact instruction generation</remarks>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector512<T> generic<T>(in Vector512<ulong> src)
            where T : unmanaged
               => ref @as<Vector512<ulong>,Vector512<T>>(edit(src));

        /// <summary>
        /// Reinterprets the source vector as a vector over parametric T-cells
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The target type</typeparam>
        /// <remarks>This operation should be dissolved when the method is closed over a concrete type
        /// and should not impact instruction generation</remarks>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector512<T> generic<T>(in Vector512<float> src)
            where T : unmanaged
               => ref @as<Vector512<float>,Vector512<T>>(edit(src));

        /// <summary>
        /// Reinterprets the source vector as a vector over parametric T-cells
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The target type</typeparam>
        /// <remarks>This operation should be dissolved when the method is closed over a concrete type
        /// and should not impact instruction generation</remarks>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector512<T> generic<T>(in Vector512<double> src)
            where T : unmanaged
                => ref @as<Vector512<double>,Vector512<T>>(edit(src));
    }
}