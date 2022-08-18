//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = NumericClaims;

    using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;
    using File = System.Runtime.CompilerServices.CallerFilePathAttribute;
    using Line = System.Runtime.CompilerServices.CallerLineNumberAttribute;

    public interface ICheckGeneric : IClaimValidator
    {
        [MethodImpl(Inline)]
        void eq<T>(T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : unmanaged
                => api.eq(a, b, caller, file, line);

        [MethodImpl(Inline)]
        void NumEq<T>(T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : unmanaged
                => api.eq(a,b,caller,file,line);

        [MethodImpl(Inline)]
        void neq<T>(T lhs, T rhs, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : unmanaged
                => api.neq(lhs,rhs, caller, file, line);

        [MethodImpl(Inline)]
        bool nonzero<T>(T x, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : unmanaged
                => api.nonzero(x,caller,file,line);

        [MethodImpl(Inline)]
        bool zero<T>(T x, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : unmanaged
                => api.zero(x, caller, file, line);

        [MethodImpl(Inline)]
        bool gt<T>(T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : unmanaged
                => api.gt(a, b, caller, file, line);

        [MethodImpl(Inline)]
        bool gteq<T>(T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : unmanaged
                => api.gteq(a, b, caller, file, line);

        [MethodImpl(Inline)]
        bool lt<T>(T lhs, T rhs, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : unmanaged
                => api.lt(lhs, rhs, caller, file, line);

        [MethodImpl(Inline)]
        bool lteq<T>(T lhs, T rhs, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : unmanaged
                => api.lteq(lhs, rhs, caller, file, line);
    }
}