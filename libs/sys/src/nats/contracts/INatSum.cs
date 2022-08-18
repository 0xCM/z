//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Requires k := k1 + k2
    /// </summary>
    /// <typeparam name="K1">The first operand type</typeparam>
    /// <typeparam name="K2">The second operand type</typeparam>
    public interface INatSum<K1,K2> : ITypeNat
        where K1 : unmanaged, ITypeNat
        where K2 : unmanaged, ITypeNat
    {

    }

    public interface INatSum<K> : ITypeNat
        where K : unmanaged, ITypeNat
    {
        ITypeNat Lhs {get;}

        ITypeNat Rhs {get;}
    }
}