//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Selects all nested types declared by an array of source types
        /// </summary>
        /// <param name="src">The source types</param>
        [Op]
        public static Type[] Generic(this Type[] src)
            => src.Where(t => !t.ContainsGenericParameters);
    }
}