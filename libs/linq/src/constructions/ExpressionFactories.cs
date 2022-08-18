//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.DynamicModels
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using LX = System.Linq.Expressions.Expression;

    public static class ExpressionFactories
    {
        /// <summary>
        /// Creates an expression that defines a function that returns true
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static Expression<Func<T,bool>> True<T>()
            => f => true;

        /// <summary>
        /// Creates an expression that defines a function that returns false
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static Expression<Func<T,bool>> False<T>()
            => f => false;

        /// <summary>
        /// Creates an expression that defines a logical OR function
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <typeparam name="T"></typeparam>
        public static Expression<Func<T,bool>> Or<T>(this Expression<Func<T,bool>> left, Expression<Func<T,bool>> right)
        {
            var invokedExpr = LX.Invoke(right, left.Parameters.Cast<LX>());
            return LX.Lambda<Func<T, bool>>
                  (LX.OrElse(left.Body, invokedExpr), left.Parameters);
        }

        /// <summary>
        /// Creates an expression that defines a logical AND function
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <typeparam name="T"></typeparam>
        public static Expression<Func<T,bool>> And<T>(this Expression<Func<T,bool>> lhs, Expression<Func<T,bool>> rhs)
        {
            var invokedExpr = LX.Invoke(rhs, lhs.Parameters.Cast<LX>());
            return LX.Lambda<Func<T, bool>>
                  (LX.AndAlso(lhs.Body, invokedExpr), lhs.Parameters);
        }

        /// <summary>
        /// Creates an expression tha defines an equality comparison
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <typeparam name="T"></typeparam>
        public static Expression<Func<bool>> Equal<T>(this Expression<Func<T>> lhs, Expression<Func<T>> rhs)
        {
            var lValue = LX.Invoke(lhs);
            var rValue = LX.Invoke(rhs);
            return LX.Lambda<Func<bool>>(LX.Equal(lValue, rValue));
        }
    }
}