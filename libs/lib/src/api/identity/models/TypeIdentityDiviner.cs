//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    readonly struct TypeIdentityDiviner : ITypeIdentityDiviner
    {
        public TypeIdentity DivineIdentity(Type arg)
            => TryDivine(arg).ValueOrElse(() => TypeIdentity.define(arg.DisplayName()));

        public Option<TypeIdentity> TryDivine(Type arg)
        {
            if(arg.IsPointer)
                return PointerId(arg);
            else if(arg.IsTypeNat())
                return NatId(arg);
            else if(arg.IsSystemDefined())
                return PrimalIdentity.from(arg).AsTypeIdentity().ToOption();
            else if(arg.IsEnum)
                return Option.some(EnumIdentity.define(arg).AsTypeIdentity());
            else if(arg.IsSpanBlock())
                return SegmentedId(arg);
            else if(arg.IsArray)
                return ArrayId(arg);
            else if(SpanTypes.IsSystemSpan(arg))
                return SystemSpanId(arg);
            else if(NatSpanAttribute.test(arg))
                return NatSpanId(arg);
            else
                return Option.none<TypeIdentity>();
        }

        /// <summary>
        /// Retrieves a cached identity provider, if found; otherwise, creates and caches the identity provider for the source type
        /// </summary>
        /// <param name="t">The source type</param>
        [MethodImpl(Inline)]
        public static ITypeIdentityProvider IdentityProvider(Type src)
            => TypeIdentityProviders.create(src, DefaultProvider);

        static TypeIdentity DoDivination(Type arg)
            => default(TypeIdentityDiviner).DivineIdentity(arg);

        static TypeIdentity PointerId(Type arg)
            => TypeIdentity.define(string.Concat(DoDivination(arg.Unwrap()), IDI.ModSep, IDI.Pointer));

        static Option<TypeIdentity> SegmentedId(Type t)
            =>  from i in ApiIdentity.SegIndicator(t)
                let segwidth = ApiIdentity.width(t)
                where segwidth.IsSome()
                let segFmt = segwidth.FormatValue()
                let arg = t.GetGenericArguments().Single()
                let argwidth = ApiIdentity.width(arg)
                where argwidth.IsSome()
                let argFmt = argwidth.FormatValue()
                let nk = arg.NumericKind()
                where  nk != 0
                let nki = nk.Indicator().Format()
                let identifer = text.concat(i, segFmt, IDI.SegSep, argFmt, nki)
                select SegmentedIdentity.define(i, segwidth, nk).AsTypeIdentity();

        static Option<TypeIdentity> NatId(Type arg)
            => from v in arg.NatValue()
                let id = text.concat(IDI.Nat, v.ToString())
                select TypeIdentity.define(id);

        static Option<TypeIdentity> SystemSpanId(Type arg)
        {
            var kind = SpanTypes.kind(arg);
            if(kind != 0 && kind != SpanKind.Custom)
            {
                var idCell = DoDivination(arg.GetGenericArguments().Single());
                return TypeIdentity.define(text.concat(kind.Format(), idCell));
            }
            else
                return Option.none<TypeIdentity>();
        }

        static Option<TypeIdentity> ArrayId(Type arg)
        {
            if(arg.IsArray)
            {
                var cellType = arg.GetElementType();
                var cellId = DoDivination(cellType);
                return TypeIdentity.define(text.concat(IDI.Array, Chars.Underscore, cellId));
            }
            else
                return Option.none<TypeIdentity>();
        }

        /// <summary>
        /// Defines an identity for a type-natural span type
        /// </summary>
        /// <param name="src">The type to examine</param>
        static Option<TypeIdentity> NatSpanId(Type src)
        {
            if(NatSpanAttribute.test(src))
            {
                var typeargs = src.SuppliedTypeArgs();
                var text = IDI.NatSpan;
                text += typeargs[0].NatValue();
                text += IDI.SegSep;
                text += typeargs[1].NumericKind().Format();
                return TypeIdentity.define(text);
            }
            else
                return Option.none<TypeIdentity>();
        }

        static readonly ITypeIdentityProvider DefaultProvider
            = new TypeIdentityProvider(DoDivination);
    }
}