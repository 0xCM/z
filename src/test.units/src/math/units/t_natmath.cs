//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_natmath : UnitTest<t_natmath>
    {
        public void add_check()
        {
            add_check(50, n20, n30);
            add_check(n20 + n30, n20, n30);
        }

        void add_check<A,B>(ulong expect, A a = default, B b = default)
            where A : unmanaged, ITypeNat
            where B : unmanaged, ITypeNat
        {
            var sum1 = TypeNats.add(a,b);
            var sum2 = default(A).NatValue + default(B).NatValue;
            ClaimNumeric.eq(expect, sum1);
            ClaimNumeric.eq(expect, sum2);
        }

        void add_check<A,B>(int expect, A a = default, B b = default)
            where A : unmanaged, ITypeNat
            where B : unmanaged, ITypeNat
        {
            var sum1 = (int)TypeNats.add(a,b);
            ClaimNumeric.eq(expect, sum1);
        }
    }
}