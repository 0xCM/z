//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly partial struct core
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline)]
        internal static Span<T> EmptySpan<T>()
            => Span<T>.Empty;
    }
}