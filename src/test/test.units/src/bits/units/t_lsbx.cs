//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_lsbx : t_bits<t_lsbx>
    {
        public void xlsb_outline()
        {
            //lsbx is an identity function over a domain consisting of powers of 2
            for(byte i = 0; i< 64; i++)
                Claim.eq(Pow2.pow(i), gbits.xlsb(Pow2.pow(i)));
        }

        public void lsbx_8()
            => lsbx_check<byte>();

        public void lsbx_16()
            => lsbx_check<ushort>();

        public void lsbx_32()
            => lsbx_check<uint>();

        public void lsbx_64()
            => lsbx_check<ulong>();

        protected void lsbx_check<T>(T t = default)
            where T : unmanaged
        {

            for(var i=0; i<RepCount; i++)
            {
                var src = Random.Next<T>();
                var x = gbits.xlsb(src);
                var y = gmath.and(src, gmath.negate(src));
                Claim.eq(x,y);
            }
        }
    }
}