//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = BitChars;

    /// <summary>
    /// Defines a character in a bitstring/bitfield representation
    /// </summary>
    public readonly record struct BitChar : IEquatable<BitChar>
    {
        public readonly BitCharKind Kind;

        [MethodImpl(Inline)]
        public BitChar(BitCharKind kind)
        {
            Kind = kind;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => false;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => true;
        }

        [MethodImpl(Inline)]
        public bool Equals(BitChar src)
            => (byte)Kind == (byte)src.Kind;

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => (byte)Kind;
        }

        public override int GetHashCode()
            => (int)Hash;

        [MethodImpl(Inline)]
        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator BitChar(BitCharKind src)
            => new BitChar(src);

        [MethodImpl(Inline)]
        public static implicit operator BitChar(bit src)
            => api.from(src);

        [MethodImpl(Inline)]
        public static implicit operator BitCharKind(BitChar src)
            => src.Kind;

        [MethodImpl(Inline)]
        public static implicit operator char(BitChar src)
            => api.render(src);
    }
}