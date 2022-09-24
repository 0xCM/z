//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Selects the non-public types from a stream
        /// </summary>
        /// <param name="src">The source stream</param>
        [Op]
        public static Type[] NonPublic(this Type[] src)
            => src.Where(t => !t.IsPublic);
    }
}