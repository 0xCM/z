//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes an homogenous 2-tuple
    /// </summary>
    /// <typeparam name="K">The reifying type</typeparam>
    /// <typeparam name="T">The member type</typeparam>
    [Free]
    public interface ITupledPair<K,T> : ITuple<K,N2>, ITupled<K,T,T>
        where K : ITupledPair<K,T>
    {
        /// <summary>
        /// The left member
        /// </summary>
        new T Left {get;}

        /// <summary>
        /// The right member
        /// </summary>
        new T Right {get;}

        T ITupled<K,T,T>.Left => Left;

        T ITupled<K,T,T>.Right => Right;
    }
}