//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct BitPatterns
{
    public static ReadOnlySeq<string> symbols(BitPattern src)
        => text.split(src.Data, Chars.Space).Reverse();
}
