//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Tables
    {
        /// <summary>
        /// Creates a <see cref='ICsvFormatter{T}'> instance for a specified record type
        /// </summary>
        /// <typeparam name="T">The record type</typeparam>
        public static ICsvFormatter<T> formatter<T>(ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular, string delimiter = DefaultDelimiter)
            => CsvTables.formatter<T>(rowpad, fk, delimiter);

        /// <summary>
        /// Creates a <see cref='ICsvFormatter'> instance for a specified record type
        /// </summary>
        /// <param name="record">The record type</param>
        /// <param name="delimiter">The field delimiter</param>
        public static ICsvFormatter formatter(Type record, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular, string delimiter = DefaultDelimiter)
            => CsvTables.formatter(record, rowpad, fk, delimiter);

        /// <summary>
        /// Defines a <typeparamref name='T'/> record formatter
        /// </summary>
        /// <param name="spec">The format spec</param>
        /// <typeparam name="T">The record type</typeparam>
        public static CsvFormatter<T> formatter<T>(RowFormatSpec spec, RecordFormatKind fk = RecordFormatKind.Tablular)
            => new CsvFormatter<T>(spec, adapter<T>());

        /// <summary>
        /// Defines a <typeparamref name='T'/> record formatter
        /// </summary>
        /// <param name="widths">The column widths</param>
        /// <typeparam name="T">The record type</typeparam>
        public static ICsvFormatter<T> formatter<T>(ReadOnlySpan<byte> widths, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
            => formatter<T>(rowspec<T>(widths, rowpad, fk));

        /// <summary>
        /// Defines a <typeparamref name='T'/> record formatter
        /// </summary>
        /// <param name="widths">The column widths</param>
        /// <typeparam name="T">The record type</typeparam>
        public static ICsvFormatter<T> formatter<T>(byte fieldwidth, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
            => formatter<T>(rowspec<T>(fieldwidth, rowpad, fk));
    }
}