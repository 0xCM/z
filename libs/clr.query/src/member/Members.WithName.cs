//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Selects the members with a particular name
        /// </summary>
        /// <param name="src">The members to examine</param>
        /// <param name="name">The name to match</param>
        public static T[] WithName<T>(this T[] src, string name)
            where T : MemberInfo
                => src.Where(x => x.Name == name);

        /// <summary>
        /// Selects the members with a name that exists within a supplied set
        /// </summary>
        /// <param name="src">The members to examine</param>
        /// <param name="name">The name to match</param>
        public static T[] WithName<T>(this T[] src, HashSet<string> names)
            where T : MemberInfo
                => src.Where(x => names.Contains(x.Name));
    }
}