//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [DataWidth(Width)]
    public readonly struct XedInstClass : IDataType<XedInstClass>
    {
        // public static Outcome parse(string src, out XedInstClass dst)
        // {
        //     var result = Outcome.Success;
        //     dst = XedInstClass.Empty;
        //     try
        //     {
                
        //         result = EnumParser<XedInstKind>.Service.Parse(src, out XedInstKind kind);
        //         if(result)
        //         {
        //             dst = kind;
        //         }
        //     }
        //     catch(Exception e)
        //     {
        //         result = e;
        //     }
        //     return result;
        // }

        const byte Width = 11;

        public readonly XedInstKind Kind;

        public XedInstClass(XedInstKind kind)
        {
            Require.nonzero(kind);
            Kind = kind;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => (uint)Kind;
        }

        public readonly XedInstClass Classifier
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

        public int CompareTo(XedInstClass src)
            => Classifier.Format().CompareTo(src.Classifier.Format());

        [MethodImpl(Inline)]
        public bool Equals(XedInstClass src)
            => Kind == src.Kind;

        public override int GetHashCode()
            => Hash;

        public override bool Equals(object o)
            => o is XedInstClass c && Equals(c);

        [MethodImpl(Inline)]
        public static implicit operator XedInstClass(XedInstKind src)
            => new XedInstClass(src);

        [MethodImpl(Inline)]
        public static implicit operator XedInstKind(XedInstClass src)
            => src.Kind;

        [MethodImpl(Inline)]
        public static bool operator ==(XedInstClass a, XedInstClass b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(XedInstClass a, XedInstClass b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static explicit operator ushort(XedInstClass src)
            => (ushort)src.Kind;

        [MethodImpl(Inline)]
        public static explicit operator Hex12(XedInstClass src)
            => (ushort)src.Kind;

        [MethodImpl(Inline)]
        public static explicit operator XedInstClass(ushort src)
            => new XedInstClass((XedInstKind)src);

        public static XedInstClass Empty => default;
    }
}