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
        /// Creates a type-test expression
        /// </summary>
        /// <param name="value">The value to test</param>
        /// <param name="t">The type to test against</param>
        [MethodImpl(Inline), Op]
        public static TypeBinaryExpression test(object value, Type t)
            => LX.TypeIs(constant(value), t);

        /// <summary>
        /// Creates an expression to adjudicate whether a value if of a specified type
        /// </summary>
        /// <param name="value">The value to test</param>
        /// <typeparam name="T">The type to test against</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static TypeBinaryExpression test<T>(object value)
            => LX.TypeIs(constant(value), typeof(T));
    }
}