//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IKeyValuePairs<K,V> : IReadOnlyDictionary<K,V>
    {
        new K[] Keys {get;}

        new V[] Values {get;}

        ISet<V> DistinctValues {get;}

        bool ContainsValue(V value);

        K[] this[V value]  {get;}

        bool TryGetKeys(V value, out K[] keys);

        K[] ValueKeys(V value);
    }
}