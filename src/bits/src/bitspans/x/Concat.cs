//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        [MethodImpl(Inline)]
        public static BitSpan Concat(this BitSpan head, BitSpan tail)
            => BitSpans.concat(head,tail);
    }
}