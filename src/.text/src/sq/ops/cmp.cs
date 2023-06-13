//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    partial struct SymbolicQuery
    {
        [MethodImpl(Inline), Op]
        public static int cmp(ReadOnlySpan<char> a, ReadOnlySpan<char> b)
            => a.CompareTo(b, StringComparison.InvariantCulture);

        [MethodImpl(Inline), Op]
        public static int cmp(Span<char> a, ReadOnlySpan<char> b)
            => cmp(a.ReadOnly(), b);

        [MethodImpl(Inline), Op]
        public static int cmp(ReadOnlySpan<char> a, Span<char> b)
            => cmp(a, b.ReadOnly());

        [MethodImpl(Inline), Op]
        public static int cmp(Span<char> a, Span<char> b)
            => cmp(a.ReadOnly(), b.ReadOnly());
        
    }
}