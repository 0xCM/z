//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Selects the closed generic methods from a stream
        /// </summary>
        /// <param name="src">The methods to examine</param>
        [Op]
        public static MethodInfo[] ClosedGeneric(this MethodInfo[] src)
            => src.Where(t => t.IsConstructedGenericMethod);
    }
}