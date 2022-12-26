//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static CsvFormatter;

    [ApiHost]
    public readonly partial struct Tables
    {
        const NumericKind Closure = UInt64k;

        internal const string DefaultDelimiter = " | ";

        internal const byte DefaultFieldWidth = 24;

        public static void generate(uint margin, CsvTableDef spec, ITextEmitter dst)
        {
            dst.IndentLine(margin, "[Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]");
            dst.IndentLineFormat(margin, "public struct {0}", spec.TypeName);
            dst.IndentLine(margin, Chars.LBrace);
            dst.IndentLineFormat(margin,"public const string TableId = \"{0}\";", spec.TableName);
            margin += 4;

            ref readonly var fields = ref spec.Columns;
            for(var i=0; i<fields.Count; i++)
            {
                dst.AppendLine();
                ref readonly var field = ref fields[i];
                dst.IndentLineFormat(margin,"public {0} {1};", field.DataType, field.Name);
            }

            margin -= 4;
            dst.IndentLine(margin, Chars.RBrace);
        }
        
        public static void emit<T>(ReadOnlySpan<T> rows, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci,
            ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
                where T : struct
        {
            var formatter = CsvTables.formatter(typeof(T), rowpad, fk);
            using var writer = dst.Writer(encoding);
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<rows.Length; i++)
                writer.WriteLine(formatter.Format(skip(rows,i)));
        }

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, StreamWriter dst)
            where T : struct
                => emit(src, Tables.rowspec<T>(24), dst);

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, RowFormatSpec spec, StreamWriter dst)
            where T : struct
        {
            var formatter = Tables.formatter<T>(spec);
            var count = src.Length;
            dst.WriteLine(formatter.FormatHeader());
            for(var i=0; i<count; i++)
            dst.WriteLine(formatter.Format(skip(src,i)));
            return count;
        }

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, RowFormatSpec spec, Encoding encoding, FilePath dst)
            where T : struct
        {
            using var writer = dst.Writer(encoding);
            return emit(src, spec, writer);
        }

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, RowFormatSpec spec, TextEncodingKind encoding, FilePath dst)
            where T : struct
                => emit(src, spec, encoding.ToSystemEncoding(), dst);

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, RowFormatSpec spec, FilePath dst)
            where T : struct
                => emit(src, spec, TextEncodingKind.Utf8, dst);

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, Encoding encoding, FilePath dst)
            where T : struct
        {
            using var writer = dst.Writer(encoding);
            return emit(src, writer);
        }

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, FilePath dst)
            where T : struct
                => emit(src, Encoding.UTF8, dst);

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, FilePath dst)
            where T : struct
                => emit(src, widths, z16, Encoding.UTF8, dst);

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, ushort rowpad, Encoding encoding, FilePath dst)
            where T : struct
                => emit(src, rowspec<T>(widths, rowpad), dst);

        public static Count emit<T>(ReadOnlySpan<T> src, ITextEmitter dst)
            where T : struct
        {
            var count = src.Length;
            var f = formatter<T>();
            dst.AppendLine(f.FormatHeader());
            for(var i=0; i<count; i++)
                dst.AppendLine(f.Format(skip(src,i)));
            return count;
        }        

        [Op]
        public static Outcome parse(TextLine src, char delimiter, byte fields, out RowHeader dst)
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

        [Op, Closures(Closure)]
        public static uint cells<T>(in RowFormatSpec rowspec, in DynamicRow<T> row, Span<string> dst)
            where T : struct
        {
            var count = (uint)min(rowspec.CellCount, row.CellCount);
            for(var i=0; i<count; i++)
            {
                ref readonly var value = ref row[i];
                ref readonly var spec = ref rowspec[i];
                var cellpad = spec.Width.Pattern();
                seek(dst, i) = string.Format(cellpad, spec.Pattern.Format(value));
            }

            return count;
        }

        public static Outcome cells(TextLine src, char delimiter, byte fields, out ReadOnlySpan<string> dst)
        {
            var cells = src.Split(Chars.Pipe, true);
            dst = default;
            if(cells.Length != fields)
            {
                return (false, Tables.FieldCountMismatch.Format(fields, cells.Length));
            }
            else
            {
                dst = cells;
                return true;
            }
        }        

        // public static ICsvFormatter<T> create<T>(ushort rowpad, RecordFormatKind fk, string delimiter = DefaultDelimiter)
        //     where T : struct
        // {
        //     var record = typeof(T);
        //     var fields = Tables.cells(record).Index();
        //     var count = fields.Length;
        //     var buffer = alloc<HeaderCell>(count);
        //     for(var i=0u; i<count; i++)
        //         seek(buffer, i) = new HeaderCell(i, fields[i].CellName, fields[i].CellWidth);
        //     var header = new RowHeader(buffer, DefaultDelimiter);
        //     var spec = rowspec(header, header.Cells.Select(x => x.CellFormat), rowpad, fk);
        //     return new Formatter2<T>(spec, api.adapter(record));
        // }

        // public static CsvFormatter create(Type record, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular, string delimiter = DefaultDelimiter)
        // {
        //     var fields = Tables.cells(record).Index();
        //     var count = fields.Length;
        //     var buffer = alloc<HeaderCell>(count);
        //     for(var i=0u; i<count; i++)
        //         seek(buffer, i) = new HeaderCell(i, fields[i].CellName, fields[i].CellWidth);
        //     var header = new RowHeader(buffer, delimiter);
        //     var spec = rowspec(header, header.Cells.Select(x => x.CellFormat), rowpad, fk);
        //     return new CsvFormatter(record, spec, api.adapter(record));
        // }

        internal static RowAdapter adapter(Type src)
            => new RowAdapter(src, Tables.cells(src));

        [MethodImpl(Inline)]
        internal static ref RowAdapter adapt<T>(in T src, ref RowAdapter adapter)
            where T : struct
        {
            adapter.Source = src;
            adapter.Index++;
            load(adapter.Source, ref adapter.Row);
            return ref adapter;
        }

        internal static void load<T>(T src, ref DynamicRow dst)
            where T : struct
        {
            var tr = __makeref(edit(src));
            for(var i=0u; i<dst.FieldCount; i++)
                dst[i] = dst.Cells[i].Definition.GetValueDirect(tr);
        }

        internal static string format(in RowFormatSpec spec, RenderBuffers buffers, in DynamicRow src)
        {
            var content = src.Format(spec.Pattern, buffers);
            var pad = spec.RowPad;
            if(pad == 0)
                return content;
            else
                return content.PadRight(pad);
        }
    }
}