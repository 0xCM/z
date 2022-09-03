//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    partial class XApi
    {
        /// <summary>
        /// Determines whether a method has numeric operands (if any) and a numeric return type (if any)
        /// </summary>
        /// <param name="src">The method to examine</param>
        [Op]
        public static bool IsNumeric(this MethodInfo m)
            => (m.HasVoidReturn() || NumericKinds.test(m.ReturnType))
             && m.ParameterTypes().All(t => NumericKinds.test(t));

        /// <summary>
        /// Determines whether a method is a numeric operator with a specified arity
        /// </summary>
        /// <param name="m">The method to examine</param>
        [Op]
        public static bool IsNumericOperator(this MethodInfo m, int? arity = null)
            => m.IsOperator()  && m.IsNumeric() && (arity != null ? m.ArityValue() == arity : true);
    }
}