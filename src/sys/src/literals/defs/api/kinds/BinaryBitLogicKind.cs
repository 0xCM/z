//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static BinaryBitLogicNames;

    using NBK = NumericBaseKind;

    /// <summary>
    /// Classifies binary boolean and bitwise logical operations
    /// </summary>
    [SymSource(api_kinds, NBK.Base16)]
    public enum BinaryBitLogicKind : ushort
    {
        /// <summary>
        /// Classifies a logical  binary operator false(a,b) := bv(0000)
        /// </summary>
        /// <remarks>
        /// bv(0000) = id(True)
        /// </remarks>
        [Symbol(@false)]
        False = 0,

        /// <summary>
        /// Classifies a logical binary operator and(a,b) := bv(1000)
        /// </summary>
        /// <remarks>
        /// bv(1000) = id(Nor)
        /// 0 0 0
        /// 1 0 0
        /// 0 1 0
        /// 1 1 1
        /// </remarks>
        [Symbol(@and)]
        And = 0b0001,

        /// <summary>
        /// Classifies a logical binary operator cnotimply(a,b) := and(a, ~b) = bv(0010)
        /// </summary>
        /// <remarks>
        /// bv(0010) = id(ConverseNonimplication)
        /// Truth table:
        /// 0 0 0
        /// 1 0 1
        /// 0 1 0
        /// 1 1 0
        /// </remarks>
        [Symbol(cnonimpl)]
        CNonImpl = 0b0010,

        /// <summary>
        /// Classifies a logical binary operator left(a,b) := a = bv(1010)
        /// </summary>
        /// <remarks>
        /// bv(1010) = id(RightNot)
        /// Truth Table:
        /// 0 0 0
        /// 1 0 1
        /// 0 1 0
        /// 1 1 1
        /// </remarks>
        [Symbol(left)]
        Left = 0b0011,

        /// <summary>
        /// Identifies a logical binary operator nonimpl(a,b) := and(~a, b) = bv(0100)
        /// </summary>
        /// <remarks>
        /// bv(0100) = id(Nonimplication)
        /// Truth table:
        /// 0 0 0
        /// 1 0 0
        /// 0 1 1
        /// 1 1 0
        /// </remarks>
        [Symbol(nonimpl)]
        NonImpl = 0b0100,

        /// <summary>
        /// Classifies a logical binary operator right(a,b) := b = bv(1100)
        /// </summary>
        /// <remarks>
        /// bv(1100) = id(LeftNot)
        /// Truth table:
        /// 0 0 0
        /// 1 0 0
        /// 0 1 1
        /// 1 1 1
        /// </remarks>
        [Symbol(right)]
        Right = 0b0101,

        /// <summary>
        /// Classifies a logical binary operator xor(a,b) := bv(0110)
        /// </summary>
        /// <remarks>
        /// bv(0110) = id(XOr)
        /// Truth Table:
        /// 0 0 0
        /// 1 0 1
        /// 0 1 1
        /// 1 1 0
        /// </remarks>
        [Symbol(xor)]
        Xor = 0b0110,

        /// <summary>
        /// Classifies a logical binary operator or(a,b) := bv(1110)
        /// </summary>
        /// <remarks>
        /// bv(1110) = id(Nand)
        /// Truth Table:
        /// 0 0 0
        /// 1 0 1
        /// 0 1 1
        /// 1 1 1
        /// </remarks>
        [Symbol(or)]
        Or = 0b0111,

        /// <summary>
        /// Classifies a logical binary operator that computes nor(a,b) := not(or(a,b)) = bv(0001)
        /// </summary>
        /// <remarks>
        /// bv(0001) = id(And)
        /// Truth Table:
        /// 0 0 1
        /// 1 0 0
        /// 0 1 0
        /// 1 1 0
        /// </remarks>
        [Symbol(nor)]
        Nor = 0b1000,

        /// <summary>
        /// Classifies a binary operator xnor(a,b) := not(xor(a,b)) = bv(1001)
        /// </summary>
        /// <remarks>
        /// bv(1001) = id(Xnor)
        /// Truth Table:
        /// 0 0 1
        /// 1 0 0
        /// 0 1 0
        /// 1 1 1
        /// </remarks>
        [Symbol(xnor)]
        Xnor = 0b1001,

        /// <summary>
        /// Classifies a logical binary operator rnot(a,b) := not(b) = bv(0011)
        /// </summary>
        /// <remarks>
        /// bv(0011) = id(LeftProject)
        /// Truth table:
        /// 0 0 1
        /// 1 0 1
        /// 0 1 0
        /// 1 1 0
        /// </remarks>
        [Symbol(rnot)]
        RNot = 0b1010,

        /// <summary>
        /// Classifies a logical binary operator impl(a,b) := or(a, not(b)) = bv(1011)
        /// </summary>
        /// <remarks>
        /// bv(1011) = id(Implication)
        /// Truth table:
        /// 0 0 1
        /// 1 0 1
        /// 0 1 0
        /// 1 1 1
        /// </remarks>
        [Symbol(impl)]
        Impl = 0b1011,

        /// <summary>
        /// Classifies a logical binary operator lnot(a,b) := not(a) = bv(0101)
        /// </summary>
        /// <remarks>
        /// bv(0101) = id(RightProject)
        /// Truth table:
        /// 0 0 1
        /// 1 0 0
        /// 0 1 1
        /// 1 1 0
        /// </remarks>
        [Symbol(lnot)]
        LNot = 0b1100,

        /// <summary>
        /// Classifies a logical binary operator cimpl(a,b) := or(not(a), b) = bv(1101)
        /// </summary>
        /// bv(1101) = id(ConverseImplication)
        /// <remarks>
        /// Truth table:
        /// 0 0 1
        /// 1 0 0
        /// 0 1 1
        /// 1 1 1
        /// </remarks>
        [Symbol(cimpl)]
        CImpl = 0b1101,

        /// <summary>
        /// Classifies a logical binary operator nand(a,b) := not(and(a,b)) = bv(0111)
        /// </summary>
        /// <remarks>
        /// bv(0111) = id(Or)
        /// Truth Table:
        /// 0 0 1
        /// 1 0 1
        /// 0 1 1
        /// 1 1 0
        /// </remarks>
        [Symbol(@nand)]
        Nand = 0b1110,

        /// <summary>
        /// Classifies a logical binary operator true(a,b) = bv(1111)
        /// </summary>
        /// <remarks>
        /// bv(1111) = id(False)
        /// </remarks>
        [Symbol(@true)]
        True = 0b1111,
    }
}