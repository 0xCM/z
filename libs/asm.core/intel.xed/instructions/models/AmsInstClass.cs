//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    [DataWidth(Width)]
    public readonly struct AmsInstClass : IDataType<AmsInstClass>
    {
        public static AmsInstClass parse(string src, out bool result)
        {
            result = XedParsers.parse(src, out AmsInstClass dst);
            return dst;
        }

        const byte Width = num11.Width;

        public readonly AsmInstKind Kind;

        public AmsInstClass(AsmInstKind kind)
        {
            Require.nonzero(kind);
            Kind = kind;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => (uint)Kind;
        }

        public readonly AmsInstClass Classifier
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

        public int CompareTo(AmsInstClass src)
            => Classifier.Format().CompareTo(src.Classifier.Format());

        [MethodImpl(Inline)]
        public bool Equals(AmsInstClass src)
            => Kind == src.Kind;

        public override int GetHashCode()
            => Hash;

        public override bool Equals(object o)
            => o is AmsInstClass c && Equals(c);

        [MethodImpl(Inline)]
        public static implicit operator AmsInstClass(AsmInstKind src)
            => new AmsInstClass(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmInstKind(AmsInstClass src)
            => src.Kind;

        [MethodImpl(Inline)]
        public static bool operator ==(AmsInstClass a, AmsInstClass b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(AmsInstClass a, AmsInstClass b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static explicit operator ushort(AmsInstClass src)
            => (ushort)src.Kind;

        [MethodImpl(Inline)]
        public static explicit operator Hex12(AmsInstClass src)
            => (ushort)src.Kind;

        [MethodImpl(Inline)]
        public static explicit operator AmsInstClass(ushort src)
            => new AmsInstClass((AsmInstKind)src);

        public static AmsInstClass Empty => default;
    }
}