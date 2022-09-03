//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;
    using System.Reflection;

    partial class ClrQuery
    {
        /// <summary>
        /// Selects the methods available through the type that were not declared by the type
        /// </summary>
        /// <param name="src">The type to examine</param>
        [Op]
        public static MethodInfo[] UndeclaredMethods(this Type src)
            => src.Methods().Except(src.DeclaredMethods()).ToArray();
    }
}