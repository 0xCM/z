//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;
    using static System.Runtime.InteropServices.MemoryMarshal;

    partial struct core
    {
        [MethodImpl(Inline), Keyword, Closures(Closure)]
        public static unsafe ref T to<T>(void* pSrc)
            => ref AsRef<T>(pSrc);

        /// <summary>
        /// Presents an S-cell as a T-cell
        /// </summary>
        /// <param name="src">The source cell</param>
        /// <typeparam name="S">The source type</typeparam>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline)]
        public static ref T to<S,T>(in S src)
            => ref As<S,T>(ref edit(src));

        /// <summary>
        /// Presents a <see cref='sbyte'/> as a <typeparamref name='T'/> cell
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The output value type</typeparam>
        [MethodImpl(Inline), Keyword, Closures(AllNumeric)]
        public static ref T to<T>(in sbyte src)
            => ref As<sbyte,T>(ref AsRef(src));

        /// <summary>
        /// Presents a <see cref='byte'/> as a <typeparamref name='T'/> cell
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The output value type</typeparam>
        [MethodImpl(Inline), Keyword, Closures(AllNumeric)]
        public static ref T to<T>(in byte src)
            => ref As<byte,T>(ref AsRef(src));

        /// <summary>
        /// Presents a <see cref='short'/> as a <typeparamref name='T'/> cell
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The output value type</typeparam>
        [MethodImpl(Inline), Keyword, Closures(AllNumeric)]
        public static ref T to<T>(in short src)
            => ref As<short,T>(ref AsRef(src));

        /// <summary>
        /// Presents a <see cref='ushort'/> as a <typeparamref name='T'/> cell
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The output value type</typeparam>
        [MethodImpl(Inline), Keyword, Closures(AllNumeric)]
        public static ref T to<T>(in ushort src)
            => ref As<ushort,T>(ref AsRef(src));

        /// <summary>
        /// Presents a <see cref='int'/> as a <typeparamref name='T'/> cell
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The output value type</typeparam>
        [MethodImpl(Inline), Keyword, Closures(AllNumeric)]
        public static ref T to<T>(in int src)
            => ref As<int,T>(ref AsRef(src));

        /// <summary>
        /// Presents a <see cref='uint'/> as a <typeparamref name='T'/> cell
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The output value type</typeparam>
        [MethodImpl(Inline), Keyword, Closures(AllNumeric)]
        public static ref T to<T>(in uint src)
            => ref As<uint,T>(ref AsRef(src));

        /// <summary>
        /// Presents a <see cref='long'/> as a <typeparamref name='T'/> cell
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The output value type</typeparam>
        [MethodImpl(Inline), Keyword, Closures(AllNumeric)]
        public static ref T to<T>(in long src)
            => ref As<long,T>(ref AsRef(src));

        /// <summary>
        /// Presents a <see cref='ulong'/> as a <typeparamref name='T'/> cell
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The output value type</typeparam>
        [MethodImpl(Inline), Keyword, Closures(AllNumeric)]
        public static ref T to<T>(in ulong src)
            => ref As<ulong,T>(ref AsRef(src));

        /// <summary>
        /// Presents a <see cref='float'/> as a <typeparamref name='T'/> cell
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The output value type</typeparam>
        [MethodImpl(Inline), Keyword, Closures(AllNumeric)]
        public static ref T to<T>(in float src)
            => ref As<float,T>(ref AsRef(src));

        /// <summary>
        /// Presents a <see cref='double'/> as a <typeparamref name='T'/> cell
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The output value type</typeparam>
        [MethodImpl(Inline), Keyword, Closures(AllNumeric)]
        public static ref T to<T>(in double src)
            => ref As<double,T>(ref AsRef(src));

        /// <summary>
        /// Presents a <see cref='decimal'/> as a <typeparamref name='T'/> cell
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The output value type</typeparam>
        [MethodImpl(Inline), Keyword, Closures(AllNumeric)]
        public static ref T to<T>(in decimal src)
            => ref As<decimal,T>(ref AsRef(src));

        /// <summary>
        /// Presents a <see cref='char'/> as a <typeparamref name='T'/> cell
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The output value type</typeparam>
        [MethodImpl(Inline), Keyword, Closures(AllNumeric)]
        public static ref T to<T>(in char src)
            => ref As<char,T>(ref AsRef(src));

        /// <summary>
        /// Presents a <see cref='bool'/> as a <typeparamref name='T'/> cell
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The output value type</typeparam>
        [MethodImpl(Inline), Keyword, Closures(AllNumeric)]
        public static ref T to<T>(in bool src)
            => ref As<bool,T>(ref AsRef(src));

        [MethodImpl(Inline), Keyword, Closures(AllNumeric)]
        public static ref T to<T>(in string src)
            => ref As<string,T>(ref AsRef(src));

        /// <summary>
        /// Reinterprets a vector over S-cells as a vector over T-cells
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="t">A target cell type representative</param>
        /// <typeparam name="S">The source cell type</typeparam>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline)]
        public static ref Vector128<T> to<S,T>(in Vector128<S> x, T t = default)
            where S : unmanaged
            where T : unmanaged
                => ref to<Vector128<S>,Vector128<T>>(x);

        /// <summary>
        /// Reinterprets a vector over S-cells as a vector over T-cells
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="t">A target cell type representative</param>
        /// <typeparam name="S">The source cell type</typeparam>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline)]
        public static ref Vector256<T> to<S,T>(in Vector256<S> x, T t = default)
            where S : unmanaged
            where T : unmanaged
                => ref to<Vector256<S>,Vector256<T>>(x);
    }
}