//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ItemIndex<K,T> : ConstLookup<K,ListItem<K,T>>
        where K : unmanaged
    {
        readonly ItemList<K,T> Data;

        public ItemIndex(ListItem<K,T>[] src)
            : base(src.Select(x => (x.Key,x)).ToDictionary())
        {
            Data = src;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ref readonly ListItem<K,T> this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref readonly ListItem<K,T> this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        [MethodImpl(Inline)]
        public static implicit operator ItemIndex<K,T>(ListItem<K,T>[] src)
            => new ItemIndex<K,T>(src);

        [MethodImpl(Inline)]
        public static implicit operator ItemList<K,T>(ItemIndex<K,T> src)
            => src.Data;
    }
}