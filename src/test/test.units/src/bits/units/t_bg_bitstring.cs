//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_bg_bitstring : t_bits<t_bg_bitstring>
    {
        public void nbg_bitstring_11x3x16()
            => nbg_bitstring_check(n11,n3, z16);

        public void nbg_bitstring_64x4x8()
            => nbg_bitstring_check(n64,n4, z8);

        public void nbg_bitstring_113x201x64()
            => nbg_bitstring_check(TypeNats.seq(n1,n1,n3), TypeNats.seq(n2,n0,n1), z64);

        /// <summary>
        /// Verifies correct function of the natural bitgrid bitstring conversion
        /// </summary>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The column count representative</param>
        /// <param name="zero">The cell representative</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The storage cell type</typeparam>
        public void nbg_bitstring_check<M,N,T>(M m = default, N n = default, T zero = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            for(var sample = 0; sample<RepCount; sample++)
            {
                var bg = BitGrid.alloc(m,n,zero);
                var bs = Random.BitString((int)NatCalc.mul(m,n));
                var count = bs.Length;

                for(var i=0u; i<count; i++)
                    bg.SetBit(i, bs[i]);

                Claim.eq(bg.ToBitString(), bs);
            }
        }
    }
}