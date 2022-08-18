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
        public static bool ProvidesEvent(this Type src, string name)
            => src.Events().Any(x => x.Name == name);
    }
}