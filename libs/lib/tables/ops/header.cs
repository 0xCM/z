//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Tables
    {
        [Op]
        public static Outcome header(TextLine src, char delimiter, byte fields, out RowHeader dst)
        {
            dst = RowHeader.Empty;
            if(src.IsEmpty)
            {
                return (false,"The source text is empty");
            }
            else
            {
                try
                {
                    var parts = src.Split(delimiter, false);
                    var count = parts.Length;
                    if(count != fields)
                        return (false, Tables.FieldCountMismatch.Format(fields, dst.Length));

                    var cells = alloc<HeaderCell>(count);
                    ref var cell = ref first(cells);
                    for(var i=0u; i<count; i++)
                    {
                        ref readonly var content = ref skip(parts,i);
                        var length = (ushort)content.Length;
                        var name = text.trim(content);
                        seek(cell,i) = new HeaderCell(i, name, length);
                    }
                    dst = new RowHeader(cells, delimiter);
                    return true;
                }
                catch(Exception e)
                {
                    dst = RowHeader.Empty;
                    return e;
                }
            }
        }

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