//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Bitfields
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T extract<T>(T src, byte offset, byte width)
            where T : unmanaged
                => generic<T>(bits.extract(@bw64(src), offset, math.add(offset, width)));
    }
}