//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Refs;
    using static Scalars;

    using C = AsciCode;
    using S = AsciSymbol;

    partial struct AsciBlocks
    {
        public static string format<N>(AsciBlock<N> src)
            where N : unmanaged, ITypeNat
        {
            var dst = span<char>(src.View.Length);
            var count = render(src,dst);
            return new string(slice(dst,0,count));
        }

        [MethodImpl(Inline)]
        public static uint render<N>(AsciBlock<N> src, Span<char> dst)
            where N : unmanaged, ITypeNat
                => decode(src.View, dst);


        [MethodImpl(Inline), Op]
        public static string format(in AsciBlock128 src)
        {
            ref var storage = ref src.First;
            var v1 = cpu.vload(w256, storage);
            var v2 = cpu.vload(w256, sys.seek(storage, 32*1));
            var v3 = cpu.vload(w256, sys.seek(storage, 32*2));
            var v4 = cpu.vload(w256, sys.seek(storage, 32*3));
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