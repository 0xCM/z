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
        /// Extracts a value from a constant expression if possible
        /// </summary>
        /// <param name="x">The expression to examine</param>
        [MethodImpl(Inline), Op]
        public static Option<object> constant(Expression x)
            => Option.TryCast<ConstantExpression>(x).TryMap(c => c.Value);
    }
}