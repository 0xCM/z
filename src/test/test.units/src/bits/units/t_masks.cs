//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;
    using System.Text;

    using static Root;
    using static core;

    public class t_masks : t_bits<t_masks>
    {
        public void lomask_case1()
        {
            Claim.eq((Pow2.pow(3) - 1)^Pow2.pow(3), BitMasks.lo64(3));
            Claim.eq((Pow2.pow(7) - 1)^Pow2.pow(7), BitMasks.lo64(7));
            Claim.eq((Pow2.pow(13) - 1)^Pow2.pow(13), BitMasks.lo64(13));
            Claim.eq((Pow2.pow(25) - 1)^Pow2.pow(25), BitMasks.lo64(25));
            Claim.eq((Pow2.pow(59) - 1)^Pow2.pow(59), BitMasks.lo64(59));
        }

        public void lomask_case2()
        {
            Claim.eq((byte)4, bits.pop(BitMasks.lo64(3)));
            Claim.eq((byte)7, bits.pop(BitMasks.lo64(6)));
            Claim.eq((byte)13, bits.pop(BitMasks.lo64(12)));
            Claim.eq((byte)25, bits.pop(BitMasks.lo64(24)));
            Claim.eq((byte)59, bits.pop(BitMasks.lo64(58)));
        }

        public void lomask_case3()
        {
            var lomask = BitMasks.lo<uint>(6);
            var himask = BitMasks.hi<uint>(8);
            var src = uint.MaxValue;
            var dst = gmath.xor(gmath.xor(src,lomask), himask);
            Claim.eq((byte)7, bits.ntz(dst));
            Claim.eq((byte)8, bits.nlz(dst));

            Claim.eq(7, bits.pop(BitMasks.lo<uint>(6)));
            Claim.eq(12, bits.pop(BitMasks.lo<uint>(11)));
        }

        public void himask_8u()
            => check_himask(z8);

        public void himask_16u()
            => check_himask(z16);

        public void himask_32u()
            => check_himask(z32);

        public void himask_64u()
            => check_himask(z64);

        void check_himask<T>(T t = default)
            where T : unmanaged
        {
            var mincount = 1;
            var maxcount = (int)width<T>();
            for(var i=0; i< RepCount; i++)
            {
                var count = Random.Next(mincount,maxcount);
                var mask = BitMasks.hi<T>(count);
                var pop = gbits.pop(mask);
                if(pop != count)
                {
                    Trace("count", count.ToString());
                    Trace("popcount", pop.ToString());
                    Trace("mask", BitStrings.scalar(mask).Format());
                }

                Claim.eq(count, gbits.pop(mask));

                var lowered = gmath.srl(mask, (byte)(width<T>() -  count));
                var width = gbits.effwidth(lowered);
                if(count != width)
                {
                    Trace("mask", BitStrings.scalar(mask).Format());
                    Trace("lowered", BitStrings.scalar(lowered).Format());
                }
                Claim.eq(count, width);
            }
        }
    }
}