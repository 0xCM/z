//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct grids
{
    [MethodImpl(Inline), Op]
    public static uint lineraize(GridDim dim, CellIndex point)
        => point.Row*dim.N+ point.Col;
}
