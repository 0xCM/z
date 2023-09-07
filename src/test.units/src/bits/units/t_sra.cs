//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;

    using static sys;
    using static Intervals;

    public class t_sra : t_bits<t_sra>
    {
        /// <summary>
        /// Applies an action to the increasing sequence of integers 0,1,2,...,count - 1
        /// </summary>
        /// <param name="count">The number of times the action will be invoked
        /// <param name="f">The action to be applied to each value</param>
        [Op]
        public static void iteri(int count, Action<int> f, bool pll = false)
        {
            if(pll)
                gcalc.stream(0,count-1).AsParallel().ForAll(i => f(i));
            else
                for(var i = 0; i<count; i++)
                    f(i);
        }

        public void bs_sra_8i_check()
            => bs_sra_check<sbyte>();

        public void bs_sra_8u_check()
            => bs_sra_check<byte>();

        public void bs_sra_16i_check()
            => bs_sra_check<short>();

        public void bs_sra_16u_check()
            => bs_sra_check<ushort>();

        public void bs_sra_32i_check()
            => bs_sra_check<int>();

        public void bs_sra_32u_check()
            => bs_sra_check<uint>();

        public void bs_sra_64i_check()
            => bs_sra_check<long>();

        public void bs_sra_64u_check()
            => bs_sra_check<ulong>();

        public void sb_sal_8i()
        {
            var src = Random.Array<sbyte>(RepCount);
            var offset = Random.Array(RepCount, closed((byte)0, (byte)width<sbyte>()));
            iteri(RepCount, i => Claim.eq((sbyte)(src[i] << offset[i]), gmath.sal(src[i], offset[i])));
        }

        public void sb_sal_8u()
        {
            var src = Random.Array<byte>(RepCount);
            var offset = Random.Array(RepCount, closed((byte)0, (byte)width<byte>()));
            iteri(RepCount,
                i => PrimalClaims.eq((byte)(src[i] << offset[i]), gmath.sal(src[i], offset[i])));
        }

        public void sb_sra_8i()
        {
            var src = Random.Array<sbyte>(RepCount);
            var offset = Random.Array(RepCount, closed((byte)0, (byte)width<sbyte>()));
            iteri(RepCount, i => Claim.eq((sbyte)(src[i] >> offset[i]), gmath.sra(src[i], offset[i])));
        }

        public void sb_sal_32i()
        {
            var src = Random.Array<int>(RepCount);
            var offset = Random.Array(RepCount, closed((byte)0, (byte)width<int>()));
            iteri(RepCount, i => Claim.eq(src[i] << offset[i], gmath.sal(src[i], offset[i])));
        }

        public void sb_sra_32i()
        {
            var src = Random.Array<int>(RepCount);
            var offset = Random.Array(RepCount, closed((byte)0, (byte)width<int>()));
            iteri(RepCount, i => Claim.eq(src[i] >> offset[i], gmath.sra(src[i], offset[i])));
        }

        public void sb_sal_64i()
        {
            var src = Random.Array<long>(RepCount);
            var offset = Random.Array(RepCount, closed((byte)0, (byte)width<ulong>()));
            iteri(RepCount, i => Claim.eq(src[i] << offset[i], gmath.sal(src[i], offset[i])));
        }

        public void sb_sra_64i()
        {
            var src = Random.Array<long>(RepCount);
            var offset = Random.Array(RepCount, closed((byte)0, (byte)width<long>()));
            iteri(RepCount, i => Claim.eq(src[i] >> offset[i], gmath.sra(src[i], offset[i])));
        }

        protected void bs_sra_check<T>()
            where T : unmanaged
        {
            var signed = NumericKinds.signed<T>();
            var bitsize = (int)width<T>();
            var bs10 = BitStrings.parse("1" + Arrays.replicate('0', bitsize - 1).Concat());
            var x10 = bs10.TakeScalar<T>();
            var bs11 = BitStrings.parse("11" + Arrays.replicate('0', bitsize - 2).Concat());
            var x11 = bs11.TakeScalar<T>();
            var bs01 = BitStrings.parse("01" + Arrays.replicate('0', bitsize - 2).Concat());
            var x01 = bs01.TakeScalar<T>();
            var y = gmath.sra(x10, 1);
            if(signed)
                Claim.eq(x11, y);
            else
                Claim.eq(x01, y);
        }
    }
}
