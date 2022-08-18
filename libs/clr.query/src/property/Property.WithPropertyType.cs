//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Selects the properties from a stream of a specified type
        /// </summary>
        /// <param name="src">The source stream</param>
        [Op]
        public static PropertyInfo[] WithPropertyType(this PropertyInfo[] src, Type t)
            => src.Where(p => p.PropertyType == t);
    }
}