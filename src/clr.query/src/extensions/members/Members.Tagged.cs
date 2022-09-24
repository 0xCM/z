//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial class ClrQuery
    {
        /// <summary>
        /// Selects the members with a particular attribute
        /// </summary>
        /// <param name="src">The members to examine</param>
        /// <param name="name">The name to match</param>
        public static IEnumerable<T> Tagged<T>(this IEnumerable<T> src, Type tAttrib)
            where T : MemberInfo
                => src.Where(m => m.Tagged(tAttrib));
    }
}