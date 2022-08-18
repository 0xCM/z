//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Selects the public fields from a stream
        /// </summary>
        /// <param name="src">The source stream</param>
        [Op]
        public static FieldInfo[] Public(this FieldInfo[] src)
            => src.Where(x => x.IsPublic);

        /// <summary>
        /// Selects the non-public fields from a stream
        /// </summary>
        /// <param name="src">The source stream</param>
        [Op]
        public static FieldInfo[] NonPublic(this FieldInfo[] src)
            => src.Where(x => !x.IsPublic);
    }
}