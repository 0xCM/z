//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Linq;

    partial class XApi
    {
        /// <summary>
        /// Determines whether a method produces, but does not accept, vector values
        /// </summary>
        /// <param name="m">The method to examine</param>
        [Op]
        public static bool IsVectorFactory(this MethodInfo m)
            => m.ParameterTypes(true).Where(t => t.IsVector()).Count() == 0 && m.ReturnType.IsVector();
    }
}