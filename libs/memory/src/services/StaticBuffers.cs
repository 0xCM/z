//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public readonly struct StaticBuffers
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline)]
        public static H fetch<H,T>()
            where H : StaticBuffer<H,T>, new()
                => StaticBuffer<H,T>.fetch();

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static StaticBuffer256<T> fetch<T>(W256 w)
            => StaticBuffer256<T>.fetch();

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> covered<T>(in StaticBuffer<T> src)
            => first(cover<Index<T>>(src.Address, 1)).Storage;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(in StaticBuffer<T> src, uint index, out T value)
        {
            value = seek(src.Content, index);
            return ref value;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> slice<T>(in StaticBuffer<T> src, uint offset)
            => core.slice(covered(src), offset);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> slice<T>(in StaticBuffer<T> src, uint offset, uint length)
            => core.slice(covered(src), offset, length);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void enumerate<T>(in StaticBuffer<T> src, Action<T> receiver)
        {
            var buffer = covered(src);
            var count = src.CellCount;
            for(var i=0; i<count; i++)
                receiver(skip(buffer, i));
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void enumerate<T>(in StaticBuffer<T> src, uint i0, uint i1, Action<T> receiver)
        {
            var buffer = covered(src);
            for(var i=i0; i<=i1; i++)
                receiver(skip(buffer, i));
        }
    }
}