//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class LinqXQuery
    {
        /// <summary>
        /// Extracts the method info for the function referenced by an expression delegate
        /// </summary>
        /// <typeparam name="T">The function return type</typeparam>
        /// <param name="selector">The call expression</param>
        [MethodImpl(Inline)]
        public static MethodInfo method<T>(Expression<Func<T>> selector)
        {
            if (selector.Body is MethodCallExpression)
                return cast<MethodCallExpression>(selector.Body).Method;
            else if (selector.Body.IsConversion())
                return (cast<UnaryExpression>(selector.Body).Operand as MethodCallExpression).Method;
            else
                throw new NotSupportedException();
        }

        /// <summary>
        /// Extracts the method info for the function referenced by an expression delegate
        /// </summary>
        /// <typeparam name="T1">The first function argument</typeparam>
        /// <typeparam name="T2">The function return type</typeparam>
        /// <param name="selector">The call expression</param>
        [MethodImpl(Inline)]
        public static MethodInfo method<T1,T2>(Expression<Func<T1,T2>> selector)
            => cast<MethodCallExpression>(selector.Body).Method;

        /// <summary>
        /// Extracts the method info for the function referenced by an expression delegate
        /// </summary>
        /// <typeparam name="T1">The first function argument</typeparam>
        /// <typeparam name="T2">The second function argument</typeparam>
        /// <typeparam name="R">The function return type</typeparam>
        /// <param name="selector">The call expression</param>
        [MethodImpl(Inline)]
        public static MethodInfo method<T1,T2,R>(Expression<Func<T1,T2,R>> selector)
            => cast<MethodCallExpression>(selector.Body).Method;

        /// <summary>
        /// Extracts the method info for the function referenced by an expression delegate
        /// </summary>
        /// <typeparam name="T1">The first function argument</typeparam>
        /// <typeparam name="T2">The second function argument</typeparam>
        /// <typeparam name="T3">The third function argument</typeparam>
        /// <typeparam name="R">The function return type</typeparam>
        /// <param name="selector">Specifies the call expression</param>
        [MethodImpl(Inline)]
        public static MethodInfo method<T1,T2,T3,R>(Expression<Func<T1,T2,T3,R>> selector)
            => cast<MethodCallExpression>(selector.Body).Method;

        /// <summary>
        /// Extracts the method for the action referenced by an an expression delegate
        /// </summary>
        /// <typeparam name="T">The action argument</typeparam>
        /// <param name="selector">Specifies the call expression</param>
        [MethodImpl(Inline)]
        public static MethodInfo method<T>(Expression<Action<T>> selector)
            => cast<MethodCallExpression>(selector.Body).Method;

        /// <summary>
        /// Extracts the method info for the action referenced by an expression delegate
        /// </summary>
        /// <typeparam name="T1">The first action argument</typeparam>
        /// <typeparam name="T2">The second action argument</typeparam>
        /// <param name="selector">Specifies the call expression</param>
        [MethodImpl(Inline)]
        public static MethodInfo method<T1,T2>(Expression<Action<T1,T2>> selector)
            => cast<MethodCallExpression>(selector.Body).Method;

        /// <summary>
        /// Extracts the method info for the action referenced by an expression delegate
        /// </summary>
        /// <typeparam name="T1">The first action argument</typeparam>
        /// <typeparam name="T2">The second action argument</typeparam>
        /// <typeparam name="T3">The third action argument</typeparam>
        /// <param name="selector">Specifies the call expression</param>
        [MethodImpl(Inline)]
        public static MethodInfo method<T1,T2,T3>(Expression<Action<T1,T2,T3>> selector)
            => cast<MethodCallExpression>(selector.Body).Method;

        /// <summary>
        /// Extracts the method info for the action referenced by an expression delegate
        /// </summary>
        /// <typeparam name="T1">The first action argument</typeparam>
        /// <typeparam name="T2">The second action argument</typeparam>
        /// <typeparam name="T3">The third action argument</typeparam>
        /// <typeparam name="T4">The fourth action argument</typeparam>
        /// <param name="selector">The call expression</param>
        [MethodImpl(Inline)]
        public static MethodInfo method<T1,T2,T3,T4>(Expression<Action<T1,T2,T3,T4>> selector)
            => cast<MethodCallExpression>(selector.Body).Method;
    }
}