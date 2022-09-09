//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;

    partial class sys
    {
        /// <summary>
        /// Transforms a <see cref='char'/> value into a <see cref='T'/> value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T generic<T>(char src)
            => As<char,T>(ref src);

        /// <summary>
        /// Transforms a <see cref='bool'/> value into a <see cref='T'/> value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T generic<T>(bool src)
            => As<bool,T>(ref src);

        /// <summary>
        /// Transforms a <see cref='sbyte'/> value into a <see cref='T'/> value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T generic<T>(sbyte src)
            => As<sbyte,T>(ref src);

        /// <summary>
        /// Transforms a <see cref='byte'/> value into a <see cref='T'/> value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T generic<T>(byte src)
            => As<byte,T>(ref src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref T generic<T>(ref byte src)
            => ref As<byte,T>(ref src);

        /// <summary>
        /// Transforms a <see cref='short'/> value into a <see cref='T'/> value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T generic<T>(short src)
            => As<short,T>(ref src);

        /// <summary>
        /// Transforms a <see cref='ushort'/> value into a <see cref='T'/> value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T generic<T>(ushort src)
            => As<ushort,T>(ref src);

        /// <summary>
        /// Transforms a <see cref='int'/> value into a <see cref='T'/> value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T generic<T>(int src)
            => As<int,T>(ref src);

        /// <summary>
        /// Transforms a <see cref='uint'/> value into a <see cref='T'/> value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T generic<T>(uint src)
            => As<uint,T>(ref src);

        /// <summary>
        /// Transforms a <see cref='long'/> value into a <see cref='T'/> value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T generic<T>(long src)
            => As<long,T>(ref src);

        /// <summary>
        /// Transforms a <see cref='ulong'/> value into a <see cref='T'/> value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T generic<T>(ulong src)
            => As<ulong,T>(ref src);

        /// <summary>
        /// Transforms a <see cref='float'/> value into a <see cref='T'/> value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T generic<T>(float src)
            => As<float,T>(ref src);

        /// <summary>
        /// Transforms a <see cref='double'/> value into a <see cref='T'/> value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T generic<T>(double src)
            => As<double,T>(ref src);

        /// <summary>
        /// Transforms a <see cref='decimal'/> value into a <see cref='T'/> value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T generic<T>(decimal src)
            => As<decimal,T>(ref src);

        [MethodImpl(Inline)]
        public static T generic<T>(string src)
            => As<string,T>(ref src);

        [MethodImpl(Inline)]
        public static T generic<T>(Type src)
            => As<Type,T>(ref src);

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