//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class text
    {
        [MethodImpl(Inline)]
        public static bool begins(ReadOnlySpan<char> src, char match)
            => UQ.begins(src, match);

        [MethodImpl(Inline)]
        public static bool begins(ReadOnlySpan<char> src, ReadOnlySpan<char> match)
            => UQ.begins(src, match);
    }
}