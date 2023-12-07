//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public abstract class DigitSeqParser<B,V> : BasedParser<B>, ISpanSeqParser<char,V>
    where B : unmanaged, INumericBase
    where V : unmanaged
{
    public abstract uint Parse(ReadOnlySpan<char> src, Span<V> dst);
}
