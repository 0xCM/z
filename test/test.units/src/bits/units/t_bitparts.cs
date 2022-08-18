//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public class t_bitparts : t_bits<t_bitparts>
    {
        // public void bitpart_64x1()
        // {
        //     var src = ulong.MaxValue;
        //     Span<bit> dst = new bit[64];
        //     BitPack.pack64x1(src, dst);
        //     for(var i=0; i< dst.Length; i++)
        //         Claim.require(dst[i]);
        // }

        public void bitpart_16x4()
        {
            var n = n4;
            var t = z8;
            var src = BitMasks.msb(n2,n1,z16);
            var dst = NatSpans.alloc(n,t);
            BitPack.unpack4x4(src, ref dst.First);
            var segment = ScalarCast.uint8(0b1010).ToBitSpan32();
            var expect = segment.Replicate(4);
            var actual = dst.Edit.ToBitSpan32();
            Claim.require(expect.Equals(actual));

        }

        public void bitpart_24x3()
        {
            var n = n8;
            var t = z8;

            var src = uint.MaxValue;
            var dst = NatSpans.alloc(n,t);

            BitPack.unpack3x8(src, ref dst.First);
            for(var i=0; i<n; i++)
                Claim.eq(dst[i],(byte)7);
        }

        public void bitpart_27x3()
        {
            var n = n9;
            var t = z8;

            var src = uint.MaxValue;
            var dst = NatSpans.alloc(n,t);

            BitPack.unpack3x9(src, ref dst.First);

            var expect = BitSpans32.parse("000001110000011100000111000001110000011100000111000001110000011100000111");
            var actual = dst.Edit.ToBitSpan32();

            Notify(expect.Format());
            Notify(actual.Format());

            for(var i=0; i<n; i+= 3)
            {
                PrimalClaims.eq((byte)expect[i], actual[i]);
                PrimalClaims.eq((byte)expect[i+1], actual[i+1]);
                PrimalClaims.eq((byte)expect[i+2], actual[i+2]);
            }
        }

        public void bitpart_30x3()
        {
            var n = n10;
            var t = z8;

            var src = uint.MaxValue;
            var dst = NatSpans.alloc(n,t);

            BitPack.unpack3x10(src, ref dst.First);
            for(var i=0; i<n; i++)
                Claim.eq(dst[i],(byte)7);
        }

        public void bitpart_63x3()
        {
            var n = n21;
            var t = z8;

            var src = ulong.MaxValue;
            var dst = NatSpans.alloc(n,t);
            BitPack.unpack3x21(src, ref dst.First);
            for(var i=0; i<n; i++)
                Claim.eq(dst[i],(byte)7);
        }
        protected void bitpart_check<A,B>(SpanPartitioner<A,B> part, int count, int width)
            where A : unmanaged
            where B : unmanaged
        {
            Span<B> dst = stackalloc B[count];

            for(var sample = 0; sample < RepCount; sample++)
            {
                var x = Random.Next<A>();
                part(x, dst);
                var y = BitStrings.scalar(x).Partition(width).Map(bs => bs.ToBitVector(n8));
                for(var i=0; i<count; i++)
                    Claim.eq(y[i], BitStrings.scalar(dst[i]).ToBitVector(n8));
            }
        }
    }
}