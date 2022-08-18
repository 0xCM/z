//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Selects literal fields from the source
        /// </summary>
        /// <param name="src">The data source</param>
        [Op]
        public static FieldInfo[] Literals(this FieldInfo[] src)
            => src.Where(x => x.IsLiteral);

        /// <summary>
        /// Selects literal fields of specified type from the source
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="match">The field type to match</param>
        [Op]
        public static FieldInfo[] Literals(this FieldInfo[] src, Type match)
            => src.Where(x => x.IsLiteral && x.FieldType == match);
    }
}