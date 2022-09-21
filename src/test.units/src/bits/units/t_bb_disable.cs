//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiComplete]
    public class t_bb_disable : t_bits<t_bb_disable>
    {
        static NatSeq<N2,N1,N3> n213 = default;

        public void bb_disable_16x16()
            => nbb_disable_check<N16,ushort>();

        public void bb_disable_32x32()
            => gbb_disable_check<uint>(32);

        public void bb_disable_n32x32()
            => nbb_disable_check<N32,uint>();

        public void bb_disable_64x64()
            => gbb_disable_check<ulong>(64);

        public void bb_disable_n64x64()
            => nbb_disable_check<N64,ulong>();

        public void bb_disable_213x8()
            => gbb_disable_check<byte>(213);

        public void bb_disable_213x16()
            => gbb_disable_check<ushort>(213);

        public void bb_disable_213x32()
            => gbb_disable_check<uint>(213);

        public void bb_disable_213x64()
            => gbb_disable_check<ulong>(213);

        public void bb_disable_n213x8()
            => nbb_disable_check(n213, z8);

        public void bb_disable_n213x16()
            => nbb_disable_check(n213, z16);

        public void bb_disable_n213x32()
            => nbb_disable_check(n213, z32);

        public void nbc_disable_213x64()
            => nbb_disable_check(n213, z64);

        void bb_disable_n707x64u()
        {
            var n707 = TypeNats.seq(n7,n0,n7);
            Claim.eq(707,(int)n707.NatValue);
            nbb_disable_check(n707, (ulong)0);
        }

        void gbb_disable_check<T>(BitWidth n)
            where T : unmanaged
        {
            for(var k=0; k<RepCount; k++)
            {
                var bv = Random.BitBlock<T>(n);
                var bs = bv.ToBitString();
                Claim.eq(bv.BitCount, n);
                Claim.eq(bv.BitCount, bs.Length);
                for(var i=0; i<bv.BitCount; i+= 2)
                {
                    bv[i] = bit.Off;
                    bs[i] = bit.Off;
                }

                Claim.eq(bv.ToBitString(),bs);
            }
        }

        void nbb_disable_check<N,T>(N n = default, T rep = default)
            where T : unmanaged
            where N : unmanaged, ITypeNat
        {
            for(var k=0; k<RepCount; k++)
            {
                var bc = Random.BitBlock<N,T>();
                var bs = bc.ToBitString();
                Claim.almost(bc.Width, n.NatValue);
                Claim.eq(bc.Width, bs.Length);
                for(var i=0; i<bc.Width; i+= 2)
                {
                    bc[i] = bit.Off;
                    bs[i] = bit.Off;
                }

                Claim.eq(bc.ToBitString(),bs);
            }
        }
    }
}