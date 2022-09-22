//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct DigitParsers
    {
        abstract class SpanValueParser<B,V> :  BasedParser<B>, ISpanValueParser<char,V>
            where B : unmanaged, INumericBase
            where V : unmanaged
        {
            public abstract bool Parse(ReadOnlySpan<char> src, out V dst);
        }

        abstract class Base16ValueParser<V> : SpanValueParser<Base16,V>
            where V : unmanaged
        {

        }

        sealed class Base16U32Parser : Base16ValueParser<uint>
        {
            public override bool Parse(ReadOnlySpan<char> src, out uint dst)
            {
                const byte MaxDigitCount = 8;
                var storage = 0ul;
                var output = recover<uint4>(bytes(storage));
                dst = 0;
                var count = min(src.Length, MaxDigitCount);
                var j=0;
                var outcome = true;
                for(var i=count-1; i>=0; i--)
                {
                    if(Digital.digit(Base, skip(src,i), out var d))
                        seek(output, j++) = d;
                    else
                        return false;
                }

                for(var k=0; k<j; k++)
                    dst |= ((uint)skip(output, k) << k*4);
                return true;
            }
        }
    }
}