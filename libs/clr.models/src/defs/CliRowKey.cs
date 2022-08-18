//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CliRowKey : IEquatable<CliRowKey>, IExpr
    {
        public readonly uint Value;

        [MethodImpl(Inline)]
        public CliRowKey(uint value)
            => Value = value;

        [MethodImpl(Inline)]
        public CliRowKey(CliTableKind table, uint index)
        {
            Value = ((uint)table << 24) | (index & 0xFFFFFF);
        }

        public CliTableKind Table
        {
            [MethodImpl(Inline)]
            get => (CliTableKind)(Value >> 24);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Row == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Row != 0;
        }

        public uint Row
        {
            [MethodImpl(Inline)]
            get => Value & 0xFFFFFF;
        }

        [MethodImpl(Inline)]
        public string Format()
            => string.Format("{0:x2}:{1:x6}", (byte)Table, Row);

        [MethodImpl(Inline)]
        public CliRowKey Next()
            => new CliRowKey(Table, Row + 1);

        [MethodImpl(Inline)]
        public CliRowKey Prior()
            => Row > 1 ? new CliRowKey(Table, Row-1) : CliRowKey.Empty;

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Value;

        [MethodImpl(Inline)]
        public bool Equals(CliRowKey src)
            => Value == src.Value;

        public override bool Equals(object src)
            => src is CliRowKey k && Equals(k);

        [MethodImpl(Inline)]
        public static implicit operator CliRowKey(uint value)
            => new CliRowKey(value);

        [MethodImpl(Inline)]
        public static CliRowKey operator ++(CliRowKey src)
            => src.Next();

        [MethodImpl(Inline)]
        public static CliRowKey operator --(CliRowKey src)
            => src.Prior();

        [MethodImpl(Inline)]
        public static implicit operator CliRowKey((CliTableKind table, uint index) src)
            => new CliRowKey(src.table, src.index);

        [MethodImpl(Inline)]
        public static implicit operator CliRowKey(int value)
            => new CliRowKey((uint)value);

        [MethodImpl(Inline)]
        public static implicit operator CliToken(CliRowKey src)
            => src;

        [MethodImpl(Inline)]
        public static implicit operator CliRowKey(Handle src)
            => CliHandleData.key(src);

        [MethodImpl(Inline)]
        public static implicit operator CliRowKey(EntityHandle src)
            => CliHandleData.key(src);

        public static CliRowKey Empty
        {
            [MethodImpl(Inline)]
            get => new CliRowKey(CliTableKind.Invalid, 0);
        }
    }
}