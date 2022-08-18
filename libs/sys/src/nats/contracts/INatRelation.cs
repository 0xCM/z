//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes binary relationship between two type naturals
    /// </summary>
    /// <typeparam name="K1">The first nat type</typeparam>
    /// <typeparam name="K2">The second nat type</typeparam>
    public interface INatRelation<K1,K2>
        where K1 : unmanaged, ITypeNat
        where K2 : unmanaged, ITypeNat
    {

    }

    /// <summary>
    /// Characterizes ternary relationship among three type naturals
    /// </summary>
    /// <typeparam name="K1">The first nat type</typeparam>
    /// <typeparam name="K2">The second nat type</typeparam>
    /// <typeparam name="K3">The third nat type</typeparam>
    public interface INatRelation<K1,K2,K3>
        where K1 : unmanaged, ITypeNat
        where K2 : unmanaged, ITypeNat
        where K3 : unmanaged, ITypeNat
    {

    }

    /// <summary>
    /// Requires k1 = n*k2 for some n>= 1
    /// </summary>
    /// <typeparam name="K1">The divisible type</typeparam>
    /// <typeparam name="K2">The divisor type</typeparam>
    public interface INatDivisible<K1,K2> : INatRelation<K1,K2>
        where K1: unmanaged, ITypeNat
        where K2: unmanaged, ITypeNat
    {

    }

    /// <summary>
    /// Requires k1 <= k <= k2
    /// </summary>
    /// <typeparam name="K1">The first nat type</typeparam>
    /// <typeparam name="K2">The second nat type</typeparam>
    public interface INatBetween<K,K1,K2> : INatRelation<K,K1,K2>
        where K : unmanaged, ITypeNat
        where K1: unmanaged, ITypeNat
        where K2: unmanaged, ITypeNat
    {

    }

    /// <summary>
    /// Requires k1 > k2
    /// </summary>
    /// <typeparam name="K1">The larger nat type</typeparam>
    /// <typeparam name="K2">The smaller nat type</typeparam>
    public interface INatGt<K1,K2> : INatRelation<K1,K2>
        where K1: unmanaged, ITypeNat
        where K2: unmanaged, ITypeNat
    {

    }

    /// <summary>
    /// Requires k1 >= k2
    /// </summary>
    /// <typeparam name="K1">The larger nat type</typeparam>
    /// <typeparam name="K2">The smaller nat type</typeparam>
    public interface INatGtEq<K1,K2> : INatRelation<K1,K2>
        where K1: unmanaged, ITypeNat
        where K2: unmanaged, ITypeNat
    {

    }

    /// <summary>
    /// Requires k1 == k2
    /// </summary>
    /// <typeparam name="K1">The first nat type</typeparam>
    /// <typeparam name="K2">The second nat type</typeparam>
    public interface INatEq<K1,K2> : INatRelation<K1,K2>
        where K1: unmanaged, ITypeNat
        where K2: unmanaged, ITypeNat
    {

    }

    /// <summary>
    /// Requires k1 != k2
    /// </summary>
    /// <typeparam name="K1">The first nat type</typeparam>
    /// <typeparam name="K2">The second nat type</typeparam>
    public interface INatNEq<K1,K2> : INatRelation<K1,K2>
        where K1: unmanaged, ITypeNat
        where K2: unmanaged, ITypeNat
    {

    }

    /// <summary>
    /// Requires k1 < k2
    /// </summary>
    public interface INatLt<K1,K2> : INatRelation<K1,K2>
        where K1: unmanaged, ITypeNat
        where K2: unmanaged, ITypeNat
    {

    }

    /// <summary>
    /// Requires k1 <= k2
    /// </summary>
    public interface INatLtEq<K1,K2> : INatRelation<K1,K2>
        where K1: unmanaged, ITypeNat
        where K2: unmanaged, ITypeNat
    {

    }

    /// <summary>
    /// Requires k1:K1 & k2:K2 & k3:K3 => k1 % k2 = k3
    /// </summary>
    /// <typeparam name="K1">The first nat type</typeparam>
    /// <typeparam name="K2">The second nat type</typeparam>
    /// <typeparam name="K3">The third nat type</typeparam>
    public interface INatMod<K1,K2,K3> : INatRelation<K1,K2,K3>
        where K1 : unmanaged, ITypeNat
        where K2 : unmanaged, ITypeNat
        where K3 : unmanaged, ITypeNat
    {

    }

    /// <summary>
    /// Requires k:K => k % 2 != 0
    /// </summary>
    /// <typeparam name="K">An Odd natural type</typeparam>
    public interface INatOdd<K> : ITypeNat
        where K : unmanaged, ITypeNat
    {

    }

    /// <summary>
    /// Requires k prime
    /// </summary>
    /// <typeparam name="K">A prime nat type</typeparam>
    public interface INatPrime<K> : ITypeNat
        where K : unmanaged, ITypeNat
    {

    }

    /// <summary>
    /// Characterizes a natural k such that b:B & e:E => k = b^e
    /// </summary>
    /// <typeparam name="B">The base type</typeparam>
    /// <typeparam name="E">The exponent type</typeparam>
    public interface INatPow<B,E> : ITypeNat
        where B : unmanaged, ITypeNat
        where E : unmanaged, ITypeNat
    {

    }

    /// <summary>
    /// Characterizes the reification of a natural k such that
    /// b:B & e:E => k = b^e
    /// </summary>
    /// <typeparam name="B">The base type</typeparam>
    /// <typeparam name="E">The exponent type</typeparam>
    public interface INatPow<S,B,E> : INatPow<B,E>, ITypeNat<S>
        where S : unmanaged, INatPow<S,B,E>
        where B : unmanaged, ITypeNat
        where E : unmanaged, ITypeNat
    {

    }

    /// <summary>
    /// Requires k1: K1 & k2:K2 => k1 - 1 = k2
    /// </summary>
    /// <typeparam name="K1"></typeparam>
    /// <typeparam name="K2"></typeparam>
    public interface INatPrior<K1,K2> : INatGt<K1,K2>, INonZeroNat<K1>
        where K1 : unmanaged, ITypeNat
        where K2 : unmanaged, ITypeNat
    {

    }
}