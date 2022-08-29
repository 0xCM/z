//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct CliRowIndex : IDataType<CliRowIndex>
    {
        readonly CliToken Data;

        public CliTableKind Table
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
        public bool Equals(CliRowIndex src)
            => Data == src.Data;

        public uint RowId
        {
            [MethodImpl(Inline)]
            get => Data.Row;
        }

        [MethodImpl(Inline)]
        public CliRowIndex(CliToken token)
        {
            Data = token;
        }

        public CliToken Token
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
        public int CompareTo(CliRowIndex src)
            => Data.CompareTo(src.Data);

        [MethodImpl(Inline)]
        public static implicit operator CliRowIndex(CliToken src)
            => new CliRowIndex(src);

        public static CliRowIndex Empty
        {
            [MethodImpl(Inline)]
            get => new CliRowIndex(CliToken.Empty);
        }
    }
}