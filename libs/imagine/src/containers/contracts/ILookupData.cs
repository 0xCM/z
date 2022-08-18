//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ILookupData<K,V>
    {
        ConcurrentDictionary<K,V> Storage {get;}

        Index<K> Keys{get;}

        Index<V> Values {get;}
    }
}