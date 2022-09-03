//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class t_blocks : t_inx<t_blocks>
    {
        public void check_cellsize()
        {
            Claim.eq(1, size<sbyte>());
            Claim.eq(1, size<byte>());
            Claim.eq(2, size<short>());
            Claim.eq(4, size<int>());
            Claim.eq(4, size<uint>());
            Claim.eq(4, size<float>());
            Claim.eq(8, size<ulong>());
            Claim.eq(8, size<double>());
            Claim.eq(8, size<long>());

            Claim.eq(1, size<sbyte>());
            Claim.eq(1, size<byte>());
            Claim.eq(2, size<short>());
            Claim.eq(4, size<int>());
            Claim.eq(4, size<uint>());
            Claim.eq(4, size<float>());
            Claim.eq(8, size<ulong>());
            Claim.eq(8, size<double>());
            Claim.eq(8, size<long>());
        }

        public void check_blocklength_128()
        {
            N128 n = default;
            Claim.eq(16, CellCalcs.blocklength<sbyte>(n));
            Claim.eq(16, CellCalcs.blocklength<byte>(n));
            Claim.eq(8, CellCalcs.blocklength<short>(n));
            Claim.eq(8, CellCalcs.blocklength<ushort>(n));
            Claim.eq(4, CellCalcs.blocklength<int>(n));
            Claim.eq(4, CellCalcs.blocklength<uint>(n));
            Claim.eq(2, CellCalcs.blocklength<long>(n));
            Claim.eq(2, CellCalcs.blocklength<ulong>(n));
            Claim.eq(4, CellCalcs.blocklength<float>(n));
            Claim.eq(2, CellCalcs.blocklength<double>(n));
            Claim.eq(8, CellCalcs.cellblocks<int>(n,2));
            Claim.eq(4, CellCalcs.cellblocks<long>(n, 2));
            Claim.eq(32, CellCalcs.cellblocks<byte>(n, 2));
        }

        public void check_blocklength_256()
        {
            var n = w256;
            Claim.eq(32, CellCalcs.blocklength<sbyte>(n));
            Claim.eq(32, CellCalcs.blocklength<byte>(n));
            Claim.eq(16, CellCalcs.blocklength<short>(n));
            Claim.eq(16, CellCalcs.blocklength<ushort>(n));
            Claim.eq(8, CellCalcs.blocklength<int>(n));
            Claim.eq(8, CellCalcs.blocklength<uint>(n));
            Claim.eq(4, CellCalcs.blocklength<long>(n));
            Claim.eq(4, CellCalcs.blocklength<ulong>(n));
            Claim.eq(8, CellCalcs.blocklength<float>(n));
            Claim.eq(4, CellCalcs.blocklength<double>(n));
        }

        public void check_block_slice()
        {
            var x = SpanBlocks.safeload(w128, array<int>(1,2,3,4,5,6,7,8));

            var block0 = x.CellBlock(0);
            Claim.eq(4, block0.Length);
            var y = SpanBlocks.safeload(w128, array(1,2,3,4));
            Claim.eq(block0, y);

            var block2 = x.CellBlock(1);
            Claim.eq(4, block2.Length);
            Claim.eq(block2, SpanBlocks.parts(w128,5,6,7,8));
        }

        public void check_safeload()
        {
            var x = SpanBlocks.safeload(w128, array<int>(1,2,3,4,5,6,7,8));
            Claim.eq(x.BlockCount,2);
            Claim.eq(x, SpanBlocks.parts(w128,1,2,3,4,5,6,7,8));
        }

        public void check_block_alloc()
        {
            var w = w128;
            var count = Pow2.T08;

            var src = Random.SpanBlocks<int>(w, count);
            var dst = SpanBlocks.alloc<int>(w, count);

            Claim.eq(src.CellCount, dst.CellCount);
            var blocklen = src.BlockLength;

            for(int block = 0, idx = 0; block<count; block++, idx ++)
            {
                for(var i =0; i<blocklen; i++)
                    dst[block*blocklen + i] = src[block*blocklen + i];
            }

            Claim.eq(src,dst);
        }
    }
}