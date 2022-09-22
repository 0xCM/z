//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    partial class XApi
    {
        /// <summary>
        /// Returns the source method's kind identifier if it exists
        /// </summary>
        /// <param name="src">The method to examine</param>
        [MethodImpl(Inline), Op]
        public static string ApiGroup(this MethodInfo src)
        {
            if(src.Tag<OpAttribute>(out var dst))
                return dst.ApiGroup;
            else
                return EmptyString;
        }
    }
}