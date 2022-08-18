//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [SymSource(api_kinds), Flags]
    public enum SpanBlockKind : ushort
    {
        None,

        Sb8 = CpuCellWidth.W8,

        Sb16 = CpuCellWidth.W8 | CpuCellWidth.W16,

        Sb32 = CpuCellWidth.W8 | CpuCellWidth.W16 | CpuCellWidth.W32,

        Sb64 = CpuCellWidth.Numeric,

        Sb128 = CpuCellWidth.W128 | CpuCellWidth.Numeric,

        Sb256 = CpuCellWidth.W256 | CpuCellWidth.W128 | CpuCellWidth.Numeric,

        Sb512 = CpuCellWidth.W512 | CpuCellWidth.W256 | CpuCellWidth.W128 | CpuCellWidth.Numeric,
    }
}