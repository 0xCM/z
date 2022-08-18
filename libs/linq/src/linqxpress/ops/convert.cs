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

    public partial class LinqXPress
    {
        /// <summary>
        /// Defines a conversion from a source expression to a target type
        /// </summary>
        /// <param name="e">The source expression</param>
        /// <param name="dstType">The target type</param>
        [MethodImpl(Inline), Op]
        public static UnaryExpression convert(LX e, Type dstType)
            => LX.Convert(e, dstType);

        /// <summary>
        /// Defines a conversion from a source expression to a target type
        /// </summary>
        /// <typeparam name="T">The target type</typeparam>
        /// <param name="e">The source expression</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static UnaryExpression convert<T>(LX e)
            => convert(e, typeof(T));
    }
}