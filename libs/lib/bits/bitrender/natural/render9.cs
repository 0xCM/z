//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static bit;

    using C = AsciCode;

    partial struct BitRender
    {
        [MethodImpl(Inline), Op]
        public static uint render(N9 n, ushort src, ref uint i, Span<C> dst)
            => render9(src, ref i,dst);

        [MethodImpl(Inline), Op]
        public static uint render(N9 n, ushort src, ref uint i, Span<char> dst)
            => render9(src, ref i,dst);
    }
}