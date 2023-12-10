//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class TypeNats
{
    [MethodImpl(Inline)]
    public static Dim<X0,X1> dim<X0,X1,T>(X0 x0, X1 x1)
        where X0 : unmanaged, ITypeNat
        where X1 : unmanaged, ITypeNat
            => default;

    [MethodImpl(Inline)]
    public static Dim<X0,X1,X2> dim<X0,X1,X2,T>(X0 x0, X1 x1, X2 x2)
        where X0 : unmanaged, ITypeNat
        where X1 : unmanaged, ITypeNat
        where X2 : unmanaged, ITypeNat
            => default;
}
