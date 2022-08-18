//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static AppErrors;

    public readonly struct CheckLengths : ICheckLengths
    {
        [MethodImpl(Inline)]
        public static int length<T>(ReadOnlySpan<T> lhs, ReadOnlySpan<T> rhs)
            => lhs.Length == rhs.Length ? lhs.Length : ThrowNotEqualNoCaller(lhs.Length, rhs.Length);

        [MethodImpl(Inline)]
        public static int length<T>(T[] lhs, T[] rhs)
            => lhs.Length == rhs.Length ? lhs.Length : ThrowNotEqualNoCaller(lhs.Length, rhs.Length);

        [MethodImpl(Inline)]
        public static int length<T>(Span<T> lhs, Span<T> rhs)
            => lhs.Length == rhs.Length ? lhs.Length : ThrowNotEqualNoCaller(lhs.Length, rhs.Length);
    }
}