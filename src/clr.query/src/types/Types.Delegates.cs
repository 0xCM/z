//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Returns all source types which are delegates
        /// </summary>
        /// <param name="src">The source types</param>
        [Op]
        public static Type[] Delegates(this Type[] src)
            => src.Where(t => t.IsDelegate());
    }
}