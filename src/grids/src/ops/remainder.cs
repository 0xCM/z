//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct grids
{
    [MethodImpl(Inline), Op]
    public static uint remainder(in GridMetrics src, W128 w)
        => src.StoreSize % 16;

    [MethodImpl(Inline), Op]
    public static uint remainder(in GridMetrics src, W256 w)
        => src.StoreSize % 32;
}
