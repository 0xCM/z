//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_gather : t_bits<t_gather>
    {
        public void gather_masks()
        {
            var m2 = BitMaskLiterals.Lsb32x8x1;
            var x2 = bits.gather(UInt32.MaxValue, m2);
            var y2 = bits.scatter(x2, m2).ToBitVector32();
            var bv = m2.ToBitVector32();

            Claim.eq(y2.State, bv.State);
            for(var i=0; i<y2.Width; i++)
                Claim.eq(y2[i], i % 8 == 0 ? bit.On : bit.Off);
        }

        public void gather_8()
            => gather_check<byte>();

        public void gather_16()
            => gather_check<ushort>();

        public void gather_32()
            => gather_check<uint>();

        public void gather_64()
            => gather_check<ulong>();

        void gather_check<T>(T t = default)
            where T : unmanaged
        {
            for(var i=0; i<RepCount; i++)
            {
                var src = Random.Next<T>();
                var mask = Random.Next<T>();
                Claim.eq(BitRefs.gather(src, mask), gbits.gather(src, mask));
            }
        }
    }
}