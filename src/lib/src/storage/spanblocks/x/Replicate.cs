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

    partial class XSb
    {
        /// <summary>
        /// Clones a 32-bit blocked container
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The element type</typeparam>
        public static SpanBlock8<T> Replicate<T>(this in SpanBlock8<T> src)
            where T : unmanaged
                => src.Replicate(span<T>(src.CellCount));

        /// <summary>
        /// Clones a 32-bit blocked container
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock8<T> Replicate<T>(this in SpanBlock8<T> src, Span<T> buffer)
            where T : unmanaged
        {
            src.CopyTo(buffer);
            return new SpanBlock8<T>(buffer);
        }

        /// <summary>
        /// Clones a 32-bit blocked container
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock16<T> Replicate<T>(this in SpanBlock16<T> src, Span<T> buffer)
            where T : unmanaged
        {
            src.CopyTo(buffer);
            return new SpanBlock16<T>(buffer);
        }

        /// <summary>
        /// Clones a 32-bit blocked container
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock32<T> Replicate<T>(this in SpanBlock32<T> src, Span<T> buffer)
            where T : unmanaged
        {
            src.CopyTo(buffer);
            return new SpanBlock32<T>(buffer);
        }

        /// <summary>
        /// Clones a blocked span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock64<T> Replicate<T>(this in SpanBlock64<T> src, Span<T> buffer)
            where T : unmanaged
        {
            src.CopyTo(buffer);
            return new SpanBlock64<T>(buffer);
        }

        /// <summary>
        /// Clones a blocked span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock128<T> Replicate<T>(this in SpanBlock128<T> src, Span<T> buffer)
            where T : unmanaged
        {
            src.CopyTo(buffer);
            return new SpanBlock128<T>(buffer);
        }

        /// <summary>
        /// Clones a 256-bit data block
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The element type</typeparam>
        public static SpanBlock256<T> Replicate<T>(this in SpanBlock256<T> src)
            where T : unmanaged
                => src.Replicate(span<T>(src.CellCount));

        /// <summary>
        /// Clones a 256-bit data block
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock256<T> Replicate<T>(this in SpanBlock256<T> src, Span<T> buffer)
            where T : unmanaged
        {
            src.CopyTo(buffer);
            return new SpanBlock256<T>(buffer);
        }

        /// <summary>
        /// Clones a 512-bit data block
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock512<T> Replicate<T>(this in SpanBlock512<T> src, Span<T> buffer)
            where T : unmanaged
        {
            src.CopyTo(buffer);
            return new SpanBlock512<T>(buffer);
        }
    }
}