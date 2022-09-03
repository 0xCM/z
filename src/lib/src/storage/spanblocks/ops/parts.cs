//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static CellCalcs;

    partial struct SpanBlocks
    {
        /// <summary>
        /// Creates a sequence of 8-bit blocks from a parameter array and raises an error if the data source is not block-aligned
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="src">The source data</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Load, Closures(UInt16k)]
        public static SpanBlock16<T> parts<T>(W8 w, params T[] src)
            where T : unmanaged
        {
            if(!aligned<T>(w,src.Length))
                Errors.ThrowBadSize(w, src.Length);

            return new SpanBlock16<T>(src);
        }

        /// <summary>
        /// Creates 16-bit blocked container from a parameter array and raises an error if the data source is not block-aligned
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="src">The source data</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Load, Closures(UInt16k)]
        public static SpanBlock16<T> parts<T>(W16 w, params T[] src)
            where T : unmanaged
        {
            if(!aligned<T>(w,src.Length))
                Errors.ThrowBadSize(w, src.Length);

            return new SpanBlock16<T>(src);
        }

        /// <summary>
        /// Creates 32-bit blocked span from a parameter array and raises an error if the data source is not block-aligned
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="src">The source data</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Load, Closures(UInt32k)]
        public static SpanBlock32<T> parts<T>(W32 w, params T[] src)
            where T : unmanaged
        {
            if(!aligned<T>(w,src.Length))
                Errors.ThrowBadSize(w, src.Length);

            return new SpanBlock32<T>(src);
        }

        /// <summary>
        /// Creates 64-bit blocked span from a parameter array and raises an error if the data source is not block-aligned
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="src">The source data</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Load, Closures(UInt32k)]
        public static SpanBlock64<T> parts<T>(W64 w, params T[] src)
            where T : unmanaged
        {
            if(!aligned<T>(w,src.Length))
                Errors.ThrowBadSize(w, src.Length);

            return new SpanBlock64<T>(src);
        }

        /// <summary>
        /// Creates 128-bit blocked span from a parameter array and raises an error if the data source is improperly blocked
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="src">The source data</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Load, Closures(UInt32k)]
        public static SpanBlock128<T> parts<T>(W128 w, params T[] src)
            where T : unmanaged
        {
            if(!aligned<T>(w,src.Length))
                Errors.ThrowBadSize(w, src.Length);

            return new SpanBlock128<T>(src);
        }

        /// <summary>
        /// Creates 256-bit blocked span from a parameter array and raises an error if the data source is improperly blocked
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="src">The source data</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Load, Closures(UInt32k)]
        public static SpanBlock256<T> parts<T>(W256 w, params T[] src)
            where T : unmanaged
        {
            if(!aligned<T>(w,src.Length))
                Errors.ThrowBadSize(w, src.Length);

            return new SpanBlock256<T>(src);
        }

        /// <summary>
        /// Creates 512-bit blocked span from a parameter array and raises an error if the data source is improperly blocked
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="src">The source data</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Load, Closures(UInt32k)]
        public static SpanBlock512<T> parts<T>(W512 w, params T[] src)
            where T : unmanaged
        {
            if(!aligned<T>(w,src.Length))
                Errors.ThrowBadSize(w, src.Length);

            return new SpanBlock512<T>(src);
        }
    }
}