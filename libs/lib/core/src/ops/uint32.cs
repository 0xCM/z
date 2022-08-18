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
        /// <summary>
        /// Presents a parametric source to a <see cref='uint'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint uint32<T>(T src)
            => As<T,uint>(ref src);

        /// <summary>
        /// Presents a parametric source reference to a <see cref='uint'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref uint uint32<T>(ref T src)
            => ref As<T,uint>(ref src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T uint32<T>(in uint src, out T dst)
        {
            dst = @as<uint,T>(src);
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref uint uint32<T>(in T src, out uint dst)
        {
            dst = @as<T,uint>(src);
            return ref dst;
        }

        /// <summary>
        /// Presents a nullable parametric source to a nullable <see cref='uint'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint? uint32<T>(T? src)
            where T : unmanaged
                => As<T?, uint?>(ref src);

        /// <summary>
        /// Presents a span of generic values as a span of unsigned 32-bit integers
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The source value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<uint> uint32<T>(Span<T> src)
            where T : struct
                => recover<T,uint>(src);

        /// <summary>
        /// Presents a readonly span of generic values as a readonly span of unsigned 32-bit integers
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The source value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<uint> uint32<T>(ReadOnlySpan<T> src)
            where T : struct
                => recover<T,uint>(src);
    }
}