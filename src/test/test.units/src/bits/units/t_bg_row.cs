//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_bg_row : t_bits<t_bg_row>
    {
        public void bg_row_128x32x4()
        {
            var t = z32;
            var m = n32;
            var n = n4;

            for(var sample = 0; sample<RepCount; sample++)
            {
                var bg = Random.BitGrid(m,n,t);
                var bs = BitGrid.bitstring(bg);
                for(var row = 0; row<m; row++)
                {
                    var r1 = BitGrid.row(bg,row);
                    var r2 = BitVectors.natural(bs.Slice(row*n,n), n, z8);
                    Claim.eq(r1,r2);
                }
            }
        }

        public void bg_row_32x8x4()
        {
            var t = z32;
            var m = n8;
            var n = n4;

            for(var i=0; i<RepCount; i++)
            {
                var bg = Random.BitGrid(m,n,t);
                var bs = BitGrid.bitstring(bg);

                for(var row = 0; row < m; row++)
                {
                    var r1 = BitGrid.row(bg,row);
                    var r2 = bs.Slice(row*n,n);
                    var r4 = BitVectors.create(n, r2);
                    Claim.eq(r1, r4);
                }
            }
        }

        public void bg_row_32x4x8()
        {
            var t = z32;
            var m = n4;
            var n = n8;

            for(var i=0; i<RepCount; i++)
            {
                var bg = Random.BitGrid(m,n,t);
                var bs = BitGrid.bitstring(bg);

                for(var row = 0; row < m; row++)
                {
                    var r1 = BitGrid.row(bg,row);
                    var r2 = bs.Slice(row*n,n);
                    var r4 = BitVectors.create(n, r2);
                    Claim.eq(r1, r4);
                }
            }
        }

        public void bg_row_256x4x64()
        {
            var w = n256;
            var m = n4;
            var n = n64;
            var t = z64;

            for(var i=0; i<RepCount; i++)
            {
                var bg = Random.BitGrid(m,n,t);
                var bs = BitGrid.bitstring(bg);
                var bd = BitGrid.store(bg);

                for(var row = 0; row<m; row++)
                {
                    var row1 = BitGrid.row(bg,row);
                    var row2 = bd[row].ToBitVector64();
                    Claim.eq(row1,row2);
                }
            }
        }

        public void bg_row_256x16x16()
        {
            var t = z16;
            var m = n16;
            var n = n16;

            for(var i=0; i<RepCount; i++)
            {
                var bg = Random.BitGrid(m,n,t);
                var bs = BitGrid.bitstring(bg);
                var bd = BitGrid.store(bg);

                for(var row = 0; row<m; row++)
                {
                    var row1 = BitGrid.row(bg,row);
                    var row2 = bd[row].ToBitVector16();
                    Claim.eq(row1,row2);
                }
            }
        }
    }
}