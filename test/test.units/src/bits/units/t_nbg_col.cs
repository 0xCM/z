//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_nbg_col : t_bits<t_nbg_col>
    {
        public void nbg_col_256x32x8()
        {
            var m = n32;
            var n = n8;
            var t = z64;

            for(var i=0; i< RepCount; i++)
            {
                var xg = Random.BitGrid(m,n,t);
                var xs = BitGrid.bitstring(xg).Transpose(m,n);
                for(var col=0; col<n; col++)
                {
                    ScalarBits<uint> bv1 = BitGrid.col(xg,col);
                    ScalarBits<uint> bv2 = BitVectors.create(m,xs.Slice(col*m, m));
                    Claim.eq(bv1,bv2);
                }
            }
        }

        public void nbg_col_128x16x8()
        {
            var m = n16;
            var n = n8;
            var t = z64;

            for(var i=0; i<RepCount; i++)
            {
                var xg = Random.BitGrid(m,n,t);
                var xs = BitGrid.bitstring(xg).Transpose(m,n);

                for(var col=0; col<n; col++)
                {
                    ScalarBits<ushort> bv1 = BitGrid.col(xg,col);
                    ScalarBits<ushort> bv2 = BitVectors.create(m,xs.Slice(col*m, m));
                    Claim.eq(bv1, bv2);
                }
            }
        }


        public void nbg_col_32x8x4()
        {
            var m = n8;
            var n = n4;
            var t = z32;

            for(var i=0; i<RepCount; i++)
            {
                var xg = Random.BitGrid(m,n,t);
                var xs = xg.ToBitString().Transpose(m,n);

                for(var col=0; col<n; col++)
                {
                    var bv1 = BitGrid.col(xg,col);
                    var bv2 = xs.Slice(col*m, m).ToBitVector(m);
                    Claim.eq(bv1, bv2);
                }
            }
        }

        public void nbg_col_32x4x8()
        {
            var m = n4;
            var n = n8;
            var t = z32;

            for(var i=0; i<RepCount; i++)
            {
                var xg = Random.BitGrid(m,n,t);
                var xs = BitGrid.bitstring(xg).Transpose(m,n);

                for(var col=0; col<n; col++)
                {
                    var bv1 = BitGrid.col(xg,col);
                    var bv2 = BitVectors.create(m,xs.Slice(col*m, m));
                    Claim.eq(bv1, bv2);
                }
            }
        }

        public void nbg_col_64x16x4()
        {
            var t = z64;
            var m = n16;
            var n = n4;

            for(var i=0; i<RepCount; i++)
            {
                var xg = Random.BitGrid(m,n,t);
                var xs = BitGrid.bitstring(xg).Transpose(m,n);

                for(var col=0; col<n; col++)
                {
                    var bv1 = BitGrid.col(xg,col);
                    var bv2 = BitVectors.create(m,xs.Slice(col*m, m));
                    Claim.eq(bv1, bv2);
                }
            }
        }

        public void nbg_col_64x32x2()
        {
            var m = n32;
            var n = n2;
            var t = z64;

            for(var i=0; i<RepCount; i++)
            {
                var xg = Random.BitGrid(m,n,t);
                var xs = BitGrid.bitstring(xg).Transpose(m,n);

                for(var col=0; col<n; col++)
                {
                    var bv1 = BitGrid.col(xg,col);
                    var bv2 = BitVectors.create(m,xs.Slice(col*m, m));
                    Claim.eq(bv1, bv2);
                }
            }
        }

        public void nbg_col_64x8x8()
        {
            var m = n8;
            var n = n8;
            var t = z64;

            for(var i=0; i<RepCount; i++)
            {
                var xg = Random.BitGrid(m,n,t);
                var xs = BitGrid.bitstring(xg).Transpose(m,n);

                for(var col=0; col<n; col++)
                {
                    var bv1 = BitGrid.col(xg,col);
                    var bv2 = BitVectors.create(m,xs.Slice(col*m, m));
                    Claim.eq(bv1, bv2);
                }
            }
        }
    }
}