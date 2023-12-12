//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_nbg_xor : t_bits<t_nbg_xor>
    {
        public void nbg_xor_8x8x8()
            => nbg_xor_check(n8,n8,z8);

        public void nbg_xor_8x16x8()
            => nbg_xor_check(n8,n16,z8);

        public void nbg_xor_50x50x16()
            => nbg_xor_check(n50,n50,z16);

        public void nbg_xor_64x64x16()
            => nbg_xor_check(n64,n64,z16);

        public void nbg_xor_256x128x64()
            => nbg_xor_check(n256,n128,z64);

        public void nbg_xor_64x128x32()
            => nbg_xor_check(n64,n128,z32);

        public void nbg_xor_64x64x64()
            => nbg_xor_check(n64,n64,z64);

        public void nbg_xor_1024x1024x32()
            => nbg_xor_check(n1024,n1024,z32);

        public void nbg_xor_1024x1024x64()
            => nbg_xor_check(n1024,n1024,z64);

        protected void nbg_xor_check<M,N,T>(M m = default, N n = default, T t = default)
            where M : unmanaged,ITypeNat
            where N : unmanaged,ITypeNat
            where T : unmanaged, IEquatable<T>
        {
            var gx = Random.BitGrid(m,n,t);
            var gy = Random.BitGrid(m,n,t);
            var gz = BitGrid.alloc(m,n,t);

            base.Claim.eq((uint)gz.BlockCount, (BitVector64)CellCalcs.blockcount(n256, m, n, t));
            base.Claim.eq((uint)gz.CellCount, (BitVector64)grids.cellcount(m, n, t));

            BitGrid.xor(gx,gy,gz);

            for(var block=0; block<gx.BlockCount; block++)
                Claim.veq(gcpu.vxor(gx[block], gy[block]), gz[block]);
        }
   }
}