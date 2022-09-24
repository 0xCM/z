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
        /// Selects all public instance fields from the source
        /// </summary>
        /// <param name="src">The source type</param>
        [Op]
        public static PropertyInfo[] PublicInstanceProperties(this Type src)
            => src.GetProperties(BF_PublicInstance);
    }
}