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
        /// Determines the imm refinement type, if any
        /// </summary>
        /// <param name="src">The source parameter</param>
        [Op]
        public static Option<Type> ImmRefinementType(this ParameterInfo src)
            => src.IsRefinedImmediate() ? Option.some(src.ParameterType) : Option.none<Type>();
    }
}