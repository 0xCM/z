//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Gets the simple name of an assembly
        /// </summary>
        /// <param name="a">The source assembly</param>
        [MethodImpl(Inline), Op]
        public static string GetSimpleName(this Assembly a)
            => a?.GetName()?.Name ?? EmptyString;
    }
}