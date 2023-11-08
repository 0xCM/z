//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static BinaryBitLogicKind;
using static UnaryBitLogicKind;

[ApiHost]
public partial struct BitLogicSpec
{
    const NumericKind Closure = UInt64k;

    /// <summary>
    /// Defines a logical not operator over a logic expression
    /// </summary>
    /// <param name="a">The operand</param>
    [MethodImpl(Inline), Op]
    public static UnaryLogicOpExpr not(ILogicExpr a)
        => unary(Not, a);

    /// <summary>
    /// Defines a logical not operator over a bit literal
    /// </summary>
    /// <param name="a">The operand</param>
    [MethodImpl(Inline), Op]
    public static UnaryLogicOpExpr not(bit a)
        => unary(Not, a);

    /// <summary>
    /// Defines a logical not operator over a typed logic expression
    /// </summary>
    /// <param name="a">The operand</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static UnaryLogicOpExpr<T> not<T>(ILogicExpr<T> a)
        where T : unmanaged
            => unary(Not, a);

    /// <summary>
    /// Defines a logical not operator over a typed literal
    /// </summary>
    /// <param name="a">The operand</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static UnaryLogicOpExpr<T> not<T>(bit a)
        where T : unmanaged
            => unary<T>(Not, a);

    /// <summary>
    /// Defines a logical And operator over expression operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op]
    public static BinaryLogicOpExpr and(ILogicExpr a, ILogicExpr b)
        => binary(And, a, b);

    /// <summary>
    /// Defines a logical And operator over bit literal operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op]
    public static BinaryLogicOpExpr and(bit a, bit b)
        => binary(And, a, b);

    /// <summary>
    /// Defines a logical And operator over typed expression operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static BinaryLogicOpExpr<T> and<T>(ILogicExpr<T> a, ILogicExpr<T> b)
        where T : unmanaged
            => binary(And, a, b);

    /// <summary>
    /// Defines a logical And operator over typed literal operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    static BinaryLogicOpExpr<T> and<T>(bit a, bit b)
        where T:  unmanaged
            => binary<T>(And, a, b);

    /// <summary>
    /// Defines a logical Nand operator over expression operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op]
    public static BinaryLogicOpExpr nand(ILogicExpr a, ILogicExpr b)
        => binary(Nand, a, b);

    /// <summary>
    /// Defines a logical Nand operator over bit literal operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op]
    public static BinaryLogicOpExpr nand(bit a, bit b)
        => binary(Nand, a, b);

    /// <summary>
    /// Defines a logical Nand operator over typed expression operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static BinaryLogicOpExpr<T> nand<T>(ILogicExpr<T> a, ILogicExpr<T> b)
        where T : unmanaged
        => binary(Nand, a, b);

    /// <summary>
    /// Defines a logical Nand operator over typed literal operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    static BinaryLogicOpExpr<T> nand<T>(bit a, bit b)
        where T : unmanaged
            => binary<T>(Nand, a, b);

    /// <summary>
    /// Defines a logical Or operator over expression operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op]
    public static BinaryLogicOpExpr or(ILogicExpr a, ILogicExpr b)
        => binary(Or, a, b);

    /// <summary>
    /// Defines a logical Or operator over literal operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op]
    public static BinaryLogicOpExpr or(bit a, bit b)
        => binary(Or, a, b);

    /// <summary>
    /// Defines a logical Or operator over typed expression operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static BinaryLogicOpExpr<T> or<T>(ILogicExpr<T> a, ILogicExpr<T> b)
        where T : unmanaged
            => binary(Or, a, b);

    /// <summary>
    /// Defines a logical Or operator over typed expression operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    static BinaryLogicOpExpr<T> or<T>(bit a, bit b)
        where T : unmanaged
            => binary<T>(Or, a, b);

    /// <summary>
    /// Defines a nor operator over expression operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op]
    public static BinaryLogicOpExpr nor(ILogicExpr a, ILogicExpr b)
        => binary(Nor, a, b);

    /// <summary>
    /// Defines a logical Nor operator over typed expression operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static BinaryLogicOpExpr<T> nor<T>(ILogicExpr<T> a, ILogicExpr<T> b)
        where T : unmanaged
            => binary(Nor, a, b);

    /// <summary>
    /// Defines a nor operator over literal operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op]
    public static BinaryLogicOpExpr nor(bit a, bit b)
        => binary(Nor, a, b);

    /// <summary>
    /// Defines a logical Nor operator over typed literal operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    static BinaryLogicOpExpr<T> nor<T>(bit a, bit b)
        where T : unmanaged
            => binary<T>(Nor, a, b);

    /// <summary>
    /// Defines a logical Xor operator over expression operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op]
    public static BinaryLogicOpExpr xor(ILogicExpr a, ILogicExpr b)
        => binary(Xor, a, b);

    /// <summary>
    /// Defines a logical Xor operator over literal operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op]
    public static BinaryLogicOpExpr xor(bit a, bit b)
        => binary(Xor, a, b);

    /// <summary>
    /// Defines a logical Xor operator over typed expression operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static BinaryLogicOpExpr<T> xor<T>(ILogicExpr<T> a, ILogicExpr<T> b)
        where T : unmanaged
            => binary(Xor, a, b);

    /// <summary>
    /// Defines a logical Xor operator over typed expression operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    static BinaryLogicOpExpr<T> xor<T>(bit a, bit b)
        where T : unmanaged
            => binary<T>(Xor, a, b);

    /// <summary>
    /// Defines an xnor operator over expression operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op]
    public static BinaryLogicOpExpr xnor(ILogicExpr a, ILogicExpr b)
        => binary(Xnor, a, b);

    /// <summary>
    /// Defines an xnor operator over literal operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op]
    public static BinaryLogicOpExpr xnor(bit a, bit b)
        => binary(Xnor, a, b);

    /// <summary>
    /// Defines a logical Xnor operator over typed expression operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static BinaryLogicOpExpr<T> xnor<T>(ILogicExpr<T> a, ILogicExpr<T> b)
        where T : unmanaged
            => binary(Xnor, a, b);

    /// <summary>
    /// Defines a logical Xnor operator over typed expression operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline)]
    static BinaryLogicOpExpr<T> xnor<T>(bit a, bit b)
        where T : unmanaged
            => binary<T>(Xnor, a, b);

    /// <summary>
    /// Defines a left projection operator over expression operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op]
    public static BinaryLogicOpExpr left(ILogicExpr a, ILogicExpr b)
        => binary(Left, a, b);

    /// <summary>
    /// Defines a logical Xor operator over typed expression operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline)]
    public static BinaryLogicOpExpr<T> left<T>(ILogicExpr<T> a, ILogicExpr<T> b)
        where T : unmanaged
            => binary(Left, a, b);

    /// <summary>
    /// Defines a left projection over literal operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op]
    public static BinaryLogicOpExpr left(bit a, bit b)
        => binary(Left, a, b);

    /// <summary>
    /// Defines a left projection operator over typed literal operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    static BinaryLogicOpExpr<T> left<T>(bit a, bit b)
        where T : unmanaged
            => binary<T>(Left, a, b);

    /// <summary>
    /// Defines a right projection operator over expression operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op]
    public static BinaryLogicOpExpr right(ILogicExpr a, ILogicExpr b)
        => binary(Right, a, b);

    /// <summary>
    /// Defines a right projection over literal operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op]
    public static BinaryLogicOpExpr right(bit a, bit b)
        => binary(Right, a, b);

    /// <summary>
    /// Defines a right projection operator over typed expression operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static BinaryLogicOpExpr<T> right<T>(ILogicExpr<T> a, ILogicExpr<T> b)
        where T : unmanaged
            => binary(Right, a, b);

    /// <summary>
    /// Defines a right projection operator over typed literal operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    static BinaryLogicOpExpr<T> right<T>(bit a, bit b)
        where T : unmanaged
            => binary<T>(Right, a, b);

    /// <summary>
    /// Defines a left negation operator over expression operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op]
    public static BinaryLogicOpExpr lnot(ILogicExpr a, ILogicExpr b)
        => binary(LNot, a, b);

    /// <summary>
    /// Defines a left negation operator over literal operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op]
    public static BinaryLogicOpExpr lnot(bit a, bit b)
        => binary(LNot, a, b);

    /// <summary>
    /// Defines a left negation operator over typed expression operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static BinaryLogicOpExpr<T> lnot<T>(ILogicExpr<T> a, ILogicExpr<T> b)
        where T : unmanaged
            => binary(LNot, a, b);

    /// <summary>
    /// Defines a left negation operator over typed literal operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    static BinaryLogicOpExpr<T> lnot<T>(bit a, bit b)
        where T : unmanaged
            => binary<T>(LNot, a, b);

    /// <summary>
    /// Defines a right negation operator over expression operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op]
    public static BinaryLogicOpExpr rnot(ILogicExpr a, ILogicExpr b)
        => binary(RNot, a, b);

    /// <summary>
    /// Defines a right negation operator over literal operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op]
    public static BinaryLogicOpExpr rnot(bit a, bit b)
        => binary(RNot, a, b);

    /// <summary>
    /// Defines a right negation operator over typed expression operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static BinaryLogicOpExpr<T> rnot<T>(ILogicExpr<T> a, ILogicExpr<T> b)
        where T : unmanaged
            => binary(RNot, a, b);

    /// <summary>
    /// Defines a right negation operator over typed literal operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    static BinaryLogicOpExpr<T> rnot<T>(bit a, bit b)
        where T : unmanaged
            => binary<T>(RNot, a, b);

    /// <summary>
    /// Defines a material implication operator over expression operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline)]
    public static BinaryLogicOpExpr impl(ILogicExpr a, ILogicExpr b)
        => binary(Impl, a, b);

    /// <summary>
    /// Defines a material implication operator over literal operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline)]
    public static BinaryLogicOpExpr impl(bit a, bit b)
        => binary(Impl, a, b);

    /// <summary>
    /// Defines a material implication operator over typed expression operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static BinaryLogicOpExpr<T> impl<T>(ILogicExpr<T> a, ILogicExpr<T> b)
        where T : unmanaged
            => binary(Impl, a, b);

    /// <summary>
    /// Defines a material implication operator over typed literal operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    static BinaryLogicOpExpr<T> impl<T>(bit a, bit b)
        where T : unmanaged
            => binary<T>(Impl, a, b);

    /// <summary>
    /// Defines a material nonimplication operator over expression operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline)]
    public static BinaryLogicOpExpr nonimpl(ILogicExpr a, ILogicExpr b)
        => binary(NonImpl, a, b);

    /// <summary>
    /// Defines a material nonimplication operator over literal operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline)]
    public static BinaryLogicOpExpr nonimpl(bit a, bit b)
        => binary(NonImpl, a, b);

    /// <summary>
    /// Defines a material nonimplication operator over typed expression operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static BinaryLogicOpExpr<T> nonimpl<T>(ILogicExpr<T> a, ILogicExpr<T> b)
        where T : unmanaged
            => binary(NonImpl, a, b);

    /// <summary>
    /// Defines a material nonimplication operator over typed literal operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    static BinaryLogicOpExpr<T> nonimpl<T>(bit a, bit b)
        where T : unmanaged
            => binary<T>(NonImpl, a, b);

    /// <summary>
    /// Defines a converse implication operator over expression operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op]
    public static BinaryLogicOpExpr cimpl(ILogicExpr a, ILogicExpr b)
        => binary(CImpl, a, b);

    /// <summary>
    /// Defines a converse implication operator over literal operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op]
    public static BinaryLogicOpExpr cimpl(bit a, bit b)
        => binary(CImpl, a, b);

    /// <summary>
    /// Defines a converse implication operator over typed expression operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static BinaryLogicOpExpr<T> cimpl<T>(ILogicExpr<T> a, ILogicExpr<T> b)
        where T : unmanaged
            => binary(CImpl, a, b);

    /// <summary>
    /// Defines a converse implication operator over typed literal operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    static BinaryLogicOpExpr<T> cimpl<T>(bit a, bit b)
        where T : unmanaged
            => binary<T>(CImpl, a, b);

    /// <summary>
    /// Defines a converse nonimplication operator over expression operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline)]
    public static BinaryLogicOpExpr cnonimpl(ILogicExpr a, ILogicExpr b)
        => binary(CNonImpl, a, b);

    /// <summary>
    /// Defines a converse nonimplication operator over literal operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline)]
    public static BinaryLogicOpExpr cnonimpl(bit a, bit b)
        => binary(CNonImpl, a, b);

    /// <summary>
    /// Defines a converse nonimplication operator over typed expression operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static BinaryLogicOpExpr<T> cnonimpl<T>(ILogicExpr<T> a, ILogicExpr<T> b)
        where T : unmanaged
            => binary(CNonImpl, a, b);

    /// <summary>
    /// Defines a converse nonimplication operator over typed literal operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    static BinaryLogicOpExpr<T> cnonimpl<T>(bit a, bit b)
        where T : unmanaged
            => binary<T>(CNonImpl, a, b);

    /// <summary>
    /// Defines a ternary select operator over expression operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op]
    public static TernaryLogicOpExpr select(ILogicExpr a, ILogicExpr b, ILogicExpr c)
        => ternary(TernaryBitLogicKind.XCA, a, b, c);

    /// <summary>
    /// Defines a ternary select operator over bit literal operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op]
    public static TernaryLogicOpExpr select(bit a, bit b, bit c)
        => ternary(TernaryBitLogicKind.XCA, a, b, c);

    /// <summary>
    /// Defines a ternary select operator over typed expression operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static TernaryLogicOpExpr<T> select<T>(ILogicExpr<T> a, ILogicExpr<T> b, ILogicExpr<T> c)
        where T : unmanaged
            => ternary(TernaryBitLogicKind.XCA, a, b, c);
}
