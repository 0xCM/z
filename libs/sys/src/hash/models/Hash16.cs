//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct Hash16 : IHashCode<Hash16,ushort>
    {
        public readonly ushort Value;

        [MethodImpl(Inline)]
        public Hash16(ushort value)
            => Value = value;

        public ushort Primitive
        {
            [MethodImpl(Inline)]
            get => Value;
        }

        ushort IHashCode<ushort>.Value
            => Value;

        [MethodImpl(Inline)]
        public bool Equals(Hash16 src)
            => Value == src.Value;

        [MethodImpl(Inline)]
        public int CompareTo(Hash16 src)
            => Value.CompareTo(src.Value);

        public override int GetHashCode()
            => Value;

        [MethodImpl(Inline)]
        public string Format()
            => Value.FormatHex(zpad:true, specifier:true, uppercase:true);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Hash16(ushort src)
            => new Hash16(src);

        [MethodImpl(Inline)]
        public static explicit operator int(Hash16 src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator Hash32(Hash16 src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator Hash64(Hash16 src)
            => src.Value;

        [MethodImpl(Inline)]
        public static Hash32 operator | (Hash16 a, Hash16 b)
            => (uint)a.Value | ((uint)b.Value << 16);

        [MethodImpl(Inline)]
        public static Hash16 operator ^ (Hash16 a, Hash16 b)
            => (ushort)((uint)a.Value ^ (uint)b.Value);

        [MethodImpl(Inline)]
        public static Hash16 operator & (Hash16 a, Hash16 b)
            => (ushort)((uint)a.Value & (uint)b.Value);
    }
}