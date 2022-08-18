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
        /// Determines whether a parameters is an unrefined immediate
        /// </summary>
        /// <param name="src">The source parameter</param>
        [Op]
        public static bool IsUnrefinedImmediate(this ParameterInfo src)
            => src.Tagged<ImmAttribute>() && !src.ParameterType.IsEnum;
    }
}