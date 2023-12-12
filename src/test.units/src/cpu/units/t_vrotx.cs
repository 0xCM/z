//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static vcpu;

public class t_vrotx : t_inx<t_vrotx>
{
    public void vrotrx_128x8u()
    {
        for(var i=0; i<RepCount; i++)
        {
            var x = vunits<byte>(w128);
            Claim.veq(vgcpu.vrorx(x,8), vrorx(x, n8));
            Claim.veq(vgcpu.vrorx(x,16), vrorx(x, n16));
            Claim.veq(vgcpu.vrorx(x,24), vrorx(x, n24));
            Claim.veq(vgcpu.vrorx(x,32), vrorx(x, n32));
        }
    }

    public void vrotlx_128x8u()
    {
        for(var i=0; i<RepCount; i++)
        {
            var x = vunits<byte>(w128);
            Claim.veq(gcpu.vrolx(x,8), vrolx(x, n8));
            Claim.veq(gcpu.vrolx(x,16), vrolx(x, n16));
            Claim.veq(gcpu.vrolx(x,24), vrolx(x, n24));
            Claim.veq(gcpu.vrolx(x,32), vrolx(x, n32));
        }
    }
}
