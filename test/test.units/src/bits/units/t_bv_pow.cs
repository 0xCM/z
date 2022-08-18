//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Collections.Generic;

    public class t_bv_pow : t_bits<t_bv_pow>
    {
        public void bvpow_8()
        {
            var x = Random.BitVector(n8);
            var expect2 = x * x;
            var actual2 = x^2;
            Claim.eq(expect2, actual2);

            var expect4 = expect2 * expect2;
            var actual4 = x^4;
            Claim.eq(expect4, actual4);

            var expect8 = expect4 * expect4;
            var actual8 = x^8;
            Claim.eq(expect8, actual8);

            var expect16 = expect8 * expect8;
            var actual16 = x^16;
            Claim.eq(expect16, actual16);
        }

        public void bvorders_Gf256()
        {
            var orders = new Dictionary<byte,int>();
            foreach(var v in BitVectors.nonempty(n8))
            {
                var order = v.Order();
                Claim.eq(BitVector8.One, v^order);
                orders.Add(v,order);
            }
            Claim.eq(orders.Count,Gf256.MemberCount - 1);
        }
    }
}