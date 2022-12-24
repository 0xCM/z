//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public class CsvTables
    {        
        const NumericKind Closure = UInt64k;

        internal const string DefaultDelimiter = " | ";

        /// <summary>
        /// Defines a <typeparamref name='T'/> record formatter
        /// </summary>
        /// <param name="widths">The column widths</param>
        /// <typeparam name="T">The record type</typeparam>
        public static ICsvFormatter<T> formatter<T>(byte fieldwidth, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
            where T : struct
                => CsvTables.formatter<T>(rowspec<T>(fieldwidth, rowpad, fk));

        /// <summary>
        /// Defines a <typeparamref name='T'/> record formatter
        /// </summary>
        /// <param name="widths">The column widths</param>
        /// <typeparam name="T">The record type</typeparam>
        public static ICsvFormatter<T> formatter<T>(ReadOnlySpan<byte> widths, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
            where T : struct
                => formatter<T>(rowspec<T>(widths, rowpad, fk));

        // /// <summary>
        // /// Creates a <see cref='ICsvFormatter{T}'> instance for a specified record type
        // /// </summary>
        // /// <typeparam name="T">The record type</typeparam>
        // public static ICsvFormatter<T> formatter<T>(ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular, string delimiter = DefaultDelimiter)
        //     where T : struct
        // {
        //     var record = typeof(T);
        //     var fields = TableDefs.cells(record).Index();
        //     var count = fields.Length;
        //     var buffer = sys.alloc<HeaderCell>(count);
        //     for(var i=0u; i<count; i++)
        //         sys.seek(buffer, i) = new HeaderCell(i, fields[i].CellName, fields[i].CellWidth);
        //     var header = new RowHeader(buffer, DefaultDelimiter);
        //     var spec = CsvTables.rowspec(header, header.Cells.Select(x => x.CellFormat), rowpad, fk);
        //     return new CsvFormatter.Formatter2<T>(spec, Tables.adapt(record));
        // }

        // /// <summary>
        // /// Creates a <see cref='ICsvFormatter'> instance for a specified record type
        // /// </summary>
        // /// <param name="record">The record type</param>
        // /// <param name="delimiter">The field delimiter</param>
        // public static ICsvFormatter formatter(Type record, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular, string delimiter = DefaultDelimiter)
        // {
        //     var fields = TableDefs.cells(record).Index();
        //     var count = fields.Length;
        //     var buffer = sys.alloc<HeaderCell>(count);
        //     for(var i=0u; i<count; i++)
        //         sys.seek(buffer, i) = new HeaderCell(i, fields[i].CellName, fields[i].CellWidth);
        //     var header = new RowHeader(buffer, delimiter);
        //     var spec = CsvTables.rowspec(header, header.Cells.Select(x => x.CellFormat), rowpad, fk);
        //     return new CsvFormatter(record, spec, Tables.adapt(record));
        // }

        public static ICsvFormatter<T> formatter<T>(RowFormatSpec spec, RecordFormatKind fk = RecordFormatKind.Tablular)
            where T : struct
                => new CsvFormatter<T>(spec, TableDefs.adapter<T>());

        public static string format(in RowFormatSpec spec, RenderBuffers buffers, in DynamicRow src)
        {
            var content = src.Format(spec.Pattern, buffers);
            var pad = spec.RowPad;
            if(pad == 0)
                return content;
            else
                return content.PadRight(pad);
        }


        public static CsvTableReader<T> reader<T>(FilePath src, RowParser<T> parser, bool header = true)
            where T : struct
                => new CsvTableReader<T>(src, parser, header);

        [Op, Closures(Closure)]
        public static string pairs<T>(in RowFormatSpec spec, in RowAdapter<T> src)
        {
            var dst = text.buffer();
            pairs(spec, src, dst);
            return dst.Emit();
        }

        /// <summary>
        /// Negates the source value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Negate]
        static short negate(short src)
            => (short)(-src);

        public static string KvpPattern(in RowFormatSpec spec)
        {
            var slot0 = RP.slot(0, negate((short)spec.MaxCellWidth));
            var slot1 = RP.slot(1);
            return slot0 + Chars.Space + spec.Delimiter + Chars.Space + slot1;
        }

        [Op, Closures(Closure)]
        public static void pairs<T>(in RowFormatSpec spec, in RowAdapter<T> src, ITextBuffer dst)
        {
            var pattern = KvpPattern(spec);
            var fields = src.Fields.View;
            for(var i=0; i<src.CellCount; i++)
                dst.AppendLineFormat(pattern, skip(fields,i).MemberName, src[i]);
            dst.AppendLine();
        }

        /// <summary>
        /// Formats a <see cref='RowHeader'/>
        /// </summary>
        /// <param name="src">The source header</param>
        public static string format(RowHeader src)
        {
            var dst = text.buffer();
            for(var i=0; i<src.Count; i++)
            {
                if(i != 0)
                    dst.Append(src.Delimiter);

                dst.Append(src[i].Format());
            }
            return dst.ToString();
        }

        public static ReadOnlySpan<uint> cuts(ReadOnlySpan<byte> widths)
        {
            var count = (uint)widths.Length;
            var dst = span<uint>(count - 1);
            cuts(widths,dst);
            return dst;
        }

        public static ReadOnlySpan<Pair<uint>> segments(ReadOnlySpan<byte> widths)
        {
            const uint SepWidth = 3u;
            var count = (uint)widths.Length;
            var dst = span<Pair<uint>>(count);
            var offset = z32;
            for(var i=0u; i<count; i++)
            {
                ref readonly var width = ref skip(widths,i);
                var cut = sys.add(offset, width + 1u);
                seek(dst,i) = (offset, cut - 1u);
                offset += (width + SepWidth);
            }
            return dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void cuts(ReadOnlySpan<byte> widths, Span<uint> dst)
        {
            const uint SepWidth = 3u;
            var count = (uint)widths.Length;
            var offset = z32;
            for(var i=0u; i<count - 1; i++)
            {
                ref readonly var width = ref skip(widths,i);
                var cut = sys.add(offset, width + 1u);
                seek(dst,i) = cut;
                offset += (width + SepWidth);
            }
        }

        [Op]
        static string slot(byte index, RenderWidth width, string delimiter = DefaultDelimiter)
            => delimiter + RP.slot(index, (short)(-(short)width));

        [Op]
        public static string pattern(Index<CellFormatSpec> cells, string delimiter = DefaultDelimiter)
        {
            var count = cells.Count;
            var view = cells.View;
            var parts = alloc<string>(count);
            for(var i=0u; i<count; i++)
            {
                var cell = skip(view,i);
                seek(parts,i) = slot((byte)i, cell.Width, i!=0 ? delimiter : EmptyString);
            }
            return string.Concat(parts);
        }

        [MethodImpl(Inline), Op]
        public static RowFormatSpec rowspec(RowHeader header, CellFormatSpec[] cells, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
            => new RowFormatSpec(header, cells, pattern(cells, header.Delimiter), rowpad, Chars.Pipe, fk);

        [Op, Closures(Closure)]
        public static RowFormatSpec rowspec<T>(ReadOnlySpan<byte> widths, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
            where T : struct
        {
            var header = TableDefs.header<T>(widths);
            return rowspec(header, header.Cells.Select(x => x.CellFormat), rowpad, fk);
        }

        [Op, Closures(Closure)]
        public static RowFormatSpec rowspec<T>(byte width, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
            where T : struct
        {
            var header = TableDefs.header<T>(width);
            return rowspec(header, header.Cells.Select(x => x.CellFormat), rowpad, fk);
        }        

        [MethodImpl(Inline), Op]
        public static TableCell cell(object content)
            => new TableCell(content);

        [MethodImpl(Inline), Op]
        public static TableColumn column(string name, string type, ushort length)
            => new TableColumn(name, type, length);

        public static TableColumn column<K>(string name)
            where K : unmanaged, Enum
        {
            var kinds = Symbols.index<K>();
            var result = kinds.Lookup(name.Trim(), out var sym);
            var type = result ? sym.Expr.Format() : string.Format("!{0}!", name);
            var length = name.Length;
            return column(name.Trim(), type, (ushort)length);
        }

        public static Seq<TableColumn> columns<K>(ReadOnlySpan<string> src)
            where K : unmanaged, Enum
        {
            var count = src.Length;
            var buffer = alloc<TableColumn>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var x = ref skip(src,i);
                seek(dst,i) = column<K>(skip(src,i));
            }
            return buffer;
        }
    }
}