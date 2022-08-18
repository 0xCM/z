//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    partial class ClrQuery
    {
        /// <summary>
        /// Determines whether the property has a public getter
        /// </summary>
        /// <param name="p">The property to examine</param>
        [MethodImpl(Inline), Op]
        public static bool HasPublicGetter(this PropertyInfo p)
            => p.GetGetMethod() != null;
    }
}