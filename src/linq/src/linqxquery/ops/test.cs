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
        /// Performs a type-test on an expression
        /// </summary>
        /// <typeparam name="X1">The first candidate type</typeparam>
        /// <typeparam name="X2">The second candidate type</typeparam>
        /// <param name="x">The expression to test</param>
        [MethodImpl(Inline)]
        public static bool test<X1,X2>(Expression x)
            where X1 : Expression
            where X2 : Expression
                => (x is X1) || (x is X2);

        /// <summary>
        /// Performs a type-test on an expression
        /// </summary>
        /// <typeparam name="X1">The first candidate type</typeparam>
        /// <typeparam name="X2">The second candidate type</typeparam>
        /// <typeparam name="X3">The third candidate type</typeparam>
        /// <param name="x">The expression to test</param>
        [MethodImpl(Inline)]
        public static bool test<X1,X2,X3>(Expression x)
            where X1 : Expression
            where X2 : Expression
            where X3 : Expression
                => test<X1,X2>(x) || (x is X3);

        /// <summary>
        /// Performs a type-test on an expression
        /// </summary>
        /// <typeparam name="X1">The first candidate type</typeparam>
        /// <typeparam name="X2">The second candidate type</typeparam>
        /// <typeparam name="X3">The third candidate type</typeparam>
        /// <typeparam name="X4">The fourth candidate type</typeparam>
        /// <param name="x">The expression to test</param>
        [MethodImpl(Inline)]
        public static bool test<X1,X2,X3,X4>(Expression x)
            where X1 : Expression
            where X2 : Expression
            where X3 : Expression
            where X4 : Expression
                => test<X1,X2,X3>(x) || (x is X4);
    }
}