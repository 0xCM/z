//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial class XTend
    {
        /// <summary>
        /// Extracts grid content to a span
        /// </summary>
        /// <param name="src">The source grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static Span<T> ToSpan<T>(this BitGrid16<T> src)
            where T : unmanaged
                => bytes(src.Data).Recover<T>();

        /// <summary>
        /// Extracts grid content to a span
        /// </summary>
        /// <param name="src">The source grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static Span<T> ToSpan<T>(this BitGrid32<T> src)
            where T : unmanaged
                => bytes(src.Data).Recover<T>();

        /// <summary>
        /// Extracts grid content to a span
        /// </summary>
        /// <param name="src">The source grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static Span<T> ToSpan<T>(this BitGrid64<T> src)
            where T : unmanaged
                => bytes(src.Data).Recover<T>();

        /// <summary>
        /// Extracts grid content to a span
        /// </summary>
        /// <param name="src">The source grid</param>
        /// <typeparam name="M">The row type</typeparam>
        /// <typeparam name="N">The col type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static Span<T> ToSpan<M,N,T>(this BitGrid32<M,N,T> src)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => bytes(src.Data).Recover<T>();

        /// <summary>
        /// Extracts grid content to a span
        /// </summary>
        /// <param name="src">The source grid</param>
        /// <typeparam name="M">The row type</typeparam>
        /// <typeparam name="N">The col type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static Span<T> ToSpan<M,N,T>(this BitGrid64<M,N,T> src)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => bytes(src.Data).Recover<T>();

        /// <summary>
        /// Extracts grid content to a span
        /// </summary>
        /// <param name="src">The source grid</param>
        /// <typeparam name="M">The row type</typeparam>
        /// <typeparam name="N">The col type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static Span<T> ToSpan<M,N,T>(this BitGrid128<M,N,T> src)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => src.Content.ToSpan();

        /// <summary>
        /// Extracts grid content to a span
        /// </summary>
        /// <param name="src">The source grid</param>
        /// <typeparam name="M">The row type</typeparam>
        /// <typeparam name="N">The col type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static Span<T> ToSpan<M,N,T>(this BitGrid256<M,N,T> src)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => src.Content.ToSpan();

        /// <summary>
        /// Extracts grid content to a span
        /// </summary>
        /// <param name="src">The source grid</param>
        /// <typeparam name="M">The row type</typeparam>
        /// <typeparam name="N">The col type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static Span<T> ToSpan<M,N,T>(this SubGrid16<M,N,T> src)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => bytes(src.Data).Recover<T>();

        /// <summary>
        /// Extracts grid content to a span
        /// </summary>
        /// <param name="src">The source grid</param>
        /// <typeparam name="M">The row type</typeparam>
        /// <typeparam name="N">The col type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static Span<T> ToSpan<M,N,T>(this SubGrid32<M,N,T> src)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => bytes(src.Data).Recover<T>();

        /// <summary>
        /// Extracts grid content to a span
        /// </summary>
        /// <param name="src">The source grid</param>
        /// <typeparam name="M">The row type</typeparam>
        /// <typeparam name="N">The col type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static Span<T> ToSpan<M,N,T>(this SubGrid64<M,N,T> src)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => bytes(src.Data).Recover<T>();

        /// <summary>
        /// Extracts grid content to a span
        /// </summary>
        /// <param name="src">The source grid</param>
        /// <typeparam name="M">The row type</typeparam>
        /// <typeparam name="N">The col type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static Span<T> ToSpan<M,N,T>(this SubGrid128<M,N,T> src)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => src.Data.ToSpan();

        /// <summary>
        /// Extracts grid content to a span
        /// </summary>
        /// <param name="src">The source grid</param>
        /// <typeparam name="M">The row type</typeparam>
        /// <typeparam name="N">The col type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static Span<T> ToSpan<M,N,T>(this SubGrid256<M,N,T> src)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => src.Data.ToSpan();
    }
}