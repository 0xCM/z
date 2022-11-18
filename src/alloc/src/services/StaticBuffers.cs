//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public readonly struct StaticBuffers
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> covered<T>(in StaticBuffer<T> src)
            => first(cover<Index<T>>(src.Address, 1)).Storage;

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