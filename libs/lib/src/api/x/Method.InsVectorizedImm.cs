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
        /// Determines whether a method is (partially) vectorized and accepts an immediate value
        /// </summary>
        /// <param name="src">The method to query</param>
        [Op]
        public static bool IsVectorizedImm(this MethodInfo src, ImmRefinementKind kind)
            => src.IsVectorized() && src.AcceptsImmediate(kind) && src.ReturnsVector();

        /// <summary>
        /// Determines whether a method is a vectorized unary operator that accepts an immediate value
        /// </summary>
        /// <param name="src">The method to query</param>
        [Op]
        public static bool IsVectorizedUnaryImm(this MethodInfo src, ImmRefinementKind refinement)
        {
            var parameters = src.GetParameters().ToArray();
            return parameters.Length == 2
                && parameters[0].ParameterType.IsVector()
                && parameters[1].IsImmediate(refinement)
                && src.ReturnsVector();
        }

        /// <summary>
        /// Determines whether a method is a vectorized binary operator that accepts an immediate value
        /// </summary>
        /// <param name="src">The method to query</param>
        [Op]
        public static bool IsVectorizedBinaryImm(this MethodInfo src, ImmRefinementKind kind)
        {
            var parameters = src.GetParameters().ToArray();
            return parameters.Length == 3
                && parameters[0].ParameterType.IsVector()
                && parameters[1].ParameterType.IsVector()
                && parameters[2].IsImmediate(kind)
                && src.ReturnsVector();
        }
    }
}