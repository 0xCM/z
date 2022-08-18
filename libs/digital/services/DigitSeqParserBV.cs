//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public abstract class DigitSeqParser<B,V> : BasedParser<B>, ISpanSeqParser<char,V>
        where B : unmanaged, INumericBase
        where V : unmanaged
    {
        public abstract uint Parse(ReadOnlySpan<char> src, Span<V> dst);
    }

    partial struct DigitParsers
    {
        sealed class Base10SeqParser : DigitSeqParser<Base10, DecimalDigitValue>
        {
            public override uint Parse(ReadOnlySpan<char> src, Span<DecimalDigitValue> dst)
            {
                var offset = 0u;
                var i=offset;
                var j=0u;
                var imax = src.Length - 1;
                while(i <= imax)
                {
                    ref readonly var c = ref skip(src, i++);
                    if(SQ.space(c) && j==0)
                        continue;

                    if(Digital.test(Base, c))
                        seek(dst, j++) = (DecimalDigitValue)(AsciCode.d9 - (AsciCode)c);
                    else
                        break;
                }
                return j;
            }
        }
    }
}