//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    partial class ClrQuery
    {
        /// <summary>
        /// Determines whether a type is classified as a blocked type via attribution
        /// </summary>
        /// <param name="t">The type to examine</param>
        [MethodImpl(Inline), Op]
        public static bool IsSpanBlock(this Type t)
            => t.Tagged<SpanBlockAttribute>();
    }
}