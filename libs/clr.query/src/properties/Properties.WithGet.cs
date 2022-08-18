//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Selects the properties with get methods from the stream
        /// </summary>
        /// <param name="src">The properties to examine</param>
        [Op]
        public static PropertyInfo[] WithGet(this PropertyInfo[] src)
            => src.Where(p => p.GetGetMethod() != null);

        /// <summary>
        /// Selects the properties from a stream that have public accessesors
        /// </summary>
        /// <param name="src">The source stream</param>
        [Op]
        public static PropertyInfo[] WithPublicGet(this PropertyInfo[] src)
            => src.Where(p => p.CanRead && p.GetGetMethod().IsPublic);
    }
}