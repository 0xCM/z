//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    /// <summary>
    /// Characterizes an homogenous 3-tuple
    /// </summary>
    /// <typeparam name="K">The reifying type</typeparam>
    /// <typeparam name="T">The member type</typeparam>
    [Free]
    public interface ITriple<K,T> : ITuple<K,N3>, ITupled<K,T,T,T>
        where K : ITriple<K,T>
    {
        new T First {get;}

        new T Second {get;}

        new T Third {get;}

        T ITupled<K,T,T,T>.First
            => First;

        T ITupled<K,T,T,T>.Second
            => Second;

        T ITupled<K,T,T,T>.Third
            => Third;
    }
}