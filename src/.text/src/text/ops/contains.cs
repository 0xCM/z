//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class text
    {
        [MethodImpl(Inline), Op]
        public static bool contains(string src, string match, bool @case = true)
            => src.Contains(match, @case ? Cased : NoCase);

        [MethodImpl(Inline), Op]
        public static bool contains(string src, char match, bool @case = true)
            => src.Contains(match, @case ? Cased : NoCase);

        [MethodImpl(Inline), Op]
        public static bool contains(ReadOnlySpan<char> src, ReadOnlySpan<char> match, bool @case = true)
            => src.Contains(match, @case ? Cased : NoCase);
    }
}