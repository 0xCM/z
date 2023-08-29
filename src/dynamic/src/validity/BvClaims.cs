//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public readonly struct BvClaims : ICheckPrimal, ICheckInvariant
{
    static ICheckPrimal Primal => default(BvClaims);

    static ICheckInvariant Invariant => default(BvClaims);

    [MethodImpl(Inline)]
    public static void eq(BitVector4 x, BitVector4 y, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
        => Primal.eq(x.State, y.State, caller, file, line);

    [MethodImpl(Inline)]
    public static void eq(BitVector8 x, BitVector8 y, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
        => Primal.eq(x.State, y.State, caller, file, line);

    [MethodImpl(Inline)]
    public static void eq(BitVector16 x, BitVector16 y, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
        => Primal.eq(x.State, y.State, caller, file, line);

    [MethodImpl(Inline)]
    public static void eq(BitVector32 x, BitVector32 y, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
        => Primal.eq(x.State, y.State, caller, file, line);

    [MethodImpl(Inline)]
    public static void eq(BitVector64 x, BitVector64 y, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
        => Primal.eq(x.State, y.State, caller, file, line);

    [MethodImpl(Inline)]
    public static void eq<T>(ScalarBits<T> x, ScalarBits<T> y, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
        where T : unmanaged
            => Invariant.yea(gmath.eq(x.State, y.State), $"{x} != {y}", caller, file, line);

    [MethodImpl(Inline)]
    public static void eq<T>(BitVector128<T> x, BitVector128<T> y, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
        where T : unmanaged
            => Invariant.yea(x.Equals(y), $"{x} != {y}", caller, file, line);

    [MethodImpl(Inline)]
    public static void eq<N,T>(ScalarBits<N,T> x, ScalarBits<N,T> y, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
        where N : unmanaged, ITypeNat
        where T : unmanaged
            => Invariant.yea(x.Equals(y), $"{x} != {y}", caller, file, line);
}
