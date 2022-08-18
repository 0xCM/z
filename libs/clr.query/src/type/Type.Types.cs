//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial class ClrQuery
    {
        /// <summary>
        /// Selects the concrete types from a stream
        /// </summary>
        /// <param name="src">The source stream</param>
        [Op]
        public static Type[] Concrete(this Type[] src)
            => src.Where(t => t.IsConcrete());

        /// <summary>
        /// Returns all source types which ar interfaces
        /// </summary>
        /// <param name="src">The source types</param>
        [Op]
        public static Type[] Interfaces(this Type[] src)
            => src.Where(t => t.IsInterface);

        /// <summary>
        /// Returns all source types which are classes
        /// </summary>
        /// <param name="src">The source types</param>
        [Op]
        public static Type[] Classes(this Type[] src)
            => src.Where(t => t.IsClass);

        /// <summary>
        /// Returns all source types which are structs
        /// </summary>
        /// <param name="src">The source types</param>
        [Op]
        public static Type[] Structs(this Type[] src)
            => src.Where(t => t.IsStruct());

        /// <summary>
        /// Returns all source types which are enums
        /// </summary>
        /// <param name="src">The source types</param>
        [Op]
        public static Type[] Enums(this Type[] src)
            => src.Where(t => t.IsEnum);

        /// <summary>
        /// Selects the types from a specified namespace
        /// </summary>
        /// <param name="src">The type to examine</param>
        [Op]
        public static Type[] InNamespace(this Type[] src, string match)
            => src.Where(t => t.Namespace == match);
    }
}