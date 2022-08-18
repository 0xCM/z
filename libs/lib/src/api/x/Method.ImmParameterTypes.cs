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
        /// Returns a method's immediate parameter types
        /// </summary>
        /// <param name="m">The method to examine</param>
        [Op]
        public static Type[] ImmParameterTypes(this MethodInfo src, ImmRefinementKind kind)
            => src.ImmParameters(kind).Select(p => p.ParameterType);
    }
}