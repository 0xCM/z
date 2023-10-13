//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitSpans
    {
        [MethodImpl(Inline), Op]
        public static BitSpan xor(BitSpan a, BitSpan b, BitSpan c)
        {
            var count = c.Length;
            for(var i=0; i< count; i++)
                c[i] = a[i] ^ b[i];
            return c;
        }

        [Op]
        public static BitSpan xor(BitSpan a, BitSpan b)
            => xor(a, b, alloc(b.BitCount));
    }
}