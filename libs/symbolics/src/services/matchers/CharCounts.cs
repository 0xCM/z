//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class StringMatcher
    {
        public class CharCounts : ConstLookup<char,CharCount>
        {
            public static CharCounts calc(ReadOnlySpan<string> src)
            {
                var count = src.Length;
                var dst = dict<char,uint>();
                for(var i=0; i<count; i++)
                    compute(skip(src,i),dst);
                return new CharCounts(map(dst, e => (e.Key,new CharCount(e.Key, e.Value))).ToDictionary());
            }

            static void compute(ReadOnlySpan<char> src, Dictionary<char,uint> dst)
            {
                var count = src.Length;
                for(var i=0; i<count; i++)
                {
                    ref readonly var c = ref skip(src,i);
                    if(dst.ContainsKey(c))
                        dst[c] = dst[c] + 1;
                    else
                        dst[c] = 1;
                }
            }

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