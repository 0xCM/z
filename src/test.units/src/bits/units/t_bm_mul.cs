//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_bm_mul : t_bits<t_bm_mul>
    {
        static BitMatrix8 bmm(BitMatrix8 A, BitMatrix8 B)
        {
            const uint n = BitMatrix8.N;

            var dst = BitMatrix.alloc(n8);
            B = B.Transpose();
            for(var i=z8; i< n; i++)
            {
                var row = A[i];
                for(var j =z8; j< n; j++)
                {
                    var col = B[j];
                    dst[i,j] = BitVectors.modprod(row,col);
                }
            }
            return dst;
        }

        public static BitMatrix16 bmm(BitMatrix16 A, BitMatrix16 B)
        {
            const uint n = BitMatrix16.N;

            var dst = BitMatrix16.Alloc();
            B = B.Transpose();
            for(var i=z8; i< n; i++)
            {
                var row = A[i];
                for(var j =z8; j< n; j++)
                {
                    var col = B[j];
                    dst[i,j] = BitVectors.modprod(row,col);
                }
            }
            return dst;
        }

        static BitMatrix32 bmm(BitMatrix32 A, BitMatrix32 B)
        {
            const uint n = BitMatrix32.N;

            var dst = BitMatrix.alloc(n32);
            B = B.Transpose();
            for(var i=z8; i< n; i++)
            {
                var row = A[i];
                for(var j=z8; j< n; j++)
                {
                    var col = B[j];
                    dst[i,j] = BitVectors.modprod(row,col);
                }
            }
            return dst;
        }

        static BitMatrix64 bmm(BitMatrix64 A, BitMatrix64 B)
        {
            const uint n = BitMatrix64.N;

            var dst = BitMatrix.alloc(n64);
            B = B.Transpose();
            for(var i=z8; i< n; i++)
            {
                var row = A[i];
                for(var j=z8; j< n; j++)
                {
                    var col = B[j];
                    dst[i,j] = BitVectors.modprod(row,col);
                }
            }
            return dst;
        }

        void bm_mul_8x8x8()
        {
            var n = n8;
            for(var i=z8; i< RepCount; i++)
            {
                var m1 = Random.BitMatrix(n);
                var m2 = m1.Replicate();
                var m3 = Random.BitMatrix(n);
                var m4 = m2 * m3;
                var m5 = bmm(m1,m3);
                Claim.require(m4 == m5);
            }
        }

        // public void bm_mul_16x16x16()
        // {
        //     var n = n16;
        //     for(var i=0; i< RepCount; i++)
        //     {
        //         var m1 = Random.BitMatrix(n);
        //         var m2 = m1.Replicate();
        //         var m3 = Random.BitMatrix(n);
        //         var m4 = m2 * m3;
        //         var m5 = bmm(m1,m3);
        //         Claim.require(m4 == m5);
        //     }
        // }

        // public void bm_mul_32x32x32()
        // {
        //     var n = n32;
        //     for(var i=0; i< RepCount; i++)
        //     {
        //         var m1 = Random.BitMatrix(n);
        //         var m2 = m1.Replicate();
        //         var m3 = Random.BitMatrix(n);
        //         var m4 = m2 * m3;
        //         var m5 = bmm(m1,m3);
        //         Claim.require(m4 == m5);
        //     }
        // }

        // public void bm_mul_64x64x64()
        // {
        //     var n = n64;
        //     for(var i=0; i< RepCount; i++)
        //     {
        //         var m1 = Random.BitMatrix(n);
        //         var m2 = m1.Replicate();
        //         var m3 = Random.BitMatrix(n);
        //         var m4 = m2 * m3;
        //         var m5 = bmm(m1,m3);
        //         Claim.require(m4 == m5);
        //     }
        // }

        // public void bm_vmul_64x64x64()
        // {
        //     for(var sample = 0; sample < RepCount; sample++)
        //     {
        //         var A = Random.BitMatrix64();
        //         var x = Random.BitVector(n64);
        //         var z = A * x;
        //         var y = BitVector.alloc(n64);
        //         for(var i = 0; i<A.Order; i++)
        //         {
        //             var r = A[i];
        //             y[i] = r % x;
        //         }

        //         Claim.eq(z,y);
        //     }
        // }

        public void bm_vmul_8x8x8()
        {
            for(var sample = 0; sample < RepCount; sample++)
            {
                var m = Random.BitMatrix8();
                var c = Random.BitVector(n8);
                var z1 = m * c;
                var z2 = BitVectors.alloc(n8);
                for(var i=z8; i<m.Order; i++)
                    z2[i] = m[i] % c;

                Claim.eq(z1, z2);
            }
        }

        // public void bm_vmul_16x16x16()
        // {
        //     for(var sample = 0; sample < RepCount; sample++)
        //     {
        //         var m = Random.BitMatrix16();
        //         var c = Random.BitVector(n16);
        //         var z1 = m * c;
        //         var z2 = BitVector.alloc(n16);
        //         for(var i = 0; i<m.Order; i++)
        //         {
        //             var r = m[i];
        //             z2[i] = r % c;
        //         }

        //         Claim.require(z1 == z2);
        //     }
        // }

        // public void bm_vmul_32x32x32()
        // {
        //     for(var sample = 0; sample < RepCount; sample++)
        //     {
        //         var m = Random.BitMatrix32();
        //         var c = Random.BitVector(n32);
        //         var z1 = m * c;
        //         var z2 = BitVector.alloc(n32);
        //         for(var i = 0; i<m.Order; i++)
        //         {
        //             var r = m[i];
        //             z2[i] = r % c;
        //         }

        //         Claim.require(z1 == z2);
        //     }
        // }

        void bm_mul_32x32x32_bench()
        {
            var last = BitMatrix32.Zero;
            var sw = stopwatch(false);

            var dst = BitMatrix.alloc(n32);
            for(var i=0; i< OpCount; i++)
            {
                var m1 = Random.BitMatrix(n32);
                var m3 = Random.BitMatrix(n32);
                sw.Start();
                last = m1 * m3;
                sw.Stop();
            }

            ReportBenchmark("bmm_32x32", OpCount, sw.Elapsed);
        }

        void bm_4x4x4_bench()
        {
            var sw = stopwatch(false);
            var last = BitMatrix4.Zero;

            for(var i=0; i< OpCount; i++)
            {
                var m1 = Random.BitMatrix4();
                var m2 = Random.BitMatrix4();
                sw.Start();
                last = m1 * m2;
                sw.Stop();
            }
            ReportBenchmark("bmm_4x4", OpCount, sw.Elapsed);
        }

        void bm_8x8x8_bench()
        {
            var count = counter();
            var last = BitMatrix8.Zero;

            for(var i = 0; i < OpCount; i++)
            {
                var m1 = Random.BitMatrix8();
                var m2 = Random.BitMatrix8();
                count.Start();
                last = m1 * m2;
                count.Stop();
            }

            ReportBenchmark("bmm_8x8", OpCount, count);
        }

        void bm_16x16x16_bench()
        {

            var last = BitMatrix16.Zero;

            var sw = stopwatch(false);
            for(var i=0; i< OpCount; i++)
            {
                var m1 = Random.BitMatrix16();
                var m2 = Random.BitMatrix16();
                sw.Start();
                last = m1 * m2;
                sw.Stop();
            }

            ReportBenchmark("bmm_16x16", OpCount, sw.Elapsed);
        }

   }
}