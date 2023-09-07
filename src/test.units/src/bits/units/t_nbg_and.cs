//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_nbg_and : t_bits<t_nbg_and>
    {
        public void nbg_and_n8x8x8()
            => nbg_and_check(n8,n8,z8);

        public void nbg_and_n8x16x8()
            => nbg_and_check(n8,n16,z8);

        public void nbg_and_n50x50x16()
            => nbg_and_check(n50,n50,z16);

        public void nbg_and_n51x51x8()
            => nbg_and_check(n51,n51,z8);

        public void nbg_and_n64x64x16()
            => nbg_and_check(n64,n64,z16);

        public void nbg_and_n256x128x64()
            => nbg_and_check(n256,n128,z64);

        public void nbg_and_n64x128x32()
            => nbg_and_check(n64,n128,z32);

        public void nbg_and_n64x64x64()
            => nbg_and_check(n64,n64,z64);

        public void nbg_and_g8x8x8()
            => nbg_and_check(n8, n8, z8);

        public void nbg_and_8x16x8()
            => nbg_and_check(n8, n16, z8);

        public void nbg_and_g50x50x16()
            => nbg_and_check(n50, n50, z16);

        public void nbg_and_g64x64x16()
            => nbg_and_check(n64, n64, z16);

        public void nbg_and_256x128x64()
            => nbg_and_check(n256, n128, z64);

        public void nbg_and_g64x128x32()
            => nbg_and_check(n64, n128, z32);

        public void nbg_and_g64x64x64()
            => nbg_and_check(n64, n64, z64);

        public void nbg_and_g256x256x64()
            => nbg_and_check(n256, n256, z64);

        public void nbg_and_g512x512x64()
            => nbg_and_check(n512, n512, z64);

        public void nbg_and_1024x1024x64()
            => nbg_and_check(n1024, n1024, z64);

        void nbg_and_check<M,N,T>(M m = default, N n = default, T t = default)
            where M : unmanaged,ITypeNat
            where N : unmanaged,ITypeNat
            where T : unmanaged
        {
            var gx = Random.BitGrid(m,n,t);
            var gy = Random.BitGrid(m,n,t);
            var gz = BitGrid.alloc(m,n,t);

            base.Claim.eq((uint)gz.BlockCount, (BitVector64)CellCalcs.blockcount(n256, m, n, t));
            base.Claim.eq((uint)gz.CellCount, (BitVector64)grids.gridcells(m, n, t));

            BitGrid.and(gx,gy,gz);

            for(var block=0; block<gx.BlockCount; block++)
                Claim.veq(gcpu.vand(gx[block], gy[block]), gz[block]);
        }
   }
}