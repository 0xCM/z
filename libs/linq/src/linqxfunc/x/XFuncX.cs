//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Linq.Expressions;

    using static Root;

    [ApiHost(ApiNames.LinqXFuncX)]
    public static partial class XFuncX
    {
        const NumericKind Closure = UnsignedInts;

        public static NamedValue<T> Evaluate<T>(this Expression<Func<T>> fx)
            => LinqXPress.evaluate(fx);

        /// <summary>
        /// Gets the expression that directly identifies the selected subject
        /// </summary>
        /// <typeparam name="M">The member type</typeparam>
        /// <param name="selector">The selecting expression that identifies the desired member</param>
        public static Expression SelectionSubject<M>(this Expression<Func<M>> selector)
            => LinqXQuery.IsConversion(selector) ? (selector.Body as UnaryExpression).Operand : selector.Body;

        /// <summary>
        /// Gets the expression that directly identifies the selected subject
        /// </summary>
        /// <typeparam name="T">The declaring type</typeparam>
        /// <typeparam name="M">The member type</typeparam>
        /// <param name="selector">The selecting expression that identifies the desired member</param>
        internal static Expression SelectionSubject<T,M>(this Expression<Func<T,M>> selector)
            => LinqXQuery.IsConversion(selector) ? (selector.Body as UnaryExpression).Operand : selector.Body;

        /// <summary>
        /// Determines the name of the property as identified by an expression delegate
        /// </summary>
        /// <typeparam name="T">The declaring type</typeparam>
        /// <typeparam name="P">The property type</typeparam>
        /// <param name="selector">The selecting expression that identifies the desired member</param>
        public static string SelectedPropertyName<T,P>(this Expression<Func<T,P>> selector)
            => selector.GetProperty().Name;

        public static Option<object> EvaluateFirst(this BinaryExpression x)
            => LinqXPress.evaluate(x);

        public static Option<object> Evaluate(this Expression x)
            => LinqXPress.evaluate(x);

        /// <summary>
        /// Returns the method invoked by an expression, if any
        /// </summary>
        /// <param name="x">The expression to test</param>
        public static Option<MethodInfo> CalledMethod(this Expression x)
            => LinqXQuery.called(x);

        /// <summary>
        /// Returns the expression if it is a logical conjunction and None otherwise
        /// </summary>
        /// <param name="x">The expression to examine</param>
        public static Option<X> Conjunction<X>(this X x)
            where X : Expression
                => LinqXQuery.conjunction(x);

        /// <summary>
        /// Returns the expression if it is a logical disjunction and None otherwise
        /// </summary>
        /// <param name="x">The expression to examine</param>
        public static Option<X> Disjunction<X>(this X x)
            where X : Expression
                => LinqXQuery.disjunction(x);

        /// <summary>
        /// Extracts a value from a constant expression if possible
        /// </summary>
        /// <param name="x">The expression to examine</param>
        public static Option<object> Constant(this Expression x)
            => LinqXQuery.constant(x);
    }
}