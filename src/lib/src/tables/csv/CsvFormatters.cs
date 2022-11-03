//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static Tables;
    using static CsvFormatter;

    using api = CsvFormatters;

    [ApiHost]
    public class CsvFormatters
    {
        const NumericKind Closure = UInt64k;

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

        public static ICsvFormatter<T> create<T>(ushort rowpad, RecordFormatKind fk, string delimiter = DefaultDelimiter)
            where T : struct
        {
            var record = typeof(T);
            var fields = Tables.fields(record).Index();
            var count = fields.Length;
            var buffer = alloc<HeaderCell>(count);
            for(var i=0u; i<count; i++)
                seek(buffer, i) = new HeaderCell(fields[i].FieldIndex, fields[i].FieldName, fields[i].FieldWidth);
            var header = new RowHeader(buffer, DefaultDelimiter);
            var spec = rowspec(header, header.Cells.Select(x => x.CellFormat), rowpad, fk);
            return new Formatter2<T>(spec, api.adapter(record));
        }

        public static CsvFormatter create(Type record, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular, string delimiter = DefaultDelimiter)
        {
            var fields = Tables.fields(record).Index();
            var count = fields.Length;
            var buffer = alloc<HeaderCell>(count);
            for(var i=0u; i<count; i++)
                seek(buffer, i) = new HeaderCell(fields[i].FieldIndex, fields[i].FieldName, fields[i].FieldWidth);
            var header = new RowHeader(buffer, delimiter);
            var spec = rowspec(header, header.Cells.Select(x => x.CellFormat), rowpad, fk);
            return new CsvFormatter(record, spec, api.adapter(record));
        }

        internal static RowAdapter adapter(Type src)
            => new RowAdapter(src, Tables.fields(src));

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
                dst[i] = dst.Fields[i].Definition.GetValueDirect(tr);
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