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
        /// Queries the source <see cref='Type'/> for <see cref='MethodInfo'/> members determined by the <see cref='BF_DeclaredStatic'/> flags
        /// </summary>
        /// <param name="src">The source type</param>
        [MethodImpl(Inline), Op]
        public static MethodInfo[] DeclaredStaticMethods(this Type src)
            => src.GetMethods(BF_DeclaredStatic);
    }
}