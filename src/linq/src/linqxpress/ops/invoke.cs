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
        /// Creates an expression to call a function
        /// </summary>
        /// <param name="f">An expression representing the function to invoke</param>
        /// <param name="args">The function arguments</param>
        [MethodImpl(Inline), Op]
        public static InvocationExpression invoke(LX f, params LX[] args)
            => LX.Invoke(f, args);

        /// <summary>
        /// Creates an invocation expression for a function f:X->Y
        /// </summary>
        /// <typeparam name="X">The function argument type</typeparam>
        /// <typeparam name="Y">The function return type</typeparam>
        /// <param name="f">The function delegate</param>
        /// <param name="arg">The name of argument</param>
        [MethodImpl(Inline)]
        public static InvocationExpression invoke<X,Y>(Func<X,Y> f, string arg = "x1")
            => LX.Invoke(func(f), paramX<X>(arg));

        /// <summary>
        /// Creates an invocation expression for a function f:X1->X2->Y
        /// </summary>
        /// <typeparam name="X1">The type of the first function argument</typeparam>
        /// <typeparam name="X2">The type of the second function argument</typeparam>
        /// <typeparam name="Y">The function return type</typeparam>
        /// <param name="f">The source function</param>
        /// <param name="arg1">The name of the first argument</param>
        /// <param name="arg2">The name of the second argument</param>
        public static InvocationExpression invoke<X1,X2,Y>(Func<X1,X2,Y> f, string arg1 = "x1", string arg2 = "x2")
            => LX.Invoke(func(f), paramX<X1>(arg1), paramX<X2>(arg2));
    }
}