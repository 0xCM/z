//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Gets the value of a member attribute if it exists
        /// </summary>
        /// <typeparam name="A">The attribute type</typeparam>
        /// <param name="m">The member</param>
        [MethodImpl(Inline)]
        public static Option<A> Tag<A>(this MemberInfo m)
            where A : Attribute
                => m.GetCustomAttribute<A>();

        /// <summary>
        /// Gets the value of a member attribute if it exists
        /// </summary>
        /// <typeparam name="A">The attribute type</typeparam>
        /// <param name="m">The member</param>
        [MethodImpl(Inline)]
        public static A RequiredTag<A>(this MemberInfo m)
            where A : Attribute
                => m.Tag<A>().Require();
    }
}