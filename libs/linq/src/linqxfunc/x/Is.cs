//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class XFuncX
    {
        /// <summary>
        /// Tests whether an expression is a conversion
        /// </summary>
        /// <param name="x">The expression to examine</param>
        [Op, MethodImpl(Inline)]
        public static bool IsConversion(this Expression x)
            => LinqXQuery.IsConversion(x);

        /// <summary>
        /// Tests whether a member is wrapped in a conversion
        /// </summary>
        /// <typeparam name="T">The declaring type</typeparam>
        /// <typeparam name="R">The member type</typeparam>
        /// <param name="selector">Expression that identifies the member</param>
        [MethodImpl(Inline)]
        public static bool IsConversion<T,R>(this Expression<Func<T,R>> selector)
            => LinqXQuery.IsConversion(selector);

        /// <summary>
        /// Tests whether the test expression is a member access expression
        /// </summary>
        /// <param name="x">The expression to examine</param>
        [Op, MethodImpl(Inline)]
        public static bool IsMemberAccess(this Expression x)
            => LinqXQuery.IsAccess(x);

        /// <summary>
        /// Tests whether the test expression is a function call
        /// </summary>
        /// <param name="x">The expression to examine</param>
        [Op, MethodImpl(Inline)]
        public static bool IsCall(this Expression x)
            => LinqXQuery.IsCall(x);

        /// <summary>
        /// Tests whether an expression is an application of the LINQ select operator
        /// </summary>
        /// <param name="x">The expression to test</param>
        [Op, MethodImpl(Inline)]
        public static bool IsSelect(this Expression x)
            => LinqXQuery.IsSelect(x);

        /// <summary>
        /// Tests whether an expression is a logical operator
        /// </summary>
        /// <param name="x">The expression to examine</param>
        [Op, MethodImpl(Inline)]
        public static bool IsLogical(this Expression x)
            => LinqXQuery.IsLogical(x);

        /// <summary>
        /// Tests whether an expression is a lambda expression
        /// </summary>
        /// <param name="x">The expression to examine</param>
        [Op, MethodImpl(Inline)]
        public static bool IsLambda(this Expression x)
            => LinqXQuery.IsLambda(x);

        /// <summary>
        /// Tests whether an expression is a logical disjunction
        /// </summary>
        /// <param name="x">The expression to examine</param>
        [MethodImpl(Inline)]
        public static bool IsDisjunction<X>(this X x)
            where X : Expression
                => LinqXQuery.disjunction(x).Exists;

        /// <summary>
        /// Tests whether an expression is a logical conjunction
        /// </summary>
        /// <param name="x">The expression to examine</param>
        [MethodImpl(Inline)]
        public static bool IsConjunction<X>(this X x)
            where X : Expression
                => LinqXQuery.conjunction(x).Exists;

        /// <summary>
        /// Deterines whether the test expression is either a logical conjuntion or disjunction
        /// </summary>
        /// <param name="X">The expression to examine</param>
        [Op, MethodImpl(Inline)]
        public static bool IsJunction(this Expression x)
            => LinqXQuery.junction(x).Exists;

        /// <summary>
        /// Performs a type-test on an expression
        /// </summary>
        /// <typeparam name="X1">The first candidate type</typeparam>
        /// <typeparam name="X2">The second candidate type</typeparam>
        /// <param name="x">The expression to test</param>
        [MethodImpl(Inline)]
        public static bool IsOneOf<X1,X2>(this Expression x)
            where X1 : Expression
            where X2 : Expression
                => LinqXQuery.test<X1,X2>(x);

        /// <summary>
        /// Performs a type-test on an expression
        /// </summary>
        /// <typeparam name="X1">The first candidate type</typeparam>
        /// <typeparam name="X2">The second candidate type</typeparam>
        /// <typeparam name="X3">The third candidate type</typeparam>
        /// <param name="x">The expression to test</param>
        [MethodImpl(Inline)]
        public static bool IsOneOf<X1,X2,X3>(this Expression x)
            where X1 : Expression
            where X2 : Expression
            where X3 : Expression
                => LinqXQuery.test<X1,X2,X3>(x);

        /// <summary>
        /// Performs a type-test on an expression
        /// </summary>
        /// <typeparam name="X1">The first candidate type</typeparam>
        /// <typeparam name="X2">The second candidate type</typeparam>
        /// <typeparam name="X3">The third candidate type</typeparam>
        /// <typeparam name="X4">The fourth candidate type</typeparam>
        /// <param name="x">The expression to test</param>
        [MethodImpl(Inline)]
        public static bool IsOneOf<X1,X2,X3,X4>(this Expression x)
            where X1 : Expression
            where X2 : Expression
            where X3 : Expression
            where X4 : Expression
                => LinqXQuery.test<X1,X2,X3,X4>(x);
    }
}