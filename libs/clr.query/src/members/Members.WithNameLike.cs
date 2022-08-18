//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    partial class ClrQuery
    {
        /// <summary>
        /// Selects the members with names that contain the supplied search field
        /// </summary>
        /// <param name="src">The members to examine</param>
        /// <param name="search">The name to match</param>
        public static IEnumerable<T> WithNameLike<T>(this IEnumerable<T> src, string search)
            where T : MemberInfo
                => src.Where(x => x.Name.Contains(search));

        /// <summary>
        /// Selects the members with names that contain the supplied search field
        /// </summary>
        /// <param name="src">The members to examine</param>
        /// <param name="search">The name to match</param>
        public static T[] WithNameLike<T>(this T[] src, string search)
            where T : MemberInfo
                => src.Where(x => x.Name.Contains(search));

        /// <summary>
        /// Selects the members with names that contain the supplied search field
        /// </summary>
        /// <param name="src">The members to examine</param>
        /// <param name="search">The name to match</param>
        public static T[] WithNameLike<T>(this T[] src, params string[] search)
            where T : MemberInfo
            => from m in src
                where search.Any(match => m.Name.Contains(match))
                select m;

        /// <summary>
        /// Selects the members with names that contain the supplied search field
        /// </summary>
        /// <param name="src">The members to examine</param>
        /// <param name="search">The name to match</param>
        public static T[] WithNameStartingWith<T>(this T[] src, params string[] search)
            where T : MemberInfo
                => from m in src
                    where search.Any(match => m.Name.StartsWith(match))
                    select m;
    }
}