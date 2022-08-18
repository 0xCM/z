//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class t_eqz : UnitTest<t_eqz>
    {
        public void check_eqz_u32()
        {
            for(uint i=0; i<RepCount; i++)
            for(uint j=0; j<RepCount; j++)
            {
                var result = math.eqz(i,j);
                if( i != j)
                    Claim.eq(result,0);
                else
                    Claim.eq(result, LimitValues.Max32u);
            }
        }
    }
}