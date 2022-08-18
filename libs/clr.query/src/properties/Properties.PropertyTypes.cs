//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
       /// <summary>
        /// Selects the property type from each source property
        /// </summary>
        /// <param name="src">The source properties</param>
        [Op]
        public static Type[] PropertyTypes(this PropertyInfo[] src)
            => src.Select(x => x.PropertyType);
    }
}