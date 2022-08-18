//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Selects the properties with set methods from the stream
        /// </summary>
        /// <param name="src">The properties to examine</param>
        [Op]
        public static PropertyInfo[] WithSet(this PropertyInfo[] src)
            => src.Where(p => p.GetSetMethod() != null);

        /// <summary>
        /// Selects the properties from a stream that have public manipulators
        /// </summary>
        /// <param name="src">The source stream</param>
        [Op]
        public static PropertyInfo[] WithPublicSet(this PropertyInfo[] src)
            => src.Where(p => p.CanWrite && p.GetSetMethod().IsPublic);
    }
}