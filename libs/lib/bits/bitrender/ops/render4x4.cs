//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Numeric;

    using C = AsciCode;

    partial struct BitRender
    {
        [MethodImpl(Inline), Op]
        public static uint render4x4(char sep, ReadOnlySpan<byte> src, Span<char> dst)
        {
            var size = src.Length;
            var j=size-1;
            var k=0u;
            for(var i=0; i<size; i++)
            {
                ref readonly var b = ref skip(src, j--);
                if(i != 0)
                    k += separate(k, sep, dst);

                render(n4,hi(b), ref k, dst);
                k+= separate(k, sep, dst);
                render(n4, lo(b), ref k, dst);
            }
            return k;
        }

        [MethodImpl(Inline), Op]
        public static uint render4x4(ReadOnlySpan<byte> src, Span<char> dst)
            => render4x4(Chars.Space, src, dst);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render4x4(char sep, uint n, ReadOnlySpan<byte> data, Span<char> dst)
        {
            var count = render4x4(sep, data, dst);
            var width = n + (n/4) - 1;
            var offset = count - width;
            return slice(dst, offset, width);
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render4x4<T>(char sep, uint n, in T src, Span<char> dst)
            where T : unmanaged
                => render4x4(sep, n, sys.bytes(src), dst);

        [MethodImpl(Inline), Op]
        public static uint render4x4(ReadOnlySpan<byte> src, Span<C> dst, C sep = C.Space)
            => render(n4,n4, src,dst, sep);
    }
}