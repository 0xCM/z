//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    partial class XApi
    {
        /// <summary>
        /// Queries the stream for methods that have a nonempty kind assignment
        /// </summary>
        /// <param name="src">The souce methods</param>
        /// <param name="kind">The kind to match</param>
        [Op]
        public static IEnumerable<MethodInfo> KindedOperators(this MethodInfo[] src)
            => src.Where(x => x.IsKindedOperator());
    }
}