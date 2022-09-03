//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Linq.Expressions;

    using static Root;

    partial class XFuncX
    {
        /// <summary>
        /// Extracts the property info for the property referenced by an expression delegate
        /// </summary>
        /// <typeparam name="P">The property type</typeparam>
        /// <param name="selector">The selecting expression that identifies the desired member</param>
        [MethodImpl(Inline)]
        public static PropertyInfo GetProperty<P>(this Expression<Func<P>> selector)
            => LinqXQuery.property(selector);

        /// <summary>
        /// Extracts the property info for the property referenced by an expression delegate
        /// </summary>
        /// <typeparam name="T">The declaring type</typeparam>
        /// <typeparam name="P">The property type</typeparam>
        /// <param name="selector">The selecting expression that identifies the desired member</param>
        [MethodImpl(Inline)]
        public static PropertyInfo GetProperty<T,P>(this Expression<Func<T,P>> selector)
            => LinqXQuery.property(selector);
    }
}