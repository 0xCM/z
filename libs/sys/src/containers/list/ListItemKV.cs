//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct ListItem<K,V> : IListItem<K,V>
        where K : unmanaged
    {
        public readonly K Key;

        public readonly V Value;

        [MethodImpl(Inline)]
        public ListItem(K key, V value)
        {
            Key = key;
            Value = value;
        }

        K IListItem<K,V>.Key 
            => Key;

        V IListItem<V>.Value 
            => Value;

        [MethodImpl(Inline)]
        public static implicit operator ListItem<K,V>((K key, V content) src)
            => new ListItem<K,V>(src.key, src.content);
    }
}