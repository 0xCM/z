//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class t_bvrank : t_bits<t_bvrank>
    {
        public void bvrank_g8()
            => bvrank_gcheck<byte>();

        public void bvrank_g16()
            => bvrank_gcheck<ushort>();

        public void bvrank_g32()
            => bvrank_gcheck<uint>();

        public void bvrank_g64()
            => bvrank_gcheck<ulong>();

        public void bv_rank_8()
        {
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.BitVector(n8);
                var pos = Random.Next(1,6);

                var actual = gbits.rank(x.State,pos);
                var expect = 0u;
                for(var j=z8; j<= pos; j++)
                    expect += (x[j] ? 1u : 0u);
                Claim.eq(expect, actual);
            }
        }

        public void bvrank_32()
        {
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.BitVector(n32);
                var pos = Random.Next(1,28);

                var actual = gbits.rank(x.State,pos);
                var expect = 0u;
                for(var j=0; j<= pos; j++)
                    expect += (x[j] ? 1u : 0u);
                Claim.eq(expect, actual);
            }
        }

        public void bvrank_64()
        {
            for(var i=0; i<RepCount; i++)
            {

                var x = Random.BitVector(n64);
                var pos = Random.Next(1,50);

                var actual = gbits.rank(x.State,pos);
                var expect = 0u;
                for(var j=0; j<= pos; j++)
                    expect += (x[j] ? 1u : 0u);
                Claim.eq(expect, actual);
            }
        }

        protected void bvrank_gcheck<T>()
            where T : unmanaged
        {
            var x = Random.ScalarBits<T>();
            var pos = Random.Next(1,(uint)width<T>() - 2);

            var actual = gbits.rank(x.State,(int)pos);
            var expect = 0u;
            for(var i=0; i<= pos; i++)
                expect += (x[i] ? 1u : 0u);
            Claim.eq(expect, actual);
        }
    }
}