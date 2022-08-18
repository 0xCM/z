//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct TypedLogicSpec
    {
        /// <summary>
        /// Defines a variable expression
        /// </summary>
        /// <param name="value">The initial value of the variable</param>
        /// <typeparam name="T">The variable type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static VariableExpr<T> variable<T>(string name, ILogixExpr<T> value)
            where T : unmanaged
                => new VariableExpr<T>(name, value);

        /// <summary>
        /// Defines a variable expression
        /// </summary>
        /// <param name="value">The initial value of the variable</param>
        /// <typeparam name="T">The variable type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static VariableExpr<T> variable<T>(char name, ILogixExpr<T> value)
            where T : unmanaged
                => new VariableExpr<T>(name.ToString(), value);

        /// <summary>
        /// Defines a variable expression
        /// </summary>
        /// <param name="value">The initial value of the variable</param>
        /// <typeparam name="T">The variable type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static VariableExpr<T> variable<T>(AsciLetterLoSym name, ILogixExpr<T> value)
            where T : unmanaged
                => new VariableExpr<T>(name.ToString(), value);

        /// <summary>
        /// Defines a bit variable expression where the variable name is defined by an integer
        /// </summary>
        /// <param name="name">The variable's name</param>
        /// <param name="init">The variable's initial value</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static VariableExpr<T> variable<T>(uint name, ILogixExpr<T> init)
            where T : unmanaged
                => new VariableExpr<T>(name.ToString(), init);

        /// <summary>
        /// Defines a variable expression with an initial value specified by a literal
        /// </summary>
        /// <param name="value">The initial value of the variable</param>
        /// <typeparam name="T">The variable type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static VariableExpr<T> variable<T>(string name, T value = default)
            where T : unmanaged
                => new VariableExpr<T>(name, literal(value));

        /// <summary>
        /// Defines a variable expression with an initial value specified by a literal
        /// </summary>
        /// <param name="value">The initial value of the variable</param>
        /// <typeparam name="T">The variable type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static VariableExpr<T> variable<T>(char name, T value = default)
            where T : unmanaged
                => new VariableExpr<T>(name.ToString(), literal(value));

        /// <summary>
        /// Defines a variable expression with an initial value specified by a literal
        /// </summary>
        /// <param name="value">The initial value of the variable</param>
        /// <typeparam name="T">The variable type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static VariableExpr<T> variable<T>(AsciLetterLoSym name, T value = default)
            where T : unmanaged
                => new VariableExpr<T>(name.ToString(), literal(value));

        /// <summary>
        /// Defines a variable expression where the variable name is defined by an integer and
        /// an initial value is specified by a literal
        /// </summary>
        /// <param name="value">The initial value of the variable</param>
        /// <typeparam name="T">The variable type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static VariableExpr<T> variable<T>(uint name, T value = default)
            where T : unmanaged
                => new VariableExpr<T>(name.ToString(), literal(value));

        /// <summary>
        /// Creates a varied expression predicated on a typed variable sequence
        /// </summary>
        /// <param name="subject">The variable-dependent expression</param>
        /// <param name="variables">The variable sequence</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static VariedExpr<T> varied<T>(ILogixExpr<T> baseExpr, params VariableExpr<T>[] variables)
            where T : unmanaged
                => new VariedExpr<T>(baseExpr, variables);

        /// <summary>
        /// Creates a varied expression predicated on a typed variable sequence of natural length
        /// </summary>
        /// <param name="subject">The variable-dependent expression</param>
        /// <param name="variables">The variable sequence</param>
        [MethodImpl(Inline)]
        public static VariedExpr<N,T> varied<N,T>(N n, ILogixExpr<T> baseExpr, params ILogixVarExpr<T>[] variables)
            where T : unmanaged
            where N : unmanaged, ITypeNat
        {
            Require.equal<N>(variables.Length);
            return new VariedExpr<N,T>(baseExpr, variables);
        }

        /// <summary>
        /// Defines a varied expression of 1 variable
        /// </summary>
        /// <param name="n">The number of variables in the expression</param>
        /// <param name="baseExpr">The variable-dependent expression </param>
        /// <param name="v0">The variable</param>
        /// <typeparam name="T">The type over which the expression is defined</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static VariedExpr<N1,T> varied<T>(N1 n, ILogixExpr<T> baseExpr, ILogixVarExpr<T> v0)
            where T : unmanaged
                => varied<N1,T>(n, baseExpr, v0);

        /// <summary>
        /// Defines a varied expression of 2 variables
        /// </summary>
        /// <param name="n">The number of variables in the expression</param>
        /// <param name="baseExpr">The variable-dependent expression </param>
        /// <param name="v0">The first variable</param>
        /// <param name="v1">The second variable</param>
        /// <typeparam name="T">The type over which the expression is defined</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static VariedExpr<N2,T> varied<T>(N2 n, ILogixExpr<T> baseExpr, ILogixVarExpr<T> v0, ILogixVarExpr<T> v1)
            where T : unmanaged
                => varied<N2,T>(n, baseExpr, v0, v1);

        /// <summary>
        /// Defines a varied expression of 3 variables
        /// </summary>
        /// <param name="n">The number of variables in the expression</param>
        /// <param name="baseExpr">The variable-dependent expression </param>
        /// <param name="v0">The first variable</param>
        /// <param name="v1">The second variable</param>
        /// <param name="v2">The third variable</param>
        /// <typeparam name="T">The type over which the expression is defined</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static VariedExpr<N3,T> varied<T>(N3 n, ILogixExpr<T> baseExpr, ILogixVarExpr<T> v0, ILogixVarExpr<T> v1, ILogixVarExpr<T> v2)
            where T : unmanaged
                => varied<N3,T>(n, baseExpr, v0, v1, v2);

        /// <summary>
        /// Defines a typed test expression
        /// </summary>
        /// <param name="test">The logical operator to use for the test</param>
        /// <param name="lhs">The control expression</param>
        /// <param name="rhs">The test subject</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ComparisonExpr<T> equals<T>(ILogixExpr<T> lhs, ILogixExpr<T> rhs, params ILogixVarExpr<T>[] variables)
            where T : unmanaged
                => new ComparisonExpr<T>(ApiComparisonClass.Eq, lhs,rhs,variables);
    }
}