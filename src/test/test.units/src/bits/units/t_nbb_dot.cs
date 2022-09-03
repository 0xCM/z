//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiComplete]
    public class t_nbb_dot : t_bits<t_nbb_dot>
    {
        static NatSeq<N2,N1,N7> n217 => default;

        public void nbb_dot_8x8()
            => bitblock_dot_check<N8,byte>();

        public void nbb_dot_16x16()
            => bitblock_dot_check<N16,ushort>();

        public void nbb_dot_32x32()
            => bitblock_dot_check<N32,uint>();

        public void nbb_dot_64x64()
            => bitblock_dot_check<N64,ulong>();

        public void nbb_dot_10x32()
            => bitblock_dot_check<N10,uint>();

        public void nbb_dot_20x32()
            => bitblock_dot_check<N20,uint>();

        public void nbb_dot_25x32()
            => bitblock_dot_check<N25,uint>();

        public void nbb_dot_63x64()
            => bitblock_dot_check<N63,ulong>();

        public void nbb_dot_64x8()
            => bitblock_dot_check<N63,byte>();

        public void nbb_dot_128x16()
            => bitblock_dot_check<N128,ushort>();

        public void nbb_dot_217x16()
            => bitblock_dot_check(n217, z16);

        public void nbb_dot_217x32()
            => bitblock_dot_check(n217, z32);

        public void nbb_dot_217x64()
            => bitblock_dot_check(n217, z64);

        public void nbb_dot_256x32()
            => bitblock_dot_check(n256, z32);

        public void nbb_dot_256x64()
            => bitblock_dot_check(n256, z64);

        /// <summary>
        /// Verifies the natural bit cell dot product operation
        /// </summary>
        /// <param name="n">The bitvector width</param>
        /// <param name="zero">A scalar representative</param>
        /// <typeparam name="N">The bitvector width type</typeparam>
        /// <typeparam name="T">The scalar type</typeparam>
        [MethodImpl(Inline), Ignore]
        protected void bitblock_dot_check<N,T>(N n = default, T zero = default)
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.BitBlock<N,T>();
                var y = Random.BitBlock<N,T>();
                bit a = x % y;
                var b = BitBlocks.modprod(x,y);
                if(a != b)
                    Notify($"nbc {n}x{TypeIdentity.numeric<T>()} is a problem");
                Claim.require(a == b);
            }
        }
    }
}