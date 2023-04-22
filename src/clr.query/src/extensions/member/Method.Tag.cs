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
        public static Option<A> Tag<A>(this MethodInfo t)
            where A : Attribute
                => t.GetCustomAttribute<A>();

        /// <summary>
        /// Gets the value of a member attribute if it exists
        /// </summary>
        /// <typeparam name="A">The attribute type</typeparam>
        /// <param name="m">The member</param>

        public static bool Tag<A>(this MethodInfo t, out A dst)
            where A : Attribute
        {
            var a = t.GetCustomAttribute<A>();
            if(a != null)
                dst = a;
            else
                dst = default;
            return a != null;
        }
    }
}