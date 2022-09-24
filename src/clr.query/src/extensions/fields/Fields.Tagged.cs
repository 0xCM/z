//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    partial class ClrQuery
    {
        /// <summary>
        /// Selects fields from the source  to which a parametrically-identified attribute is attached
        /// </summary>
        /// <param name="src">The source stream</param>
        /// <typeparam name="A">The attribute type</typeparam>
        public static FieldInfo[] Tagged<A>(this FieldInfo[] src)
            where A : Attribute
                => src.Where(x => x.Tagged<A>());
    }
}