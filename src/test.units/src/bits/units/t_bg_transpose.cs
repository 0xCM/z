//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_bg_transpose : t_bits<t_bg_transpose>
    {
        public void bg_transpose_256x16x16()
        {
            var w = n256;
            var m = n16;
            var n = n16;
            var t = z16;
            ushort pattern = 0b1100110011001100;

            var g = BitGrid.broadcast(pattern, BitGrid.zero(w,m,n,t));
            var gT = BitGrid.transpose(g);
            var bsT = g.ToBitString().Transpose(m,n).ToBitGrid(w,m,n,t);

            var g1 = gT.ToBitString();
            var g2 = bsT.ToBitString();
            Claim.eq(g1,g2);
        }
    }
}