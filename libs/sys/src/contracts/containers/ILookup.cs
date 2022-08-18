// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ILookup
    {
        Type KeyType {get;}

        Type ValueType {get;}
    }

    [Free]
    public interface ILookup<K,V> : ILookup, ICounted
    {
        bool Find(K key, out V value);

        Type ILookup.KeyType
            => typeof(K);

        Type ILookup.ValueType
            => typeof(V);
    }
}