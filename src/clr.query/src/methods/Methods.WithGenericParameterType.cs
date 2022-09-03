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
        /// Selects generic methods from a stream that have a specified generic type definition parameter
        /// </summary>
        /// <param name="src">The methods to examine</param>
        /// <param name="typedef">The type definition to match</param>
        [Op]
        public static MethodInfo[] WithGenericParameterType(this MethodInfo[] src, Type typedef)
            => src.Where(m => m.GetParameters().Any(p => p.ParameterType.IsGenericTypeDefinition && p.ParameterType == typedef));
    }
}