//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        /// <summary>
        /// Reads a c16-value from an enum of primal u16-kind
        /// </summary>
        /// <param name="eVal">The enum value</param>
        /// <param name="cVal">The character output value</param>
        /// <typeparam name="E">The enum type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref char scalar<S>(in S eVal, out char cVal)
            where S : unmanaged
        {
            cVal = (char)deposit(eVal, out ushort _);
            return ref cVal;
        }

        /// <summary>
        /// Extracts an inclusive seqment form the source span
        /// </summary>
        /// <param name="src">The source text</param>
        /// <param name="i0">The index of the first span cell</param>
        /// <param name="i1">The index of the last last span cell</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> segment<T>(Span<T> src, long i0, long i1)
            => slice(src, i0, i1 - i0 + 1);

        /// <summary>
        /// Extracts an inclusive seqment form the source span
        /// </summary>
        /// <param name="src">The source text</param>
        /// <param name="i0">The index of the first span cell</param>
        /// <param name="i1">The index of the last last span cell</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> segment<T>(Span<T> src, ulong i0, ulong i1)
            => slice(src, i0, i1 - i0 + 1);

        /// <summary>
        /// Extracts an inclusive seqment form the source span
        /// </summary>
        /// <param name="src">The source text</param>
        /// <param name="i0">The index of the first span cell</param>
        /// <param name="i1">The index of the last last span cell</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> segment<T>(ReadOnlySpan<T> src, long i0, long i1)
            => slice(src, i0, i1 - i0 + 1);

        /// <summary>
        /// Extracts an inclusive seqment form the source span
        /// </summary>
        /// <param name="src">The source text</param>
        /// <param name="i0">The index of the first span cell</param>
        /// <param name="i1">The index of the last last span cell</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> segment<T>(ReadOnlySpan<T> src, ulong i0, ulong i1)
            => slice(src, i0, i1 - i0 + 1);

        /// <summary>
        /// Extracts an inclusive seqment form the source span
        /// </summary>
        /// <param name="src">The source text</param>
        /// <param name="i0">The index of the first span cell</param>
        /// <param name="i1">The index of the last last span cell</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<char> segment(ReadOnlySpan<char> src, long i0, long i1)
            => slice(src, i0, i1 - i0 + 1);

        /// <summary>
        /// Extracts an inclusive seqment form the source span
        /// </summary>
        /// <param name="src">The source text</param>
        /// <param name="i0">The index of the first span cell</param>
        /// <param name="i1">The index of the last last span cell</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<char> segment(ReadOnlySpan<char> src, ulong i0, ulong i1)
            => slice(src, i0, i1 - i0 + 1);
    }
}