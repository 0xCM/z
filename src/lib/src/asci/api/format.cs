//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using C = AsciCode;
    using S = AsciSymbol;

    partial struct Asci
    {
        [MethodImpl(Inline), Op]
        public static string format(AsciSymbol src)
            => src.Text;

        public static string format<N>(AsciBlock<N> src)
            where N : unmanaged, ITypeNat
        {
            var dst = span<char>(src.View.Length);
            var count = render(src,dst);
            return new string(slice(dst,0,count));
        }

        [Op]
        public static string format<T>(in AsciLineCover<T> src)
            where T : unmanaged
        {
            Span<char> buffer = stackalloc char[src.RenderLength];
            var i=0u;
            render(recover<T,AsciCode>(src.View), ref i, buffer);
            return sys.@string(buffer);
        }

        public static string format(in AsciLineCover src)
        {
            Span<char> buffer = stackalloc char[src.RenderLength];
            var i=0u;
            render(src.Codes, ref i, buffer);
            return sys.@string(buffer);
        }

        [Op]
        public static string format(ReadOnlySpan<C> src, Span<char> buffer)
            => sys.@string(sys.slice(buffer,0, decode(src, buffer)));

        [Op]
        public static string format(ReadOnlySpan<byte> src, Span<char> dst)
        {
            var len = src.Length;
            for(var i=0u; i<len; i++)
                seek(dst, i) = (char)skip(src,i);
            return sys.@string(slice(dst,0,len));
        }

        [Op]
        public static string format(AsciSeq seq)
            => format(seq.Codes);

        [Op]
        public static string format(ReadOnlySpan<byte> src)
        {
            Span<char> dst = stackalloc char[src.Length];
            decode(src, dst);
            return new string(dst);
        }

        [Op]
        public static string format(ReadOnlySpan<C> src)
        {
            Span<char> dst = stackalloc char[src.Length];
            decode(src, dst);
            return new string(dst);
        }

        [Op]
        public static string format(ReadOnlySpan<S> src)
        {
            Span<char> dst = stackalloc char[src.Length];
            decode(src, dst);
            return new string(dst);
        }

        [MethodImpl(Inline), Op]
        public static string format(in AsciBlock128 src)
        {
            ref var storage = ref src.First;
            var v1 = vcpu.vload(w256, storage);
            var v2 = vcpu.vload(w256, sys.seek(storage, 32*1));
            var v3 = vcpu.vload(w256, sys.seek(storage, 32*2));
            var v4 = vcpu.vload(w256, sys.seek(storage, 32*3));
            var x0 = vpack.vinflatelo256x16u(v1);
            var x1 = vpack.vinflatehi256x16u(v1);
            var x2 = vpack.vinflatelo256x16u(v2);
            var x3 = vpack.vinflatehi256x16u(v2);
            var x4 = vpack.vinflatelo256x16u(v3);
            var x5 = vpack.vinflatehi256x16u(v3);
            var x6 = vpack.vinflatelo256x16u(v4);
            var x7 = vpack.vinflatehi256x16u(v4);
            var chars = recover<char>(sys.bytes(new V512x4(x0,x1,x2,x3,x4,x5,x6,x7)));
            var length = text.index(chars, '\0');
            var data = length == NotFound ? chars : slice(chars, 0, length);
            return new string(data);
        }
    }
}