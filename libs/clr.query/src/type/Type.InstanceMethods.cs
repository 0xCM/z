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

    using F = System.Reflection.BindingFlags;

    partial class ClrQuery
    {
        /// <summary>
        /// Retrieves the public and non-public instance methods declared by a type
        /// </summary>
        /// <param name="t">The type to examine</param>
        [MethodImpl(Inline), Op]
        public static MethodInfo[] InstanceMethods(this Type src)
            => src.GetMethods(F.Public | F.NonPublic | F.Instance | F.FlattenHierarchy);
    }
}