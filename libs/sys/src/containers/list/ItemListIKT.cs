//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    public class ItemList<I,K,T> : IItemList<I,K,T>
        where K : unmanaged
        where I : IListItem
    {
        readonly Index<I> Data;

        public readonly string Name;

        [MethodImpl(Inline)]
        public ItemList(I[] src)
        {
            Data = src;
            Name = EmptyString;
        }

        [MethodImpl(Inline)]
        public ItemList(string name, I[] src)
        {
            Name = name;
            Data = src;
        }

        public ref I this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref I this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public I[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        [MethodImpl(Inline)]
        public static implicit operator ItemList<I,K,T>(I[] src)
            => new ItemList<I,K,T>(src);

        [MethodImpl(Inline)]
        public static implicit operator I[](ItemList<I,K,T> src)
            => src.Data;

        public static ItemList<I,K,T> Empty => new ItemList<I,K,T>(sys.empty<I>());            
    }
}