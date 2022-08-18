//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    partial struct Tables
    {
        public static string name(FieldInfo src)
            => src.Tag<FieldAttribute>().MapValueOrDefault(a => text.ifempty(a.FieldName, src.Name), src.Name);
    }
}