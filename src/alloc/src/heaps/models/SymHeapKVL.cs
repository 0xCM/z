//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Covers a contiguous <see cref='char'/> sequence
    /// </summary>
    /// <typeparam name="K">The linear index type</typeparam>
    /// <typeparam name="T">The offset type</typeparam>
    /// <typeparam name="W">The width type</typeparam>
    public ref struct SymHeap<K,T,W>
        where K : unmanaged
        where T : unmanaged
        where W : unmanaged
    {
        readonly ReadOnlySpan<HeapEntry<K,T,W>> Entries;

        readonly ReadOnlySpan<char> Data;

        public readonly uint Size;

        public uint EntryCount
        {
            [MethodImpl(Inline)]
            get => (uint)Entries.Length;
        }

        [MethodImpl(Inline)]
        public SymHeap(ReadOnlySpan<HeapEntry<K,T,W>> entries, ReadOnlySpan<char> data)
        {
            Entries = entries;
            Data = data;
            Size = (uint)(data.Length * 2);
        }

        [MethodImpl(Inline)]
        public K Key(uint index)
            => @as<K>(index);

        [MethodImpl(Inline)]
        public uint Index(K key)
            => bw32(key);

        [MethodImpl(Inline)]
        public ref readonly HeapEntry<K,T,W> Entry(uint index)
            => ref skip(Entries,index);

        [MethodImpl(Inline)]
        public ref readonly HeapEntry<K,T,W> Entry(K key)
            => ref skip(Entries, Index(key));

        [MethodImpl(Inline)]
        public ReadOnlySpan<char> Symbol(in HeapEntry<K,T,W> entry)
            => slice(Data,bw32(entry.Offset), bw32(entry.Length));

        [MethodImpl(Inline)]
        public ReadOnlySpan<char> Symbol(uint index)
            => Symbol(Entry(index));

        [MethodImpl(Inline)]
        public ReadOnlySpan<char> Symbol(K key)
            => Symbol(Entry(key));
    }
}