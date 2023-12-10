//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class TypeNats
{
    public static Product<A,B> product<A,B>(A a = default, B b = default)
        where A : unmanaged, ITypeNat
        where B : unmanaged, ITypeNat
            => new();
}