//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IListItem : IHashed
    {
        uint Key {get;}

        object Value {get;}

        Hash32 IHashed.Hash
            => Key;
    }

    public interface IListItem<T> : IListItem
    {
        new T Value {get;}

        object IListItem.Value
            => Value;
    }

    public interface IListItem<K,T> : IListItem<T>
        where K : unmanaged
    {
        new K Key {get;}

        uint IListItem.Key
            => core.hash(Key);
    }

    public interface IListItem<I,K,T> : IListItem<K,T>, IEquatable<I>, IComparable<I>
        where K : unmanaged
        where I : IListItem<I,K,T>     
    {
    
        bool IEquatable<I>.Equals(I? other)
            => core.u32(Key) == core.u32(other.Key);
        
        int IComparable<I>.CompareTo(I? other)
            => core.u32(Key).CompareTo(other.Key);
    }
}