//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct EcmaRowKeys : IIndex<EcmaRowKey>
    {
        readonly Index<EcmaRowKey> Data;

        public readonly TableIndex Table;

        [MethodImpl(Inline)]
        public EcmaRowKeys(Index<EcmaRowKey> src, TableIndex table = default)
        {
            Data = src;
            Table = table;
        }

        public ref EcmaRowKey First
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }
        public ref EcmaRowKey this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref EcmaRowKey this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }
        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNonEmpty;
        }

        public ReadOnlySpan<EcmaRowKey> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public EcmaRowKey[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        [MethodImpl(Inline)]
        public static implicit operator EcmaRowKeys(EcmaRowKey[] src)
            => new EcmaRowKeys(src);

        [MethodImpl(Inline)]
        public static implicit operator EcmaRowKeys((EcmaRowKey[] keys, TableIndex table) src)
            => new EcmaRowKeys(src.keys, src.table);
    }
}