//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ErrorMsg;

    using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;
    using File = System.Runtime.CompilerServices.CallerFilePathAttribute;
    using Line = System.Runtime.CompilerServices.CallerLineNumberAttribute;

    public interface ICheckEqual : IClaimValidator
    {
        void Eq<T>(T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
        {
            if(!object.Equals(a,b))
                throw failed(ClaimKind.Eq, NotEqual(a, b, caller, file, line));
        }

        void Neq<T>(T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
        {
            if(object.Equals(a,b))
                throw failed(ClaimKind.Eq, NotEqual(a,b, caller, file, line));
        }
    }
}