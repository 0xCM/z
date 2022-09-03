//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a type-level sequence of typenats
    /// </summary>
    public interface INatSeq : ITypeNat
    {

    }

    /// <summary>
    /// Characterizes a reified natural sequence
    /// </summary>
    /// <typeparam name="S">The reification type</typeparam>
    public interface INatSeq<S> : ITypeNat<S>, INatSeq
        where S : unmanaged, INatSeq<S>
    {

    }

    /// <summary>
    /// Characterizes a reified 2-term natural sequence
    /// </summary>
    /// <typeparam name="K">The reification type</typeparam>
    /// <typeparam name="K1">The first term</typeparam>
    /// <typeparam name="K2">The second term</typeparam>
    public interface INatSeq<K,K1,K2> : INatSeq<K>
        where K : unmanaged, INatSeq<K,K1,K2>
        where K1 : unmanaged, INatPrimitive<K1>
        where K2 : unmanaged, INatPrimitive<K2>
    {

    }

    /// <summary>
    /// Characterizes a reified 3-term natural sequence
    /// </summary>
    /// <typeparam name="K">The reification type</typeparam>
    /// <typeparam name="K1">The first term</typeparam>
    /// <typeparam name="K2">The second term</typeparam>
    /// <typeparam name="K2">The third term</typeparam>
    public interface INatSeq<K,K1,K2,K3> : INatSeq<K>
        where K : unmanaged, INatSeq<K,K1,K2,K3>
        where K1 : unmanaged, INatPrimitive<K1>
        where K2 : unmanaged, INatPrimitive<K2>
        where K3 : unmanaged, INatPrimitive<K3>
    {

    }
}