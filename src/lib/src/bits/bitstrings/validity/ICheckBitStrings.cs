//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ErrorMsg;

    public interface ICheckBitStrings : IClaimValidator
    {
        void eq(BitString a, BitString b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
        {
            if(!a.Equals(b))
                throw failed(ClaimKind.Eq, NotEqual(a,b, caller, file, line));
        }

        void neq(BitString a, BitString b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
        {
            if(a.Equals(b))
                throw failed(ClaimKind.NEq, Equal(a,b, caller, file, line));
        }
    }
}