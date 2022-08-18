//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    partial class ClrQuery
    {
        /// <summary>
        /// Queries literal fields for their values
        /// </summary>
        /// <param name="src">The source stream</param>
        [Op]
        public static FieldInfo[] Reify(this FieldInfo[] src, Type t)
            => src.Where(x => x.FieldType.Reifies(t));

        /// <summary>
        /// Queries literal fields for their values
        /// </summary>
        /// <param name="src">The source stream</param>
        [Op]
        public static FieldInfo[] Reify<T>(this FieldInfo[] src)
            where T : class
                => src.Reify(typeof(T));
    }
}