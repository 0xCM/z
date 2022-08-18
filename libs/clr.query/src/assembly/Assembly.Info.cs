//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    using static Root;

    partial class ClrQuery
    {
        /// <summary>
        /// Gets the value of <see cref="AssemblyProductAttribute"/> if it exists
        /// </summary>
        /// <param name="a">The source assembly</param>
        [Op]
        public static string Product(this Assembly a)
            => a.Tag<AssemblyProductAttribute>()?.Product ?? EmptyString;

        /// <summary>
        /// Gets the value of <see cref="AssemblyTitleAttribute"/> if it exists
        /// </summary>
        /// <param name="a">The source assembly</param>
        [Op]
        public static string Title(this Assembly a)
            => a.Tag<AssemblyTitleAttribute>()?.Title ?? EmptyString;

        /// <summary>
        /// Gets the value of <see cref="AssemblyCompanyAttribute"/> if it exists
        /// </summary>
        /// <param name="a">The source assembly</param>
        [Op]
        public static string Company(this Assembly a)
            => a.Tag<AssemblyCompanyAttribute>()?.Company ?? EmptyString;

        /// <summary>
        /// Gets the value of <see cref="AssemblyDefaultAliasAttribute"/> if it exists
        /// </summary>
        /// <param name="a">The source assembly</param>
        [Op]
        public static string DefaultAlias(this Assembly a)
            => a.Tag<AssemblyDefaultAliasAttribute>()?.DefaultAlias ?? EmptyString;
    }
}