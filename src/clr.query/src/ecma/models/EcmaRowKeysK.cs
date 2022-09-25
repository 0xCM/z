//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct EcmaRowKeys<K> : IIndex<EcmaRowKey<K>>
        where K : unmanaged, IEcmaTableKind<K>
    {
        readonly Index<EcmaRowKey<K>> Data;

        public EcmaTableKind TableKind
        {
            [MethodImpl(Inline)]
            get => default(K).TableKind;
        }

        [MethodImpl(Inline)]
        public EcmaRowKeys(Index<EcmaRowKey<K>> src)
        {
            Data = src;
        }

        public EcmaRowKey<K>[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public ref EcmaRowKey<K> First
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        public ref EcmaRowKey<K> this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref EcmaRowKey<K> this[uint index]
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

        public Span<EcmaRowKey<K>> Edit
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ReadOnlySpan<EcmaRowKey<K>> View
        {
            [MethodImpl(Inline)]
            get => Data;
        }


        [MethodImpl(Inline)]
        public static implicit operator EcmaRowKeys<K>(EcmaRowKey<K>[] src)
            => new EcmaRowKeys<K>(src);
    }
}