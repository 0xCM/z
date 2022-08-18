//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_bitrev : t_bits<t_bitrev>
    {
        public void bitrev_8()
            => bitrev_check<byte>();

        public void bitrev_16()
            => bitrev_check<ushort>();

        public void bitrev_32()
            => bitrev_check<uint>();

        public void bitrev_64()
            => bitrev_check<ulong>();

         protected void bitrev_check<T>(T t = default)
            where T : unmanaged
        {
            for(var i=0; i<RepCount; i++)
            {
                var src = Random.Next<T>();
                var r1 = gbits.reverse(src);
                var r2 = BitStrings.scalar(src).Reverse().TakeScalar<T>();
                Claim.eq(r1,r2);
            }
        }
    }
}