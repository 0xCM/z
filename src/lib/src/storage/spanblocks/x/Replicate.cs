//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XSb
    {
        /// <summary>
        /// Shuffles bitstring content as determined by a permutation
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="p">The permutation to apply</param>
        public static BitString Permute(this BitString src, Perm p)
        {
            var dst = BitStrings.alloc(p.Length);
            for(var i = 0; i<p.Length; i++)
                dst[i] = src[p[i]];
            return dst;
        }

        /// <summary>
        /// Extracts a 128-bit cpu vector from a bitsring of sufficient length
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="w">The bit width selector</param>
        /// <param name="t">The component type representative</param>
        /// <typeparam name="T">The target vector component type</typeparam>
        [MethodImpl(Inline)]
        public static Vector128<T> ToCpuVector<T>(this BitString src, N128 w, T t = default)
            where T : unmanaged
                => src.Pack().Recover<byte,T>().Blocked(w).LoadVector();

        /// <summary>
        /// Extracts a 256-bit cpu vector from a bitsring of sufficient length
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="w">The bit width selector</param>
        /// <param name="t">The component type representative</param>
        /// <typeparam name="T">The target vector component type</typeparam>
        [MethodImpl(Inline)]
        public static Vector256<T> ToCpuVector<T>(this BitString src, N256 w, T t = default)
            where T : unmanaged
                => src.Pack().Recover<byte,T>().Blocked(w).LoadVector();


        /// <summary>
        /// Converts blocked content to a bitstring
        /// </summary>
        /// <param name="src">The source bits</param>
        [MethodImpl(Inline)]
        public static BitString ToBitString<T>(this SpanBlock64<T> src, int? maxbits = null)
            where T : unmanaged
                => BitStrings.scalars(src.Storage, maxbits ?? w64);

        /// <summary>
        /// Converts blocked content to a bitstring
        /// </summary>
        /// <param name="src">The source bits</param>
        [MethodImpl(Inline)]
        public static BitString ToBitString<T>(this SpanBlock128<T> src, int? maxbits = null)
            where T : unmanaged
                => BitStrings.scalars(src.Storage, maxbits ?? w128);

        /// <summary>
        /// Converts datablock content to a bitstring
        /// </summary>
        /// <param name="src">The source bits</param>
        [MethodImpl(Inline)]
        public static BitString ToBitString<T>(this SpanBlock256<T> src, int? maxbits = null)
            where T : unmanaged
                => BitStrings.scalars(src.Storage, maxbits ?? w256);

        /// <summary>
        /// Clones a 32-bit blocked container
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The element type</typeparam>
        public static SpanBlock8<T> Replicate<T>(this SpanBlock8<T> src)
            where T : unmanaged
                => src.Replicate(span<T>(src.CellCount));

        /// <summary>
        /// Clones a 32-bit blocked container
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock8<T> Replicate<T>(this SpanBlock8<T> src, Span<T> buffer)
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
        public static SpanBlock16<T> Replicate<T>(this SpanBlock16<T> src, Span<T> buffer)
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
        public static SpanBlock32<T> Replicate<T>(this SpanBlock32<T> src, Span<T> buffer)
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
        public static SpanBlock64<T> Replicate<T>(this SpanBlock64<T> src, Span<T> buffer)
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
        public static SpanBlock128<T> Replicate<T>(this SpanBlock128<T> src, Span<T> buffer)
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
        public static SpanBlock256<T> Replicate<T>(this SpanBlock256<T> src)
            where T : unmanaged
                => src.Replicate(span<T>(src.CellCount));

        /// <summary>
        /// Clones a 256-bit data block
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock256<T> Replicate<T>(this SpanBlock256<T> src, Span<T> buffer)
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
        public static SpanBlock512<T> Replicate<T>(this SpanBlock512<T> src, Span<T> buffer)
            where T : unmanaged
        {
            src.CopyTo(buffer);
            return new SpanBlock512<T>(buffer);
        }
    }
}