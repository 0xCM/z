//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(StructLayout, Pack=1)]
    public readonly struct ListItem<T> : IListItem<T>
    {
        public readonly uint Key;

        public readonly T Value;

        [MethodImpl(Inline)]
        public ListItem(uint index, T content)
        {
            Key = index;
            Value = content;
        }

        uint IListItem.Key 
            => Key;

        T IListItem<T>.Value 
            => Value;

        public ListItem Untype()
            => ItemLists.untype(this);

        [MethodImpl(Inline)]
        public static implicit operator ListItem<T>((uint index, T content) src)
            => new ListItem<T>(src.index, src.content);
    }
}