//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Selects properaties from a source stream to which a parametrically-identified attribute is attached
        /// </summary>
        /// <param name="src">The source stream</param>
        /// <typeparam name="A">The attribute type</typeparam>
        public static PropertyInfo[] Tagged<A>(this PropertyInfo[] src)
            where A : Attribute
                => src.Where(x => x.Tagged<A>());
    }
}