//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;

    using static ReflectionFlags;

    partial class ClrQuery
    {
        /// <summary>
        /// Retrieves the type's properties together with applied attributes
        /// </summary>
        /// <typeparam name="A">The attribute type</typeparam>
        /// <param name="t">The type to examine</param>
        public static IReadOnlyDictionary<PropertyInfo,A> PropertyAttributions<A>(this Type t)
            where A : Attribute
        {
            var q = from p in t.GetProperties(BF_Instance)
                    where Attribute.IsDefined(p, typeof(A))
                    let attrib = p.GetCustomAttribute<A>()
                    select new
                    {
                        Member = p,
                        Attribute = attrib
                    };
            return q.ToDictionary(x => x.Member, x => x.Attribute);
        }
    }
}