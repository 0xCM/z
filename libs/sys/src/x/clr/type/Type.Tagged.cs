//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    partial class ClrQuery
    {
       /// <summary>
        /// Determines whether an attribute is applied to a type
        /// </summary>
        /// <param name="src">The source type</param>
        /// <typeparam name="A">The attribute type</typeparam>
        public static bool Tagged<A>(this Type src)
            where A : Attribute
                => System.Attribute.IsDefined(src.TEffective(), typeof(A));
    }
}