//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;

    using static Root;

    using LX = System.Linq.Expressions.Expression;
    using PX = System.Linq.Expressions.ParameterExpression;

    partial class LinqXPress
    {
        /// <summary>
        /// Defines a lambda expression sans parameters
        /// </summary>
        /// <typeparam name="T">The aligned delegate type</typeparam>
        /// <param name="body">The expression body</param>
        public static Expression<T> lambda<T>(LX body)
            where T : Delegate => LX.Lambda<T>(body);

        /// <summary>
        /// Creates a lambda expression
        /// </summary>
        /// <param name="parameters">The expression parameters</param>
        /// <param name="body">The expression body</param>
        /// <typeparam name="T">The aligned delegate type</typeparam>
        public static Expression<T> lambda<T>(IEnumerable<PX> parameters, Expression body)
            where T : Delegate => LX.Lambda<T>(body, parameters);

        /// <summary>
        /// Creates a 2-parameter lambda expression
        /// </summary>
        /// <typeparam name="T">The aligned delegate type</typeparam>
        /// <param name="parameters">The expression parameters</param>
        /// <param name="body">The expression body</param>
        [MethodImpl(Inline)]
        public static Expression<T> lambda<T>((PX p1, PX p2) parameters, Expression body)
            where T : Delegate
                => LX.Lambda<T>(body, core.array(parameters.p1, parameters.p2));

        /// <summary>
        /// Defines a lambda expression
        /// </summary>
        /// <typeparam name="T">The aligned delegate type</typeparam>
        /// <param name="parameters">The expression parameters</param>
        /// <param name="body">The expression body</param>
        [MethodImpl(Inline)]
        public static Expression<T> lambda<T>((PX p1, PX p2, PX p3) parameters, Expression body)
            where T : Delegate
                => LX.Lambda<T>(body, core.array(parameters.p1, parameters.p2, parameters.p3));

        /// <summary>
        /// Creates a an emitter expression
        /// </summary>
        /// <param name="parameters">The expression parameters</param>
        /// <param name="body">The expression body</param>
        [MethodImpl(Inline)]
        public static Expression<Func<T>> emitter<T>(LX body)
            => LX.Lambda<Func<T>>(body);

        /// <summary>
        /// Creates a 1-argument lambda expression
        /// </summary>
        /// <param name="parameters">The expression parameters</param>
        /// <param name="body">The expression body</param>
        [MethodImpl(Inline)]
        public static Expression<Func<X,Y>> lambda<X,Y>(IEnumerable<PX> parameters, LX body)
            => LX.Lambda<Func<X,Y>>(body, parameters);

        /// <summary>
        /// Creates a 2-argument lambda expression
        /// </summary>
        /// <param name="parameters">The expression parameters</param>
        /// <param name="body">The expression body</param>
        [MethodImpl(Inline)]
        public static Expression<Func<X1,X2,Y>> lambda<X1,X2,Y>(IEnumerable<PX> parameters, LX body)
            => LX.Lambda<Func<X1,X2,Y>>(body, parameters);

        /// <summary>
        /// Creates a 3-argument lambda expression
        /// </summary>
        /// <param name="parameters">The expression parameters</param>
        /// <param name="body">The expression body</param>
        [MethodImpl(Inline)]
        public static Expression<Func<X1,X2,X3,Y>> lambda<X1,X2,X3,Y>(IEnumerable<PX> parameters, LX body)
            => LX.Lambda<Func<X1,X2,X3,Y>>(body, parameters);

        /// <summary>
        /// Creates a 4-argument lambda expression
        /// </summary>
        /// <param name="parameters">The expression parameters</param>
        /// <param name="body">The expression body</param>
        [MethodImpl(Inline)]
        public static Expression<Func<X1,X2,X3,X4,Y>> lambda<X1,X2,X3,X4,Y>(IEnumerable<PX> parameters, LX body)
            => LX.Lambda<Func<X1,X2,X3,X4,Y>>(body, parameters);

        /// <summary>
        /// Creates a unary lambda expression
        /// </summary>
        /// <param name="f">The defining function</param>
        [MethodImpl(Inline)]
        public static Expression<Func<X,Y>> lambda<X,Y>(Func<LX,UnaryExpression> f)
        {
            var p1 = paramX<X>();
            var eval = f(p1);
            return lambda<Func<X,Y>>(core.array(p1), eval);
        }

        /// <summary>
        /// Creates a binary lambda expression
        /// </summary>
        /// <param name="f">The defining function</param>
        [MethodImpl(Inline)]
        public static Expression<Func<X,Y,Z>> lambda<X,Y,Z>(Func<LX,LX,BinaryExpression> f)
        {
            var args = paramX<X,Y>();
            var eval = f(args[0], args[1]);
            return lambda<Func<X,Y,Z>>(args, eval);
        }
    }
}