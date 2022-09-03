//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a potentially non-homogenous 2-tuple
    /// </summary>
    /// <typeparam name="K">The reifying type</typeparam>
    /// <typeparam name="T0">The first member type</typeparam>
    /// <typeparam name="T1">The second member type</typeparam>
    [Free]
    public interface ITupled<K,T0,T1> : ITuple<K,N2>
        where K : ITupled<K,T0,T1>
    {
        void Deconstruct(out T0 x0, out T1 x1);

        /// <summary>
        /// The left member
        /// </summary>
        T0 Left {get;}

        /// <summary>
        /// The right member
        /// </summary>
        T1 Right {get;}
    }

    /// <summary>
    /// Characterizes a potentially non-homogenous 3-tuple
    /// </summary>
    /// <typeparam name="K">The reifying type</typeparam>
    /// <typeparam name="T0">The first member type</typeparam>
    /// <typeparam name="T1">The second member type</typeparam>
    /// <typeparam name="T2">The third member type</typeparam>
    [Free]
    public interface ITupled<K,T0,T1,T2> : ITuple<K,N3>
        where K : ITupled<K,T0,T1,T2>
    {
        void Deconstruct(out T0 x0, out T1 x1, out T2 x2);

        T0 First {get;}

        T1 Second {get;}

        T2 Third {get;}
    }

    /// <summary>
    /// Characterizes a potentially non-homogenous 4-tuple
    /// </summary>
    /// <typeparam name="K">The reifying type</typeparam>
    /// <typeparam name="T0">The first member type</typeparam>
    /// <typeparam name="T1">The second member type</typeparam>
    /// <typeparam name="T2">The third member type</typeparam>
    /// <typeparam name="T3">The fourth member type</typeparam>
    [Free]
    public interface ITupled<K,T0,T1,T2,T3> : ITuple<K,N4>
        where K : ITupled<K,T0,T1,T2,T3>
    {
        void Deconstruct(out T0 x0, out T1 x1, out T2 x2, out T3 x3);
    }
}