//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly record struct Hash8<T> : IHashCode<Hash8<T>,byte>
        where T : unmanaged, IEquatable<T>
    {
        public readonly T Value;

        [MethodImpl(Inline)]
        public Hash8(T value)
            => Value = value;

        public byte Primitive
        {
            [MethodImpl(Inline)]
            get => u8(Value);
        }

        byte IHashCode<byte>.Value
            => Primitive;

        public int CompareTo(Hash8<T> src)
            => Primitive.CompareTo(src.Primitive);

        public string Format()
            => u8(Value).ToString("X");

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Hash8(Hash8<T> src)
            => new Hash8(src.Primitive);
    }

}