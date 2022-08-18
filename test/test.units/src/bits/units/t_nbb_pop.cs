//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_nbb_pop : t_bits<t_nbb_pop>
    {
        public void gbb_pop_64()
        {
            const int bitlen = 128;
            const int bytelen = 128/8;

            for(var i=0; i<RepCount; i++)
            {
                var bc = Random.BitBlock<ulong>(bitlen);
                var bcpop = bc.Pop();
                var expect = 0ul;
                var bcbytes = bc.Bytes;
                for(var j=0; j< bcbytes.Length; j++)
                    expect += bits.pop(bcbytes[j]);
                Claim.eq(expect, bcpop);
            }

        }

        public void nbb_pop_8x8()
            => bitblock_pop_check<N8,byte>();

        public void nbb_pop_9x8()
            => bitblock_pop_check<N9,byte>();

        public void nbb_pop_16x8()
            => bitblock_pop_check<N16,byte>();

        public void nbb_pop_31x8()
            => bitblock_pop_check<N31,byte>();

        public void nbb_pop_10x16()
            => bitblock_pop_check<N10,ushort>();

        public void nbb_pop_11x16()
            => bitblock_pop_check<N11,ushort>();

        public void nbb_pop_16x16()
            => bitblock_pop_check<N16,ushort>();

        public void nbb_pop_64x16()
            => bitblock_pop_check<N64,ushort>();

        public void nbb_pop_128x16()
            => bitblock_pop_check<N128,ushort>();

        public void nbb_pop_256x16()
            => bitblock_pop_check<N256,ushort>();

        public void nbb_pop_512x16()
            => bitblock_pop_check<N512,ushort>();

        public void nbb_pop_1024x16()
            => bitblock_pop_check<N1024,ushort>();

        public void nbb_pop_2048x16()
            => bitblock_pop_check<N2048,ushort>();

        public void nbb_pop_4096x16()
            => bitblock_pop_check<N4096,ushort>();

        public void nbb_pop_8192x16()
            => bitblock_pop_check<N8192,ushort>();

        public void nbb_pop_16384x16()
            => bitblock_pop_check<N16384,ushort>();

        public void nbb_pop_64x64()
            => bitblock_pop_check<N64,ulong>();

        public void nbb_pop_256x64()
            => bitblock_pop_check<N256,ulong>();

        public void nbb_pop_512x64()
            => bitblock_pop_check<N512,ulong>();

        public void nbb_pop_1024x64()
            => bitblock_pop_check<N1024,ulong>();

        public void nbb_pop_2048x64()
            => bitblock_pop_check<N2048,ulong>();

        public void nbb_pop_4096x64()
            => bitblock_pop_check<N4096,ulong>();

        public void nbb_pop_8192x64()
            => bitblock_pop_check<N8192,ulong>();

        public void nbb_pop_16384x64()
            => bitblock_pop_check<N16384,ulong>();

        void bitblock_pop_check<N,T>(N n = default)
            where T : unmanaged
            where N : unmanaged, ITypeNat
        {

            // var dst = BitBlocks.alloc<N,T>();
            // Random.Fill(dst.Data);
            // var bbPop = dst.Pop();
            // var bs = BitSpans.create(dst.Data);
            // var bsPop = bs.Pop();
            //Claim.eq(bbPop, bsPop);
        }
    }
}