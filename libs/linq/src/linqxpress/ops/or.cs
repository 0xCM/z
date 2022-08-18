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

    using LX = System.Linq.Expressions.Expression;

    partial class LinqXPress
    {
        /// <summary>
        /// Creates a disjunction of a left and right expression
        /// </summary>
        /// <param name="lhs">The left expression</param>
        /// <param name="rhs">The right expression</param>
        [MethodImpl(Inline), Op]
        public static BinaryExpression or(LX lhs, LX rhs)
            => LX.OrElse(lhs, rhs);

        /// <summary>
        /// Forms a disjunction from two function predicates
        /// </summary>
        /// <typeparam name="X1">The first predicate argument type</typeparam>
        /// <typeparam name="X2">The second predicate argument type</typeparam>
        /// <param name="f1">The first predicate</param>
        /// <param name="f2">The second predicate</param>
        public static Option<Func<X1,X2,bool>> or<X1,X2>(Func<X1,bool> f1, Func<X2,bool> f2)
            => from args in Option.some(paramX<X1,X2>())
                let left = invoke(func(f1),args[0])
                let right = invoke(func(f2),args[1])
                let body = or(left, right)
                select lambda<Func<X1,X2,bool>>(args, body).Compile();
    }
}