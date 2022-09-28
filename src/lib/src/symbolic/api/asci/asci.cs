//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Asci
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
            encode(desc, slice(dst,offset));
            return (uint)width;
        }

        [MethodImpl(Inline), Op]
        public static asci8 asci(N8 n, char src)
            => new asci8((ulong)src);

        [MethodImpl(Inline), Op]
        public static asci8 asci(N8 n, ReadOnlySpan<byte> src)
        {
            var length = (byte)min(available(src), asci8.Size);
            var storage = 0ul;
            var dst = bytes(storage);
            for(var i=0; i<length; i++)
                seek(dst,i) = skip(src,i);
            return new (storage);
        }
    }
}