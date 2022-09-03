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
        /// Queries the source <see cref='Type'/> for <see cref='BF_Declared'/> <see cref='MethodInfo'/> members
        /// </summary>
        /// <param name="src">The source type</param>
        [MethodImpl(Inline), Op]
        public static MethodInfo[] DeclaredMethods(this Type src)
            => src.GetMethods(BF_Declared);

        /// <summary>
        /// Queries the source <see cref='Type'/> for <see cref='BF_Declared'/> <see cref='MethodInfo'/> members with a specified name
        /// </summary>
        /// <param name="src">The source type</param>
        [MethodImpl(Inline), Op]
        public static MethodInfo[] DeclaredMethods(this Type src, string name)
            => src.DeclaredMethods().Where(m => m.Name == name);
    }
}