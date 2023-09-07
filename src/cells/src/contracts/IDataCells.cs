//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a <see cref='IDataCell'/> index
    /// </summary>
    /// <typeparam name="H">The reifying type</typeparam>
    /// <typeparam name="I">The indexer type</typeparam>
    /// <typeparam name="C">The cell type</typeparam>
    [Free]
    public interface IDataCells<H,I,C> : IIndex<H,I,C>
        where H : struct, IDataCells<H,I,C>
        where I : unmanaged
        where C : unmanaged, IDataCell
    {

    }
}