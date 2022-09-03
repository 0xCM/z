//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Selects the public types from a stream
        /// </summary>
        /// <param name="src">The source stream</param>
        [Op]
        public static Type[] Public(this Type[] src)
            => src.Where(t => t.IsPublic);
    }
}