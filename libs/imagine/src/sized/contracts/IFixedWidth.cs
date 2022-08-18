//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IFixedWidth<F> : ICellWidth, WType<F>
        where F : struct, IFixedWidth<F>
    {
        CpuCellWidth ICellWidth.CellWidth
            => Widths.cell<F>();
    }
}