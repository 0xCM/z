//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static ErrorMsg;
using static ClaimValidator;


public readonly struct NumericClaims : ICheckNumeric
{
    public static ICheckNumeric Checker => default(NumericClaims);

    const NumericKind Closure = UnsignedInts;

    public static void eq<T>(T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
        where T : unmanaged
    {
        if(typeof(T).IsPrimalNumeric())
            gmath.eq(a,b).OnNone(() => throw ClaimException.define(ClaimKind.Eq, NotEqual(a, b, caller, file, line).Format()));
        else
            CheckEqual.Checker.Eq(a,b);
    }

    public static void neq<T>(T lhs, T rhs, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
        where T : unmanaged
    {
        if(typeof(T).IsPrimalNumeric())
            gmath.neq(lhs,rhs).OnNone(() => throw failed(ClaimKind.NEq, Equal(lhs, rhs, caller, file, line)));
        else
            CheckEqual.Checker.Neq(lhs,rhs);
    }

    public static bool nonzero<T>(T x, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
        where T : unmanaged
            => gmath.nonz(x) ? true : throw AppErrors.NotNonzero(caller,file,line);

    public static bool zero<T>(T x, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
        where T : unmanaged
            => !gmath.nonz(x) ? true : throw AppErrors.NotNonzero(caller,file,line);

    public static bool gt<T>(T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
        where T : unmanaged
            => gmath.gt(a,b) ? true : throw failed(ClaimKind.Gt, NotGreaterThan(a, b, caller, file, line));

    public static bool gteq<T>(T lhs, T rhs, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
        where T : unmanaged
            => gmath.gteq(lhs,rhs) ? true : throw failed(ClaimKind.Gt, NotGreaterThan(lhs, rhs, caller, file, line));

    public static bool lt<T>(T lhs, T rhs, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
        where T : unmanaged
            => gmath.lt(lhs,rhs) ? true : throw failed(ClaimKind.Lt, NotLessThan(lhs, rhs, caller, file, line));

    public static bool lteq<T>(T lhs, T rhs, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
        where T : unmanaged
            => gmath.lteq(lhs,rhs) ? true : throw failed(ClaimKind.GtEq, NotGreaterThanOrEqual(lhs, rhs, caller, file, line));
}
