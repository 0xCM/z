//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_natproof : UnitTest<t_natproof>
    {
        public void equality()
        {
            NatRequire.eq<N16>(16);
            NatRequire.eq<N512>(512);
            NatRequire.eq<NatSeq<N8,N2,N1>>(821);
        }

        public void smaller()
        {
            NatRequire.lt(n11, n12);
            NatRequire.lt(n512, n1024);
        }

        public void larger()
        {
            NatRequire.gt(n12, n11);
            NatRequire.gt(n1024, n512);
        }

        public void nonzero()
        {
            NatRequire.nonzero(n12);
            NatRequire.nonzero(n4);
            NatRequire.nonzero(n1);
        }

        public void sum()
        {
            NatRequire.sum(n5, n5, n10.NatValue);
            NatRequire.sum(n13, n0, n13.NatValue);
            NatRequire.sum(n512, n10, 522);
        }

        public void product()
        {
            NatRequire.mul(n5, n5, 25);
            NatRequire.mul(n13, n10, 130);
            NatRequire.mul(n512, n10, 5120);
        }

        public void next()
        {
            NatRequire.next(n0, n1);
            NatRequire.next(n5, n6);
            NatRequire.next(n15, n16);

            var n11 = TypeNats.next(n10);
            var n12 = TypeNats.next(n11);
            var n13 = TypeNats.next(n12);
            NatRequire.next(n10, n11);
            NatRequire.next(n11, n12);
            NatRequire.next(n12, n13);

        }

        public void iterate()
        {
           var n11 = TypeNats.next(n10);
           var n12 = TypeNats.next(n11);
           var n13 = TypeNats.next(n12);
           var n14 = TypeNats.next(n13);
           var n15 = TypeNats.next(n14);
           var n16 = TypeNats.next(n15);
           var n17 = TypeNats.next(n16);
           var n18 = TypeNats.next(n17);
           var n19 = TypeNats.next(n18);
           Claim.eq(n19.NatValue,19ul);
        }
    }
}