//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IConstRefResolver<K,V>
        where K : unmanaged
    {
        ref readonly V Resolve(K key);
    }

    [Free]
    public interface IConstRefResolver<V> : IConstRefResolver<uint,V>
    {

    }
}