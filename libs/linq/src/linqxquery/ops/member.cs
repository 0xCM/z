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
        /// Extracts the member info for the member referenced by an expression delegate
        /// </summary>
        /// <typeparam name="T">The first selector parameter</typeparam>
        /// <typeparam name="M">The member type</typeparam>
        /// <param name="selector">The selecting expression that identifies the desired member</param>
        [MethodImpl(Inline)]
        public static MemberInfo member<T,M>(Expression<Func<T,M>> selector)
            => cast<MemberInfo>(cast<MemberExpression>(selector.Body).Member);
    }
}