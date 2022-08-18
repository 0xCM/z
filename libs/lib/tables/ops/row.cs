//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    partial struct Tables
    {
        [MethodImpl(Inline), Op]
        public static TableRow row(uint seq, TableCell[] cells)
            => new TableRow(seq, cells);

        [MethodImpl(Inline), Op]
        public static TableRow row(TableCell[] cells)
            => new TableRow(0, cells);


        [MethodImpl(Inline), Op]
        public static TableRow row(string[] cells)
            => new TableRow(0, cells.Select(cell));

        [MethodImpl(Inline), Op]
        public static TableRow row(object[] cells)
            => new TableRow(0, cells.Select(cell));
    }
}