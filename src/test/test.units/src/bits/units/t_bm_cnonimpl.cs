//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_bm_cnonimpl : t_bits<t_bm_cnonimpl>
    {
        public void bm_not_32x32x32()
        {
            for(var i=0; i<RepCount; i++)
            {
                var A = Random.BitMatrix(n32);
                var B = BitMatrix.not(A);
                var C = BitMatrix.not(A.Replicate().Generic(), A.Replicate().Generic());
                var D = BitMatrix32.from(C);

                Claim.require(B == D);
            }
        }

        public void bm_cnonimpl_8x8x8()
        {
            var lhs = Random.BitMatrix8();
            var rhs = lhs.Replicate();
            Claim.require(lhs.AndNot(rhs).IsZero());
        }

        public void bm_cnonimpl_16x16x16()
        {
            var lhs = Random.BitMatrix16();
            var rhs = lhs.Replicate();
            Claim.require(lhs.AndNot(rhs).IsZero());
        }

        public void bm_cnonimpl_32x32x32()
        {
            var lhs = Random.BitMatrix32();
            var rhs = lhs.Replicate();
            Claim.require(lhs.AndNot(rhs).IsZero());
        }

        public void bm_cnonimpl_64x64x64()
        {
            var lhs = Random.BitMatrix64();
            var rhs = lhs.Replicate();
            Claim.require(lhs.AndNot(rhs).IsZero());
        }
    }
}