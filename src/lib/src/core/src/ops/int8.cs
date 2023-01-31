//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;

    partial struct core
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static sbyte int8<T>(T src)
            => As<T,sbyte>(ref src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static sbyte? int8<T>(T? src)
            where T : unmanaged
                => As<T?,sbyte?>(ref src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref sbyte int8<T>(ref T src)
            => ref As<T,sbyte>(ref src);

        /// <summary>
        /// Projects a sequence of <typeparamref name='T'/> cells onto a sequence of <see cref='sbyte'/> cells
        /// </summary>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<sbyte> int8<T>(Span<T> src)
            where T : struct
                => recover<T,sbyte>(src);

        /// <summary>
        /// Projects a readonly sequence of <typeparamref name='T'/> cells onto a sequence of readonly <see cref='sbyte'/> cells
        /// </summary>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<sbyte> int8<T>(ReadOnlySpan<T> src)
            where T : struct
                => recover<T,sbyte>(src);
    }
}