//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CliRowKey<K>
        where K : unmanaged, ICliTableKind<K>
    {
        public readonly uint Value;

        [MethodImpl(Inline)]
        public CliRowKey(uint value)
            => Value = (value & 0xFFFFFF);

        public CliTableKind Table
        {
            [MethodImpl(Inline)]
            get => default(K).TableKind;
        }

        public uint Row
        {
            [MethodImpl(Inline)]
            get => Value;
        }

        [MethodImpl(Inline)]
        public bool Equals(CliRowKey<K> src)
            => Value == src.Value;

        public override bool Equals(object src)
            => src is CliRowKey<K> k && Equals(k);

        [MethodImpl(Inline)]
        public string Format()
            => string.Format("{0:x2}:{1:x6}", (byte)Table, Row);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Value;

        [MethodImpl(Inline)]
        public static implicit operator CliRowKey<K>(uint value)
            => new CliRowKey<K>(value);

        [MethodImpl(Inline)]
        public static implicit operator CliRowKey<K>(int value)
            => new CliRowKey<K>((uint)value);

        [MethodImpl(Inline)]
        public static implicit operator CliRowKey(CliRowKey<K> src)
            => new CliRowKey((src.Value));

        [MethodImpl(Inline)]
        public static implicit operator CliToken(CliRowKey<K> src)
            => src;
    }
}