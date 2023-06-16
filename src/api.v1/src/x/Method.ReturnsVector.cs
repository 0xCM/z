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
        /// Determines whether a method returns an intrinsic vector
        /// </summary>
        /// <param name="src">The method to test</param>
        [Op]
        public static bool ReturnsVector(this MethodInfo src)
            => src.ReturnType.IsVector();
    }
}