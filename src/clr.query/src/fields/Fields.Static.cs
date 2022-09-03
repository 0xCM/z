//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Selects the static fields from a stream
        /// </summary>
        /// <param name="src">The source stream</param>
        [Op]
        public static FieldInfo[] Static(this FieldInfo[] src)
            => src.Where(x => x.IsStatic);

        /// <summary>
        /// Selects the instance fields from a stream
        /// </summary>
        /// <param name="src">The source stream</param>
        [Op]
        public static FieldInfo[] Instance(this FieldInfo[] src)
            => src.Where(x => !x.IsStatic);
    }
}