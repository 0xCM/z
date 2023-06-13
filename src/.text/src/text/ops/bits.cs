//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    using static sys;
 
    partial class text
    {
        public static string bits(ReadOnlySpan<byte> src, in BitFormat config)
        {
            var count = src.Length*8;
            var dst = span<char>(count);
            dst.Fill(Chars.D0);
            Require.invariant(config.MaxBitCount > 0);

            render8x8(src, config.MaxBitCount, dst);

            dst.Reverse();

            var bs = new string(dst);

            if(config.TrimLeadingZeros)
                bs = bs.TrimStart(Chars.D0);

            if(config.ZPad != 0)
                bs = bs.PadLeft(config.ZPad, Chars.D0);

            if(config.BlockWidth != 0)
                bs = string.Join(config.BlockSep, bs.Partition(config.BlockWidth));

            return config.SpecifierPrefix ? "0b" + bs : bs;
        }

        [MethodImpl(Inline), Op]
        static uint render8x8(ReadOnlySpan<byte> src, uint limit, Span<char> dst)
        {
            var k=0u;
            var count = src.Length;
            for(var i=0u; i<count && k < limit; i++)
                render8(skip(src,i), limit, ref k, dst);
            return k;
        }

        [MethodImpl(Inline), Op]
        static uint render8(byte src, uint limit, ref uint i, Span<char> dst)
        {
            var i0 = i;
            for(byte k=0; k<8 && i<limit; k++)
                seek(dst, i++) = bit.test(src, k).ToChar();
            return i - i0;
        }
    }
}