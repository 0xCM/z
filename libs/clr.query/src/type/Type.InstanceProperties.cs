//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    using static Root;
    using static ReflectionFlags;

    partial class ClrQuery
    {
        /// <summary>
        /// Retrieves the public and non-public instance properties declared or inherited by a type
        /// </summary>
        /// <param name="t">The type to examine</param>
        [MethodImpl(Inline), Op]
        public static PropertyInfo[] InstanceProperties(this Type src)
            => src.GetProperties(BF_World);
    }
}