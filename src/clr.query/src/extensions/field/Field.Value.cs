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
        /// Attempts to retrieve the value of an instance or static field
        /// </summary>
        /// <param name="field">The field</param>
        /// <param name="instance">The object instance, if applicable</param>
        [Op]
        public static Option<object> Value(this FieldInfo field, object instance = null)
            => Try(() => field.GetValue(instance));

        /// <summary>
        /// Attempts to retrieves the value of a field
        /// </summary>
        /// <typeparam name="V">The value type</typeparam>
        /// <param name="member">The field</param>
        /// <param name="instance">The object instance, if applicable</param>
        [Op, Closures(Closure)]
        public static Option<V> Value<V>(this FieldInfo member, object instance = null)
            => from o in member.Value(instance)
            from v in Option.TryCast<V>(o)
            select v;
    }
}