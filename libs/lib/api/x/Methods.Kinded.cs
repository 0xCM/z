//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    partial class XApi
    {
        /// <summary>
        /// Queries the stream for methods that have a nonempty kind assignment
        /// </summary>
        /// <param name="src">The source methods</param>
        [Op]
        public static MethodInfo[] Kinded(this MethodInfo[] src)
            => src.Where(x => x.IsKinded());
    }
}