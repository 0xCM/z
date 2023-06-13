//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static Numeric;

    partial struct BitRender
    {
        [MethodImpl(Inline), Op]
        public static uint render16x8(char sep, ReadOnlySpan<byte> src, Span<char> dst)
        {
            var size = src.Length;
            var j=size-1;
            var k=0u;
            for(var i=0; i<size; i++)
            {
                ref readonly var b = ref skip(src,j--);
                if(i != 0)
                    k += separate(k, sep, dst);
                render8(hi(b), ref k, dst);
                k += separate(k, sep, dst);
                render8(lo(b), ref k, dst);
            }
            return k;
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render16x8(char sep, uint n, ReadOnlySpan<byte> data, Span<char> dst)
        {
            var count = render16x8(sep, data, dst);
            var k = n + (n/8) - 1;
            var m = count - k;
            return slice(dst, m, k);
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render16x8<T>(char sep, uint n, in T src, Span<char> dst)
            where T : unmanaged
                => render16x8(sep, n, sys.bytes(src), dst);

        [MethodImpl(Inline), Op]
        public static uint render16x8(char sep, ushort src, uint offset, Span<char> dst)
        {
            var counter = 0u;
            var cells = sys.bytes(src);
            counter += render8(skip(cells,1), counter + offset, dst);
            counter += separate(counter + offset, sep, dst);
            counter += render8(skip(cells,0), counter + offset, dst);
            return counter;
        }

        [MethodImpl(Inline), Op]
        public static uint render16x8(char sep, ushort src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            var cells = sys.bytes(src);
            render8(skip(cells,1), ref i, dst);
            seek(dst,i++) = sep;
            render8(skip(cells,0), ref i, dst);
            return i-i0;
        }

        [MethodImpl(Inline), Op]
        public static uint render16x8(ushort src, ref uint i, Span<char> dst)
            => render16x8(Chars.Space, src, ref i, dst);

        [MethodImpl(Inline), Op]
        public static string render16x8(char sep, ushort src)
        {
            Span<char> buffer = stackalloc char[32];
            var count = render16x8(sep, src, 0, buffer);
            return new(slice(buffer,0,count));
        }
    }
}