//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;
    using static cpu;

    public class t_vinflate : t_inx<t_vinflate>
    {
        public void vinflate_128x8u()
        {
            var v128x8u_input = gcpu.vinc<byte>(w128,0);
            var v256x16u =  vpack.vinflate256x16u(v128x8u_input);
            var v128x16u_a = cpu.vlo(v256x16u);
            var v128x16u_b = cpu.vhi(v256x16u);
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
            var v128x16u_a = cpu.vlo(v256x16u);
            var v128x16u_b = cpu.vhi(v256x16u);

            for(byte i=0; i<8; i++)
                Claim.eq(vcell(v128x8u, i), vcell(v128x16u_a,i));
        }

        public void vinflate_256x8_1024x32()
        {
            var w = w256;

            var a0 = gcpu.vinc<uint>(w,0);
            var b0 = gcpu.vinc<uint>(w,8);
            var c0 = gcpu.vinc<uint>(w,16);
            var d0 = gcpu.vinc<uint>(w,24);

            var u16inc = gcpu.vinc<ushort>(w,0);
            var u8inc = gcpu.vinc<byte>(w,0);

            var c8 = vpack.vpack256x8u(a0, b0, c0, d0);
            var c16 = vpack.vpack256x16u(a0, b0);
            vpack.vinflate1024x32u(c8, out var x0, out var y0);
            Claim.veq(u16inc, c16);
            Claim.veq(u8inc, c8);
            Claim.veq(a0, x0.Lo);
            Claim.veq(b0, x0.Hi);
            Claim.veq(c0, y0.Lo);
            Claim.veq(d0, y0.Hi);
        }
    }
}