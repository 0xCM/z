//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static sys;
    using static Intervals;

    public class t_bb_extract : t_bits<t_bb_extract>
    {
        public void bb_extract_64()
        {
            var src = Random.Stream<ulong>().Take(RepCount).ToArray();
            var lower = Random.Stream(closed<byte>(0,32)).Take(RepCount).ToArray();
            var upper = Random.Stream(closed<byte>(32,64)).Take(RepCount).ToArray();
            for(var i=0; i< RepCount; i++)
            {
                var v1 = SpanBlocks.literals(n256,src[i]);
                var v2 = BitVectors.create(n64,src[i]);
                Claim.eq(v1.ToBitVector(n64), v2);

                var r1 = v1.BitSeg(lower[i], upper[i]);
                var r2 = v2[lower[i], upper[i]];

                if(r1 != r2)
                {
                    Notify($"v1 = {v1.ToBitString()}");
                    Notify($"v2 = {v2.ToBitString()}");

                    Notify($"v1[{lower[i]}, {upper[i]}] = {r1.ToBitString()}");
                    Notify($"v2[{lower[i]}, {upper[i]}] = {r2.ToBitString()}");
                }
                Claim.eq(r1,r2);
            }
        }

        public void bb_extract_32()
        {
            var src = Random.Stream<uint>().Take(RepCount).ToArray();
            var lower = Random.Stream(closed<byte>(0,16)).Take(RepCount).ToArray();
            var upper = Random.Stream(closed<byte>(16,32)).Take(RepCount).ToArray();
            for(var i=0; i< RepCount; i++)
            {
                var v1 = SpanBlocks.literals(n256,src[i]);
                var v2 = BitVectors.create(n32,src[i]);
                Claim.eq(v1.ToBitVector(n32),v2);

                var r1 = v1.BitSeg(lower[i], upper[i]);
                var r2 = v2[lower[i], upper[i]];
                Claim.eq(r1,r2);
            }
        }

        public void bb_extract_16()
        {
            var src = Random.Stream<ushort>().Take(RepCount).ToArray();
            var lower = Random.Stream(closed<byte>(0,8)).Take(RepCount).ToArray();
            var upper = Random.Stream(closed<byte>(8,16)).Take(RepCount).ToArray();
            for(var i=0; i< RepCount; i++)
            {
                var v1 = SpanBlocks.literals(n256,src[i]);
                var v2 = BitVectors.create(n16,src[i]);
                Claim.eq(v1.ToBitVector(n16),v2);

                var r1 = v1.BitSeg(lower[i], upper[i]);
                var r2 = v2[lower[i], upper[i]];
                Claim.eq(r1,r2);
            }
        }

        public void bb_extract_aligned()
        {
            byte x0 = 0b11010110;
            byte x1 = 0b10010101;
            byte x2 = 0b10100011;
            byte x3 = 0b10011101;
            byte x4 = 0b01011000;
            var bcx = SpanBlocks.literals(n256,x0,x1,x2,x3,x4);

            byte y0 = 0b0110;
            byte y1 = 0b1101;
            var y01 = gmath.or(y0, gmath.sal(y1, 4));
            byte y2 = 0b0101;
            byte y3 = 0b1001;
            var y23 = gmath.or(y2, gmath.sal(y3, 4));
            byte y4 = 0b0011;
            byte y5 = 0b1010;
            var y45 = gmath.or(y4, gmath.sal(y5, 4));
            byte y6 = 0b1101;
            byte y7 = 0b1001;
            var y67 = gmath.or(y6, gmath.sal(y7, 4));
            byte y8 = 0b1000;
            byte y9 = 0b0101;
            var y89 = gmath.or(y8, gmath.sal(y9, 4));
            var bcy = SpanBlocks.literals(n256,y01,y23,y45,y67,y89);

            const ulong bLit =  0b0101100010011101101000111001010111010110;
            const string sLit =  "101100010011101101000111001010111010110";

            var bSpan1 = BitSpans.parse(sLit);
            var bSpan2 = BitSpans.create(bLit);
            Claim.eq(sLit, bSpan2.Format(BitFormatter.configure(true)));


            var bvz = SpanBlocks.literals(n256,bLit);

            var bsy = bcy.ToBitString().Format(true);
            var bsx = bcx.ToBitString().Format(true);
            var bsz = bvz.ToBitString().Format(true);
            ClaimPrimalSeq.eq(bsx, sLit);
            ClaimPrimalSeq.eq(bsx, bsy);
            ClaimPrimalSeq.eq(bsx, bsz);


            Claim.eq(y0, bcx.BitSeg(0,3));
            Claim.eq(y1, bcx.BitSeg(4,7));
            Claim.eq(y2, bcx.BitSeg(8,11));
            Claim.eq(y3, bcx.BitSeg(12,15));
            Claim.eq(y4, bcx.BitSeg(16,19));
            Claim.eq(y5, bcx.BitSeg(20,23));
            Claim.eq(y6, bcx.BitSeg(24,27));
            Claim.eq(y7, bcx.BitSeg(28,31));
            Claim.eq(y8, bcx.BitSeg(32,35));
            Claim.eq(y9, bcx.BitSeg(36,39));

            Claim.eq(y0, (byte)bvz.BitSeg(0,3));
            Claim.eq(y1, bvz.BitSeg(4,7));
            Claim.eq(y2, bvz.BitSeg(8,11));
            Claim.eq(y3, bvz.BitSeg(12,15));
            Claim.eq(y4, bvz.BitSeg(16,19));
            Claim.eq(y5, bvz.BitSeg(20,23));
            Claim.eq(y6, bvz.BitSeg(24,27));
            Claim.eq(y7, bvz.BitSeg(28,31));
            Claim.eq(y8, bvz.BitSeg(32,35));
            Claim.eq(y9, bvz.BitSeg(36,39));
        }

        public void bb_extract_40()
        {
            const ulong src = 0b01011_00010_01110_11010_00111_00101_01110_10110ul;
            const byte count = 40;
            var bvz = BitBlocks.single(src, count);
            var xSrc =  bytes(src);
            Claim.eq(8, xSrc.Length);
            Span<ushort> ySrc = xSrc.AsUInt16();
            Claim.eq(8, ySrc.Length*2);
        }

        public void bb_extract_arb()
        {
            ulong src = 0b01011_00010_01110_11010_00111_00101_01110_10110;
            var bvz = BitBlocks.single(src,40);
            var xSrc =  sys.bytes(src);
            Span<ushort> ySrc = xSrc.AsUInt16();
            //Claim.eq(ySrc.Length*4, xSrc.Length);

            var bvx = BitBlocks.load(xSrc.Slice(0,5).ToArray());
            var bvy = BitBlocks.load(ySrc.Slice(0,2).ToArray());
            var bsx = bvx.ToBitString().Format(true);
            var bsz = bvz.ToBitString().Format(true);
            ClaimPrimalSeq.eq(bsx, bsz);

            Claim.eq((byte)0b10110, bvx.TakeScalarBits(0, 4));
            Claim.eq((byte)0b01110, bvx.TakeScalarBits(5, 9));
            Claim.eq((byte)0b00101, bvx.TakeScalarBits(10, 14));
            Claim.eq((byte)0b00111, bvx.TakeScalarBits(15, 19));
            Claim.eq((byte)0b11010, bvx.TakeScalarBits(20, 24));
            Claim.eq((byte)0b01110, bvx.TakeScalarBits(25, 29));

            Claim.eq((ushort)0b10110, bvy.TakeScalarBits(0, 4));
            Claim.eq((ushort)0b01110, bvy.TakeScalarBits(5, 9));
            Claim.eq((ushort)0b00101, bvy.TakeScalarBits(10, 14));
            Claim.eq((ushort)0b00111, bvy.TakeScalarBits(15, 19));
            Claim.eq((ushort)0b11010, bvy.TakeScalarBits(20, 24));
            Claim.eq((ushort)0b01110, bvy.TakeScalarBits(25, 29));

            Claim.eq((ulong)0b10110, bvz.TakeScalarBits(0, 4));
            Claim.eq((ulong)0b01110, bvz.TakeScalarBits(5, 9));
            Claim.eq((ulong)0b00101, bvz.TakeScalarBits(10, 14));
            Claim.eq((ulong)0b00111, bvz.TakeScalarBits(15, 19));
            Claim.eq((ulong)0b11010, bvz.TakeScalarBits(20, 24));
            Claim.eq((ulong)0b01110, bvz.TakeScalarBits(25, 29));
        }
    }
}