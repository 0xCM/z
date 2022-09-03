//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct gcpu
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector128<sbyte> vcast8i<T>(in Vector128<T> src)
            where T : unmanaged
                => ref @as<Vector128<T>,Vector128<sbyte>>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector128<byte> vcast8u<T>(in Vector128<T> src)
            where T : unmanaged
                => ref @as<Vector128<T>,Vector128<byte>>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector128<short> vcast16i<T>(in Vector128<T> src)
            where T : unmanaged
                => ref @as<Vector128<T>,Vector128<short>>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector128<ushort> vcast16u<T>(in Vector128<T> src)
            where T : unmanaged
                => ref @as<Vector128<T>,Vector128<ushort>>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref  Vector128<int> vcast32i<T>(in Vector128<T> src)
            where T : unmanaged
                => ref @as<Vector128<T>,Vector128<int>>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector128<uint> vcast32u<T>(in Vector128<T> src)
            where T : unmanaged
                => ref @as<Vector128<T>,Vector128<uint>>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector128<long> vcast64i<T>(in Vector128<T> src)
            where T : unmanaged
                => ref @as<Vector128<T>,Vector128<long>>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector128<ulong> vcast64u<T>(in Vector128<T> src)
            where T : unmanaged
                => ref @as<Vector128<T>,Vector128<ulong>>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector128<float> vcast32f<T>(in Vector128<T> src)
            where T : unmanaged
                => ref @as<Vector128<T>,Vector128<float>>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector128<double> vcast64f<T>(in Vector128<T> src)
            where T : unmanaged
                => ref @as<Vector128<T>,Vector128<double>>(src);


        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector256<sbyte> vcast8i<T>(in Vector256<T> src)
            where T : unmanaged
                => ref @as<Vector256<T>,Vector256<sbyte>>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector256<byte> vcast8u<T>(in Vector256<T> src)
            where T : unmanaged
                => ref @as<Vector256<T>,Vector256<byte>>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector256<short> vcast16i<T>(in Vector256<T> src)
            where T : unmanaged
                => ref @as<Vector256<T>,Vector256<short>>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector256<ushort> vcast16u<T>(in Vector256<T> src)
            where T : unmanaged
                => ref @as<Vector256<T>,Vector256<ushort>>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref  Vector256<int> vcast32i<T>(in Vector256<T> src)
            where T : unmanaged
                => ref @as<Vector256<T>,Vector256<int>>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector256<uint> vcast32u<T>(in Vector256<T> src)
            where T : unmanaged
                => ref @as<Vector256<T>,Vector256<uint>>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector256<long> vcast64i<T>(in Vector256<T> src)
            where T : unmanaged
                => ref @as<Vector256<T>,Vector256<long>>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector256<ulong> vcast64u<T>(in Vector256<T> src)
            where T : unmanaged
                => ref @as<Vector256<T>,Vector256<ulong>>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector512<sbyte> vcast8i<T>(in Vector512<T> src)
            where T : unmanaged
                => ref @as<Vector512<T>,Vector512<sbyte>>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector512<byte> vcast8u<T>(in Vector512<T> src)
            where T : unmanaged
                => ref @as<Vector512<T>,Vector512<byte>>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector512<short> vcast16i<T>(in Vector512<T> src)
            where T : unmanaged
                => ref @as<Vector512<T>,Vector512<short>>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector512<ushort> vcast16u<T>(in Vector512<T> src)
            where T : unmanaged
                => ref @as<Vector512<T>,Vector512<ushort>>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref  Vector512<int> vcast32i<T>(in Vector512<T> src)
            where T : unmanaged
                => ref @as<Vector512<T>,Vector512<int>>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector512<uint> vcast32u<T>(in Vector512<T> src)
            where T : unmanaged
                => ref @as<Vector512<T>,Vector512<uint>>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector512<long> vcast64i<T>(in Vector512<T> src)
            where T : unmanaged
                => ref @as<Vector512<T>,Vector512<long>>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector512<ulong> vcast64u<T>(in Vector512<T> src)
            where T : unmanaged
                => ref @as<Vector512<T>,Vector512<ulong>>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector512<float> vcast32f<T>(in Vector512<T> src)
            where T : unmanaged
                => ref @as<Vector512<T>,Vector512<float>>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Vector512<double> vcast64f<T>(in Vector512<T> src)
            where T : unmanaged
                => ref @as<Vector512<T>,Vector512<double>>(src);

        /// <summary>
        /// Presents a 128-bit S-cell vector as a 128-bit T-cell vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="t">A target cell representative used only for type inference</param>
        /// <typeparam name="S">The source cell type</typeparam>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline)]
        public static Vector128<T> vcast<S,T>(Vector128<S> x, T t = default)
            where S : unmanaged
            where T : unmanaged
                => x.As<S,T>();

        /// <summary>
        /// Presents a 256-bit S-cell vector as a 256-bit T-cell vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="t">A target cell representative used only for type inference</param>
        /// <typeparam name="S">The source cell type</typeparam>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline)]
        public static Vector256<T> vcast<S,T>(Vector256<S> x, T t = default)
            where S : unmanaged
            where T : unmanaged
                => x.As<S,T>();

        /// <summary>
        /// Presents a 512-bit S-cell vector as a 512-bit T-cell vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="t">A target cell representative used only for type inference</param>
        /// <typeparam name="S">The source cell type</typeparam>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline)]
        public static Vector512<T> vcast<S,T>(Vector512<S> x, T t = default)
            where S : unmanaged
            where T : unmanaged
                => x.As<T>();
    }
}