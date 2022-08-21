//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICellWidth : ITypeWidth
    {
        /// <summary>
        /// Defines a class specifier synonym to facilitate disambiguation
        /// </summary>
        CpuCellWidth CellWidth
            => (CpuCellWidth)BitWidth;
   }

    public interface ICellWidth<W> : ICellWidth, ITypeWidth<W>
        where W : unmanaged, ICellWidth<W>
    {

    }
}