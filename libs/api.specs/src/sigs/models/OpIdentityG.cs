//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines identity for a generic operation
    /// </summary>
    public readonly struct OpIdentityG : IMethodIdentity<OpIdentityG>
    {
        /// <summary>
        /// The operation identifier
        /// </summary>
        public string IdentityText {get;}

        [MethodImpl(Inline)]
        public OpIdentityG(string src)
            => IdentityText = src ?? EmptyString;

        public override int GetHashCode()
            => IdentityText?.GetHashCode() ?? 0;

        public override bool Equals(object obj)
            => Identified.Same(obj);

        public override string ToString()
            => Identified.Format();

        IMethodIdentity<OpIdentityG> Identified
            => this;

        public static OpIdentityG Empty
            => new OpIdentityG(EmptyString);
    }
}