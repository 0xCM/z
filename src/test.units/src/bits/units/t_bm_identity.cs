//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_bm_identity : t_bits<t_bm_identity>
    {
        public void bm_identity_n8x8u_check()
            => bm_identity_check<N8,byte>();

        public void bm_identity_n8x16u_check()
            => bm_identity_check<N8,short>();

        public void bm_identity_n16x8u_check()
            => bm_identity_check<N16,byte>();

        public void bm_identity_n18x8u_check()
            => bm_identity_check<N18,byte>();

        public void bm_identity_n19x8u_check()
            => bm_identity_check<N19,byte>();

        public void bm_indentity_n12x16u_check()
            => bm_identity_check<N12,ushort>();

        public void bm_identity_4x8u_check()
        {
            var I = BitMatrix4.Identity;

            for(var i=0; i<4; i++)
            for(var j=0; j<4; j++)
            {
                if(i == j)
                    Claim.eq(bit.On, I[i,j]);
                else
                    Claim.eq(bit.Off, I[i,j]);
            }
        }

        public void bm_identity_8x8u_check()
        {
            var m = BitMatrix8.Identity;
            for(byte i=0; i < m.Order; i++)
                Claim.eq(m[i,i],bit.On);

            Claim.require(m.Diagonal().Enabled);

            var lhs = BitMatrix8.Identity;
            var rhs = BitMatrix8.Identity;
            var result = lhs & rhs;
            var order = result.Order;
            for(var row=0; row<order; row++)
            for(var col=0; col<order; col++)
                Claim.eq(result[row,col], rhs[row,col]);
        }

        public void bm_identity_16x16u_check()
        {
            var m = BitMatrix16.Identity;
            for(byte i=0; i < m.Order; i++)
                Claim.eq(m[i,i], bit.On);
            Claim.require(BitMatrix.diagonal(m).Enabled);
        }

        public void bm_identity_32x32u_check()
        {
            var m = BitMatrix32.Identity;
            for(byte i=0; i < m.Order; i++)
                Claim.eq(m[i,i], bit.On);
            Claim.require(BitMatrix.diagonal(m).TestC());
        }

        public void bm_identity_64x64_check()
        {
            var m = BitMatrix64.Identity;
            for(byte i=0; i < m.Order; i++)
                Claim.eq(m[i,i], bit.On);

            Claim.require(BitMatrix.diagonal(m).Enabled);

            var lhs = BitMatrix64.Identity;
            var rhs = BitMatrix64.Identity;
            var result = lhs & rhs;
            for(var row=0; row<result.Order; row++)
            for(var col=0; col<result.Order; col++)
                Claim.eq(result[row,col], rhs[row,col]);
        }

        public void bm_iszero_check()
        {
            Claim.require(BitMatrix8.Zero.IsZero());
            Claim.nea(BitMatrix8.Identity.IsZero());
            Claim.nea(Random.BitMatrix(n8).IsZero());

            Claim.require(BitMatrix16.Zero.IsZero());
            Claim.nea(BitMatrix16.Identity.IsZero());
            Claim.nea(Random.BitMatrix(n16).IsZero());

            Claim.require(BitMatrix32.Zero.IsZero());
            Claim.nea(BitMatrix32.Identity.IsZero());
            Claim.nea(Random.BitMatrix(n32).IsZero());

            Claim.require(BitMatrix64.Zero.IsZero());
            Claim.nea(BitMatrix64.Identity.IsZero());
            Claim.nea(Random.BitMatrix(n64).IsZero());
        }

        protected void bm_identity_check<N,T>()
            where N : unmanaged, ITypeNat
            where T : unmanaged
       {
            var identity = BitMatrixA.identity<N,T>();
            for(var i=0; i< identity.Order; i++)
            for(var j=0; j< identity.Order; j++)
                Claim.eq(identity[i,j], i==j ? bit.On : bit.Off);
        }
    }
}