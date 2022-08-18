//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Selects source types from the stream to which a parametrically-identified attribute is applied
        /// </summary>
        /// <param name="src">The source stypes</param>
        /// <typeparam name="A">The attribute type</typeparam>
        public static Type[] Tagged<A>(this Type[] src)
            where A : Attribute
                => src.Where(t => t.Tagged<A>());
    }
}