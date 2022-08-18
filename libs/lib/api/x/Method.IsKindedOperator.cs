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
        /// Determines whether a method defines an operator with identified kind
        /// </summary>
        /// <param name="m">The source method</param>
        [Op]
        public static bool IsKindedOperator(this MethodInfo m)
            => m.IsKinded() && m.IsOperator();
    }
}