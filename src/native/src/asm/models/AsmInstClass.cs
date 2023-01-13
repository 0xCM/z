//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [DataWidth(Width)]
    public readonly struct AsmInstClass : IDataType<AsmInstClass>
    {
        public static Outcome parse(string src, out AsmInstClass dst)
        {
            var result = Outcome.Success;
            dst = AsmInstClass.Empty;
            try
            {
                
                result = EnumParser<AsmInstKind>.Service.Parse(src, out AsmInstKind kind);
                if(result)
                {
                    dst = kind;
                }
            }
            catch(Exception e)
            {
                result = e;
            }
            return result;
        }

        const byte Width = 11;

        public readonly AsmInstKind Kind;

        public AsmInstClass(AsmInstKind kind)
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
        public static implicit operator AsmInstClass(AsmInstKind src)
            => new AsmInstClass(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmInstKind(AsmInstClass src)
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
            => new AsmInstClass((AsmInstKind)src);

        public static AsmInstClass Empty => default;
    }
}