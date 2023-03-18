//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiComplete]
    public class t_bg_permute : t_bits<t_bg_permute>
    {
        public void bg_permute_32x5()
        {
            var p = Permute.natural(n32);
            Claim.eq(p.Length,32);
        }

        public void bg_permute_16x4()
        {
            var identity = Permute.identity(n16);
            var symbols =  Permute.symbols(identity);
            var g1 = identity.ToBitGrid();
            var nP = identity.ToNatural();
            var g2 = nP.ToBitGrid();
            Claim.require(g1 == g2);

        }

        public void bg_permute_8x3()
        {
            var id = Permute.identity(n8);
            var symbols = Permute.symbols(id);
            var g1 = id.ToSubGrid();
            var nP = id.ToNatural();
            var g2 = nP.ToSubGrid();
            Claim.yea(g1 == g2);
        }

        public void perm_8x32_digits()
        {
            var symbols = NatSpans.parts(n8, Perm8L.B, Perm8L.A, Perm8L.D, Perm8L.C, Perm8L.F, Perm8L.E, Perm8L.H, Perm8L.G);
            var spec = Permute.assemble(symbols[0], symbols[1], symbols[2], symbols[3], symbols[4], symbols[5], symbols[6], symbols[7]);

            //[o1, o0, o3, o2, o5, o4, o7, o6]
            var digits = spec.ToDigits();
            for(var i =0; i<8; i++)
                Claim.eq((uint)symbols[i], (uint)digits[i]);
        }

        // public void bg_perm_8x32_bits()
        // {
        //     var p1 = Permute.identity(n8);
        //     var v1 = BitVector24.FromEnum(p1);
        //     var p1F = p1.ToBitString(24).Format(3);
        //     var v1F = v1.Format(3);
        //     Claim.eq(p1F, v1F);

        //     var p2 = Permute.reversed(n8);
        //     var p2F = p2.ToBitString(24).Format(3);
        //     var v2 = BitVector24.FromEnum(p2);
        //     var v2F = v2.Format(3);
        //     Claim.eq(p2F, v2F);
        //     Claim.require(v2.ToSubGrid(n8,n3) == p2.ToSubGrid());
        // }
    }
}