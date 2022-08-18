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
        /// Determines whether the method has a kind identifier
        /// </summary>
        /// <param name="m">The source method</param>
        [Op]
        public static bool IsKinded(this MethodInfo m)
            => m.ApiClass() != 0;
    }
}