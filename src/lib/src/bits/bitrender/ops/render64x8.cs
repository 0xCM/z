//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct BitRender
    {
        [MethodImpl(Inline), Op]
        public static uint render64x8(char sep, ulong src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            render32x8(sep, (uint)(src >> 32), ref i, dst);
            render32x8(sep, (uint)src, ref i, dst);
            return i - i0;
        }

        [MethodImpl(Inline), Op]
        public static uint render64x8(char sep, ulong src, Span<char> dst)
        {
            var i=0u;
            return render64x8(sep, src, ref i, dst);
        }
    }
}