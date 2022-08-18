//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IMonoid<T> : ISemigroup<T>
    {

    }

    [Free]
    public interface IMonoidal<T> : IMonoid<T>
    {
        T Identity {get;}

        T Compose(in T a, in T b);
    }

    /// <summary>
    /// Characterizes monoidal structure
    /// </summary>
    /// <typeparam name="S">The classified structure</typeparam>
    /// <typeparam name="T">The underlying type</typeparam>
    [Free]
    public interface IMonoid<H,T> : IMonoidal<T>, ISemigroup<H,T>
        where H : IMonoid<H,T>, new()
    {

    }
}