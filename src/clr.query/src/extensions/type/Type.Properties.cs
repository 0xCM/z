//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    using static ReflectionFlags;

    partial class ClrQuery
    {
        /// <summary>
        /// Retrieves all declared or inheraited by a type
        /// </summary>
        /// <param name="src">The type to examine</param>
        [Op]
        public static PropertyInfo[] Properties(this Type src)
            => src.GetProperties(BF_All);
    }
}