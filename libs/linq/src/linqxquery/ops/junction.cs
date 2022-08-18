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

    partial class LinqXQuery
    {
        /// <summary>
        /// If the source expression is a logical disjunction, returns the expression; otherwise, returns none
        /// </summary>
        /// <param name="x">The expression to examine</param>
        [MethodImpl(Inline)]
        public static Option<X> disjunction<X>(X x)
            where X : Expression
                => x.NodeType == ExpressionType.OrElse ? x : Option.none<X>();

        /// <summary>
        /// Tests whether an expression is a logical conjunction
        /// </summary>
        /// <param name="x">The expression to examine</param>
        [MethodImpl(Inline)]
        public static Option<X> conjunction<X>(X x)
            where X : Expression
                => x.NodeType == ExpressionType.AndAlso ? x : Option.none<X>();

        /// <summary>
        /// Deterines whether the test expression is either a logical conjunction or disjunction
        /// </summary>
        /// <param name="X">The expression to examine</param>
        [MethodImpl(Inline)]
        public static Option<X> junction<X>(X x)
            where X : Expression
                => disjunction(x).ValueOrElse(() => conjunction(x).ValueOrDefault());
    }
}