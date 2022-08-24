//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;
    using static System.Runtime.InteropServices.MemoryMarshal;

    [Free,ApiHost]
    public static class Refs
    {
        const NumericKind Closure = Root.UnsignedInts;

        const NumericKind Options = Root.UnsignedInts;

        /// <summary>
        /// Presents a generic value as a bytespan
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The source value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<byte> bytes<T>(in T src)
            where T : struct
                => sys.cover(sys.@as<T,byte>(src), sys.size<T>());

        [MethodImpl(Inline)]
        public static uint size<T>()
            => (uint)sys.size<T>();

        /// <summary>
        /// Presents an S-cell as a T-cell
        /// </summary>
        /// <param name="src">The source cell</param>
        /// <typeparam name="S">The source type</typeparam>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline)]
        public static ref T @as<S,T>(in S src)
            => ref As<S,T>(ref sys.edit(src));

        /// <summary>
        /// Presents an S-cell as a <typeparamref name='T'/>-cell reference
        /// </summary>
        /// <param name="src">The source cell</param>
        /// <param name="src">The target cell</param>
        /// <typeparam name="S">The source type</typeparam>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline)]
        public static ref T @as<S,T>(in S src, ref T dst)
            => ref As<S,T>(ref sys.edit(src));

        /// <summary>
        /// Presents a <see cref='sbyte'/> as a <typeparamref name='T'/>-cell reference
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The output value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref T @as<T>(in sbyte src)
            => ref As<sbyte,T>(ref AsRef(src));

        /// <summary>
        /// Presents a <see cref='byte'/> as a <typeparamref name='T'/>-cell reference
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The output value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref T @as<T>(in byte src)
            => ref As<byte,T>(ref AsRef(src));

        /// <summary>
        /// Presents a <see cref='short'/> as a <typeparamref name='T'/>-cell reference
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The output value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref T @as<T>(in short src)
            => ref As<short,T>(ref AsRef(src));

        /// <summary>
        /// Presents a <see cref='ushort'/> as a <typeparamref name='T'/> cell
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The output value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref T @as<T>(in ushort src)
            => ref As<ushort,T>(ref AsRef(src));

        /// <summary>
        /// Presents a <see cref='int'/> as a <typeparamref name='T'/> cell
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The output value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref T @as<T>(in int src)
            => ref As<int,T>(ref AsRef(src));

        /// <summary>
        /// Presents a <see cref='uint'/> as a <typeparamref name='T'/> cell
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The output value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref T @as<T>(in uint src)
            => ref As<uint,T>(ref AsRef(src));

        /// <summary>
        /// Presents a <see cref='long'/> as a <typeparamref name='T'/> cell
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The output value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref T @as<T>(in long src)
            => ref As<long,T>(ref AsRef(src));

        /// <summary>
        /// Presents a <see cref='ulong'/> as a <typeparamref name='T'/> cell
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The output value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref T @as<T>(in ulong src)
            => ref As<ulong,T>(ref AsRef(src));

        /// <summary>
        /// Presents a <see cref='float'/> as a <typeparamref name='T'/> cell
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The output value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref T @as<T>(in float src)
            => ref As<float,T>(ref AsRef(src));

        /// <summary>
        /// Presents a <see cref='double'/> as a <typeparamref name='T'/> cell
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The output value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref T @as<T>(in double src)
            => ref As<double,T>(ref AsRef(src));

        /// <summary>
        /// Presents a <see cref='decimal'/> as a <typeparamref name='T'/> cell
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The output value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref T @as<T>(in decimal src)
            => ref As<decimal,T>(ref AsRef(src));

        /// <summary>
        /// Presents a <see cref='char'/> as a <typeparamref name='T'/> cell
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The output value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref T @as<T>(in char src)
            => ref As<char,T>(ref AsRef(src));

        /// <summary>
        /// Presents a <see cref='bool'/> as a <typeparamref name='T'/>-cell reference
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The output value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref T @as<T>(in bool src)
            => ref As<bool,T>(ref AsRef(src));

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref T @as<T>(in string src)
            => ref As<string,T>(ref AsRef(src));

        /// <summary>
        /// Presents the source as a <typeparamref name='T'/>-cell reference
        /// </summary>
        /// <param name="pSrc">A pointer to the source</param>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline), Keyword, Closures(Closure)]
        public static unsafe ref T @as<T>(void* pSrc)
            => ref AsRef<T>(pSrc);

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
        /// Transforms a readonly T-cell into an editable T-cell
        /// </summary>
        /// <param name="src">The source cell</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T edit<T>(in T src)
            => ref AsRef(src);

        /// <summary>
        /// Transforms a readonly S-cell into an editable T-cell
        /// </summary>
        /// <param name="src">The source cell</param>
        /// <typeparam name="S">The source type</typeparam>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline)]
        public static ref T edit<S,T>(in S src)
            => ref As<S,T>(ref AsRef(src));

        /// <summary>
        /// Transforms a readonly S-cell into an editable T-cell
        /// </summary>
        /// <param name="src">The source cell</param>
        /// <param name="dst">The target cell</param>
        /// <typeparam name="S">The source type</typeparam>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline)]
        public static ref T edit<S,T>(in S src, ref T dst)
            => ref As<S,T>(ref AsRef(src));

        /// <summary>
        /// Returns a reference to the head of a readonly span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T edit<T>(ReadOnlySpan<T> src)
            => ref GetReference<T>(src);            
    }
}