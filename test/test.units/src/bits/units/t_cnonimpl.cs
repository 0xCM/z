//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_cnonimpl : t_bits<t_cnonimpl>
    {
        public void cnonimpl_8u()
            => cnonimpl_check<byte>();

        public void cnonimpl_16u()
            => cnonimpl_check<ushort>();

        public void cnonimpl_32u()
            => cnonimpl_check<uint>();

        public void cnonimpl_64u()
            => cnonimpl_check<ulong>();

        void cnonimpl_check<T>(T t = default)
            where T : unmanaged
        {
            var vZero = gcpu.vzero<T>(n128);
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.Next<T>();
                var y = Random.Next<T>();
                var z1 = gmath.cnonimpl(x, y);
                var z2 = gmath.and(x,gmath.not(y));
                Claim.eq(z1,z2);
            }
        }
    }
}