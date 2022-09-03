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
        /// Queries the source <see cref='Type'/> for <see cref='PropertyInfo'/> members determined by the <see cref='BF_DeclaredInstance'/> flags
        /// </summary>
        /// <param name="src">The source type</param>
        [MethodImpl(Inline), Op]
        public static PropertyInfo[] DeclaredInstanceProperties(this Type src)
            => src.GetProperties(BF_DeclaredInstance);
    }
}