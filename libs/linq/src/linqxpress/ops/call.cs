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

    using LX = System.Linq.Expressions.Expression;
    using PX = System.Linq.Expressions.ParameterExpression;

    partial class LinqXPress
    {
        /// <summary>
        /// Creates an expression that invokes a static or instance method
        /// </summary>
        /// <param name="Host">The object that exposes the method if not static; otherwise null</param>
        /// <param name="m">The method to be invoked</param>
        /// <param name="args">The arguments supplied to the method when invoked</param>
        [MethodImpl(Inline), Op]
        public static MethodCallExpression call(object Host, MethodInfo m, params PX[] args)
            => LX.Call(core.coalesce(Host, h => constant(h)), m, args);

        /// <summary>
        /// Creates an expression that invokes a static method
        /// </summary>
        /// <param name="m">The method to be invoked</param>
        /// <param name="args">The arguments supplied to the method when invoked</param>
        [MethodImpl(Inline), Op]
        public static MethodCallExpression call(MethodInfo m, params PX[] args)
            => call(null, m, args);
    }
}