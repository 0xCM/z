//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    /// <summary>
    /// Defines a T-value index together with a comanion K-index ,
    /// where each K-value i is either obtained directly from the caller or by
    /// invoking a caller-supplied index function f:T -> K that computes a unique K-value for each T-value
    /// </summary>
    public readonly struct KeyedValues<K,V> : IIndex<KeyedValue<K,V>>
    {
        public Index<KeyedValue<K,V>> Pairs {get;}

        readonly KeyFunction<K,V> KeyFunction;

        [MethodImpl(Inline)]
        public KeyedValues(V[] src, KeyFunction<K,V> kf, KeyedValue<K,V>[] dst)
        {
            Pairs = dst;
            KeyFunction = kf;
            var edit = Edit;
            var values = src.ToReadOnlySpan();
            var count = src.Length;
            for(var i= 0u; i<count; i++)
            {
                ref readonly var value = ref skip(values,i);
                var key = kf(value);
                seek(edit,i) = Lookups.kvp(key,value);
            }
        }

        [MethodImpl(Inline)]
        public KeyedValues(KeyedValue<K,V>[] dst)
        {
            Pairs = dst;
            KeyFunction = (in V key) => default(K);
        }

        public KeyedValues(uint capacity)
        {
            Pairs = alloc<KeyedValue<K,V>>(capacity);
            KeyFunction = (in V key) => default(K);
        }

        [MethodImpl(Inline)]
        public KeyedValues(KeyedValue<K,V>[] dst, KeyFunction<K,V> kf)
        {
            Pairs = dst;
            KeyFunction = kf;
        }

        [MethodImpl(Inline)]
        public KeyedValues(KeyFunction<K,V> kf, ReadOnlySpan<V> src)
        {
            KeyFunction = kf;
            Pairs = alloc<KeyedValue<K,V>>(src.Length);
            var edit = Pairs.Edit;
            for(var i=0u; i<src.Length; i++)
            {
                ref readonly var value = ref skip(src,i);
                var key = kf(value);
                seek(edit, i) = Lookups.kvp(key, value);
            }
        }

        public KeyedValues(KeyFunction<K,V> kf, uint capacity)
        {
            KeyFunction = kf;
            Pairs = alloc<KeyedValue<K,V>>(capacity);
        }

        public ReadOnlySpan<KeyedValue<K,V>> View
        {
            [MethodImpl(Inline)]
            get => Pairs;
        }

        public Span<KeyedValue<K,V>> Edit
        {
            [MethodImpl(Inline)]
            get => Pairs;
        }

        public ref KeyedValue<K,V> First
        {
            [MethodImpl(Inline)]
            get => ref Pairs[0];
        }

        [MethodImpl(Inline)]
        public ref KeyedValue<K,V> Pair(uint index)
            => ref Pairs[index];

        [MethodImpl(Inline)]
        public bool Search(in K key, out V value)
        {
            var view = View;
            for(var i=0; i<view.Length; i++)
            {
                ref readonly var candidate = ref skip(view,i);
                if(key.Equals(candidate))
                {
                    value = skip(view, i).Value;
                    return true;
                }
            }
            value = default;
            return false;
        }

        [MethodImpl(Inline)]
        public ref V Search(in K key)
        {
            var view = Edit;
            ref var start = ref first(Edit);
            ref var found = ref start.Value;
            for(var i=0; i<view.Length; i++)
            {
                ref readonly var candidate = ref skip(view,i);
                if(key.Equals(candidate))
                {
                    found = candidate.Value;
                    break;
                }
            }
            return ref found;
        }

        [MethodImpl(Inline)]
        public bool Search(Func<V,bool> predicate, out V found)
        {
            var view = View;
            for(var i=0; i<view.Length; i++)
            {
                ref readonly var candidate = ref skip(view,i);
                if(predicate(candidate.Value))
                {
                    found = candidate.Value;
                    return true;
                }
            }
            found = default;
            return false;
        }

        public ref KeyedValue<K,V> this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Pair(index);
        }

        public ref KeyedValue<K,V> this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Pair((uint)index);
        }

        public ref V this[in K key]
        {
            [MethodImpl(Inline)]
            get => ref Search(key);
        }

        [MethodImpl(Inline)]
        public ref K Key(uint index)
            => ref Pairs[index].Key;

        [MethodImpl(Inline)]
        public ref V Value(uint index)
            => ref Pairs[index].Value;

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Pairs.Count;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Pairs.Length;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Count == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Count != 0;
        }

        public KeyedValue<K,V>[] Storage
            => Pairs;

        public Span<KeyedValue<K,V>> Terms
            => Pairs;

        [MethodImpl(Inline)]
        public static implicit operator KeyedValues<K,V>(KeyedValue<K,V>[] src)
            => new KeyedValues<K,V>(src);

       [MethodImpl(Inline)]
       public static implicit operator KeyedValues<K,V>(Index<KeyedValue<K,V>> src)
            => new KeyedValues<K,V>(src);

        public static KeyedValues<K,V> Empty
            => default;
    }
}