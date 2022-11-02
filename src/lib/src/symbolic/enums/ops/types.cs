//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Enums
    {
        /// <summary>
        /// Queries the source assemblies for enum types
        /// </summary>
        /// <param name="src">The assemblies to query</param>
        [Op]
        public static Type[] types(params Assembly[] src)
            => src.Enums();
    }
}