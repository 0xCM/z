//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class t_bits_concat : t_bits<t_bits_concat>
    {
        public void concat_8x2()
        {
            var count = RepCount;
            var s0 = Random.Span<byte>(count);
            var s1 = Random.Span<byte>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var lo = ref skip(s0,i);
                ref readonly var hi = ref skip(s1,i);
                var c = bits.join(lo,hi);
                var c0 = (byte)c;
                var c1 = (byte)(c >> 8);
                Claim.eq(lo,c0);
                Claim.eq(hi,c1);
            }
        }

        public void concat_8x4()
        {
            var count = RepCount;
            var s0 = Random.Span<byte>(count);
            var s1 = Random.Span<byte>(count);
            var s2 = Random.Span<byte>(count);
            var s3 = Random.Span<byte>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var a0 = ref skip(s0,i);
                ref readonly var a1 = ref skip(s1,i);
                ref readonly var a2 = ref skip(s2,i);
                ref readonly var a3 = ref skip(s3,i);

                var b = bits.join(a0,a1,a2,a3);
                var b0 = (byte)b;
                var b1 = (byte)(b >> 8);
                var b2 = (byte)(b >> 16);
                var b3 = (byte)(b >> 24);

                Claim.eq(a0,b0);
                Claim.eq(a1,b1);
                Claim.eq(a2,b2);
                Claim.eq(a3,b3);
            }
        }
    }
}
