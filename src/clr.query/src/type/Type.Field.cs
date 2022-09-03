//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using System;
    using System.Linq;
    using System.Reflection;

    using static ReflectionFlags;

    partial class ClrQuery
    {
        /// <summary>
        /// Attempts to retrieve a name-identified field from a type
        /// </summary>
        /// <param name="src">The type to examine</param>
        /// <param name="name">The name of the field</param>
        /// <param name="declared">Whether the field is required to be declared by the source type</param>
        [Op]
        public static FieldInfo Field(this Type src, string name)
            => src.GetFields(BF_All).FirstOrDefault(f => f.Name == name);
    }
}