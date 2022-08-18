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
        /// Selects parameters from a method, if any, that acceptrequire an immediate value
        /// </summary>
        /// <param name="m">The method to examine</param>
        [Op]
        public static ParameterInfo[] ImmParameters(this MethodInfo src, ImmRefinementKind refinement)
        {
            var refined = src.GetParameters().Where(p => p.IsRefinedImmediate());
            var unrefined = src.GetParameters().Where(p => p.IsUnrefinedImmediate());
            if(refinement == ImmRefinementKind.All)
                return refined.Concat(unrefined).Array();
            else if(refinement == ImmRefinementKind.Refined)
                return refined;
            else
                return unrefined;
        }
    }
}