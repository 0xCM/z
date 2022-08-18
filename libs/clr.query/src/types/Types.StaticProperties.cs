//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Selects all static properties declared by the source types
        /// </summary>
        /// <param name="src">The types to search</param>
        [Op]
        public static PropertyInfo[] StaticProperties(this Type[] src)
            => src.SelectMany(x => x.StaticProperties());
    }
}