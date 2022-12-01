//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class StringMatcher
    {
        public class CharCounts : ConstLookup<char,CharCount>
        {
            internal CharCounts(Dictionary<char,CharCount> src)
                : base(src)
            {

            }

            public ReadOnlySpan<char> Chars
            {
                [MethodImpl(Inline)]
                get => Keys;
            }
        }
    }
}