//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ReflectionFlags;

    partial class ClrQuery
    {
        /// <summary>
        /// Queries the source <see cref='Type'/> for <see cref='MethodInfo'/> members determined by the <see cref='BF_DeclaredPublicInstance'/> flags
        /// </summary>
        /// <param name="src">The source type</param>
        [MethodImpl(Inline), Op]
        public static MethodInfo[] DeclaredPublicInstanceMethods(this Type src)
            => src.GetMethods(BF_DeclaredPublicInstance);
    }
}