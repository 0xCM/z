//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class t_modn : UnitTest<t_modn>
    {
        public void mod16()
        {
            var ops = ModN.create(16);
            for(var i=0; i< RepCount; i++)
            {
                var a = Random.Next<uint>();
                var m0 = a % ops.N;
                var m1 = ops.mod(a);
                Claim.eq(m0,m1);
            }
        }

        public void mod18()
        {
            var ops = ModN.create(18);
            for(var i=0; i< RepCount; i++)
            {
                var a = Random.Next<uint>();
                var m0 = a % ops.N;
                var m1 = ops.mod(a);
                Claim.eq(m0,m1);
            }
        }
    }
}