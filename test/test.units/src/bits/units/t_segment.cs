//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public class t_segment : t_bits<t_segment>
    {
        // public void segment_outline()
        // {
        //     const ulong U64_00 = 0b00001001_11110000_11001001_10011111_00010001_10111100_00111000_11110000;
        //     const uint U32_01 = 0b00001001_11110000_11001001_10011111;

        //     Span<byte> dst = stackalloc byte[8];

        //     var r1 = gbits.segment(U64_00, 0, 7);
        //     PrimalClaims.eq((byte)0b11110000, r1);

        //     gbits.segment(U64_00, 0, 7, dst, 0);
        //     PrimalClaims.eq((byte)0b11110000, dst[0]);

        //     gbits.segment(U64_00, 8, 15, dst, 0);
        //     PrimalClaims.eq((byte)0b00111000, dst[0]);

        //     gbits.segment(U64_00, 4, 7, dst, 0);
        //     PrimalClaims.eq((byte)0b1111, dst[0]);

        //     gbits.segment(U64_00, 4, 6, dst, 1);
        //     PrimalClaims.eq((byte)0b111, dst[1]);

        //     gbits.segment(U32_01, 7, 8, dst, 2);
        //     PrimalClaims.eq((byte)0b11, dst[2]);
        // }

        public void segment_32u()
        {
            for(var i=0; i< RepCount; i++)
            {
                var x = Random.Next<uint>();
                bits.split(x,out var x0, out var x1);

                var y0 = gbits.extract(x, 0, 15);
                var y1 = gbits.extract(x, 16, 31);
                PrimalClaims.eq(y0,x0);
                PrimalClaims.eq(y1,x1);
            }
        }

        public void segment_64u()
        {
            for(var i=0; i< RepCount; i++)
            {
                var x = Random.Next<ulong>();
                bits.split(x, out var x0, out var x1);
                var y0 = gbits.extract(x, 0, 31);
                var y1 = gbits.extract(x, 32, 63);

                PrimalClaims.eq(y0,x0);
                PrimalClaims.eq(y1,x1);
            }
        }

        public void segment_16u()
        {
            for(var i=0; i< RepCount; i++)
            {
                var x = Random.Next<ushort>();

                var x0 = gbits.extract(x,0, 2);
                var x1 = gmath.sll(gbits.extract(x,3, 5),3);
                var x2 = gmath.sll(gbits.extract(x,6, 8),6);
                var x3 = gmath.sll(gbits.extract(x,9, 11),9);
                var x4 = gmath.sll(gbits.extract(x,12, 14),12);
                var x5 = gmath.sll(gbits.extract(x,15, 15),15);
                var y = x0;
                y |= x1;
                y |= x2;
                y |= x3;
                y |= x4;
                y |= x5;
                PrimalClaims.eq(x,y);
            }
        }
    }
}