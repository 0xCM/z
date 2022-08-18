//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial class ClrQuery
    {
        /// <summary>
        /// Selects the literal fields defined by a type and extracts/casts their values
        /// </summary>
        /// <param name="src">The source type</param>
        /// <typeparam name="T">The target value type</typeparam>
        [Op, Closures(Closure)]
        public static T[] LiteralValues<T>(this Type src, string filter = null)
            where T : unmanaged
        {
            var fields = filter == null ? src.LiteralFields() : src.LiteralFields().WithNameLike(filter);
            return fields.LiteralValues().Cast<T>();
        }
    }
}