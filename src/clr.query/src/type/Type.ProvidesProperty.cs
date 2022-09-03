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
        public static bool ProvidesProperty(this Type src, string name)
            => src.GetProperties(BF_World).Any(x => x.Name == name);
    }
}