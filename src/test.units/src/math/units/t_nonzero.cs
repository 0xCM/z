//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_nonzero : t_numeric<t_nonzero>
    {
        public void nonzero_create()
        {
            NonZero<uint> a = 0u;
            NonZero<byte> b = 5;
            Claim.nonzero(a.Value);
            Claim.eq(b, (byte)5);
        }
    }
}