//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;
    using static core;

    public class t_bb_literal : t_bits<t_bb_literal>
    {
        public void bb_literal_40x64()
        {
            var n = n40;
            ulong x = 0b01011_00010_01110_11010_00111_00101_01110_10110;
            var bvz = BitBlocks.single(x,n);
            Span<byte> xSrc =  bytes(x);
            var bvx = BitBlocks.load(xSrc.Slice(0,5).ToArray());
            Claim.eq(gbits.pop(x), bvz.Pop());
            Claim.eq(gbits.pop(x), bvx.Pop());

            for(var i=0; i<n; i++)
                Claim.eq(bvz[i], bvx[i]);
        }

        public void bb_literal_12x32()
        {
            var bv = BitBlocks.single(0b101110001110u, n12);
            Claim.eq(bv[0], bit.Off);
            Claim.eq(bv[1], bit.On);
            Claim.eq(bv[11], bit.On);
        }
    }
}