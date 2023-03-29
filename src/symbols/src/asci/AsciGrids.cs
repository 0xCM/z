//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class AsciGrids
    {
        public static uint asci<T>(W8 w, N5 n, in SymExpr symbol, T kind, uint offset, Span<byte> dst)
            where T : unmanaged
        {
            const string RenderPattern = "{0,-2} {1,-4} {2,-2} {3,-5}";
            var index = u8(kind);
            var bits = BitRender.format5(index);
            var hex = index.FormatHex(specifier:false);
            var desc = string.Format(RenderPattern,index, symbol, hex, bits);
            var width = desc.Length;
            AsciSymbols.encode(desc, slice(dst,offset));
            return (uint)width;
        }


        [Op,Closures(UInt8k)]
        public static AsciGrid<T> grid<T>(Symbols<T> src, uint width)
            where T : unmanaged
        {
            var count = src.Count;
            var size = count*width;
            var dst = alloc<byte>(size);
            var offset = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var symbol = ref src[i];
                offset += encode(w8, n5, symbol.Expr, symbol.Kind, offset, dst);
            }
            return new AsciGrid<T>(AsciSeq.seq(dst), width);
        }

        public static uint encode<T>(W8 w, N5 n, in SymExpr symbol, T kind, uint offset, Span<byte> dst)
            where T : unmanaged
        {
            const string RenderPattern = "{0,-2} {1,-4} {2,-2} {3,-5}";
            var index = u8(kind);
            var bits = BitRender.format5(index);
            var hex = index.FormatHex(specifier:false);
            var desc = string.Format(RenderPattern,index, symbol, hex, bits);
            var width = desc.Length;
            AsciSymbols.encode(desc, slice(dst,offset));
            return (uint)width;
        }
    }
}