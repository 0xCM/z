//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class gbits
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bit state<T>(in T src, byte pos)
            where T : unmanaged
                => bit.gtest(src,pos);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T state<T>(ref T src, byte pos, bit value)
            where T : unmanaged
        {
            src = set(src,pos,value);
            return ref src;
        }
    }
}