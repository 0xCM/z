//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class ClrQuery
    {
        [MethodImpl(Inline)]
        public static string[] ManifestResourceNames(this Assembly src)
            => src.GetManifestResourceNames() ?? Array.Empty<string>();
    }
}