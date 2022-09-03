//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static TypedLogicSpec;

    using TLS = TypedLogicSpec;
    using BCK = ApiComparisonClass;

    /// <summary>
    /// Constructs type operator comparison expressions
    /// </summary>
    [ApiHost]
    public readonly struct Comparisons
    {
        const NumericKind Closure = UInt64k;

        /// <summary>
        /// Defines comparison expression
        /// </summary>
        /// <param name="kind">The comparisonkind</param>
        /// <param name="lhs">The left expression</param>
        /// <param name="rhs">The right expression</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonExpr<T> define<T>(BCK kind, ILogixExpr<T> lhs, ILogixExpr<T> rhs, params ILogixVarExpr<T>[] vars)
            where T : unmanaged
                => new ComparisonExpr<T>(kind,lhs,rhs,vars);

        [MethodImpl(Inline), Op]
        public static ComparisonExpr define(BCK kind, ILogicExpr lhs, ILogicExpr rhs, params ILogicVarExpr[] vars)
            => new ComparisonExpr(kind, lhs, rhs, vars);

        /// <summary>
        /// Defines an equality comparison expression
        /// </summary>
        /// <param name="lhs">The left expression</param>
        /// <param name="rhs">The right expression</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op]
        public static ComparisonExpr equals(ILogicExpr lhs, ILogicExpr rhs, params ILogicVarExpr[] variables)
            => define(ApiComparisonClass.Eq, lhs,rhs,variables);

        /// <summary>
        /// Defines an equality comparison expression
        /// </summary>
        /// <param name="lhs">The left expression</param>
        /// <param name="rhs">The right expression</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonExpr<T> equals<T>(ILogicExpr<T> lhs, ILogicExpr<T> rhs, params ILogixVarExpr<T>[] variables)
            where T : unmanaged
                => define(ApiComparisonClass.Eq, lhs,rhs, variables);

        /// <summary>
        /// Defines a comparison expression of specified kind over typed expressions
        /// </summary>
        /// <param name="kind">The comparison kind</param>
        /// <param name="lhs">The left expression</param>
        /// <param name="rhs">The right expression</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonExpr<T> compare<T>(BCK kind, ILogixExpr<T> lhs, ILogixExpr<T> rhs)
            where T : unmanaged
                => binary(kind, lhs,rhs);

        /// <summary>
        /// Defines a comparison expression of specified kind over literals
        /// </summary>
        /// <param name="kind">The comparison kind</param>
        /// <param name="lhs">The left operand</param>
        /// <param name="rhs">The right operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonExpr<T> compare<T>(BCK kind, T lhs, T rhs)
            where T : unmanaged
                => binary(kind, literal(lhs), literal(rhs));

        /// <summary>
        /// Defines an equals operator expression
        /// </summary>
        /// <param name="lhs">The left operand</param>
        /// <param name="rhs">The right operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonExpr<T> equals<T>(ILogixExpr<T> lhs, ILogixExpr<T> rhs)
            where T : unmanaged
                => compare(BCK.Eq, lhs,rhs);

        /// <summary>
        /// Defines an equals operator expression over literal values
        /// </summary>
        /// <param name="lhs">The left operand</param>
        /// <param name="rhs">The right operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonExpr<T> equals<T>(T lhs, T rhs)
            where T : unmanaged
                => binary(BCK.Eq, TLS.literal(lhs), TLS.literal(rhs));

        /// <summary>
        /// Defines a not equal operator expression
        /// </summary>
        /// <param name="lhs">The left operand</param>
        /// <param name="rhs">The right operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonExpr<T> neq<T>(ILogixExpr<T> lhs, ILogixExpr<T> rhs)
            where T : unmanaged
                => compare(BCK.Neq, lhs,rhs);

        /// <summary>
        /// Defines a not equal operator expression over literal values
        /// </summary>
        /// <param name="lhs">The left operand</param>
        /// <param name="rhs">The right operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonExpr<T> neq<T>(T lhs, T rhs)
            where T : unmanaged
                => binary(BCK.Neq, TLS.literal(lhs), TLS.literal(rhs));

        /// <summary>
        /// Defines a less than operator expression
        /// </summary>
        /// <param name="lhs">The left operand</param>
        /// <param name="rhs">The right operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonExpr<T> lt<T>(ILogixExpr<T> lhs, ILogixExpr<T> rhs)
            where T : unmanaged
                => compare(BCK.Lt, lhs,rhs);

        /// <summary>
        /// Defines an less than operator expression over literal values
        /// </summary>
        /// <param name="lhs">The left operand</param>
        /// <param name="rhs">The right operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonExpr<T> lt<T>(T lhs, T rhs)
            where T : unmanaged
                => binary(BCK.Lt, TLS.literal(lhs), TLS.literal(rhs));

        /// <summary>
        /// Defines a less than or equal operator expression
        /// </summary>
        /// <param name="lhs">The left operand</param>
        /// <param name="rhs">The right operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonExpr<T> lteq<T>(ILogixExpr<T> lhs, ILogixExpr<T> rhs)
            where T : unmanaged
                => compare(BCK.LtEq, lhs,rhs);

        /// <summary>
        /// Defines an less than or equal operator expression over literal values
        /// </summary>
        /// <param name="lhs">The left operand</param>
        /// <param name="rhs">The right operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonExpr<T> lteq<T>(T lhs, T rhs)
            where T : unmanaged
                => binary(BCK.LtEq, TLS.literal(lhs), TLS.literal(rhs));

        /// <summary>
        /// Defines a greater than operator expression
        /// </summary>
        /// <param name="lhs">The left operand</param>
        /// <param name="rhs">The right operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonExpr<T> gt<T>(ILogixExpr<T> lhs, ILogixExpr<T> rhs)
            where T : unmanaged
                => compare(BCK.Gt, lhs,rhs);

        /// <summary>
        /// Defines greater than operator expression over literal values
        /// </summary>
        /// <param name="lhs">The left operand</param>
        /// <param name="rhs">The right operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonExpr<T> gt<T>(T lhs, T rhs)
            where T : unmanaged
                => binary(BCK.Gt, TLS.literal(lhs), TLS.literal(rhs));

        /// <summary>
        /// Defines a greater than or equal operator expression
        /// </summary>
        /// <param name="lhs">The left operand</param>
        /// <param name="rhs">The right operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonExpr<T> gteq<T>(ILogixExpr<T> lhs, ILogixExpr<T> rhs)
            where T : unmanaged
                => compare(BCK.GtEq, lhs,rhs);

        /// <summary>
        /// Defines a greater than or equal operator expression over literal values
        /// </summary>
        /// <param name="lhs">The left operand</param>
        /// <param name="rhs">The right operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonExpr<T> gteq<T>(T lhs, T rhs)
            where T : unmanaged
                => binary(BCK.GtEq, TLS.literal(lhs), TLS.literal(rhs));
    }
}