//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    partial class XApi
    {
        /// <summary>
        /// Queries the stream for methods that are recognized as numeric operators
        /// </summary>
        /// <param name="src">The source stream</param>
        [Op]
        public static MethodInfo[] NumericOperators(this MethodInfo[] src)
            => src.Where(x => x.IsNumericOperator());

        /// <summary>
        /// Selects numeric operators with a specified arity from the source stream
        /// </summary>
        /// <param name="src">The methods to filter</param>
        [Op]
        public static MethodInfo[] NumericOperators(this MethodInfo[] src, int arity)
            => src.Where(x => x.IsNumericOperator(arity));
    }
}