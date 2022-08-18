//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Gets the value of a specified field or property
        /// </summary>
        /// <param name="m">The field or property</param>
        /// <param name="o">The object on which the member is defined</param>
        [Op]
        public static object MemberValue(this MemberInfo m, object o)
        {
            if (m is FieldInfo)
                return (m as FieldInfo).GetValue(o);
            else if (m is PropertyInfo)
                return (m as PropertyInfo).GetValue(o);
            else
                throw new NotSupportedException();
        }

        /// <summary>
        /// Gets the value of the identified member field or property
        /// </summary>
        /// <typeparam name="T">The value type</typeparam>
        /// <param name="m">The member</param>
        /// <param name="o">The instance from which to access the member</param>
        [MethodImpl(Inline), Closures(AllNumeric)]
        public static T MemberValue<T>(this MemberInfo m, object o)
            => (T)m.MemberValue(o);
    }
}