//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Selects the fields from the stream for which the field type name contains the search string
        /// </summary>
        /// <param name="src">The source stream</param>
        /// <param name="search">The search string</param>
        [Op]
        public static FieldInfo[] WithTypeNameLike(this FieldInfo[] src, string search)
            => src.Where(x => x.FieldType.Name.Contains(search));
    }
}