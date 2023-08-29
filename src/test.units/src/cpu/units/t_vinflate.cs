//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static vcpu;

    public class t_vinflate : t_inx<t_vinflate>
    {
        public void vinflate_128x8u()
        {
            var v128x8u_input = gcpu.vinc<byte>(w128,0);
            var v256x16u =  vpack.vinflate256x16u(v128x8u_input);
            var v128x16u_a = vlo(v256x16u);
            var v128x16u_b = vhi(v256x16u);
            var v128x16u_a_expect = gcpu.vinc<ushort>(w128,0);
            var v128x16u_b_expect = gcpu.vinc<ushort>(w128,8);
            var v128x8u_output = vpack.vpack128x8u(v128x16u_a, v128x16u_b);

            Claim.veq(v128x16u_a_expect, v128x16u_a);
            Claim.veq(v128x16u_b_expect, v128x16u_b);
            Claim.veq(v128x8u_input, v128x8u_output);
        }

        public void vinflate_128x8u_128x16u()
        {
            var v128x8u = gcpu.vinc(default(Vector128<byte>));
            var v256x16u =  vpack.vinflate256x16u(v128x8u);
            var v128x16u_a = vlo(v256x16u);
            var v128x16u_b = vhi(v256x16u);

            for(byte i=0; i<8; i++)
                Claim.eq(vcell(v128x8u, i), vcell(v128x16u_a,i));
        }


    }
}