//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class t_bm_layout : t_bits<t_bm_layout>
    {
        public void bm_cellcount()
        {
            var row_14x16 = CellCalcs.mincells<N14,ushort>();
            var total_12x14x16 = BitMatrix.cellcount<N12,N14,ushort>();
            Claim.eq(1, row_14x16);
            Claim.eq(12*1, total_12x14x16);

            var row_64x32 = CellCalcs.mincells<N64,uint>();
            var total_13x64x32 = BitMatrix.cellcount<N13,N64,uint>();
            Claim.eq(2, row_64x32);
            Claim.eq(13*2, total_13x64x32);

            var row_32x8 = CellCalcs.mincells<N32,byte>();
            var total_32x32x8 = BitMatrix.cellcount<N32,N32,byte>();
            Claim.eq(4,row_32x8);
            Claim.eq(32*4, total_32x32x8);
        }

        public void bm_layout_n16x8()
        {
            const byte t = z8;
            const int order = 16;
            const int bitcount = order*order;
            const int cellwidth = 8;
            const int cellcount = 2;

            var m = BitMatrixA.ones<N16,byte>();

            Claim.eq(order, m.Order);
            Claim.eq(order, m.Order);
            Claim.eq(cellcount, BitMatrix<N16,byte>.RowCellCount);
            Claim.eq(cellcount, CellCalcs.mincells((ulong)width<byte>(),(ulong)order));

            for(var i=0; i < order; i++)
            for(var j=0; j < order; j++)
                Claim.eq(bit.On, m[i,j]);
        }
    }
}