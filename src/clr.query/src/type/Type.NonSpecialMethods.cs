//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    using static ReflectionFlags;

    partial class ClrQuery
    {
        /// <summary>
        /// Selects all methods declared by a type; however, property getters/setters and other
        /// compiler-generated artifacts are excluded
        /// </summary>
        /// <param name="src">The type to examine</param>
        [Op]
        public static MethodInfo[] NonSpecialMethods(this Type src)
            => src.GetMethods(BF_Declared).Where(m => !m.IsSpecialName);
    }
}