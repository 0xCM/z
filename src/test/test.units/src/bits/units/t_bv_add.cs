//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_bv_add : t_bits<t_bv_add>
    {
        public void pvb_add_8()
        {
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.BitVector(n8);
                var y = Random.BitVector(n8);
                Claim.eq(math.add(x.State,  y.State), (x + y).State);
                Claim.eq(math.add(x.State,  (byte)1), (++x).State);
            }
        }

        public void pvb_add_16()
        {
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.BitVector(n16);
                var y = Random.BitVector(n16);
                Claim.eq(math.add(x.State,  y.State), (x + y).State);
                Claim.eq(math.add(x.State,  (ushort)1), (++x).State);
            }
        }

        public void pvb_add_32()
        {
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.BitVector(n32);
                var y = Random.BitVector(n32);
                Claim.eq(math.add(x.State,  y.State), (x + y).State);
                Claim.eq(math.add(x.State,  1), (++x).State);

            }
        }

        public void pvb_add_64()
        {
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.BitVector(n64);
                var y = Random.BitVector(n64);
                Claim.eq(math.add(x.State,  y.State), (x + y).State);
                Claim.eq(math.add(x.State,  1), (++x).State);
            }
        }
    }
}