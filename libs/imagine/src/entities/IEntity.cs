//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IEntity : IKeyed
    {        
    }

    [Free]
    public interface IEntity<E> : IEntity, IEquatable<E>
        where E : IEntity<E>, new()
    {

    }

    [Free]
    public interface IEntity<E,K> : IEntity<E>, IKeyed<K>
        where K : IEquatable<K>, IComparable<K>
        where E : IEntity<E,K>, new()
    {

    }
}