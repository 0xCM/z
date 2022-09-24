//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Selects the static types from a stream
        /// </summary>
        /// <param name="src">The source stream</param>
        [Op]
        public static Type[] Static(this Type[] src)
            => src.Where(p => p.IsStatic());
    }
}