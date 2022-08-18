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
        /// Returns true if a method is open generic with parametric arity 2 and is attributed
        /// with both natural an numeric closures
        /// </summary>
        /// <param name="m">The method to test</param>
        [Op]
        public static bool IsNaturalNumeric(this MethodInfo m)
            => m.IsOpenGeneric(2) &&  m.Tagged<OpAttribute>() && m.Tagged<NumericClosuresAttribute>() && m.Tagged<NaturalsAttribute>();
    }
}