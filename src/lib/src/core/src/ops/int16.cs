//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;

    partial struct core
    {
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static short int16<T>(T src)
            => As<T,short>(ref src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static short? int16<T>(T? src)
            where T : unmanaged
                => As<T?, short?>(ref src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref short int16<T>(ref T src)
            => ref As<T,short>(ref src);

        // [MethodImpl(Inline), Op, Closures(Closure)]
        // public static ref T int16<T>(in short src, out T dst)
        // {
        //     dst = @as<short,T>(src);
        //     return ref dst;
        // }

        // [MethodImpl(Inline), Op, Closures(Closure)]
        // public static ref short int16<T>(in T src, out short dst)
        // {
        //     dst = @as<T,short>(src);
        //     return ref dst;
        // }

        /// <summary>
        /// Projects a sequence of <typeparamref name='T'/> cells onto a sequence of <see cref='short'/> cells
        /// </summary>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<short> int16<T>(Span<T> src)
            where T : struct
                => recover<T,short>(src);

        /// <summary>
        /// Projects a readonly sequence of <typeparamref name='T'/> cells onto a sequence of readonly <see cref='short'/> cells
        /// </summary>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<short> int16<T>(ReadOnlySpan<T> src)
            where T : struct
                => recover<T,short>(src);
    }
}