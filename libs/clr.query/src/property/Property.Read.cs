//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using static Option;

    partial class ClrQuery
    {
        /// <summary>
        /// Attempts to retrieve the value of an instance or static property
        /// </summary>
        /// <param name="p">The property</param>
        /// <param name="instance">The object instance, if applicable</param>
        [Op]
        public static Option<object> Read(this PropertyInfo p, object instance = null)
            => Try(() => p.GetValue(instance));

        [Op]
        public static Option<T> Read<T>(this PropertyInfo p, object src)
            => Try(() => (T)p.GetValue(src));
    }
}