//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class Lookup<K,V>
    {
        readonly ConcurrentDictionary<K,V> Storage;

        Index<K> _Keys;

        Index<V> _Values;

        Index<LookupEntry<K,V>> _Entries;

        bool Sealed;

        object locker;

        ConstLookup<K,V> _Const;

        public Lookup()
        {
            Storage = new();
            Sealed = false;
            locker = new();
            _Keys = sys.empty<K>();
            _Values = sys.empty<V>();
            _Entries = sys.empty<LookupEntry<K,V>>();
            _Const = ConstLookup<K,V>.Empty;
        }

        public ConstLookup<K,V> Seal()
        {
            lock(locker)
            {
                if(_Const.IsEmpty)
                    _Const = new(Storage);
            }
            return _Const;
        }

        public ReadOnlySpan<K> Keys
        {
            [MethodImpl(Inline)]
            get => _Const.Keys;
        }

        public ReadOnlySpan<V> Values
        {
            [MethodImpl(Inline)]
            get => _Const.Values;
        }

        public ReadOnlySpan<LookupEntry<K,V>> Entries
        {
            [MethodImpl(Inline)]
            get => _Const.Entries;
        }

        public uint EntryCount
        {
            [MethodImpl(Inline)]
            get => _Const.EntryCount;
        }

        [MethodImpl(Inline)]
        public bool Include(K key, V value)
            =>  _Const.IsNonEmpty ? false : Storage.TryAdd(key,value);

        [MethodImpl(Inline)]
        public bool Find(K key, out V value)
            => Storage.TryGetValue(key, out value);
    }
}