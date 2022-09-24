//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial class ClrQuery
    {
        /// <summary>
        /// For the generic methods in a stream, selects their respective definitions
        /// </summary>
        /// <param name="src">The methods to examine</param>
        [Op]
        public static MethodInfo[] MemberOf(this MethodInfo[] src, GenericState g)
            => (g.IsGeneric() ? src.OpenGeneric().Union(src.ClosedGeneric()) : src.NonGeneric()).Array();
    }
}