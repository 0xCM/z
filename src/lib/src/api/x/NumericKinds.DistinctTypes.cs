//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XApi
    {
        /// <summary>
        /// Specifies the primal types identified by a specified kind
        /// </summary>
        /// <param name="k">The primal kind</param>
        [MethodImpl(Inline), Op]
        public static HashSet<Type> DistinctTypes(this NumericKind k)
            => ApiIdentityKinds.typeset(k);
    }
}