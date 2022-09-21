//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;

    public class t_vmove : t_inx<t_vmove>
    {
        public void vmove_128x16u()
        {
            var src = gcpu.vinc(w128,z16);
            Claim.eq((ushort)3, cpu.vmove(src, w16, n3, n0));
            Claim.eq((ushort)2, cpu.vmove(src, w16, n2, n0));
            Claim.eq((ushort)1, cpu.vmove(src, w16, n1, n0));
        }
    }
}