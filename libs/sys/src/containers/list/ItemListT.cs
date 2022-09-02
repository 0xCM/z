//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ItemList<T> : IIndex<ListItem<T>>
    {
        readonly Index<ListItem<T>> Data;

        public readonly string Name;

        [MethodImpl(Inline)]
        public ItemList(ListItem<T>[] src)
        {
            Name = Identifier.Empty;
            Data = src;
        }

        [MethodImpl(Inline)]
        public ItemList(string name, ListItem<T>[] src)
        {
            Name = name;
            Data = src;
        }

        public ref ListItem<T> this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref ListItem<T> this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public Span<ListItem<T>> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public ReadOnlySpan<ListItem<T>> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public ListItem<T>[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        [MethodImpl(Inline)]
        public static implicit operator ItemList<T>(ListItem<T>[] src)
            => new ItemList<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator ItemList<T>((string name, ListItem<T>[] items) src)
            => new ItemList<T>(src.name,src.items);

        [MethodImpl(Inline)]
        public static implicit operator ListItem<T>[](ItemList<T> src)
            => src.Storage;

        public static ItemList<T> Empty => new ItemList<T>(sys.empty<ListItem<T>>());
    }
}