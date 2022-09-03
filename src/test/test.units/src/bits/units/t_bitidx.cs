//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_bitidx : t_bits<t_bitidx>
    {
        public void bit_index_inc()
        {
            var pos = BitPos<byte>.Zero;
            BitPos<byte> max = (1024, 35);
            while(pos < max)
                pos++;

            Claim.eq(pos.LinearIndex, max.LinearIndex);
        }

        public void bit_index_dec()
        {
            var min = BitPos<byte>.Zero;
            BitPos<byte> pos = (1024, 35);
            while(pos > min)
                pos--;

            Claim.eq(pos.LinearIndex, min.LinearIndex);
        }

        public void bit_index_add()
        {
            var n = Pow2.T12;
            var positions = Random.BitPositions<uint>(512,1024).TakeArray(n);
            var additions = Random.Stream(Intervals.closed(0u, 100u)).TakeArray(n);
            for(var i=0; i<n; i++)
            {
                var posX = positions[i];
                var add = additions[i];
                var posY = posX + add;
                Claim.require(posY >= posX);

                var pos = posX;
                for(var j=0; j< add; j++)
                    pos++;

                Claim.eq(pos.LinearIndex, posY.LinearIndex);
            }
        }
    }
}