//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Selects all literal fields from the source types
        /// </summary>
        /// <param name="src">The types to search</param>
        [Op]
        public static FieldInfo[] LiteralFields(this Type[] src)
            => src.SelectMany(x => x.LiteralFields()).Array();
    }
}