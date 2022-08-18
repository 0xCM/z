//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class LinqXQuery
    {
        /// <summary>
        /// Tests whether an expression is a conversion
        /// </summary>
        /// <param name="x">The expression to examine</param>
        [MethodImpl(Inline), Op]
        public static bool IsConversion(Expression x)
            => x.NodeType == ExpressionType.Convert;

        /// <summary>
        /// Tests whether a member is wrapped in a conversion
        /// </summary>
        /// <typeparam name="T">The declaring type</typeparam>
        /// <typeparam name="R">The member type</typeparam>
        /// <param name="selector">Expression that identifies the member</param>
        [MethodImpl(Inline)]
        public static bool IsConversion<T,R>(Expression<Func<T,R>> selector)
            => selector.Body.IsConversion();

        /// <summary>
        /// Tests whether the test expression is a member access expression
        /// </summary>
        /// <param name="x">The expression to examine</param>
        [MethodImpl(Inline), Op]
        public static bool IsAccess(Expression x)
            => x.NodeType == ExpressionType.MemberAccess;

        /// <summary>
        /// Tests whether the test expression is a function call
        /// </summary>
        /// <param name="x">The expression to examine</param>
        [MethodImpl(Inline), Op]
        public static bool IsCall(Expression x)
            => x.NodeType == ExpressionType.Call;

        /// <summary>
        /// Tests whether an expression is an application of the LINQ select operator
        /// </summary>
        /// <param name="x">The expression to test</param>
        [MethodImpl(Inline), Op]
        public static bool IsSelect(Expression x)
            => x.CalledMethod().Select(m => m.Name == nameof(Enumerable.Select)).ValueOrDefault(false);

        /// <summary>
        /// Tests whether an expression is a logical operator
        /// </summary>
        /// <param name="x">The expression to examine</param>
        [MethodImpl(Inline), Op]
        public static bool IsLogical(Expression x)
            => x.NodeType == ExpressionType.AndAlso ||
                x.NodeType == ExpressionType.OrElse ||
                x.NodeType == ExpressionType.Not;

        /// <summary>
        /// Tests whether an expression is a lambda expression
        /// </summary>
        /// <param name="x">The expression to examine</param>
        [MethodImpl(Inline), Op]
        public static bool IsLambda(Expression x)
            => x.NodeType == ExpressionType.Lambda;
    }
}