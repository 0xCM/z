//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class t_bitspan_and : t_bits<t_bitspan_and>
    {
        public override bool Enabled => true;

        public void bitsspan_and_8()
            => bsand_check<byte>();

        public void bitsspan_and_16()
            => bsand_check<ushort>();

        public void bitsspan_and_32()
            => bsand_check<uint>();

        public void bitsspan_and_64()
            => bsand_check<ulong>();

        void bsand_check<T>()
            where T : unmanaged
        {
            var n = width<T>();
            for(var rep = 0u; rep <= RepCount; rep++)
            {
                var x = Random.BitSpan32(n);
                var y = Random.BitSpan32(n);
                var z = x & y;
                var a = x.Extract<T>();
                var b = y.Extract<T>();
                var c = gmath.and(a, b);
                Claim.eq(c, z.Extract<T>());
            }
        }
    }
}