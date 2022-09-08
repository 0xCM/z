//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static Numeric;

    using C = AsciCode;

    partial struct BitRender
    {
        [MethodImpl(Inline), Op]
        public static uint render(N4 n, byte src, ref uint i, Span<char> dst)
            => render4(src, ref i,dst);

        [MethodImpl(Inline), Op]
        public static uint render(N4 n, byte src, ref uint i, Span<C> dst)
        {
            var i0  = i;
            seek(dst, i++) = code(src, 3);
            seek(dst, i++) = code(src, 2);
            seek(dst, i++) = code(src, 1);
            seek(dst, i++) = code(src, 0);
            return i - i0;
        }

        [MethodImpl(Inline), Op]
        public static uint render(N4 m, N4 n, ReadOnlySpan<byte> src, Span<char> dst, char sep = Chars.Space)
        {
            var size = src.Length;
            var j=size-1;
            var k=0u;
            for(var i=0; i<size; i++)
            {
                ref readonly var b = ref skip(src, j--);
                if(i != 0)
                    k += separate(k, sep, dst);

                render(m,hi(b), ref k, dst);
                k+= separate(k, sep, dst);
                render(n, lo(b), ref k, dst);
            }
            return k;
        }

        [MethodImpl(Inline), Op]
        public static uint render(N4 m, N4 n, ReadOnlySpan<byte> src, Span<C> dst, C sep = C.Space)
        {
            var size = src.Length;
            var j=size-1;
            var k=0u;
            for(var i=0; i<size; i++)
            {
                ref readonly var b = ref skip(src, j--);
                if(i != 0)
                    k += separate(k, sep, dst);

                render(m,hi(b), ref k, dst);
                k+= separate(k, sep, dst);
                render(n, lo(b), ref k, dst);
            }
            return k;
        }
    }
}