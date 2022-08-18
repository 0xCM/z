//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;
    using static Arrays;

    [ApiHost,Free]
    public class MemorySegs
    {
        const NumericKind Closure = UnsignedInts;

        /// <summary>
        /// Covers a memory reference with a readonly span
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static ReadOnlySpan<T> view<T>(MemorySeg src)
            => cover(src.BaseAddress.Ref<T>(), count<T>(src));

        /// <summary>
        /// Computes the whole number of T-cells identified by a reference
        /// </summary>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint count<T>(MemorySeg src)
            => (uint)(src.Length/size<T>());

        /// <summary>
        /// Computes the whole number of <typeparamref name='T'/> cells covered by a specified <see cref='MemoryRange'/>
        /// </summary>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint cells<T>(MemoryRange src)
            => (uint)(src.ByteCount/size<T>());

        /// <summary>
        /// Covers a <see cref='MemoryRange'/> with a readonly span
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> view<T>(MemoryRange src)
            => Algs.cover(src.Min.Ref<T>(), cells<T>(src));

        [MethodImpl(Inline), Op]
        public static void store(ReadOnlySpan<byte> src, ByteSize size, MemoryAddress dst)
            => src.CopyTo(edit(dst, size));

        /// <summary>
        /// Defines a memory <see cref='MemorySeg'/> with a specified base and size
        /// </summary>
        /// <param name="base">The base address</param>
        /// <param name="bytes">The number of reference bytes</param>
        [MethodImpl(Inline), Op]
        public static MemorySeg define(MemoryAddress @base, ByteSize bytes)
            => new MemorySeg(@base, bytes);

        /// <summary>
        /// Defines a memory <see cref='MemorySeg'/> over source span content
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public unsafe static MemorySeg define(ReadOnlySpan<byte> src)
            => define((ulong)gptr(src), src.Length);

        [MethodImpl(Inline), Op]
        public static unsafe MemorySeg define(string src)
            => define(pchar(src), (uint)src.Length);

        [MethodImpl(Inline), Op]
        public static unsafe MemorySeg define(char* src, uint count)
            => new MemorySeg(address(src), count*2);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SegRef<byte> segref(in byte src, ByteSize size)
            => new SegRef<byte>(new SegRef(address(src), size));

        [MethodImpl(Inline), Op]
        public static ulong sib(MemorySeg n, int i, byte scale, ushort offset)
            => ((ulong)scale)*skip(n.Load(),i) + (ulong)offset;

        [MethodImpl(Inline), Op]
        public static ulong sib(ReadOnlySpan<MemorySeg> refs, in MemorySlot n, int i, byte scale, ushort offset)
            => sib(segment(refs,n), i, scale,offset);

        /// <summary>
        /// Covers a <see cref='MemoryRange'/> with a <see cref='Span{T}'
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> edit<T>(MemoryRange src)
            => Algs.cover(src.Min.Ref<T>(), cells<T>(src));

        /// <summary>
        /// Covers a memory segment with a span
        /// </summary>
        /// <param name="src">The base address</param>
        /// <param name="size">The segment size, in bytes</param>
        [MethodImpl(Inline), Op]
        public static unsafe Span<byte> edit(MemoryAddress src, ByteSize size)
            => Algs.cover<byte>(src.Ref<byte>(), size);

        [MethodImpl(Inline), Op]
        public static ref readonly MemorySeg segment(ReadOnlySpan<MemorySeg> refs, MemorySlot n)
            => ref skip(refs, n);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> load<T>(MemorySeg src)
            where T : unmanaged
                => src.Load<T>();

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<byte> load(ReadOnlySpan<MemorySeg> src, MemorySlot n)
            => segment(src,n).Load();

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<byte> slice(ReadOnlySpan<MemorySeg> refs, MemorySlot n, int offset)
            => Spans.slice(load(refs, n),offset);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<byte> slice(ReadOnlySpan<MemorySeg> refs, MemorySlot n, int offset, int length)
            => Spans.slice(load(refs,n), offset, length);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly T cell<T>(ReadOnlySpan<MemorySeg> src, MemorySlot n, long offset)
            where T : unmanaged
                => ref skip<T>(load<T>(segment(src,n)), offset);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly T cell<T>(ReadOnlySpan<MemorySeg> src, MemorySlot n, ulong offset)
            where T : unmanaged
                => ref skip<T>(load<T>(segment(src,n)), offset);

        [MethodImpl(Inline), Op]
        public static ref readonly byte cell(ReadOnlySpan<MemorySeg> src, MemorySlot n, long i)
            => ref skip(segment(src,n).Load(), (uint)i);

        [MethodImpl(Inline), Op]
        public static ref readonly byte cell(ReadOnlySpan<MemorySeg> src, MemorySlot n, ulong i)
            => ref skip(segment(src,n).Load(), (uint)i);
    }
}