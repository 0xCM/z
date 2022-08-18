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
        [Op]
        public static PropertyInfo[] PublicStaticProperties(this Type src)
            => src.GetProperties(BF_PublicStatic);
    }
}