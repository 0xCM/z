//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static BitNumbers;

    public class t_quartet : UnitTest<t_quartet>
    {
        public void add_4u_check()
        {
            var x = uint4(3u) + uint4(5u);
            Claim.eq(8u, x);

            var y = uint4(10u) + uint4(5u);
            Claim.eq(uint4.Max,y);
        }

        public void inc_4u_check()
        {
            var i = uint4.Min;
            i++;
            i++;
            i++;
            i++;
            Claim.eq(i, 4u);

            i++;
            i++;
            i++;
            i++;
            Claim.eq(i, 8u);

            i++;
            i++;
            i++;
            i++;
            Claim.eq(i, 12u);

            i++;
            i++;
            i++;
            i++;
            Claim.eq(i, uint4.Min);

        }

        public void dec_4u_check()
        {
            var i = uint4.Max;
            i--;
            i--;
            i--;
            i--;
            Claim.eq(i, uint4.Max - 4);

            i--;
            i--;
            i--;
            i--;
            Claim.eq(i, uint4.Max - 8);

            i--;
            i--;
            i--;
            i--;
            Claim.eq(i, uint4.Max - 12);

            i--;
            i--;
            i--;
            i--;
            Claim.eq(i,uint4.Max);

        }

        public void uint4_create()
        {
            var x0 = (uint4)0;
            byte y0 = x0;
            var z0 = (byte)0;
            Claim.eq(y0,z0);

            var x1 = (uint4)5;
            byte y1 = x1;
            var z1 = (byte)5;
            Claim.eq(y1,z1);

            var x2 = join(bit.On, bit.Off, bit.On, bit.On);
            byte y2 = x2;
            var z2 = (byte)0b1101;
            Claim.eq(y2,z2);

            var x3 = join(bit.On, bit.Off, bit.On, bit.On);
            byte y3 = x3;
            var z3 = (byte)0b1101;
            Claim.eq(y3,z3);

            var x4 = uint4((byte)0);
            Claim.eq(x4,(byte)0);

            byte y4 = x4;
            var z4 = (byte)0;
            Claim.eq(y4,z4);

        }

        public void uint4_format()
        {
            var x0 = (uint4)0;
            var x1 = (uint4)1;
            var x2 = (uint4)2;
            var x3 = (uint4)3;
            ClaimPrimalSeq.eq(x0.Format(), "0000");
            ClaimPrimalSeq.eq(x1.Format(), "0001");
            ClaimPrimalSeq.eq(x2.Format(), "0010");
            ClaimPrimalSeq.eq(x3.Format(), "0011");
        }

        public void uint4_inc()
        {
            var x = (uint4)7;
            for(var i=0; i< 3; i++)
                x++;

            Claim.eq((uint4)10,x);

            for(var i=0; i< 3; i++)
                x++;

            Claim.eq((uint4)13,x);

            for(var i=0; i< 3; i++)
                x++;

            Claim.eq((uint4)0,x);

        }

        public void uint4_dec()
        {
            var x = (uint4)7;
            for(var i=0; i< 3; i++)
                x--;

            Claim.eq((uint4)4,x);

            for(var i=0; i< 3; i++)
                x--;

            Claim.eq((uint4)1,x);

            for(var i=0; i< 3; i++)
                x--;

            Claim.eq((uint4)14,x);

        }

        public void uint4_flip()
        {
            var x0 = (uint4)0b1011;
            var y0 = ~x0;
            var z0 = (uint4)0b0100;
            Claim.eq(y0,z0);
        }

        public void uint4_add()
        {
            var x1 = (uint4)3;
            var x2 = (uint4)4;
            var y0 = (uint4)7;
            var z0 = (uint4)10;
            var z1 = (uint4)1;
            Claim.eq(y0, x1 + x2);
            Claim.eq(z0, y0 + x1);
            Claim.eq(z1, z0 + y0);

        }
    }
}