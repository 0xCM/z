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
        /// Determines whether a method defines a parameter that requires an 8-bit immediate immediate
        /// </summary>
        /// <param name="m">The method to examine</param>
        [Op]
        public static bool AcceptsImmediate(this MethodInfo src, ImmRefinementKind refinement)
            => src.ImmParameters(refinement).Any();

        /// <summary>
        /// Determines whether a method defines a parameter that requires an 8-bit immediate immediate
        /// </summary>
        /// <param name="m">The method to examine</param>
        [Op]
        public static bool AcceptsImmediate(this MethodInfo src)
            => src.Parameters(p => p.Tagged<ImmAttribute>()).Any();

        /// <summary>
        /// Determines whether a method defines an index-identified parameter that requires an 8-bit immediate immediate
        /// </summary>
        /// <param name="m">The method to examine</param>
        [Op]
        public static bool AcceptsImmediate(this MethodInfo m, int index, ImmRefinementKind refinement)
        {
            var parameters = m.GetParameters();
            return parameters.Length > index && parameters[index].IsImmediate(refinement);
        }
    }
}