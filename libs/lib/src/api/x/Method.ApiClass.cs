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

    partial class XApi
    {
        /// <summary>
        /// Returns the source method's kind identifier if it exists
        /// </summary>
        /// <param name="src">The method to examine</param>
        [MethodImpl(Inline), Op]
        public static ApiClassKind ApiClass(this MethodInfo src)
        {
            if(src.Tag<OpKindAttribute>(out var dst))
                return dst.ApiClass;
            else
                return 0;
        }
    }
}