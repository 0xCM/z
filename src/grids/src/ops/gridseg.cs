//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct grids
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static GridSegment<T> gridseg<T>(GridDim dim, uint segwidth)
            where T : unmanaged
                => new GridSegment<T>(dim, segwidth);
    }
}