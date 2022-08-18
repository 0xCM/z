//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct TableRow
    {
        public uint Seq;

        readonly TableCell[] _Cells;

        [MethodImpl(Inline)]
        public TableRow(uint index, TableCell[] cells)
        {
            Seq = index;
            _Cells = cells ?? new TableCell[]{};
        }

        public Span<TableCell> Cells
        {
            [MethodImpl(Inline)]
            get => _Cells ?? Span<TableCell>.Empty;
        }


        public static TableRow Empty
            => new TableRow(0, new TableCell[0]{});
    }
}