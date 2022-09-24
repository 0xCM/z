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
        /// Retrieves the public and non-public instance fields declared or inherited by a type
        /// </summary>
        /// <param name="t">The type to examine</param>
        [MethodImpl(Inline), Op]
        public static FieldInfo[] InstanceFields(this Type src)
            => src.GetFields(BF_World);
    }
}