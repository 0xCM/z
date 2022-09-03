//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct BitConverters
    {
        // 65472 0xFFC0 0b1111111111000000
        const string RenderPattern = "{0:D5} 0x{0:X4} 0b{1}";

        public static N16 MaxWidth => default;

        static Index<asci32> rows<N>(N n = default)
            where N : unmanaged, ITypeNat
        {
            var width = (byte)n.NatValue;
            var count = Numbers.count(n);
            var src = PolyBits.bitstrings(n);
            var dst = alloc<asci32>(count);

            for(var i=0; i<count; i++)
            {
                var offset = i*width;
                var seq = slice(src, offset, width);
                seek(dst,i) = string.Format(RenderPattern, i, text.format(seq));
            }

            return dst;
        }

        public static BitConverter<N> converter<N>(N n =default)
            where N : unmanaged, ITypeNat
        {
            Demand.lteq((byte)n.NatValue, (byte)MaxWidth);
            return new (rows(n));
        }
    }
}