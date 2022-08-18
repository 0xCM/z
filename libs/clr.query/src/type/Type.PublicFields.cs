//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    using static ReflectionFlags;

    partial class ClrQuery
    {
        /// <summary>
        /// Selects all public static/instance fields from the source
        /// </summary>
        /// <param name="src">The source type</param>
        public static FieldInfo[] PublicFields(this Type src)
            => src.GetFields(BF_PublicStatic | BF_PublicInstance);
    }
}