//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct EcmaRowKey : IEquatable<EcmaRowKey>, IExpr
    {
        public readonly uint Value;

        [MethodImpl(Inline)]
        public EcmaRowKey(uint value)
            => Value = value;

        [MethodImpl(Inline)]
        public EcmaRowKey(EcmaTableKind table, uint index)
        {
            Value = ((uint)table << 24) | (index & 0xFFFFFF);
        }

        [MethodImpl(Inline)]
        public EcmaRowKey(TableIndex table, uint index)
        {
            Value = ((uint)table << 24) | (index & 0xFFFFFF);
        }

        public TableIndex Table
        {
            [MethodImpl(Inline)]
            get => (TableIndex)(Value >> 24);
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
        public EcmaRowKey Next()
            => new EcmaRowKey(Table, Row + 1);

        [MethodImpl(Inline)]
        public EcmaRowKey Prior()
            => Row > 1 ? new EcmaRowKey(Table, Row-1) : EcmaRowKey.Empty;

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Value;

        [MethodImpl(Inline)]
        public bool Equals(EcmaRowKey src)
            => Value == src.Value;

        public override bool Equals(object src)
            => src is EcmaRowKey k && Equals(k);

        [MethodImpl(Inline)]
        public static implicit operator EcmaRowKey(uint value)
            => new EcmaRowKey(value);

        [MethodImpl(Inline)]
        public static EcmaRowKey operator ++(EcmaRowKey src)
            => src.Next();

        [MethodImpl(Inline)]
        public static EcmaRowKey operator --(EcmaRowKey src)
            => src.Prior();

        [MethodImpl(Inline)]
        public static implicit operator EcmaRowKey((EcmaTableKind table, uint index) src)
            => new EcmaRowKey(src.table, src.index);

        [MethodImpl(Inline)]
        public static implicit operator EcmaRowKey(int value)
            => new EcmaRowKey((uint)value);

        [MethodImpl(Inline)]
        public static implicit operator EcmaToken(EcmaRowKey src)
            => src;

        [MethodImpl(Inline)]
        public static implicit operator EcmaRowKey(Handle src)
            => EcmaHandles.key(src);

        [MethodImpl(Inline)]
        public static implicit operator EcmaRowKey(EntityHandle src)
            => EcmaHandles.key(src);

        public static EcmaRowKey Empty
        {
            [MethodImpl(Inline)]
            get => new EcmaRowKey(EcmaTableKind.Invalid, 0);
        }
    }
}