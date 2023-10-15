//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly struct BitConverters
    {
        // 65472 0xFFC0 0b1111111111000000
        const string RenderPattern = "{0:D5} 0x{0:X4} 0b{1}";

        public static N16 MaxWidth => default;

        /// <summary>
        /// Allocates and populates a character span, comprising each value covered by an <typeparamref name='N'>-bit number, expressed as a bitstring of length <typeparamref name='N'>
        /// </summary>
        /// <param name="n">The natural bit width</param>
        /// <typeparam name="N">The natural with type</typeparam>
        public static Span<char> bitstrings<N>(N n)
            where N : unmanaged, ITypeNat
        {
            var width = (uint)n.NatValue;
            var count = Numbers.count(n);
            var buffer = span<char>(count*width);
            for(var i=0; i<count; i++)
            {
                ref var c = ref seek(buffer,i*width);
                for(byte j=0; j<width; j++)
                    seek(c,width-1-j) = bit.test(i,(byte)j).ToChar();
            }
            return buffer;
        }

        static Index<asci32> rows<N>(N n = default)
            where N : unmanaged, ITypeNat
        {
            var width = (byte)n.NatValue;
            var count = Numbers.count(n);
            var src = bitstrings(n);
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