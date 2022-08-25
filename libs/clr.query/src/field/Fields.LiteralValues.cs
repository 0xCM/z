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
        public static object[] LiteralValues(this FieldInfo[] src)
            => src.Literals().Select(f => f.GetRawConstantValue());

        /// <summary>
        /// Queries literal fields for values of parametric type
        /// </summary>
        /// <param name="src">The source stream</param>
        [Op]
        public static IEnumerable<T> LiteralValues<T>(this FieldInfo[] src)
            where T : unmanaged
                => src.LiteralValues().Select(v => (T)v);
    }
}