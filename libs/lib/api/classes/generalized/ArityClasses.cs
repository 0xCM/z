//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = ApiArityKind;

    /// <summary>
    /// Classifies operations of arity 0
    /// </summary>
    public readonly struct A0 : ILiteralKind<A0,K>
    {
        public K Class => K.Nullary;
    }

    /// <summary>
    /// Classifies operations of arity 0
    /// </summary>
    public readonly struct A1 : ILiteralKind<A1,K>
    {
        public K Class => K.Unary;
    }

    /// <summary>
    /// Classifies operations of arity 0
    /// </summary>
    public readonly struct A2 : ILiteralKind<A2,K>
    {
        public K Class => K.Binary;
    }

    /// <summary>
    /// Classifies operations of arity 3
    /// </summary>
    public readonly struct A3 : ILiteralKind<A3,K>
    {
        public K Class => K.Ternary;
    }
}