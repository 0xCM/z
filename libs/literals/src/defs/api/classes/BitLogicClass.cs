//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiAtomic;

    using Id = ApiClassKind;

    /// <summary>
    /// Classifies binary boolean and bitwise logical operations
    /// </summary>
    [ApiClass, SymSource(api_classes)]
    public enum BitLogicClass : ushort
    {
        /// <summary>
        /// The empty identity which, unfortunately conflicts with the inescapable defintion of 'False'
        /// </summary>
        None = 0b000,

        /// <summary>
        /// Classifies a logical  binary operator false(a,b) := bv(0000)
        /// </summary>
        [Symbol("false")]
        False = Id.None,

        /// <summary>
        /// Classifies a logical binary operator and(a,b) := bv(1000)
        /// </summary>
        [Symbol("and")]
        And = Id.And,

        /// <summary>
        /// Classifies a logical binary operator cnotimply(a,b) := and(a, ~b) = bv(0010)
        /// </summary>
        [Symbol("cnonimpl")]
        CNonImpl = Id.CNonImpl,

        /// <summary>
        /// Classifies a logical binary operator left(a,b) := a = bv(1010)
        /// </summary>
        [Symbol("left")]
        LProject = Id.LProject,

        /// <summary>
        /// Identifies a logical binary operator notimply(a,b) := and(~a, b) = bv(0100)
        /// </summary>
        [Symbol("nonimpl")]
        NonImpl = Id.NonImpl,

        /// <summary>
        /// Classifies a logical binary operator right(a,b) := b = bv(1100)
        /// </summary>
        [Symbol("right")]
        RProject = Id.RProject,

        /// <summary>
        /// Classifies a logical binary operator xor(a,b) := bv(0110)
        /// </summary>
        [Symbol("xor")]
        Xor = Id.Xor,

        /// <summary>
        /// Classifies a logical binary operator or(a,b) := bv(1110)
        /// </summary>
        [Symbol("or")]
        Or = Id.Or,

        /// <summary>
        /// Classifies a logical binary operator that computes nor(a,b) := not(or(a,b)) = bv(0001)
        /// </summary>
        [Symbol("nor")]
        Nor = Id.Nor,

        /// <summary>
        /// Classifies a binary operator xnor(a,b) := not(xor(a,b)) = bv(1001)
        /// </summary>
        [Symbol("xnor")]
        Xnor = Id.Xnor,

        /// <summary>
        /// Classifies a logical binary operator rnot(a,b) := not(b) = bv(0011)
        /// </summary>
        [Symbol("rnot")]
        RNot = Id.RNot,

        /// <summary>
        /// Classifies a logical binary operator imply(a,b) := or(a, not(b)) = bv(1011)
        /// </summary>
        [Symbol("impl")]
        Impl = Id.Impl,

        /// <summary>
        /// Classifies a logical binary operator lnot(a,b) := not(a) = bv(0101)
        /// </summary>
        [Symbol("lnot")]
        LNot = Id.LNot,

        /// <summary>
        /// Classifies a logical binary operator cimpl(a,b) := or(not(a), b) = bv(1101)
        /// </summary>
        [Symbol("cimpl")]
        CImpl = Id.CImpl,

        /// <summary>
        /// Classifies a logical binary operator nand(a,b) := not(and(a,b)) = bv(0111)
        /// </summary>
        [Symbol("nand")]
        Nand = Id.Nand,

        /// <summary>
        /// Classifies a logical binary operator true(a,b) = bv(1111)
        /// </summary>
        [Symbol("true")]
        True = Id.True,

        /// <summary>
        /// Classifies a logical unary negation operator
        /// </summary>
        [Symbol("not")]
        Not = Id.Not,

        /// <summary>
        /// Classifies a ternary select operator
        /// </summary>
        [Symbol("xelect")]
        Select = Id.Select,

        [Symbol("xornot")]
        XorNot = Id.XorNot
    }
}