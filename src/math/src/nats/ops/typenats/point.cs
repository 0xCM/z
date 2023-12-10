//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class TypeNats
{
    [MethodImpl(Inline)]
    public static Point<X0,X1,T> point<X0,X1,T>(X0 x0, X1 x1, T value)
        where X0 : unmanaged, ITypeNat
        where X1 : unmanaged, ITypeNat
        where T : unmanaged
            => value;

    [MethodImpl(Inline)]
    public static Point<X0,X1,X2,T> point<X0,X1,X2,T>(X0 x0, X1 x1, X2 x2, T value)
        where X0 : unmanaged, ITypeNat
        where X1 : unmanaged, ITypeNat
        where X2 : unmanaged, ITypeNat
        where T : unmanaged
            => value;

    [MethodImpl(Inline)]
    public static Point<X0,X1,T> point<X0,X1,T>(Dim<X0,X1> dim, T value)
        where X0 : unmanaged, ITypeNat
        where X1 : unmanaged, ITypeNat
        where T : unmanaged
            => value;

    [MethodImpl(Inline)]
    public static Point<X0,X1,X2,T> point<X0,X1,X2,T>(Dim<X0,X1,X2> dim, T value)
        where X0 : unmanaged, ITypeNat
        where X1 : unmanaged, ITypeNat
        where X2 : unmanaged, ITypeNat
        where T : unmanaged
            => value; 
}
