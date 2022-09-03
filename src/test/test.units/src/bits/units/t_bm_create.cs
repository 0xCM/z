//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;
    using static Root;

    public class t_bm_create : t_bits<t_bm_create>
    {
        void bm_format_n7x9x8()
        {
            var m1 = BitMatrix.alloc<N7,N9,byte>();
            m1.Fill(bit.On);
            var fmt = m1.Format().RemoveBlanks();

            Claim.eq(7*9, fmt.Length);
        }

        public void bm_cellcount()
        {
            Claim.eq(BitMatrix.cellcount<N2,N1,byte>(),2);
            Claim.eq(BitMatrix.cellcount<N2,N2,byte>(),2);
            Claim.eq(BitMatrix.cellcount<N4,N4,byte>(),4);
            Claim.eq(BitMatrix.cellcount<N8,N3,byte>(),8);
            Claim.eq(BitMatrix.cellcount<N8,N4,byte>(),8);
            Claim.eq(BitMatrix.cellcount<N8,N5,byte>(),8);
        }

        public void bm_create_4x3x8g()
        {
            var bm = BitMatrix.alloc<N4,N3,byte>();
            Claim.eq(4, bm.RowCount);
            Claim.eq(4, bm.CellCount);

            byte p0 = 0b101;
            byte p1 = 0b010;

            for(byte row=0; row < bm.RowCount; row++)
                bm[row] = BitBlocks.single<N3,byte>(gmath.even(row) ? p0 : p1);

            for(byte row=0; row < bm.RowCount; row++)
            for(byte col=0; col < bm.ColCount; col++)
                Claim.eq(bm[row,col], gmath.even(row) ? bit.test(p0,col) : bit.test(p1,col));
        }

        public void bm_create_fromfixed_16x16x16()
        {
            var src = Cells.load<ushort>(w256,Random.Span<ushort>(16));
            var dst = Cells.alloc(w256);
            Cells.store(src, dst.Bytes);
            var A = BitMatrix.primal(n16, dst.Bytes);
            var B = BitMatrix.primal(n16, src.Bytes);
            Claim.require(BitMatrix.same(A,B));
        }

        public void bm_load_8x8x8()
        {
            var src = Random.Stream<ulong>().Take(Pow2.T07).GetEnumerator();
            while(src.MoveNext())
            {
                var m1 = BitMatrix.primal(n8,src.Current);
                var n = new N8();
                var m2 = BitMatrix.load(n, n, BitConverter.GetBytes(src.Current).ToSpan());
                for(var i=0; i<8; i++)
                for(var j=0; j<8; j++)
                    Claim.eq(m1[i,j], m2[i,j]);
            }
        }


        public void bm_init_n7x9x8()
        {
            const byte pattern = 0b01010101;
            var fill = BitBlocks.alloc(n9, pattern);
            var matrix = BitMatrix.init(fill, n7);
            for(var i=0; i<matrix.RowCount; i++)
                Claim.require(fill == matrix[i]);
        }
    }
}