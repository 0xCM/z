//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a blittable entity
    /// </summary>
    /// <typeparam name="E">The concrete entity type</typeparam>
    [Free]
    public interface INativeEntity<E> : IEntity<E>
        where E : unmanaged, INativeEntity<E>
    {

    }

    /// <summary>
    /// Characterizes a key-parametric blittable entity
    /// </summary>
    /// <typeparam name="E">The concrete entity type</typeparam>
    /// <typeparam name="K">The key type</typeparam>
    [Free]
    public interface INativeEntity<E,K> : INativeEntity<E>, INativeKey<K>
        where E : unmanaged, INativeEntity<E>
        where K : unmanaged, IEquatable<K>, IComparable<K>
    {        
    }    
}