//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    public readonly struct ApiOpIndex<T> : IEnumerable<KeyedValue<OpIdentity,T>>, IApiOpIndex<T>
    {
        public readonly Dictionary<OpIdentity,T> HashTable;

        public readonly OpIdentity[] Duplicates;

        public ApiOpIndex(Dictionary<OpIdentity,T> index, OpIdentity[] duplicates)
        {
            HashTable = index;
            Duplicates = duplicates;
        }

        public bool Lookup(OpIdentity id, out T value)
        {
            if(HashTable.TryGetValue(id, out value))
                return true;
            else
                return false;
        }

        public T this[OpIdentity id]
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

        public IEnumerable<(OpIdentity, T)> Enumerated
            => HashTable.Select(kvp => (kvp.Key, kvp.Value));

        public IEnumerable<OpIdentity> Keys
            => HashTable.Keys;

        public IReadOnlyList<OpIdentity> DuplicateKeys
            => Duplicates;

        public IEnumerable<T> Values
            => HashTable.Values;

        IEnumerable<KeyedValue<OpIdentity,T>> KeyedValues
            => HashTable.Select(x => sys.kv(x.Key, x.Value));

        public IEnumerator<KeyedValue<OpIdentity,T>> GetEnumerator()
            => KeyedValues.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

       public static ApiOpIndex<T> Empty
            => new ApiOpIndex<T>(new Dictionary<OpIdentity,T>(), sys.empty<OpIdentity>());
    }
}