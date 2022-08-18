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
        /// Determines whether a method is a vectorized operator which, by definition, is an operator
        /// (which, by definition, is an homogenous function) with a vectorized operand which, by definition,
        /// is an operand of intrinsic vector type (which, by definition, is one of the system-defined intrinsic vector types
        /// or a custom intrinsic vector type)
        /// </summary>
        /// <param name="src">The method to test</param>
        [Op]
        public static bool IsVectorizedOperator(this MethodInfo src)
            => src.IsOperator() && src.ReturnType.IsVector();
    }
}