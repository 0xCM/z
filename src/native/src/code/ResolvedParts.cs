//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ResolvedParts
    {
        public Index<ResolvedPart> Data;

        public ResolvedParts(ResolvedPart[] src)
        {
            Data = src;
        }

        public ReadOnlySpan<ResolvedPart> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }
    }
}