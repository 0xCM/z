//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using System.Collections;

    using static core;

    public readonly struct ApiOpIndex<T> : IEnumerable<KeyedValue<_OpIdentity,T>>, IApiOpIndex<T>
    {
        public readonly Dictionary<_OpIdentity,T> HashTable;

        public readonly _OpIdentity[] Duplicates;

        public ApiOpIndex(Dictionary<_OpIdentity,T> index, _OpIdentity[] duplicates)
        {
            HashTable = index;
            Duplicates = duplicates;
        }

        public bool Lookup(_OpIdentity id, out T value)
        {
            if(HashTable.TryGetValue(id, out value))
                return true;
            else
                return false;
        }

        public T this[_OpIdentity id]
        {
            get
            {
                if(HashTable.TryGetValue(id, out var value))
                    return value;
                else
                    return default;
            }
        }

        public int EntryCount
            => HashTable.Count;

        public IEnumerable<(_OpIdentity, T)> Enumerated
            => HashTable.Select(kvp => (kvp.Key, kvp.Value));

        public IEnumerable<_OpIdentity> Keys
            => HashTable.Keys;

        public IReadOnlyList<_OpIdentity> DuplicateKeys
            => Duplicates;

        public IEnumerable<T> Values
            => HashTable.Values;

        IEnumerable<KeyedValue<_OpIdentity,T>> KeyedValues
            => HashTable.Select(x => kvp(x.Key, x.Value));

        public IEnumerator<KeyedValue<_OpIdentity,T>> GetEnumerator()
            => KeyedValues.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

       public static ApiOpIndex<T> Empty
            => new ApiOpIndex<T>(new Dictionary<_OpIdentity,T>(), sys.empty<_OpIdentity>());
    }
}