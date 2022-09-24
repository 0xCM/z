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
        /// Selects the instance methods from a stream
        /// </summary>
        /// <param name="src">The methods to examine</param>
        [Op]
        public static MethodInfo[] Instance(this MethodInfo[] src)
            => src.Where(t => !t.IsStatic);
    }
}