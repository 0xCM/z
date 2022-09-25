//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct EcmaRowKey<K>
        where K : unmanaged, IEcmaTableKind<K>
    {
        public readonly uint Value;

        [MethodImpl(Inline)]
        public EcmaRowKey(uint value)
            => Value = (value & 0xFFFFFF);

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Value;
        }

        public EcmaTableKind Table
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
        public bool Equals(EcmaRowKey<K> src)
            => Value == src.Value;

        [MethodImpl(Inline)]
        public string Format()
            => string.Format("{0:x2}:{1:x6}", (byte)Table, Row);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Value;

        [MethodImpl(Inline)]
        public static implicit operator EcmaRowKey<K>(uint value)
            => new EcmaRowKey<K>(value);

        [MethodImpl(Inline)]
        public static implicit operator EcmaRowKey<K>(int value)
            => new EcmaRowKey<K>((uint)value);

        [MethodImpl(Inline)]
        public static implicit operator EcmaRowKey(EcmaRowKey<K> src)
            => new EcmaRowKey((src.Value));

        [MethodImpl(Inline)]
        public static implicit operator EcmaToken(EcmaRowKey<K> src)
            => src;
    }
}