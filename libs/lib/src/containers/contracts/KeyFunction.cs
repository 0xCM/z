//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Signature for a key function, also called in index function, that computes a K-value for any V-value
    /// </summary>
    /// <param name="src"></param>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    public delegate K KeyFunction<K,V>(in V src);
}