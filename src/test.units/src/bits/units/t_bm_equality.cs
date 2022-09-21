//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    #pragma warning disable 1718 // Because comparison to self is a valid test case

    public class t_bm_equality : t_bits<t_bm_equality>
    {

        void bm_equality_8x8x8()
        {
            var n = n8;
            for(var i=0; i<RepCount; i++)
            {

                var m1 = Random.BitMatrix(n);
                Claim.require(BitMatrix.same(m1,m1));

                var m2 = m1.Replicate();
                Claim.require(BitMatrix.same(m1,m2));
                Claim.require(are_equal(m1,m2));

                m2[5,5] = !m1[5,5];
                Claim.nea(BitMatrix.same(m1,m2));
                Claim.nea(m1.Equals(m2));

            }
        }

        static bool are_equal(in BitMatrix8 A, in BitMatrix8 B)
        {
            var n = BitMatrix8.N;
            var result  = true;
            for(var i =0; i<8; i++)
            for(var j=0; j<8; j++)
            {
                if(A[i,j] != B[i,j])
                    return false;
            }
            return result;
        }

        static bool are_equal(in BitMatrix16 A, in BitMatrix16 B)
        {
            var n = BitMatrix16.N;
            var result  = true;
            for(var i=0; i<n; i++)
            for(var j=0; j<n; j++)
            {
                if(A[i,j] != B[i,j])
                    return false;
            }
            return result;
        }


        // public void bm_equality_16x16x16()
        // {
        //     var n = n16;
        //     for(var i=0; i<RepCount; i++)
        //     {
        //         var m1 = Random.BitMatrix(n);
        //         Claim.require(BitMatrix.same(m1,m1));

        //         var m2 = m1.Replicate();
        //         Claim.require(BitMatrix.same(m1,m2));
        //         Claim.require(are_equal(m1,m2));

        //         m2[5,5] = !m1[5,5];
        //         Claim.nea(BitMatrix.same(m1,m2));
        //         Claim.nea(m1.Equals(m2));


        //     }
        // }

        public void bm_equality_32x32x32()
        {
            var n = n32;
            for(var i=0; i<RepCount; i++)
            {
                var m1 = Random.BitMatrix(n);
                Claim.require(BitMatrix.same(m1,m1));

                var m2 = m1.Replicate();
                Claim.require(BitMatrix.same(m1,m2));

                m2[5,5] = !m1[5,5];
                Claim.nea(BitMatrix.same(m1,m2));
                Claim.nea(m1.Equals(m2));

            }
        }

        public void bm_equality_64x64x64()
        {
            var n = n64;
            for(var i=0; i<RepCount; i++)
            {
                var m1 = Random.BitMatrix(n);
                Claim.require(BitMatrix.same(m1,m1));

                var m2 = m1.Replicate();
                Claim.require(BitMatrix.same(m1,m2));

                m2[5,5] = !m1[5,5];
                Claim.nea(BitMatrix.same(m1,m2));
                Claim.nea(m1.Equals(m2));

            }
        }
    }
}