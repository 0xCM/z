//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    partial class ClrQuery
    {
        /// <summary>
        /// Gets the static methods defined on a specified type
        /// </summary>
        /// <param name="src">The type to examine</param>
        public static MethodInfo[] StaticMethods(this Type src)
            => src.Methods().Where(m => m.IsStatic);

        /// <summary>
        /// Retrieves the public and non-public static methods declared by a type that have a specific name
        /// </summary>
        /// <param name="t">The type to examine</param>
        /// <param name="InstanceType">Whether to selct static or instance </param>
        public static MethodInfo[] StaticMethods(this Type t, string name)
            => t.StaticMethods().Where(m => m.Name == name);
    }
}