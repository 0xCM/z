//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Selects the mutable fields from a stream
        /// </summary>
        /// <param name="src">The source stream</param>
        [Op]
        public static FieldInfo[] Mutable(this FieldInfo[] src)
            => src.Where(x => !(x.IsInitOnly || x.IsLiteral));

        /// <summary>
        /// Selects the immutable fields from a stream
        /// </summary>
        /// <param name="src">The source stream</param>
        [Op]
        public static FieldInfo[] Immutable(this FieldInfo[] src)
            => src.Where(x => x.IsInitOnly || x.IsLiteral);
    }
}