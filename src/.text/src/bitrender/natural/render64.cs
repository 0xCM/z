//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static bit;

    using C = AsciCode;

    partial struct BitRender
    {
        [MethodImpl(Inline), Op]
        public static uint render(N64 n, ulong src, ref uint i, Span<char> dst)
            => render64(src, ref i,dst);

        [MethodImpl(Inline), Op]
        public static uint render(N64 n, ulong src, ref uint i, Span<C> dst)
        {
            var i0 = i;
            render(n32, (uint)(src >> 32), ref i, dst);
            render(n32, (uint)src, ref i, dst);
            return i - i0;
        }
    }
}