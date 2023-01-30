//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Asci
    {
        [Op, Closures(UInt8k)]
        public static AsciSeq seq<T>(W8 w, in Sym<T> symbol)
            where T : unmanaged
                => seq(w, n5, symbol.Expr, symbol.Kind);

        public static AsciSeq seq<T>(W8 w, N5 n, in SymExpr symbol, T kind)
            where T : unmanaged
        {
            const string RenderPattern = "{0,-2} {1,-4} {2,-2} {3,-5}";
            var index = u8(kind);
            var bits = BitRender.format5(index);
            var hex = index.FormatHex(specifier:false);
            var desc = string.Format(RenderPattern,index, symbol, hex, bits);
            var width = desc.Length;
            var dst = alloc<byte>(width);
            encode(desc, dst);
            return seq(dst);
        }        

        [MethodImpl(Inline), Op]
        public static AsciSeq seq(uint size)
            => new AsciSeq(alloc<byte>(size));

        [MethodImpl(Inline), Op]
        public static AsciSeq seq(byte[] src)
            => new AsciSeq(src);

        [MethodImpl(Inline), Op]
        public static AsciSeq seq(string src)
        {
            var buffer = alloc<byte>(src.Length);
            var seq = new AsciSeq(buffer);
            return encode(src, seq);
        }

        [MethodImpl(Inline), Op]
        public static AsciSeq seq(string src, byte[] dst)
        {
            encode(src,dst);
            return seq(dst);
        }

        [MethodImpl(Inline)]
        public static AsciSeq<A> seq<A>(A content)
            where A : unmanaged, IAsciSeq<A>
                => new AsciSeq<A>(content);
    }
}