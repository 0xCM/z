//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;
    using System.Reflection;

    partial class ClrQuery
    {
        /// <summary>
        /// For the generic methods in a stream, selects their respective definitions
        /// </summary>
        /// <param name="src">The methods to examine</param>
        [Op]
        public static MethodInfo[] GenericDefinitions(this MethodInfo[] src)
            => src.Where(m => m.IsOpenGeneric() || m.IsClosedGeneric()).Select(m => m.GetGenericMethodDefinition()).Distinct();
    }
}