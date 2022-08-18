//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class ClrQuery
    {
        [MethodImpl(Inline), Op]
        public static bool IsSpan(this Type src)
            => src.IsGenericType && src.GetGenericTypeDefinition() == typeof(Span<>);

        [MethodImpl(Inline), Op]
        public static bool IsReadOnlySpan(this Type src)
            => src.IsGenericType && src.GetGenericTypeDefinition() == typeof(ReadOnlySpan<>);
    }
}