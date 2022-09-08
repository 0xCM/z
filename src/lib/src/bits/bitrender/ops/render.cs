//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct BitRender
    {
        public static void render<T>(uint n, CharFence fence, char sep, in T src, ITextBuffer dst)
            where T : unmanaged
        {
            if(fence.IsNonEmpty)
                dst.Append(fence.Left);
            var data = bytes(src);
            var count = data.Length;
            var k=0;
            for(var i=0; i<count; i++)
            {
                ref readonly var b = ref skip(data,i);
                for(byte j=0; j<8 && k<n; j++, k++)
                {
                    dst.Append(bit.test(b,j).ToChar());
                    if(k < n-1 && sep != 0)
                        dst.Append(sep);
                }
            }

            if(fence.IsNonEmpty)
                dst.Append(fence.Right);
        }

        [Op, Closures(Closure)]
        public static uint render<T>(uint n, in T src, Span<char> dst)
            where T : unmanaged
        {
            var w=0u;
            var i=0u;
            var data = bytes(src);
            var k=0u;
            var max = dst.Length;
            while(i < max && w < n && k < max)
            {
                ref readonly var b = ref skip(data, k++);
                var m = (int)n - (int)w;
                if(m >= 8)
                    w += render(b, ref i, 8, dst);
                else
                {
                    w += render(b, ref i, (byte)m, dst);
                    break;
                }
            }

            return w;
        }

        [Op]
        public static uint render(byte src, ref uint i, uint w, Span<char> dst)
        {
            var i0 = i;
            switch(w)
            {
                case 1:
                    render1(src, ref i, dst);
                break;
                case 2:
                    render2(src, ref i, dst);
                break;
                case 3:
                    render3(src, ref i, dst);
                break;
                case 4:
                    render4(src, ref i, dst);
                break;
                case 5:
                    render5(src, ref i, dst);
                break;
                case 6:
                    render6(src, ref i, dst);
                break;
                case 7:
                    render7(src, ref i, dst);
                break;
                case 8:
                    render8(src, ref i, dst);
                break;
            }
            return i - i0;
        }

        [Op]
        public static uint render(ushort src, ref uint i, uint w, Span<char> dst)
        {
            var i0 = i;
            if(w <= 8)
                return render((byte)src, ref i, w, dst);

            switch(w)
            {
                case 9:
                    render9(src, ref i, dst);
                break;
                case 10:
                    render10(src, ref i, dst);
                break;
                case 11:
                    render11(src, ref i, dst);
                break;
                case 12:
                    render12(src, ref i, dst);
                break;
                case 13:
                    render13(src, ref i, dst);
                break;
                case 14:
                    render14(src, ref i, dst);
                break;
                case 15:
                    render15(src, ref i, dst);
                break;
                case 16:
                    render16(src, ref i, dst);
                break;
            }
            return i - i0;
        }

        [Op]
        public static uint render(ReadOnlySpan<byte> src, ReadOnlySpan<byte> widths, Span<char> dst)
        {
            var i=0u;
            var count = core.min(src.Length,widths.Length);
            for(var j=0; j<count; j++)
                i+= render(skip(src,j), ref i, skip(widths,j), dst);
            return i;
        }

        public static uint render(ReadOnlySpan<byte> src, uint maxbits, Span<char> dst)
        {
            var n = (uint)min(src.Length*8, maxbits);
            var q = n/8u;
            var r = n%8;
            var m = maxbits % 8;
            var count = q + (r != 0 ? 1 : 0);
            var k=0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var input = ref skip(src,i);
                var last = i == count -1;
                if(last && r != 0)
                    render(input, ref k, m, dst);
                else
                    render8(input, ref k, dst);
            }
            return k;
        }

        [Op]
        public static Span<char> render(ReadOnlySpan<byte> src, uint maxbits = uint.MaxValue)
        {
            var dst = span<char>(src.Length*8);
            var count = render(src,maxbits,dst);
            return slice(dst,0,count);
        }
    }
}