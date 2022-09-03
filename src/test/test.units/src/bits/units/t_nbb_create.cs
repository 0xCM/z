//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class t_nbb_create : t_bits<t_nbb_create>
    {
        public void nbb_create_n63x64u()
            => check_nbb_create<N63,ulong>();

        public void nbb_create_n13x16u()
            => check_nbb_create<N13,ushort>();

        public void nbb_create_n32x32u()
            => check_nbb_create<N32,uint>();

         [MethodImpl(Inline), Ignore]
         protected void check_nbb_create<N,T>(N _ = default, T t = default)
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            int n = (int)nat64u<N>();
            var rep = default(N);
            var segcount = (int)CellCalcs.mincells<T>(nat64u<N>());
            Claim.eq(BitBlock<N,T>.RequiredCells, segcount);

            var totalcap = BitBlock<N,T>.RequiredWidth;
            var segcap = (uint)width<T>();
            Claim.eq(BitBlock<N,T>.CellWidth, (BitVector32)segcap);

            var src = Random.Span<T>(RepCount);
            for(var i=0; i<RepCount; i+= segcount)
            {
                var bcSrc = src.Slice(i,segcount);
                var bc = bcSrc.ToNatBits(rep);
                ClaimEqual(bc,bc.ToBitString());
                Claim.eq(n, bc.Width);
                Claim.eq(segcap * segcount, totalcap);

                var x = src[i];
                for(byte j = 0; j<n; j++)
                    ClaimPrimal.eq(gbits.test(x,j), bc[j]);
            }
        }

        /// <summary>
        /// Asserts logical bitvector/bitstring equality
        /// </summary>
        /// <param name="bv">The bitvector to compare</param>
        /// <param name="bs">The bitstring to compare</param>
        /// <typeparam name="N">The vector length type</typeparam>
        /// <typeparam name="S">The vector cell type</typeparam>
        void ClaimEqual<N,S>(BitBlock<N,S> bv, BitString bs)
            where N : unmanaged, ITypeNat
            where S : unmanaged
        {
            var n = (int)(new N().NatValue);
            Claim.eq(bs.Length, n);
            for(var i=0; i<n; i++)
                Claim.eq(bv[i], bs[i]);
        }
    }
}