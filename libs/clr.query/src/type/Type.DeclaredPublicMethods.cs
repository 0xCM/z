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
        /// Queries the source <see cref='Type'/> for <see cref='MethodInfo'/> members determined by joining the
        /// <see cref='BF_DeclaredPublicInstance'/> and <see cref='BF_DeclaredPublicStatic'/> flags
        /// </summary>
        /// <param name="src">The source type</param>
        [MethodImpl(Inline), Op]
        public static MethodInfo[] DeclaredPublicMethods(this Type src)
            => src.GetMethods(BF_DeclaredPublicInstance | BF_DeclaredPublicStatic);
    }
}