//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using C = AsciCode;

    partial struct AsciSymbols
    {
        [Op]
        public static ReadOnlySpan<C> unfence(ReadOnlySpan<C> src, Fence<C> fence)
        {
            (var i0, var i1) = SQ.indices(src, fence);
            if(i0 != NotFound && i1 != NotFound && (i0 < i1))
            {
                var start = i0 + 1;
                var length = i1 - start;
                return sys.slice(src, start, length);
            }
            else
                return ReadOnlySpan<C>.Empty;
        } 
    }
}
