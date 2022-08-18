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
        public static long int64<T>(T src)
            => As<T,long>(ref src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static long? int64<T>(T? src)
            where T : unmanaged
                => As<T?, long?>(ref src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref long int64<T>(ref T src)
            => ref As<T,long>(ref src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T int64<T>(in long src, out T dst)
        {
            dst = @as<long,T>(src);
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref long int64<T>(in T src, out long dst)
        {
            dst = @as<T,long>(src);
            return ref dst;
        }

        /// <summary>
        /// Projects a sequence of <typeparamref name='T'/> cells onto a sequence of <see cref='long'/> cells
        /// </summary>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<long> int64<T>(Span<T> src)
            where T : struct
                => recover<T,long>(src);

        /// <summary>
        /// Projects a readonly sequence of <typeparamref name='T'/> cells onto a sequence of readonly <see cref='long'/> cells
        /// </summary>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<long> int64<T>(ReadOnlySpan<T> src)
            where T : struct
                => recover<T,long>(src);
    }
}