//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static vcpu;

    public class tv_mul : t_inx<tv_mul>
    {
        void vmul_128x32u()
        {
            var ws = n128;
            var wt = n256;
            var s = z32;
            var t = z64;
            var count = vcount(ws,s);

            var a0 = gcpu.vinc(ws,1u);
            var a1 = gcpu.vinc(ws,a0.LastCell() + 1);
            var b0 = vmul(a0,a1);
            var b1 = vmul(vswaphl(a0), vswaphl(a1));
            Trace("x", a0.Format());
            Trace("y", a1.Format());
            Trace("lo", b0.Format());
            Trace("hi", b1.Format());

            for(var rep=0; rep< RepCount; rep++)
            {
                var x = Random.CpuVector(ws,s);
                var y = Random.CpuVector(ws,s);
                var x0 = zUInt128.mul(vcell(x,0), vcell(y,0));
                var x1 = zUInt128.mul(vcell(x,1), vcell(y,1));
                var x2 = zUInt128.mul(vcell(x,2), vcell(y,2));
                var x3 = zUInt128.mul(vcell(x,3), vcell(y,3));
                var expect = vparts(wt, x0,x1,x2,x3);
                var actual = vmul(x,y);

                Claim.veq(expect,actual);
            }
        }

    }
}