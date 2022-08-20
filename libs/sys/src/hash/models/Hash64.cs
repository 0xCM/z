//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct Hash64 : IHashCode<Hash64,ulong>
    {
        public readonly ulong Value;

        [MethodImpl(Inline)]
        public Hash64(ulong value)
            => Value = value;

        public ulong Primitive
        {
            [MethodImpl(Inline)]
            get => Value;
        }

        ulong IHashCode<ulong>.Value
            => Value;

        [MethodImpl(Inline)]
        public bool Equals(Hash64 src)
            => Value == src.Value;

        [MethodImpl(Inline)]
        public int CompareTo(Hash64 src)
            => Value.CompareTo(src.Value);

        public override int GetHashCode()
            => Value.GetHashCode();

        public string Format()
            => Value.FormatHex(zpad:true, specifier:true, uppercase:true);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Hash64(ulong src)
            => new Hash64(src);
    }
}