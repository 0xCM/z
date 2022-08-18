//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    [DataWidth(Width)]
    public readonly struct AsmInstClass : IComparable<AsmInstClass>, IEquatable<AsmInstClass>
    {
        public static AsmInstClass parse(string src, out bool result)
        {
            result = XedParsers.parse(src, out AsmInstClass dst);
            return dst;
        }

        public const byte Width = num11.Width;

        public readonly InstClassType Kind;

        public AsmInstClass(InstClassType kind)
        {
            Require.nonzero(kind);
            Kind = kind;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => (uint)Kind;
        }

        public readonly AsmInstClass Classifier
            => this;

        public Identifier Name
            => IsEmpty ? EmptyString : Kind.ToString();

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

        public string Format()
            => Name;

        public override string ToString()
            => Format();

        public int CompareTo(AsmInstClass src)
            => Classifier.Format().CompareTo(src.Classifier.Format());

        [MethodImpl(Inline)]
        public bool Equals(AsmInstClass src)
            => Kind == src.Kind;

        public override int GetHashCode()
            => Hash;

        public override bool Equals(object o)
            => o is AsmInstClass c && Equals(c);

        [MethodImpl(Inline)]
        public static implicit operator AsmInstClass(InstClassType src)
            => new AsmInstClass(src);

        [MethodImpl(Inline)]
        public static implicit operator InstClassType(AsmInstClass src)
            => src.Kind;

        [MethodImpl(Inline)]
        public static bool operator ==(AsmInstClass a, AsmInstClass b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(AsmInstClass a, AsmInstClass b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static explicit operator ushort(AsmInstClass src)
            => (ushort)src.Kind;

        [MethodImpl(Inline)]
        public static explicit operator Hex12(AsmInstClass src)
            => (ushort)src.Kind;

        [MethodImpl(Inline)]
        public static explicit operator AsmInstClass(ushort src)
            => new AsmInstClass((InstClassType)src);

        public static AsmInstClass Empty => default;
    }
}