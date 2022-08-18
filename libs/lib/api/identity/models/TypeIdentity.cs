//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    public readonly struct TypeIdentity : IIdentifiedType<TypeIdentity>
    {
        public string IdentityText {get;}

        /// <summary>
        /// Produces an identifier of the form {bitsize[T]}{u | i | f} for a numeric type
        /// </summary>
        /// <param name="t">A primal type representative</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static TypeIdentity numeric<T>(T t = default)
            where T : unmanaged
                => define(typeof(T).NumericKind().Format());

        public static TypeIdentity numeric(string prefix, Type arg)
        {
            var kind = arg.NumericKind();
            var indicator = kind.Indicator().ToChar();
            var width = kind.Width();
            return TypeIdentity.define($"{prefix}{width}{indicator}");
        }

        [MethodImpl(Inline)]
        public static TypeIdentity define(string id)
            => new TypeIdentity(id);

        /// <summary>
        /// Attempts to parse a numeric kind from a string in the form {width}{indicator}
        /// </summary>
        /// <param name="src">The source text</param>
        [Op]
        public static NumericKind numeric(string src)
        {
            var input = src.Trim();
            if(string.IsNullOrWhiteSpace(input))
                return 0;

            var indicator = (NumericIndicator)input.Last();
            if(!indicator.IsLiteral() || indicator == NumericIndicator.None)
                return 0;

            var width = 0u;
            if(!uint.TryParse(input.Substring(0, input.Length - 1), out width))
                return 0;

            var nw = (NumericWidth)width;
            if(!nw.IsLiteral())
                return 0;

            var kind = nw.ToNumericKind(indicator);
            if(!kind.IsLiteral())
                return 0;

            return kind;
        }

        /// <summary>
        /// Attempts to parse a sequence of numeric kinds from a sequence of strings in the form {width}{indicator}
        /// </summary>
        /// <param name="src">The source text</param>
        public static IEnumerable<NumericKind> numeric(IEnumerable<string> kinds)
            => from part in kinds
               let x = part.StartsWith(IDI.GenericLocator)
                    ? numeric(part.Substring(1, part.Length - 1))
                    : numeric(part)
                select x;


        [MethodImpl(Inline)]
        public TypeIdentity(string id)
            => IdentityText = id;

        IIdentifiedType<TypeIdentity> Identified => this;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => string.IsNullOrWhiteSpace(IdentityText);
        }

        public override int GetHashCode()
            => IdentityText?.GetHashCode() ?? 0;

        public override bool Equals(object obj)
            => Identified.Same(obj);

        public override string ToString()
            => Identified.Format();

        [MethodImpl(Inline)]
        public Option<TypeIdentity> ToOption()
            => IsEmpty ? Option.none<TypeIdentity>() : Option.some(this);

        [MethodImpl(Inline)]
        public static TypeIdentity operator +(TypeIdentity lhs, string rhs)
            => define($"{lhs}{rhs}");

        [MethodImpl(Inline)]
        public static TypeIdentity operator +(string lhs, TypeIdentity rhs)
            => define($"{lhs}{rhs}");

        [MethodImpl(Inline)]
        public static implicit operator string(TypeIdentity src)
            => src.IdentityText;

        [MethodImpl(Inline)]
        public static bool operator==(TypeIdentity a, TypeIdentity b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator!=(TypeIdentity a, TypeIdentity b)
            => !a.Equals(b);

        public static TypeIdentity Empty
            => define(EmptyString);
    }
}