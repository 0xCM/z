//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Asci
    {
        [Op]
        public static ReadOnlySpan<AsciCode> unfence(ReadOnlySpan<AsciCode> src, Fence<AsciCode> fence)
        {
            (var i0, var i1) = SQ.indices(src, fence);
            if(i0 != NotFound && i1 != NotFound && (i0 < i1))
            {
                var start = i0 + 1;
                var length = i1 - start;
                return sys.slice(src, start, length);
            }
            else
                return ReadOnlySpan<AsciCode>.Empty;
        }
    }
}