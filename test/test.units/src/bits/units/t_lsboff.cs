//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class t_lsboff : t_bits<t_lsboff>
    {
        public void lsboff_8()
            => lsboff_check<byte>();

        public void lsboff_16()
            => lsboff_check<ushort>();

        public void lsboff_32()
            => lsboff_check<uint>();

        public void lsboff_64()
            => lsboff_check<ulong>();

        void lsboff_check<T>(T t = default)
            where T : unmanaged
        {
            for(var i=0; i<RepCount; i++)
            {
                var a = Random.Next<T>();
                var b0 = gbits.lsboff(a);
                var b1 = gmath.and(gmath.sub(a, one<T>()), a);
                Claim.eq(b0, b1);
            }
        }
    }
}
