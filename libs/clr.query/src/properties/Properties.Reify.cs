//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Queries literal fields for their values
        /// </summary>
        /// <param name="src">The source stream</param>
        [Op]
        public static PropertyInfo[] Reify(this PropertyInfo[] src, Type t)
            => src.Where(x => x.PropertyType.Reifies(t));

        /// <summary>
        /// Queries literal fields for their values
        /// </summary>
        /// <param name="src">The source stream</param>
        [Op]
        public static PropertyInfo[] Reify<T>(this PropertyInfo[] src)
            where T : class
                => src.Reify(typeof(T));
    }
}