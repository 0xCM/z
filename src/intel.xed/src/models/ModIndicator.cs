//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    public readonly record struct ModIndicator : IComparable<ModIndicator>, IEquatable<ModIndicator>
    {
        public readonly ModKind Kind;

        [MethodImpl(Inline)]
        public ModIndicator(ModKind kind)
        {
            Kind = kind;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Kind == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Kind != 0;
        }

        public bool IsNonZero
        {
            [MethodImpl(Inline)]
            get => Kind != 0;
        }

        public uint2 Glyph
        {
            [MethodImpl(Inline)]
            get => IsEmpty ? uint2.Zero : (Kind == ModKind.NE3 ? uint2.One : uint2.Max);
        }

        public string Format()
            => Kind == 0 ? EmptyString : XedRender.format(Kind);

        public override string ToString()
            => Format();

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => (byte)Kind;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public int CompareTo(ModIndicator src)
            => ((byte)Kind).CompareTo((byte)src.Kind);

        [MethodImpl(Inline)]
        public bool Equals(ModIndicator src)
            => Kind == src.Kind;

        [MethodImpl(Inline)]
        public static implicit operator ModIndicator(ModKind src)
            => new (src);

        [MethodImpl(Inline)]
        public static explicit operator ModIndicator(num3 src)
            => new ((ModKind)(byte)src);

        [MethodImpl(Inline)]
        public static explicit operator num3(ModIndicator src)
            => (num3)(byte)src.Kind;

        [MethodImpl(Inline)]
        public static explicit operator uint(ModIndicator src)
            => (uint)src.Kind;

        [MethodImpl(Inline)]
        public static explicit operator ModIndicator(uint src)
            => new ((ModKind)src);

        public static ModIndicator Empty => default;
    }
}
