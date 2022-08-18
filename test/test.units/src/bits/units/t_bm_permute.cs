//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_bm_permute : t_bits<t_bm_permute>
    {
        bit on => bit.On;

        bit off => bit.Off;

        public void bm_fromperm_8x8x8()
        {
            var n = n8;

            for(var sample = 0; sample < RepCount; sample++)
            {
                var p = Random.Perm(n);
                var m = p.ToBitMatrix();

                for(var i=0; i<n; i++)
                for(var j=0; j<n; j++)
                {
                    if(p[i] == j)
                        Claim.eq(m[i,j], on);
                    else
                        Claim.eq(m[i,j], off);
                }
            }
        }

        // public void bm_fromperm_16x16x16()
        // {
        //     var n = n16;

        //     for(var sample=0; sample<RepCount; sample++)
        //     {
        //         var p = Random.Perm(n);
        //         var m = p.ToBitMatrix();

        //         for(var i=0; i<n; i++)
        //         for(var j=0; j<n; j++)
        //         {
        //             if(p[i] == j)
        //                 Claim.eq(m[i,j], on);
        //             else
        //                 Claim.eq(m[i,j], off);
        //         }
        //     }
        // }

        // public void bm_fromperm_64x64x64()
        // {
        //     var n = n64;

        //     for(var sample=0; sample<RepCount; sample++)
        //     {
        //         var p = Random.Perm(n);
        //         var m = p.ToBitMatrix();

        //         for(var i=0; i<n; i++)
        //         for(var j=0; j<n; j++)
        //         {
        //             if(p[i] == j)
        //                 Claim.eq(m[i,j], on);
        //             else
        //                 Claim.eq(m[i,j], off);
        //         }
        //     }
        // }

        public void bm_perm_exchange_8x8x8()
        {
            for(var i= 0; i<RepCount; i++)
            {
                //Creates an "exchange" matrix
                var perm = Z0.Perm.natural(n8).Reverse();
                var mat = perm.ToBitMatrix();

                var v1 = Random.BitVector(n8);
                var v2 = mat * v1;
                var v3 = v1.Replicate();
                v3 = BitVectors.reverse(v3);
                Claim.eq(v3,v2);
            }
        }

        // public void bm_perm_exchange_32x32x32()
        // {
        //     for(var i= 0; i<RepCount; i++)
        //     {
        //         //Creates an "exchange" matrix
        //         var perm = Permute.natural(n32).Reverse();
        //         var mat = perm.ToBitMatrix();

        //         var v1 = Random.BitVector(n32);
        //         var v2 = mat * v1;
        //         var v3 = v1.Replicate();
        //         Claim.eq(v3.Reverse(),v2);
        //     }
        // }

        // public void bm_perm_exchange_64x64x64()
        // {
        //     for(var i= 0; i<RepCount; i++)
        //     {
        //         //Creates an "exchange" matrix
        //         var perm = Permute.natural(n64).Reverse();
        //         var mat = perm.ToBitMatrix();

        //         var v1 = Random.BitVector(n64);
        //         var v2 = mat * v1;
        //         var v3 = v1.Replicate();
        //         v3 = BitVector.reverse(v3);
        //         Claim.eq(v3,v2);
        //     }
        // }
    }

}