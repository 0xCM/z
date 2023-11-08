//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static ApiUnaryArithmeticClass;
using static ApiBinaryArithmeticClass;

using TLS = TypedLogicSpec;

[ApiHost]
public readonly struct ArithmeticSpec
{
    const NumericKind Closure = UInt64k;

    /// <summary>
    /// Defines an arithmetic unary expression
    /// </summary>
    /// <param name="op">The operator classifier</param>
    /// <param name="a">The operand</param>
    /// <typeparam name="T">The operand type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static UnaryArithmeticOpExpr<T> unary<T>(ApiUnaryArithmeticClass op, ILogixExpr<T> a)
        where T : unmanaged
            => new UnaryArithmeticOpExpr<T>(op,a);

    /// <summary>
    /// Defines an arithmetic unary expression over a literal operand
    /// </summary>
    /// <param name="op">The operator classifier</param>
    /// <param name="operand">The literal value</param>
    /// <typeparam name="T">The operand type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static UnaryArithmeticOpExpr<T> unary<T>(ApiUnaryArithmeticClass op, T a)
        where T : unmanaged
            => new UnaryArithmeticOpExpr<T>(op, TLS.literal(a));

    /// <summary>
    /// Defines a binary arithmetic expression
    /// </summary>
    /// <param name="a">The left expression</param>
    /// <param name="b">The right expression</param>
    /// <typeparam name="T">The operand type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static BinaryArithmeticOpExpr<T> binary<T>(ApiBinaryArithmeticClass op, ILogixExpr<T> a, ILogixExpr<T> b)
        where T : unmanaged
            => new BinaryArithmeticOpExpr<T>(op, a, b);

    /// <summary>
    /// Defines a binary arithmetic expression over literal operands
    /// </summary>
    /// <param name="a">The left expression</param>
    /// <param name="b">The right expression</param>
    /// <typeparam name="T">The operand type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static BinaryArithmeticOpExpr<T> binary<T>(ApiBinaryArithmeticClass op, T a, T b)
        where T : unmanaged
            => new BinaryArithmeticOpExpr<T>(op, TLS.literal(a), TLS.literal(b));

    /// <summary>
    /// Defines a unary increment expression
    /// </summary>
    /// <param name="a">The expression operand</param>
    /// <typeparam name="T">The operand type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static UnaryArithmeticOpExpr<T> inc<T>(ILogixExpr<T> a)
        where T : unmanaged
            => unary(Inc, a);

    /// <summary>
    /// Defines a unary increment expression with a literal operand
    /// </summary>
    /// <param name="a">The literal value</param>
    /// <typeparam name="T">The operand type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static UnaryArithmeticOpExpr<T> inc<T>(T a)
        where T : unmanaged
            => unary(Inc, a);

    /// <summary>
    /// Defines a unary decrement expression
    /// </summary>
    /// <param name="a">The expression operand</param>
    /// <typeparam name="T">The operand type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static UnaryArithmeticOpExpr<T> dec<T>(ILogixExpr<T> a)
        where T : unmanaged
            => unary(Dec, a);

    /// <summary>
    /// Defines a decrement increment expression with a literal operand
    /// </summary>
    /// <param name="a">The literal value</param>
    /// <typeparam name="T">The operand type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static UnaryArithmeticOpExpr<T> dec<T>(T a)
        where T : unmanaged
            => unary(Dec, a);

    /// <summary>
    /// Defines a unary decrement expression
    /// </summary>
    /// <param name="a">The expression operand</param>
    /// <typeparam name="T">The operand type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static UnaryArithmeticOpExpr<T> negate<T>(ILogixExpr<T> a)
        where T : unmanaged
            => unary(Negate, a);

    /// <summary>
    /// Defines a decrement increment expression with a literal operand
    /// </summary>
    /// <param name="a">The literal value</param>
    /// <typeparam name="T">The operand type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static UnaryArithmeticOpExpr<T> negate<T>(T a)
        where T : unmanaged
            => unary(Negate, a);

    /// <summary>
    /// Defines a binary addition expression
    /// </summary>
    /// <param name="a">The left operand</param>
    /// <param name="b">The right operand</param>
    /// <typeparam name="T">The operand type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static BinaryArithmeticOpExpr<T> add<T>(ILogixExpr<T> a, ILogixExpr<T> b)
        where T : unmanaged
            => binary(Add, a, b);

    /// <summary>
    /// Defines a binary addition expression over literal operands
    /// </summary>
    /// <param name="a">The left literal value</param>
    /// <param name="b">The right literal value</param>
    /// <typeparam name="T">The operand type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static BinaryArithmeticOpExpr<T> add<T>(T a, T b)
        where T : unmanaged
            => binary(Add, a, b);

    /// <summary>
    /// Defines a binary subtraction expression
    /// </summary>
    /// <param name="a">The left expression</param>
    /// <param name="b">The right expression</param>
    /// <typeparam name="T">The operand type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static BinaryArithmeticOpExpr<T> sub<T>(ILogixExpr<T> a, ILogixExpr<T> b)
        where T : unmanaged
            => binary(Sub, a, b);

    /// <summary>
    /// Defines a binary subtraction expression over literal operands
    /// </summary>
    /// <param name="a">The left literal value</param>
    /// <param name="b">The right literal value</param>
    /// <typeparam name="T">The operand type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static BinaryArithmeticOpExpr<T> sub<T>(T a, T b)
        where T : unmanaged
            => binary(Sub, a, b);
}
