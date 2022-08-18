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
    using static Option;

    using LX = System.Linq.Expressions.Expression;

    partial class LinqXPress
    {
        /// <summary>
        /// Creates a conjunction of a left and right expression
        /// </summary>
        /// <param name="a">The left expression</param>
        /// <param name="b">The right expression</param>
        [MethodImpl(Inline), Op]
        public static BinaryExpression and(LX a, LX b)
            => LX.AndAlso(a, b);

        /// <summary>
        /// Forms a conjunction from two function predicates
        /// </summary>
        /// <typeparam name="X1">The first predicate argument type</typeparam>
        /// <typeparam name="X2">The second predicate argument type</typeparam>
        /// <param name="p1">The first predicate</param>
        /// <param name="p2">The second predicate</param>
        public static Option<Func<X1,X2,bool>> and<X1,X2>(Func<X1,bool> p1, Func<X2,bool> p2)
            => from args in some(paramXPair<X1,X2>())
               let left = invoke(func(p1), args.x1)
               let right = invoke(func(p2), args.x2)
               let body = and(left, right)
               select lambda<Func<X1,X2,bool>>(args, body).Compile();
    }
}