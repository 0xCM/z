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
        /// Extracts the field info for the field referenced by an expression delegate
        /// </summary>
        /// <typeparam name="F">The field type</typeparam>
        /// <param name="selector">The selecting expression that identifies the desired member</param>

        [MethodImpl(Inline)]
        public static FieldInfo field<F>(Expression<Func<F>> selector)
            => cast<FieldInfo>(cast<MemberExpression>(selector.SelectionSubject()).Member);

        /// <summary>
        /// Extracts the field info for the field referenced by an expression delegate
        /// </summary>
        /// <typeparam name="T">The declaring type</typeparam>
        /// <typeparam name="P">The property type</typeparam>
        /// <param name="selector">The selecting expression that identifies the desired member</param>
        [MethodImpl(Inline)]
        public static FieldInfo field<T,P>(Expression<Func<T,P>> selector)
            => cast<FieldInfo>(cast<MemberExpression>(selector.SelectionSubject()).Member);
    }
}