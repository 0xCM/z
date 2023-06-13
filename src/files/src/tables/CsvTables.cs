//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static CsvFormatter;

    [ApiHost]
    public class CsvTables
    {        
        const NumericKind Closure = UInt64k;

        internal static RowAdapter adapter(Type src)
            => new RowAdapter(src, CsvTables.cells(src));

        internal static string format(in RowFormatSpec spec, RenderBuffers buffers, in DynamicRow src)
        {
            var content = src.Format(spec.Pattern, buffers);
            var pad = spec.RowPad;
            if(pad == 0)
                return content;
            else
                return content.PadRight(pad);
        }

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

        [Op, Closures(Closure)]
        public static uint cells<T>(in RowFormatSpec rowspec, in DynamicRow<T> row, Span<string> dst)
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

        [MethodImpl(Inline), Op]
        public static CsvTableDef def(TableId name, Identifier type, params ColumDef[] cols)
            => new CsvTableDef(name, type, cols);

        [Op]
        public static CsvTableDef def(Type src)
        {
            var fields = src.PublicInstanceFields();
            var count = fields.Length;
            if(count == 0)
                return new CsvTableDef(TableId.identify(src), src.Name, sys.empty<ColumDef>());
            var specs = alloc<ColumDef>(count);
            for(var i=z16; i<count; i++)
            {
                var field = skip(fields,i);
                seek(specs,i) = new ColumDef(i, ClrTableCol.name(field), field.FieldType.CodeName());
            }

            return new CsvTableDef(TableId.identify(src), src.Name, specs);
        }

        [Op]
        public static Index<CsvTableDef> defs(ReadOnlySpan<Type> src)
        {
            var count = src.Length;
            var dst = alloc<CsvTableDef>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = def(skip(src,i));
            return dst;
        }

        [Op]
        public static Index<CsvTableDef> defs(params Assembly[] src)
            => defs(src.Types().Concrete().Tagged<RecordAttribute>());

        public static CsvTableDef def<T>()
            where T : struct
                => def(typeof(T));        


        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref RowAdapter<T> adapt<T>(in T src, ref RowAdapter<T> adapter)
        {
            adapter.Source = src;
            adapter.Index++;
            load(adapter.Source, ref adapter.Row);
            return ref adapter;
        }


        [Op, Closures(Closure)]
        public static void load<T>(in T src, ref DynamicRow<T> dst)
        {
            var tr = __makeref(edit(src));
            for(var i=0u; i<dst.FieldCount; i++)
                dst[i] = dst.Fields[i].Definition.GetValueDirect(tr);
        }

        /// <summary>
        /// Adapts a <see cref='ClrTableCols'/> sequence to a <typeparamref name='T'/> parametric row
        /// </summary>
        /// <param name="fields">The record fields</param>
        /// <typeparam name="T">The record type</typeparam>
        [Op, Closures(Closure)]
        public static RowAdapter<T> adapter<T>(in ClrTableCols fields)
            => new RowAdapter<T>(fields);

        /// <summary>
        /// Creates a <see cref='RowAdapter{T}'/> predicated a specified <typeparamref name='T'/>
        /// </summary>
        /// <typeparam name="T">The row type</typeparam>
        [Op, Closures(Closure)]
        public static RowAdapter<T> adapter<T>()
            => adapter<T>(CsvTables.cells<T>());

        public static ReadOnlySeq<Type> types(params Assembly[] src)
            => src.Types().Tagged<RecordAttribute>();

        public static FileName filename(TableId id)
            => filename(id, FS.Csv);

        public static FileName filename(TableId id, FileExt ext)
            => FS.file(id.Format(), ext);

        public static FileName filename<T>()
            => filename<T>(FS.Csv);

        public static FileName filename<T>(FileExt ext)
            => filename(Tables.identify<T>());

        public static FileName filename<T>(string prefix)
            => FS.file(string.Format("{0}.{1}", prefix, Tables.identify<T>()), FS.Csv);        

        public static FileName filename<T>(string prefix, string suffix)
            => FS.file(string.Format("{0}.{1}.{2}", prefix, Tables.identify<T>(), suffix), FS.Csv);        

        internal const string DefaultDelimiter = " | ";

        public static ExecToken emit<T>(IWfChannel channel, ReadOnlySpan<T> rows, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci,
            ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
        {
            var emitting = channel.EmittingTable<T>(dst);
            var formatter = CsvTables.formatter(typeof(T), rowpad, fk);
            using var writer = dst.Writer(encoding);
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<rows.Length; i++)
                writer.WriteLine(formatter.Format(skip(rows,i)));
             return channel.EmittedTable(emitting, rows.Length, dst);
        }

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, StreamWriter dst)
            => emit(src,Tables.rowspec<T>(24), dst);

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, RowFormatSpec spec, StreamWriter dst)
        {
            var formatter = CsvTables.formatter<T>(spec);
            var count = src.Length;
            dst.WriteLine(formatter.FormatHeader());
            for(var i=0; i<count; i++)
            dst.WriteLine(formatter.Format(skip(src,i)));
            return count;
        }

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, RowFormatSpec spec, Encoding encoding, FilePath dst)
        {
            using var writer = dst.Writer(encoding);
            return emit(src, spec, writer);
        }

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, RowFormatSpec spec, TextEncodingKind encoding, FilePath dst)
            => emit(src, spec, encoding.ToSystemEncoding(), dst);

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, RowFormatSpec spec, FilePath dst)
            => emit(src, spec, TextEncodingKind.Utf8, dst);

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, Encoding encoding, FilePath dst)
        {
            using var writer = dst.Writer(encoding);
            return emit(src, writer);
        }

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, FilePath dst)
            => emit(src, Encoding.UTF8, dst);

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, FilePath dst)
            => emit(src, widths, z16, Encoding.UTF8, dst);

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, ushort rowpad, Encoding encoding, FilePath dst)
            => emit(src, Tables.rowspec<T>(widths, rowpad), dst);

        public static Count emit<T>(ReadOnlySpan<T> src, ITextEmitter dst)
        {
            var count = src.Length;
            var f = CsvTables.formatter<T>();
            dst.AppendLine(f.FormatHeader());
            for(var i=0; i<count; i++)
                dst.AppendLine(f.Format(skip(src,i)));
            return count;
        }        

        public static ICsvFormatter<T> formatter<T>(ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular, string delimiter = DefaultDelimiter)
        {
            var record = typeof(T);
            var fields = cells(record).Index();
            var count = fields.Length;
            var buffer = alloc<HeaderCell>(count);
            for(var i=0u; i<count; i++)
                seek(buffer, i) = new HeaderCell(i, fields[i].CellName, fields[i].CellWidth);
            var header = new RowHeader(buffer, DefaultDelimiter);
            var spec = rowspec(header, header.Cells.Select(x => x.CellFormat), rowpad, fk);
            return new CsvFormatter.Formatter2<T>(spec, CsvTables.adapter(record));
        }

        public static CsvFormatter formatter(Type record, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular, string delimiter = DefaultDelimiter)
        {
            var fields = cells(record).Index();
            var count = fields.Length;
            var buffer = alloc<HeaderCell>(count);
            for(var i=0u; i<count; i++)
                seek(buffer, i) = new HeaderCell(i, fields[i].CellName, fields[i].CellWidth);
            var header = new RowHeader(buffer, delimiter);
            var spec = rowspec(header, header.Cells.Select(x => x.CellFormat), rowpad, fk);
            return new CsvFormatter(record, spec, CsvTables.adapter(record));
        }

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
            => CsvTables.formatter<T>(Tables.rowspec<T>(fieldwidth, rowpad, fk));

        public static ICsvFormatter<T> formatter<T>(RowFormatSpec spec)
            => new CsvFormatter<T>(spec, Tables.adapter<T>());

        public static CsvTableReader<T> reader<T>(FilePath src, RowParser<T> parser, bool header = true)
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
        {
            var header = CsvTables.header<T>(widths);
            return rowspec(header, header.Cells.Select(x => x.CellFormat), rowpad, fk);
        }

        [Op, Closures(Closure)]
        public static RowFormatSpec rowspec<T>(byte width, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
            where T : struct
        {
            var header = CsvTables.header<T>(width);
            return rowspec(header, header.Cells.Select(x => x.CellFormat), rowpad, fk);
        }        

        /// <summary>
        /// Discerns a <see cref='ClrTableCols'/> for a parametrically-identified record type
        /// </summary>
        /// <typeparam name="T">The record type</typeparam>
        [Op, Closures(Closure)]
        public static ClrTableCol[] cells<T>()
            => cells(typeof(T));

        /// <summary>
        /// Discerns a <see cref='ClrTableCols'/> for a specified record type
        /// </summary>
        /// <param name="src">The record type</typeparam>
        [Op]
        public static ClrTableCol[] cells(Type src)
        {
            var fields = src.DeclaredPublicInstanceFields().Ignore().Index();
            var count = fields.Count;
            var dst = sys.alloc<ClrTableCol>(count);
            for(var i=z32; i<count; i++)
            {
                ref readonly var field = ref fields[i];
                var tag = field.Tag<RenderAttribute>();
                if(tag)
                {
                    var tv = tag.Value;
                    seek(dst,i) = new ClrTableCol(new CellRenderSpec(i, tv.Width, TextFormat.formatter(field.FieldType, (ushort)tv.Style)), field);
                }
                else
                {
                    seek(dst,i) = new ClrTableCol(new CellRenderSpec(i, 16, TextFormat.formatter(field.FieldType)), field);
                }

            }
            return dst;
        }
 
        /// <summary>
        /// Creates a row header for parametrically-identified record type
        /// </summary>
        /// <param name="widths">The cell render widths</param>
        /// <typeparam name="T">The record type</typeparam>
        public static RowHeader header<T>(ReadOnlySpan<byte> widths, string delimiter = DefaultDelimiter)
            => header(typeof(T), widths);

        /// <summary>
        /// Creates a row header for parametrically-identified record type and uniform field width
        /// </summary>
        /// <param name="fieldwidht">The uniform field width</param>
        /// <typeparam name="T">The record type</typeparam>
        public static RowHeader header<T>(byte fieldwidth, string delimiter = DefaultDelimiter)
            => header(typeof(T), fieldwidth, delimiter);

        /// <summary>
        /// Creates a row header for a specified record type record type and uniform field width
        /// </summary>
        /// <param name="fieldwidht">The uniform field width</param>
        /// <typeparam name="T">The record type</typeparam>
        public static RowHeader header(Type record, byte fieldwidth, string delimiter = DefaultDelimiter)
        {
            var _fields = CsvTables.cells(record).ToReadOnlySpan();
            var count = _fields.Length;
            var buffer = alloc<HeaderCell>(count);
            var cells = span(buffer);
            for(var i=0u; i<count; i++)
                seek(cells, i) = new HeaderCell(i, skip(_fields,i).CellName, fieldwidth);
            return new RowHeader(buffer, delimiter);
        }

        /// <summary>
        /// Creates a row header for a specified record type
        /// </summary>
        /// <param name="widths">The cell render widths</param>
        public static RowHeader header(Type record, ReadOnlySpan<byte> widths, string delimiter = DefaultDelimiter)
        {
            var _fields = CsvTables.cells(record).ToReadOnlySpan();
            var count = _fields.Length;
            if(count != widths.Length)
                sys.@throw(FieldCountMismatch.Format(count, widths.Length));
            var buffer = alloc<HeaderCell>(count);
            var cells = span(buffer);
            for(var i=0u; i<count; i++)
            {
                ref readonly var field = ref skip(_fields,i);
                seek(cells,i) = new HeaderCell(i, field.CellName, skip(widths,i));
            }
            return new RowHeader(buffer, delimiter);
        }

 
        static MsgPattern<Count,Count> FieldCountMismatch
            => "The target requires {0} fields but {1} were found in the source";
    }
}