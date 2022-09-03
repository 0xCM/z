//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_replicate : t_bits<t_replicate>
    {
        public void replicate_8x32()
        {
            for(var i=0; i<RepCount; i++)
            {
                var pattern = Random.Next<byte>();
                (var x0, var x1, var x2, var x3) = bits.split(gbits.replicate<uint>(pattern),n4);
                Claim.eq(x0, pattern);
                Claim.eq(x1, pattern);
                Claim.eq(x2, pattern);
                Claim.eq(x3, pattern);
            }
        }

        public void replicate_64u()
        {
            var src = 0b111000ul;
            var actual = gbits.replicate(src).ToBitVector64();

            var width = gbits.effwidth(src);
            Claim.eq((byte)6,width);

            var expect = BitVectors.alloc(n64);
            for(int i=0; i< expect.Width; i++)
                if(math.between( i % 6,3,5))
                    expect[i] = Bit32.On;

            Claim.eq(expect.State,actual.State);

            void report()
            {
                Trace("expect", text.bracket(expect.Format(6)));
                Trace("actual", actual.FormatBlocked(6));
            }
        }
    }
}