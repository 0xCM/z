//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Attempts to retrieves the value of a static or instance property
        /// </summary>
        /// <typeparam name="V">The value type</typeparam>
        /// <param name="member">The property</param>
        /// <param name="instance">The object instance, if applicable</param>
        [Op]
        public static Option<V> Value<V>(this PropertyInfo member, object instance = null)
            => from o in member.Read(instance)
                from v in Option.TryCast<V>(o)
                select v;
    }
}