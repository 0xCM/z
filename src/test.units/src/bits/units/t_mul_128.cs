//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public class t_mul128 : t_bits<t_mul128>
    {
        public void mul_no_overflow()
        {
            var x = Random.Span<ulong>(RepCount, z32, uint.MaxValue);
            var y = Random.Span<ulong>(RepCount, z32, uint.MaxValue);
            Span<Pair<ulong>> z = new Pair<ulong>[RepCount];
            Math128.mul(x,y,z);
            for(var i=0; i<RepCount; i++)
                Claim.eq(x[i] * y[i], z[i].Left);
        }
    }
}