//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedRules
{
    [DataWidth(Width)]
    public readonly record struct RuleField : IComparable<RuleField>
    {
        public const byte Width = num7.Width;

        public readonly FieldKind Kind;

        [MethodImpl(Inline)]
        public RuleField(FieldKind kind)
        {
            Kind = kind;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => (byte)Kind;
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

        [MethodImpl(Inline)]
        public bool Equals(RuleField src)
            => Kind == src.Kind;

        public int CompareTo(RuleField src)
            => Xed.cmp(Kind,src.Kind);

        public string Format()
            => XedRender.format(Kind);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public static explicit operator num7(RuleField src)
            => (byte)src.Kind;

        [MethodImpl(Inline)]
        public static explicit operator RuleField(num7 src)
            => new RuleField((FieldKind)(byte)src);

        [MethodImpl(Inline)]
        public static implicit operator RuleField(FieldKind src)
            => new RuleField(src);

        [MethodImpl(Inline)]
        public static implicit operator FieldKind(RuleField src)
            => src.Kind;

        public static RuleField Empty => default;
    }
}
