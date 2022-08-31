//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = HashCodes;

    using H = Hash8;
    using V = System.Byte;

    public readonly record struct Hash8 : IHashCode<H,V>
    {
        public readonly byte Value;

        [MethodImpl(Inline)]
        public Hash8(byte value)
            => Value = value;

        public byte Primitive
        {
            [MethodImpl(Inline)]
            get => Value;
        }

        byte IHashCode<byte>.Value 
            => Value;

        [MethodImpl(Inline)]
        public bool Equals(Hash8 src)
            => Value == src.Value;

        [MethodImpl(Inline)]
        public int CompareTo(Hash8 src)
            => Value.CompareTo(src.Value);

        public override int GetHashCode()
            => Value;

        public string Format()
            => api.format<Hash8,byte>(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Hash8(byte src)
            => new Hash8(src);

        [MethodImpl(Inline)]
        public static implicit operator Hash16(Hash8 src)
            => new Hash16(src.Value);

        [MethodImpl(Inline)]
        public static implicit operator Hash32(Hash8 src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator Hash64(Hash8 src)
            => src.Value;

        [MethodImpl(Inline)]
        public static Hash16 operator | (Hash8 a, Hash8 b)
            => (ushort)((uint)a.Value | ((uint)b.Value << 8));

        [MethodImpl(Inline)]
        public static Hash8 operator ^ (Hash8 a, Hash8 b)
            => (byte)((uint)a.Value ^ (uint)b.Value);

        [MethodImpl(Inline)]
        public static Hash8 operator & (Hash8 a, Hash8 b)
            => (byte)((uint)a.Value & (uint)b.Value);
    }
}