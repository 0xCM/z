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

        public void nbg_transpose_16x4()
        {
            var w = n64;
            var m = n16;
            var n = n4;
            var t = z64;

            for(var i=0; i<RepCount;i++)
            {
                var g = Random.BitGrid(m,n,t);
                var tr1 = BitGrid.transpose(g);
                var tr2 = BitGrid.transpose2(g);
                var tr3 = g.ToBitString().Transpose(m,n).ToBitGrid(w,n,m,t);

                if(tr1 != tr3)
                {
                    Notify(tr1.Format());
                    Notify("!=");
                    Notify(tr3.Format());
                    Claim.fail();
                }

                if(tr1 != tr2)
                {
                    Notify(tr1.Format());
                    Notify("!=");
                    Notify(tr2.Format());
                    Claim.fail();
                }
            }
        }
    }
}