//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Tables
    {
        [MethodImpl(Inline), Op]
        public static RowFormatSpec rowspec(RowHeader header, CellFormatSpec[] cells, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
            => new RowFormatSpec(header, cells, pattern(cells, header.Delimiter), rowpad, Chars.Pipe, fk);

        [Op, Closures(Closure)]
        public static RowFormatSpec rowspec<T>(ReadOnlySpan<byte> widths, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
            where T : struct
        {
            var header = Tables.header<T>(widths);
            return rowspec(header, header.Cells.Select(x => x.CellFormat), rowpad, fk);
        }

        [Op, Closures(Closure)]
        public static RowFormatSpec rowspec<T>(byte width, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
        {
            var header = Tables.header<T>(width);
            return rowspec(header, header.Cells.Select(x => x.CellFormat), rowpad, fk);
        }
    }
}