//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes the reification of a natural number k such that 
    /// a:K1 & b:K2 & k = a * b
    /// </summary>
    /// <typeparam name="K2">The base type</typeparam>
    /// <typeparam name="E">The exponent type</typeparam>
    public interface INatProduct<S,K1,K2> : ITypeNat
        where S : INatProduct<S,K1,K2>, new()
        where K1 : unmanaged, ITypeNat
        where K2 : unmanaged, ITypeNat
    {

    }

}