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
        /// Selects all methods available through the type
        /// </summary>
        /// <param name="src">The type to examine</param>
        [MethodImpl(Inline), Op]
        public static MethodInfo[] Methods(this Type src)
            => src.GetMethods(BF_World);
    }
}