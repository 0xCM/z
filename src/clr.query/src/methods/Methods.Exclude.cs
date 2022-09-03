//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial class ClrQuery
    {
        /// <summary>
        /// Filters out the source methods with names that match those from a specified array
        /// </summary>
        /// <param name="src">The source methods</param>
        /// <param name="names">The exclusion filter</param>
        [Op]
        public static MethodInfo[] Exclude(this MethodInfo[] src, params string[] names)
            => src.Where(t => !names.Contains(t.Name));

        /// <summary>
        /// Filters out the source methods with names that match those from a specified set
        /// </summary>
        /// <param name="src">The source methods</param>
        /// <param name="names">The exclusion filter</param>
        [Op]
        public static MethodInfo[] Exclude(this MethodInfo[] src, ISet<string> names)
            => src.Where(t => !names.Contains(t.Name));
    }
}