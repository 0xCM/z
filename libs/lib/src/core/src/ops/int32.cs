//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static System.Runtime.CompilerServices.Unsafe;
    using static Root;

    partial struct core
    {
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static int int32<T>(T src)
            => As<T,int>(ref src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static int? int32<T>(T? src)
            where T : unmanaged
                => As<T?, int?>(ref src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref int int32<T>(ref T src)
            => ref As<T,int>(ref src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T int32<T>(in int src, out T dst)
        {
            dst = @as<int,T>(src);
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref int int32<T>(in T src, out int dst)
        {
            dst = @as<T,int>(src);
            return ref dst;
        }

        /// <summary>
        /// Presents a span of generic values as a span of signed 32-bit integers
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The source value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<int> int32<T>(Span<T> src)
            where T : unmanaged
                => recover<T,int>(src);

        /// <summary>
        /// Presents a readonly span of generic values as a readonly span of signed 32-bit integers
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The source value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<int> int32<T>(ReadOnlySpan<T> src)
            where T : unmanaged
                => recover<T,int>(src);
    }
}