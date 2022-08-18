//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_stitch : t_bits<t_stitch>
    {
        public void stitch_basecases()
        {
            void case1()
            {
                var x = 0b001111u;
                var y = 0b11111100000000u;
                var z = 0b1111111111;
                var s = gbits.stitch(x,2,y,2);
                Claim.eq(z,s);
            }

            void case2()
            {
                byte x = 0b00000011;
                byte y = 0b00110000;
                byte z = 0b1111;
                var s = gbits.stitch(x, 1, y, 1);
                Claim.eq(z, s);
            }

            case1();
            case2();

        }

        public void split_basecases()
        {
            var src = 0b11111111_10101010_11111111_11111111_10101010_11111111_11100111_11111111;
            bits.split(src, 24, out var x0, out var x1);
            var y0 = 0b11111111_11100111_11111111ul;
            var y1 = 0b11111111_10101010_11111111_11111111_10101010ul;

            Claim.eq(x0,y0);
            Claim.eq(x1,y1);

            void report()
            {
                Trace("00", src.FormatBits());
                Trace("in  lo", x0.FormatBits());
                Trace("out lo", y0.FormatBits());
                Trace("in  hi", x1.FormatBits());
                Trace("out hi", y1.FormatBits());
            }

        }
    }
}