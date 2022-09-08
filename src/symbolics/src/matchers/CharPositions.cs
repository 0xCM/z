//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class StringMatcher
    {
        public class CharPositions : ConstLookup<CharIndex,List<uint>>
        {
            public static CharPositions compute(ReadOnlySpan<string> src)
            {
                var dst = dict<CharIndex,List<uint>>();
                var count = src.Length;
                for(var i=0u; i<count; i++)
                    compute(i,skip(src,i),dst);

                return new CharPositions(dst);
            }

            static void compute(uint target, ReadOnlySpan<char> src, Dictionary<CharIndex,List<uint>> dst)
            {
                var count = src.Length;
                for(var i=z16; i<count; i++)
                {
                    ref readonly var c = ref skip(src,i);
                    var index = new CharIndex(c,i);
                    if(dst.TryGetValue(index, out var positions))
                    {
                        positions.Add(target);
                    }
                    else
                    {
                        dst[index] = new();
                        dst[index].Add(target);
                    }
                }
            }

            public ReadOnlySpan<uint> Targets(char c, ushort index)
            {
                if(Find((c,index), out var targets))
                {
                    return targets.ViewDeposited();
                }
                else
                {
                    return default;
                }
            }

            internal CharPositions(Dictionary<CharIndex,List<uint>> src)
                : base(src)
            {


            }
        }
    }
}