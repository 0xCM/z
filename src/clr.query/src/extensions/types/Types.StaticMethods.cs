//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Selects all static methods declared by the source types
        /// </summary>
        /// <param name="src">The types to search</param>
        [Op]
        public static MethodInfo[] StaticMethods(this Type[] src)
            => src.SelectMany(x => x.StaticMethods());

        /// <summary>
        /// Selects all static methods declared by the source types
        /// </summary>
        /// <param name="src">The types to search</param>
        [Op]
        public static MethodInfo[] DeclaredStaticMethods(this Type[] src)
            => src.SelectMany(x => x.DeclaredStaticMethods());
    }
}