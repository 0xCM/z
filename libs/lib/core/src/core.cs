//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [ApiHost]
    public readonly partial struct core
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline)]
        internal static Span<T> EmptySpan<T>()
            => Span<T>.Empty;
    }
}