//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class TypeNats
    {
        [MethodImpl(Inline)]
        public static Dim<X0,X1,T> dim<X0,X1,T>(X0 x0, X1 x1, T t = default)
            where X0 : unmanaged, ITypeNat
            where X1 : unmanaged, ITypeNat
            where T : unmanaged
                => default;

        [MethodImpl(Inline)]
        public static Dim<X0,X1,X2,T> dim<X0,X1,X2,T>(X0 x0, X1 x1, X2 x2, T t = default)
            where X0 : unmanaged, ITypeNat
            where X1 : unmanaged, ITypeNat
            where X2 : unmanaged, ITypeNat
            where T : unmanaged
                => default;
    }
}