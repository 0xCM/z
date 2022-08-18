//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_bitslice : t_bits<t_bitslice>
    {
        public void bitslice_32u()
        {
            var src = 0b00001010110000101001_001_111_011_001u;
            var bsSrc = src.ToBitString().Format(true);
            ClaimPrimalSeq.eq("1010110000101001001111011001", bsSrc);

            var i=-3;

            var x0 = gbits.slice(src, ScalarCast.uint8(i += 3), 3);
            var bsx0 = x0.ToBitString();
            var y0 = bsx0.TakeScalar<uint>();
            Claim.eq(x0,y0);

            var x1 = gbits.slice(src, ScalarCast.uint8(i += 3), 3);
            var bsx1 = x1.ToBitString();
            var y1 = bsx1.TakeScalar<uint>();
            Claim.eq(x1,y1);

            var x2 = gbits.slice(src, ScalarCast.uint8(i += 3), 3);
            var bsx2 = x2.ToBitString();
            var y2 = bsx2.TakeScalar<uint>();
            Claim.eq(x2,y2);

            var x3 = gbits.slice(src, ScalarCast.uint8(i += 3), 3);
            var bsx3 = x3.ToBitString();
            var y3 = bsx3.TakeScalar<uint>();
            Claim.eq(x3,y3);
        }
    }
}