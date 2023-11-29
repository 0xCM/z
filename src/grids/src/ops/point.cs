//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct grids
{
    /// <summary>
    /// Defines a <see cref='CellIndex'/> identifier
    /// </summary>
    /// <param name="row">The 0-based row index</param>
    /// <param name="col">The 0-based col index</param>
    [MethodImpl(Inline), Op]
    public static CellIndex point(uint row, uint col)
        => new (row,col);

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static CellIndex<T> point<T>(T row, T col)
        where T : unmanaged
            => new (row, col);
}
