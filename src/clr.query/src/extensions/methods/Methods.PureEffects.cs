//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    partial class ClrQuery
    {
        /// <summary>
        /// Filters the source collection to include only receivers with void return
        /// </summary>
        /// <param name="src">The source methods</param>
        [Op]
        public static MethodInfo[] PureEffects(this MethodInfo[] src)
            => src.Where(t => t.HasVoidReturn() && t.ArityValue() == 0);
    }
}