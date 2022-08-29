//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct PrimalIdentity : IIdentifiedType<PrimalIdentity>
    {
        /// <summary>
        /// Defines a primal identity if the source type represents a recognized primitive; otherwise,
        /// returns <see cref='PrimalIdentity.Empty'/>
        /// </summary>
        /// <param name="src">The source type</param>
        [Op]
        public static PrimalIdentity from(Type src)
            => src.IsSystemDefined() ?
               (NumericKinds.test(src)
               ? new PrimalIdentity(src.NumericKind(), CsData.keyword(src))
               : new PrimalIdentity(CsData.keyword(src))
               ) : PrimalIdentity.Empty;

        public string IdentityText {get;}

        public string Keyword {get;}

        [MethodImpl(Inline)]
        public PrimalIdentity(NumericKind kind, string keyword)
        {
            IdentityText = NumericIdentity.define(kind);
            Keyword = keyword;
        }

        [MethodImpl(Inline)]
        public PrimalIdentity(string keyword)
        {
            IdentityText = keyword;
            Keyword = keyword;
        }

        [MethodImpl(Inline)]
        public TypeIdentity AsTypeIdentity()
            => TypeIdentity.define(IdentityText);

        IIdentifiedType<PrimalIdentity> Identified => this;

        public override int GetHashCode()
            => IdentityText?.GetHashCode() ?? 0;

        public override bool Equals(object obj)
            => Identified.Same(obj);

        public override string ToString()
            => Identified.Format();

        [MethodImpl(Inline)]
        public static implicit operator string(PrimalIdentity src)
            => src.IdentityText;

        [MethodImpl(Inline)]
        public static implicit operator TypeIdentity(PrimalIdentity src)
            => src.AsTypeIdentity();

        [MethodImpl(Inline)]
        public static bool operator==(PrimalIdentity a, PrimalIdentity b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator!=(PrimalIdentity a, PrimalIdentity b)
            => !a.Equals(b);

        public static PrimalIdentity Empty => new PrimalIdentity(EmptyString);
    }
}