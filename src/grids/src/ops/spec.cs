//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct grids
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static GridSpec spec<T>(uint rows, uint cols)
            where T : unmanaged
                => gridspec((ushort)rows, (ushort)cols, (ushort)width<T>());


    }
}