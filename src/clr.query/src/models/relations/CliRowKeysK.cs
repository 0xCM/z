//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CliRowKeys<K> : IIndex<CliRowKey<K>>
        where K : unmanaged, ICliTableKind<K>
    {
        readonly Index<CliRowKey<K>> Data;

        public CliTableKind TableKind
        {
            [MethodImpl(Inline)]
            get => default(K).TableKind;
        }

        [MethodImpl(Inline)]
        public CliRowKeys(Index<CliRowKey<K>> src)
        {
            Data = src;
        }

        public CliRowKey<K>[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public ref CliRowKey<K> First
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        public ref CliRowKey<K> this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref CliRowKey<K> this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !Data.IsEmpty;
        }

        public Span<CliRowKey<K>> Edit
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ReadOnlySpan<CliRowKey<K>> View
        {
            [MethodImpl(Inline)]
            get => Data;
        }


        [MethodImpl(Inline)]
        public static implicit operator CliRowKeys<K>(CliRowKey<K>[] src)
            => new CliRowKeys<K>(src);
    }
}