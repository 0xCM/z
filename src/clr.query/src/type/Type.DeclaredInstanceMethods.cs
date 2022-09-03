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
        /// Queries the source <see cref='Type'/> for <see cref='BF_DeclaredInstance'/> <see cref='MethodInfo'/> members
        /// </summary>
        /// <param name="src">The source type</param>
        [MethodImpl(Inline), Op]
        public static MethodInfo[] DeclaredInstanceMethods(this Type src)
            => src.GetMethods(BF_DeclaredInstance);

        /// <summary>
        /// Queries the source <see cref='Type'/> for <see cref='BF_DeclaredInstance'/> <see cref='MethodInfo'/> members with a specified name
        /// </summary>
        /// <param name="src">The source type</param>
        [MethodImpl(Inline), Op]
        public static MethodInfo[] DeclaredInstanceMethods(this Type src, string name)
            => src.DeclaredInstanceMethods().Where(m => m.Name == name);
    }
}