//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Tables
    {
        /// <summary>
        /// Creates a row header for parametrically-identified record type
        /// </summary>
        /// <param name="widths">The cell render widths</param>
        /// <typeparam name="T">The record type</typeparam>
        public static RowHeader header<T>(ReadOnlySpan<byte> widths, string delimiter = DefaultDelimiter)
            where T : struct
                => header(typeof(T), widths);

        /// <summary>
        /// Creates a row header for parametrically-identified record type and uniform field width
        /// </summary>
        /// <param name="fieldwidht">The uniform field width</param>
        /// <typeparam name="T">The record type</typeparam>
        public static RowHeader header<T>(byte fieldwidth, string delimiter = DefaultDelimiter)
            where T : struct
                => header(typeof(T), fieldwidth, delimiter);

        /// <summary>
        /// Creates a row header for a specified record type record type and uniform field width
        /// </summary>
        /// <param name="fieldwidht">The uniform field width</param>
        /// <typeparam name="T">The record type</typeparam>
        public static RowHeader header(Type record, byte fieldwidth, string delimiter = DefaultDelimiter)
        {
            var _fields = fields(record).ToReadOnlySpan();
            var count = _fields.Length;
            var buffer = alloc<HeaderCell>(count);
            var cells = span(buffer);
            for(var i=0u; i<count; i++)
                seek(cells, i) = new HeaderCell(i, skip(_fields,i).FieldName, fieldwidth);
            return new RowHeader(buffer, delimiter);
        }

        /// <summary>
        /// Creates a row header for a specified record type
        /// </summary>
        /// <param name="widths">The cell render widths</param>
        public static RowHeader header(Type record, ReadOnlySpan<byte> widths, string delimiter = DefaultDelimiter)
        {
            var _fields = fields(record).ToReadOnlySpan();
            var count = _fields.Length;
            if(count != widths.Length)
                sys.@throw(FieldCountMismatch.Format(count, widths.Length));
            var buffer = alloc<HeaderCell>(count);
            var cells = span(buffer);
            for(var i=0u; i<count; i++)
            {
                ref readonly var field = ref skip(_fields,i);
                seek(cells,i) = new HeaderCell(i, field.FieldName, skip(widths,i));
            }
            return new RowHeader(buffer, delimiter);
        }

        public static MsgPattern<Count,Count> FieldCountMismatch
            => "The target requires {0} fields but {1} were found in the source";
    }
}