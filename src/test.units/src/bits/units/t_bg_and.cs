//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MLeftT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_bg_and : t_bits<t_bg_and>
    {
        void bg_and_check<T>(uint m, uint n, T t = default)
            where T : unmanaged, IEquatable<T>
        {
            var gx = Random.BitGrid(m,n,t);
            var gy = Random.BitGrid(m,n,t);
            var gz = BitGrid.alloc(m,n,t);

            base.Claim.eq((uint)gz.BlockCount, (BitVector64)CellCalcs.blockcount<T>(n256, m, n));
            base.Claim.eq((uint)gz.CellCount, (BitVector64)grids.cellcount<T>(m, n));

            BitGrid.and(gx,gy,gz);

            for(var block=0; block<gx.BlockCount; block++)
                Claim.veq(gcpu.vand(gx[block], gy[block]), gz[block]);

        }

        protected void bg_xor_check<T>(uint m, uint n, T t = default)
            where T : unmanaged, IEquatable<T>
        {
            var gx = Random.BitGrid(m,n,t);
            var gy = Random.BitGrid(m,n,t);
            var gz = BitGrid.alloc(m,n,t);

            base.Claim.eq((uint)gz.BlockCount, (BitVector64)CellCalcs.blockcount<T>(n256, m, n));
            base.Claim.eq((uint)gz.CellCount, (BitVector64)grids.cellcount<T>(m, n));

            BitGrid.xor(gx,gy,gz);

            for(var block=0; block<gx.BlockCount; block++)
                Claim.veq(gcpu.vxor(gx[block], gy[block]), gz[block]);
        }
    }
}