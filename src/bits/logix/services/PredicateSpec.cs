//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiComparisonClass;
    using static TypedLogicSpec;

    [ApiHost]
    public readonly struct PredicateSpec
    {
        const NumericKind Closure = UInt64k;

        /// <summary>
        /// Defines a typed comparison predicate over operand expressions
        /// </summary>
        /// <param name="kind">The comparison kind</param>
        /// <param name="a">The left expression</param>
        /// <param name="b">The right expression</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonPredExpr<T> predicate<T>(ApiComparisonClass kind, ILogixExpr<T> a, ILogixExpr<T> b)
            where T : unmanaged
                => new ComparisonPredExpr<T>(kind,a,b);

        /// <summary>
        /// Defines a typed comparison predicate over literal operands
        /// </summary>
        /// <param name="kind">The comparison kind</param>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonPredExpr<T> predicate<T>(ApiComparisonClass kind, T a, T b)
            where T : unmanaged
                => new ComparisonPredExpr<T>(kind, literal(a), literal(b));

        /// <summary>
        /// Defines an equality comparison expression
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonPredExpr<T> equals<T>(ILogixExpr<T> a, ILogixExpr<T> b)
            where T : unmanaged
                => predicate(Eq, a, b);

        /// <summary>
        /// Defines an equality comparison expression over literal operands
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonPredExpr<T> equals<T>(T a, T b)
            where T : unmanaged
                => predicate(Eq, a, b);

        /// <summary>
        /// Defines a less-than comparison expression
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonPredExpr<T> lt<T>(ILogixExpr<T> a, ILogixExpr<T> b)
            where T : unmanaged
                => predicate(Lt, a, b);

        /// <summary>
        /// Defines a less-than comparison expression over literal operands
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonPredExpr<T> lt<T>(T a, T b)
            where T : unmanaged
                => predicate(Lt, a, b);

        /// <summary>
        /// Defines a less-than or equal comparison expression
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonPredExpr<T> lteq<T>(ILogixExpr<T> a, ILogixExpr<T> b)
            where T : unmanaged
                => predicate(LtEq, a, b);

        /// <summary>
        /// Defines a less-than or equal comparison expression over literal operands
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonPredExpr<T> lteq<T>(T a, T b)
            where T : unmanaged
                => predicate(LtEq, a, b);

        /// <summary>
        /// Defines a greater-than comparison expression
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonPredExpr<T> gt<T>(ILogixExpr<T> a, ILogixExpr<T> b)
            where T : unmanaged
                => predicate(Gt, a, b);

        /// <summary>
        /// Defines a greater-than comparison expression over literal operands
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonPredExpr<T> gt<T>(T a, T b)
            where T : unmanaged
                => predicate(Gt, a, b);

        /// <summary>
        /// Defines a greater-than or equal comparison expression
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonPredExpr<T> gteq<T>(ILogixExpr<T> a, ILogixExpr<T> b)
            where T : unmanaged
                => predicate(GtEq, a, b);

        /// <summary>
        /// Defines a greater-than or equal comparison expression over literal operands
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonPredExpr<T> gteq<T>(T a, T b)
            where T : unmanaged
                => predicate(GtEq, a, b);
    }
}