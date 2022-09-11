//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    unsafe partial struct memory
    {
        [MethodImpl(Inline), Op]
        public static unsafe void copy(Ptr src, Ptr dst, Size<uint> size)
        {
            var pDst = dst.Cast<uint>();
            var pSrc = src.Cast<uint>();
            var count = size/4;
            for(var i=0u; i<count; i++, pDst++, pSrc++)
                *(~pDst) = !pSrc;
        }
    }
}