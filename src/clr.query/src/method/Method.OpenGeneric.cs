//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Queries the source for open generic methods
        /// </summary>
        /// <param name="src">The source methods</param>
        [Op]
        public static MethodInfo[] OpenGeneric(this MethodInfo[] src)
            => src.Where(m => m.IsOpenGeneric());

        /// <summary>
        /// Queries the source for open generic methods that have a specified argument count
        /// </summary>
        /// <param name="src">The source methods</param>
        /// <param name="args">The target argument count</param>
        [Op]
        public static MethodInfo[] OpenGeneric(this MethodInfo[] src, int args)
            => src.OpenGeneric().Where(m => m.GetGenericArguments().Length == args);
    }
}