//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using C = AsciCode;

    partial struct BitRender
    {
        [MethodImpl(Inline), Op]
        public static uint render64(ulong src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            render32((uint)(src >> 32), ref i, dst);
            render32((uint)src, ref i, dst);
            return i - i0;
        }

        [MethodImpl(Inline), Op]
        public static uint render64(ulong src, ref uint i, Span<C> dst, N64 n = default)
            => render(n, src, ref i, dst);
    }
}