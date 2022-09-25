//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct EcmaRowIndex : IDataType<EcmaRowIndex>
    {
        readonly EcmaToken Data;

        public EcmaTableKind Table
        {
            [MethodImpl(Inline)]
            get  => Data.Table;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Data.Hash;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(EcmaRowIndex src)
            => Data == src.Data;

        public uint RowId
        {
            [MethodImpl(Inline)]
            get => Data.Row;
        }

        [MethodImpl(Inline)]
        public EcmaRowIndex(EcmaToken token)
        {
            Data = token;
        }

        public EcmaToken Token
        {
            [MethodImpl(Inline)]
            get => Data;
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

        public string Format()
            => Data.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(EcmaRowIndex src)
            => Data.CompareTo(src.Data);

        [MethodImpl(Inline)]
        public static implicit operator EcmaRowIndex(EcmaToken src)
            => new EcmaRowIndex(src);

        public static EcmaRowIndex Empty
        {
            [MethodImpl(Inline)]
            get => new EcmaRowIndex(EcmaToken.Empty);
        }
    }
}