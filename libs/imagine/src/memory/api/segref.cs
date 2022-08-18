//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Sized;
    using static Spans;
    using static Arrays;

    partial struct memory
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SegRef<byte> segref(in byte src, ByteSize size)
            => new SegRef<byte>(new SegRef(address(src), size));

        [MethodImpl(Inline), Op]
        public static ulong sib(MemorySeg n, int i, byte scale, ushort offset)
            => ((ulong)scale)*skip(n.Load(),i) + (ulong)offset;

        [MethodImpl(Inline), Op]
        public static ref readonly MemorySeg segment(ReadOnlySpan<MemorySeg> refs, MemorySlot n)
            => ref skip(refs, n);

        [MethodImpl(Inline), Op]
        public static ulong sib(ReadOnlySpan<MemorySeg> refs, in MemorySlot n, int i, byte scale, ushort offset)
            => sib(segment(refs,n), i, scale,offset);

        /// <summary>
        /// Captures a parametric reference to cell content beginning at a specified address
        /// </summary>
        /// <param name="src">The content address</param>
        /// <param name="count">The content cell count</param>
        /// <typeparam name="T">The content type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SegRef<T> segref<T>(MemoryAddress address, Count count)
            where T : unmanaged
                => new SegRef<T>(address, size<T>(count));

        /// <summary>
        /// Captures a sized readonly parametric reference to source span content
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe SegRef<T> segref<T>(ReadOnlySpan<T> src)
            => new SegRef<T>(address(first(src)), size<T>((uint)src.Length));

        /// <summary>
        /// Captures a character segment over source string content
        /// </summary>
        /// <param name="src">The source string</param>
        [MethodImpl(Inline), Op]
        public static unsafe SegRef<char> segref(string src)
            => new SegRef<char>(new SegRef(address(src), (uint)src.Length*2));

        /// <summary>
        /// Captures a segment reference
        /// </summary>
        /// <param name="src">The leading cell</param>
        /// <param name="count">The covered cell count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SegRef<T> segref<T>(in T src, uint count)
            => new SegRef(address(src), count*Sized.size<T>());

        /// <summary>
        /// Captures a segment reference
        /// </summary>
        /// <param name="src">The leading cell</param>
        /// <param name="count">The covered cell count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SegRef<T> segref<T>(in T src, int count)
            => new SegRef<T>(address(src), size<T>((uint)count));

        /// <summary>
        /// Captures an untyped sized reference
        /// </summary>
        /// <param name="pSrc">The source pointer</param>
        /// <param name="size">The data size</param>
        [MethodImpl(Inline), Op]
        public static unsafe SegRef segref(void* pSrc, ByteSize size)
            => new SegRef(address(pSrc), size);

        /// <summary>
        /// Captures a pointer-identified segment reference of a specified size
        /// </summary>
        /// <param name="pSrc">A base address pointer</param>
        /// <param name="size">The segment size, in bytes</param>
        /// <typeparam name="T">The sement type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe SegRef<byte> segref(byte* pSrc, ByteSize size)
            => new SegRef<byte>(pSrc, size);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe SegRef<T> segref<T>(T[] src)
            => segref<T>(first(src), (uint)src.Length);

        [MethodImpl(Inline), Op]
        public static unsafe SegRef<sbyte> segref(sbyte[] src)
            => segref<sbyte>(address(src), (uint)src.Length);

        [MethodImpl(Inline), Op]
        public static unsafe SegRef<byte> segref(byte[] src)
            => segref<byte>(address(src), (uint)src.Length);

        [MethodImpl(Inline), Op]
        public static unsafe SegRef<ulong> segref(ulong[] src)
            => segref<ulong>(address(src), (uint)src.Length);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe SegRef<T> segref<T>(Span<T> src)
            => new SegRef<T>(Pointers.pvoid(sys.first(src)), size<T>((uint)src.Length));

        [MethodImpl(Inline), Op]
        public static SegRef<T>[] segrefs<T>(ReadOnlySpan<T> src)
            where T : struct
        {
            var dst = sys.alloc<SegRef<T>>(src.Length);
            segrefs(src, dst);
            return dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void segrefs<T>(ReadOnlySpan<T> src, Span<SegRef<T>> dst)
            where T : struct
        {
            for(var i=0u; i<src.Length; i++)
                seek(dst,i) = segref(skip<T>(src,i), sys.size<T>());
        }

        [Op]
        public static void materialize(ReadOnlySpan<SegRef> src, Span<byte> dst, byte? delimiter = null)
        {
            var m = src.Length;
            var n = dst.Length;
            var o = 0u;
            var d = delimiter ?? 0;
            for(var i=0u; i<m; i++)
            {
                var c = skip(src,i).Edit;
                var p = c.Length;

                for(var j=0u; j<p && o<n; j++, o++)
                    seek(dst,o) = skip(c,j);

                if(delimiter != null)
                    seek(dst, ++o) = d;
            }
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void store<T>(ReadOnlySpan<SegRef> src, Span<T> dst)
            where T : struct
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
                seek(dst,i) = sys.first(sys.recover<T>(skip(src,i).Edit));
        }
    }
}