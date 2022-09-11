//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = NumericIndicator;
    using C = NumericClass;

    public readonly record struct NumericClass : IComparable<C>
    {
        public static bool parse(ReadOnlySpan<char> src, out C dst)
        {
            dst = Empty;
            if(src.Length == 1)
            {
                 var c = (AsciCode)sys.first(src);
                 switch(c)
                 {
                     case AsciCode.i:
                        dst = Signed;
                     break;
                     case AsciCode.f:
                        dst = Float;
                     break;
                     case AsciCode.u:
                        dst = Unsigned;
                     break;
                 }
            }

            return dst != Empty;
        }

        [Parser]
        public static bool parse(string src, out C dst)
            => parse(sys.span(src), out dst);

        public static C Signed => K.Signed;

        public static C Float => K.Float;

        public static C Unsigned => K.Unsigned;

        public readonly K Kind;

        [MethodImpl(Inline)]
        public NumericClass(K src)
        {
            Kind = src;
        }

        public string Format()
            => Symbol.Format();

        public override string ToString()
            => Format();

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => (uint)Kind;
        }

        public AsciSymbol Symbol
        {
            [MethodImpl(Inline)]
            get => (AsciCode)Kind;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(C src)
            => Kind == src.Kind;

        [MethodImpl(Inline)]
        static byte order(K src)
        {
            const byte UOrder = 1;
            const byte IOrder = 2;
            const byte FOrder = 3;
            var result = z8;
            if(src == K.Unsigned)
                result = UOrder;
            else if(src == K.Signed)
                result = IOrder;
            else if(src == K.Float)
                result = FOrder;
            return result;
        }

        [MethodImpl(Inline)]
        public int CompareTo(C src)
            => order(Kind).CompareTo(order(src.Kind));

        [MethodImpl(Inline)]
        public static implicit operator C(K src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator K(C src)
            => src.Kind;

        public static C Empty => default;
    }
}