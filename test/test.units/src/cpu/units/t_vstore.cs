//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.Intrinsics;

    using static Root;
    using static core;

    public class t_vstore : t_inx<t_vstore>
    {
        public void check_vwrite_u8()
        {
            var src = Random.Span<byte>(16);
            var dst = gcpu.vcover<uint>(w128, ref first(src));
            var a = span<uint>(4);
            cpu.vstore(dst, ref first(a));
            var b = uint32(src);
            Claim.eq(a,b);
        }
    }
}