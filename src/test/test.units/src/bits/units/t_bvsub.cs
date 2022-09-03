//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_bvsub : t_bits<t_bvsub>
    {
        public void bvsub_8()
        {
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.BitVector(n8);
                var y = Random.BitVector(n8);
                Claim.eq(math.sub(x.State,  y.State), (x - y).State);
                Claim.eq(math.sub(x.State,  y.State), (x + -y).State);
                Claim.eq(math.sub(x.State,  (byte)1), (--x).State);
            }
        }

        public void bvsub_16()
        {
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.BitVector(n16);
                var y = Random.BitVector(n16);
                Claim.eq(math.sub(x.State,  y.State), (x - y).State);
                Claim.eq(math.sub(x.State,  y.State), (x + -y).State);
                Claim.eq(math.sub(x.State,  (ushort)1), (--x).State);
            }
        }

        public void bvsub_32()
        {
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.BitVector(n32);
                var y = Random.BitVector(n32);
                Claim.eq(math.sub(x.State,  y.State), (x - y).State);
                Claim.eq(math.sub(x.State,  y.State), (x + -y).State);
                Claim.eq(math.sub(x.State,  1u), (--x).State);
            }
        }

        public void bvsub_64()
        {
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.BitVector(n64);
                var y = Random.BitVector(n64);
                Claim.eq(math.sub(x.State,  y.State), (x - y).State);
                Claim.eq(math.sub(x.State,  y.State), (x + -y).State);
                Claim.eq(math.sub(x.State,  1ul), (--x).State);
            }
        }
    }
}