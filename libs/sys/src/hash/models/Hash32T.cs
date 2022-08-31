//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly record struct Hash32<T> : IHashCode<Hash32<T>,uint>
        where T : unmanaged, IEquatable<T>
    {
        public readonly T Value;

        [MethodImpl(Inline)]
        public Hash32(T value)
            => Value = value;

        public uint Primitive
        {
            [MethodImpl(Inline)]
            get => u32(Value);
        }

        uint IHashCode<uint>.Value
            => Primitive;

        [MethodImpl(Inline)]
        public bool Equals(Hash32<T> src)
            => Primitive == src.Primitive;

        public override int GetHashCode()
            => (int)Primitive;

        public int CompareTo(Hash32<T> src)
            => Primitive.CompareTo(src.Primitive);

        public string Format()
            => u32(Value).ToString("X");

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Hash32(Hash32<T> src)
            => new Hash32(src.Primitive);
    }
}