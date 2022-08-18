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
    using static core;

    partial struct gcpu
    {
        /// <summary>
        /// Hydrates a 128-bit T-vector from an S-reference
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="S">The source reference type</typeparam>
        /// <typeparam name="T">The target vector cell type</typeparam>
        [MethodImpl(Inline)]
        public static ref Vector128<T> vcover<S,T>(W128 w, ref S src)
            where T : unmanaged
                => ref @as<S,Vector128<T>>(src);

        /// <summary>
        /// Hydrates a 256-bit T-vector from an S-reference
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="S">The source reference type</typeparam>
        /// <typeparam name="T">The target vector cell type</typeparam>
        [MethodImpl(Inline)]
        public static ref Vector256<T> vcover<S,T>(W256 w, ref S src)
            where T : unmanaged
                => ref @as<S,Vector256<T>>(src);

        /// <summary>
        /// Hydrates a 512-bit T-vector from an S-reference
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="S">The source reference type</typeparam>
        /// <typeparam name="T">The target vector cell type</typeparam>
        [MethodImpl(Inline)]
        public static ref Vector512<T> vcover<S,T>(W512 w, ref S src)
            where T : unmanaged
                => ref @as<S,Vector512<T>>(src);

        /// <summary>
        /// Covers a 16-byte segment with a 128-bit T-vector
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The target vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector128<T> vcover<T>(W128 w, ref byte src)
            where T : unmanaged
                => ref vcover<byte,T>(w, ref src);

        /// <summary>
        /// Covers a 16-byte segment with a 128-bit T-vector
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The target vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector128<T> vcover<T>(W128 w, ref sbyte src)
            where T : unmanaged
                => ref vcover<sbyte,T>(w, ref src);

        /// <summary>
        /// Covers a 16-byte segment with a 128-bit T-vector
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The target vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector128<T> vcover<T>(W128 w, ref short src)
            where T : unmanaged
                => ref vcover<short,T>(w, ref src);

        /// <summary>
        /// Covers a 16-byte segment with a 128-bit T-vector
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The target vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector128<T> vcover<T>(W128 w, ref ushort src)
            where T : unmanaged
                => ref vcover<ushort,T>(w, ref src);

        /// <summary>
        /// Covers a 16-byte segment with a 128-bit T-vector
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The target vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector128<T> vcover<T>(W128 w, ref int src)
            where T : unmanaged
                => ref vcover<int,T>(w, ref src);

        /// <summary>
        /// Covers a 16-byte segment with a 128-bit T-vector
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The target vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector128<T> vcover<T>(W128 w, ref uint src)
            where T : unmanaged
                => ref vcover<uint,T>(w, ref src);

        /// <summary>
        /// Covers a 16-byte segment with a 128-bit T-vector
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The target vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector128<T> vcover<T>(W128 w, ref long src)
            where T : unmanaged
                => ref vcover<long,T>(w, ref src);

        /// <summary>
        /// Covers a 16-byte segment with a 128-bit T-vector
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The target vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector128<T> vcover<T>(W128 w, ref ulong src)
            where T : unmanaged
                => ref vcover<ulong,T>(w, ref src);

        /// <summary>
        /// Covers a 16-byte segment with a 128-bit T-vector
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The target vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector128<T> vcover<T>(W128 w, ref char src)
            where T : unmanaged
                => ref vcover<char,T>(w, ref src);

        /// <summary>
        /// Covers a 16-byte segment with a 128-bit T-vector
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The target vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector128<T> vcover<T>(W128 w, ref decimal src)
            where T : unmanaged
                => ref vcover<decimal,T>(w, ref src);

        /// <summary>
        /// Covers a 32-byte segment with a 256-bit T-vector
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The target vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector256<T> vcover<T>(W256 w, ref byte src)
            where T : unmanaged
                => ref vcover<byte,T>(w, ref src);

        /// <summary>
        /// Covers a 32-byte segment with a 256-bit T-vector
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The target vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector256<T> vcover<T>(W256 w, ref sbyte src)
            where T : unmanaged
                => ref vcover<sbyte,T>(w, ref src);

        /// <summary>
        /// Covers a 32-byte segment with a 256-bit T-vector
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The target vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector256<T> vcover<T>(W256 w, ref short src)
            where T : unmanaged
                => ref vcover<short,T>(w, ref src);

        /// <summary>
        /// Covers a 32-byte segment with a 256-bit T-vector
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The target vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector256<T> vcover<T>(W256 w, ref ushort src)
            where T : unmanaged
                => ref vcover<ushort,T>(w, ref src);

        /// <summary>
        /// Covers a 32-byte segment with a 256-bit T-vector
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The target vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector256<T> vcover<T>(W256 w, ref int src)
            where T : unmanaged
                => ref vcover<int,T>(w, ref src);

        /// <summary>
        /// Covers a 32-byte segment with a 256-bit T-vector
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The target vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector256<T> vcover<T>(W256 w, ref uint src)
            where T : unmanaged
                => ref vcover<uint,T>(w, ref src);

        /// <summary>
        /// Covers a 32-byte segment with a 256-bit T-vector
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The target vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector256<T> vcover<T>(W256 w, ref long src)
            where T : unmanaged
                => ref vcover<long,T>(w, ref src);

        /// <summary>
        /// Covers a 32-byte segment with a 256-bit T-vector
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The target vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector256<T> vcover<T>(W256 w, ref ulong src)
            where T : unmanaged
                => ref vcover<ulong,T>(w, ref src);

        /// <summary>
        /// Covers a 32-byte segment with a 256-bit T-vector
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The target vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector256<T> vcover<T>(W256 w, ref bool src)
            where T : unmanaged
                => ref vcover<bool,T>(w, ref src);

        /// <summary>
        /// Covers a 32-byte segment with a 256-bit T-vector
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The target vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector256<T> vcover<T>(W256 w, ref char src)
            where T : unmanaged
                => ref vcover<char,T>(w, ref src);

        /// <summary>
        /// Covers a 32-byte segment with a 256-bit T-vector
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The target vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector256<T> vcover<T>(W256 w, ref decimal src)
            where T : unmanaged
                => ref vcover<decimal,T>(w, ref src);

        /// <summary>
        /// Covers a 64-byte segment with a 256-bit T-vector
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The target vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector512<T> vcover<T>(W512 w, ref byte src)
            where T : unmanaged
                => ref vcover<byte,T>(w, ref src);

        /// <summary>
        /// Covers a 64-byte segment with a 256-bit T-vector
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The target vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector512<T> vcover<T>(W512 w, ref sbyte src)
            where T : unmanaged
                => ref vcover<sbyte,T>(w, ref src);

        /// <summary>
        /// Covers a 64-byte segment with a 256-bit T-vector
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The target vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector512<T> vcover<T>(W512 w, ref short src)
            where T : unmanaged
                => ref vcover<short,T>(w, ref src);

        /// <summary>
        /// Covers a 64-byte segment with a 256-bit T-vector
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The target vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector512<T> vcover<T>(W512 w, ref ushort src)
            where T : unmanaged
                => ref vcover<ushort,T>(w, ref src);

        /// <summary>
        /// Covers a 64-byte segment with a 256-bit T-vector
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The target vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector512<T> vcover<T>(W512 w, ref int src)
            where T : unmanaged
                => ref vcover<int,T>(w, ref src);

        /// <summary>
        /// Covers a 64-byte segment with a 256-bit T-vector
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The target vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector512<T> vcover<T>(W512 w, ref uint src)
            where T : unmanaged
                => ref vcover<uint,T>(w, ref src);

        /// <summary>
        /// Covers a 64-byte segment with a 256-bit T-vector
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The target vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector512<T> vcover<T>(W512 w, ref long src)
            where T : unmanaged
                => ref vcover<long,T>(w, ref src);

        /// <summary>
        /// Covers a 64-byte segment with a 256-bit T-vector
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The target vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector512<T> vcover<T>(W512 w, ref ulong src)
            where T : unmanaged
                => ref vcover<ulong,T>(w, ref src);

        /// <summary>
        /// Covers a 64-byte segment with a 256-bit T-vector
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The target vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector512<T> vcover<T>(W512 w, ref bool src)
            where T : unmanaged
                => ref vcover<bool,T>(w, ref src);

        /// <summary>
        /// Covers a 64-byte segment with a 256-bit T-vector
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The target vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector512<T> vcover<T>(W512 w, ref char src)
            where T : unmanaged
                => ref vcover<char,T>(w, ref src);

        /// <summary>
        /// Covers a 64-byte segment with a 256-bit T-vector
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The target vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Vector512<T> vcover<T>(W512 w, ref decimal src)
            where T : unmanaged
                => ref vcover<decimal,T>(w, ref src);
    }
}