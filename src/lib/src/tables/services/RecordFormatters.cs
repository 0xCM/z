//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Tables;
    using static RecordFormatter;

    using api = RecordFormatters;

    public class RecordFormatters
    {
        public static IRecordFormatter<T> create<T>(ushort rowpad, RecordFormatKind fk, string delimiter = DefaultDelimiter)
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

        public static RecordFormatter create(Type record, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular, string delimiter = DefaultDelimiter)
        {
            var fields = Tables.fields(record).Index();
            var count = fields.Length;
            var buffer = alloc<HeaderCell>(count);
            for(var i=0u; i<count; i++)
                seek(buffer, i) = new HeaderCell(fields[i].FieldIndex, fields[i].FieldName, fields[i].FieldWidth);
            var header = new RowHeader(buffer, delimiter);
            var spec = rowspec(header, header.Cells.Select(x => x.CellFormat), rowpad, fk);
            return new RecordFormatter(record, spec, api.adapter(record));
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