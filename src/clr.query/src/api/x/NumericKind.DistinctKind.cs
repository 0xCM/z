//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XApi
    {
        /// <summary>
        /// Enumerates the distinct numeric kinds represented by the (bitfield) source kind
        /// </summary>
        /// <param name="k">The kind to evaluate</param>
        [MethodImpl(Inline), Op]
        public static HashSet<NumericKind> DistinctKinds(this NumericKind k)
            => ApiIdentityKinds.kindset(k);
    }
}