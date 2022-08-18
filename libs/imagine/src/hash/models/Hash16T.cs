//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct Hash16<T> : IHashCode<Hash16<T>,ushort>
        where T : unmanaged, IEquatable<T>
    {
        public readonly T Value;

        [MethodImpl(Inline)]
        public Hash16(T value)
            => Value = value;

        public ushort Primitive
        {
            [MethodImpl(Inline)]
            get => Scalars.uint16(Value);
        }

        ushort IHashCode<ushort>.Value
            => Primitive;

        public int CompareTo(Hash16<T> src)
            => Primitive.CompareTo(src.Primitive);

        public string Format()
            => Primitive.ToString("X");

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Hash16(Hash16<T> src)
            => new Hash16(src.Primitive);
    }

}