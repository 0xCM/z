//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static bit;

    using C = AsciCode;

    partial struct BitRender
    {
        [MethodImpl(Inline), Op]
        public static uint render(N1 n, byte src, ref uint i, Span<char> dst)
            => render1(src, ref i,dst);

        [MethodImpl(Inline), Op]
        public static uint render(N1 n, byte src, ref uint i, Span<C> dst)
        {
            var i0  = i;
            seek(dst, i++) = code(src, 0);
            return i - i0;
        }
    }
}