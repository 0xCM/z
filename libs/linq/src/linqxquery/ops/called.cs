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
        /// Returns the method invoked by an expression, if any
        /// </summary>
        /// <param name="x">The expression to test</param>
        [MethodImpl(Inline), Op]
        public static Option<MethodInfo> called(Expression x)
            => cast<MethodCallExpression>(x)?.Method;
    }
}