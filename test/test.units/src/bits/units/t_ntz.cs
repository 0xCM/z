//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class t_ntz : t_bits<t_ntz>
    {
        public void ntz_outline()
        {
            Claim.eq((byte)3, bits.ntz((byte)0b111000));
            Claim.eq(2u, bits.ntz(0b0001011000100u));
            Claim.eq(5u, bits.ntz(0b000101100000u));
            Claim.eq(3ul, bits.ntz(Pow2.pow(3)));
        }

        public void ntz_8()
            => ntz_check<byte>();

        public void ntz_16()
            => ntz_check<ushort>();

        public void ntz_32()
            => ntz_check<uint>();

        public void ntz_64()
            => ntz_check<ulong>();

        protected void ntz_check<T>()
            where T : unmanaged
        {
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.Next<T>();
                var ntzX = gbits.ntz(x);
                var y = BitSpans.ntz(BitSpans.create(x));
                var ntzY = generic<T>(y);
                Claim.eq(ntzX, ntzY);
            }
        }
    }
}