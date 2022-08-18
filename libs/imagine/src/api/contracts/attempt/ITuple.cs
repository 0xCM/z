//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Common non-parametric tuple contract
    /// </summary>
    [Free]
    public interface ITuple : ITextual
    {
        /// <summary>
        /// The tuple arity
        /// </summary>
        uint N {get;}
    }

    [Free]
    public interface ITuple<N> : ITuple
        where N : unmanaged, ITypeNat
    {
        uint ITuple.N
            => Typed.nat32u<N>();
    }

    [Free]
    public interface ITuple<T,N> : ITuple<N>, IEquatable<T>
        where T : ITuple<T,N>
        where N : unmanaged, ITypeNat
    {

    }

    [Free]
    public interface ITuple<F,N,T0> : ITuple<F,N>
        where N : unmanaged, ITypeNat
        where F : ITuple<F,N,T0>
    {

    }

    [Free]
    public interface ITuple<F,N,T0,T1> : ITuple<F,N>
        where N : unmanaged, ITypeNat
        where F : ITuple<F,N,T0,T1>
    {

    }

    [Free]
    public interface ITuple<F,N,T0,T1,T2> : ITuple<F,N>
        where N : unmanaged, ITypeNat
        where F : ITuple<F,N,T0,T1,T2>
    {

    }

    [Free]
    public interface ITuple<F,N,T0,T1,T2,T3> : ITuple<F,N>
        where N : unmanaged, ITypeNat
        where F : ITuple<F,N,T0,T1,T2,T3>
    {

    }
}