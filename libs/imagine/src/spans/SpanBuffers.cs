//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost, Free]
    public class SpanBuffers
    {
        const NumericKind Closure = UnsignedInts;

        public static SpanBuffer<T> cover<T>(Span<T> src)
            => new SpanBuffer<T>(src);

        public static SpanBuffer<T> create<T>(uint count)
            => new SpanBuffer<T>(new T[count]);

        /// <summary>
        /// Creates a T-parametric sink predicated on a <see cref='Receiver{T}'/> process function
        /// </summary>
        /// <param name="wf">The workflow context</param>
        /// <param name="f">The process function</param>
        /// <typeparam name="T">The data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanSink<T> sink<T>(Receiver<T> f)
            => new SpanSink<T>(f);

        /// <summary>
        /// Allocates a span-predicated S/T ring buffer
        /// </summary>
        /// <param name="capacity">The segment count</param>
        /// <typeparam name="S">The segmented type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        public static PartRing<S,T> parts<S,T>(int capacity)
            where S : unmanaged
            where T : unmanaged
                => new PartRing<S,T>(new S[capacity]);

        /// <summary>
        /// Covers an S-span with an S/T ring buffer
        /// </summary>
        /// <param name="src">The data source</param>
        /// <typeparam name="S">The segmented type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static PartRing<S,T> parts<S,T>(S[] src)
            where S : unmanaged
            where T : unmanaged
                => new PartRing<S,T>(src);

        /// <summary>
        /// Allocates a span-predicated T-ring buffer
        /// </summary>
        /// <param name="capacity">The T-cell count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [Op, Closures(Closure)]
        public static RingBuffer<T> ring<T>(int capacity)
            where T : unmanaged
                => new RingBuffer<T>(new T[capacity]);

        /// <summary>
        /// Covers a span with a ring buffer
        /// </summary>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static RingBuffer<T> ring<T>(Span<T> src)
            where T : unmanaged
                => new RingBuffer<T>(src);

        /// <summary>
        /// Allocates a span-predicated T-stack
        /// </summary>
        /// <param name="capacity">The T-cell count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [Op, Closures(Closure)]
        public static SpanStack<T> stack<T>(uint capacity)
            where T : unmanaged
                => new SpanStack<T>(new T[capacity]);

        /// <summary>
        /// Covers a span with a stack buffer
        /// </summary>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanStack<T> stack<T>(T[] src)
            where T : unmanaged
                => new SpanStack<T>(src);
    }
}