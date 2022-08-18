//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct Hash32 : IHashCode<Hash32,uint>
    {
        public readonly uint Value;

        [MethodImpl(Inline)]
        public Hash32(uint value)
            => Value = value;

        [MethodImpl(Inline)]
        public string Format()
            => Value.FormatHex(zpad:true, specifier:true, uppercase:true);

        public override string ToString()
            => Format();

        public uint Primitive
        {
            [MethodImpl(Inline)]
            get => Value;
        }

        uint IHashCode<uint>.Value
            => Value;

        [MethodImpl(Inline)]
        public bool Equals(Hash32 src)
            => Value.Equals(src.Value);

        [MethodImpl(Inline)]
        public int CompareTo(Hash32 src)
            => Value.CompareTo(src.Value);

        public override int GetHashCode()
            => (int)Value;

        [MethodImpl(Inline)]
        public static implicit operator Hash32(uint src)
            => new Hash32(src);

        [MethodImpl(Inline)]
        public static implicit operator int(Hash32 src)
            => (int)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator uint(Hash32 src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator Hash32(int src)
            => new Hash32((uint)src);

        [MethodImpl(Inline)]
        public static implicit operator Hash32(ushort src)
            => new Hash32((uint)src);

        [MethodImpl(Inline)]
        public static uint operator %(Hash32 src, uint m)
            => src.Value % m;

        [MethodImpl(Inline)]
        public static Hash32 operator | (Hash32 a, Hash32 b)
            => HashCodes.combine(a,b);

        [MethodImpl(Inline)]
        public static Hash32 operator ^ (Hash32 a, Hash32 b)
            => a.Value ^ b.Value;

        [MethodImpl(Inline)]
        public static Hash32 operator & (Hash32 a, Hash32 b)
            => a.Value & b.Value;

        public static Hash32 Zero => default;
    }
}