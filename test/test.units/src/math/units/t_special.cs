//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_special : t_gmath<t_special>
    {
        public void ilog2()
        {
            Claim.eq(math.log2(Pow2.T20),20);
            Claim.eq(math.log2(Pow2.T24),24);
            Claim.eq(math.log2(Pow2.T30),30);
            Claim.eq(math.log2(Pow2.T40),40);
            Claim.eq(math.log2(Pow2.T50),50);
            Claim.eq(math.log2(Pow2.T60),60);
            Claim.eq(math.log2(Pow2.T63),63);
        }
    }
}

