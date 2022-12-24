//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    // public class CsvFormatter : ICsvFormatter
    // {
    //     [MethodImpl(Inline)]
    //     internal static ref RowAdapter adapt<T>(in T src, ref RowAdapter adapter)
    //         where T : struct
    //     {
    //         adapter.Source = src;
    //         adapter.Index++;
    //         TableDefs.load(adapter.Source, ref adapter.Row);
    //         return ref adapter;
    //     }

    //     internal static RowAdapter adapt(Type src)
    //         => new RowAdapter(src, TableDefs.cells(src));

    //     const string DefaultDelimiter = " | ";

    //     public static ICsvFormatter<T> create<T>(ushort rowpad, RecordFormatKind fk, string delimiter = DefaultDelimiter)
    //         where T : struct
    //     {
    //         var record = typeof(T);
    //         var fields = TableDefs.cells(record).Index();
    //         var count = fields.Length;
    //         var buffer = sys.alloc<HeaderCell>(count);
    //         for(var i=0u; i<count; i++)
    //             sys.seek(buffer, i) = new HeaderCell(i, fields[i].CellName, fields[i].CellWidth);
    //         var header = new RowHeader(buffer, DefaultDelimiter);
    //         var spec = CsvTables.rowspec(header, header.Cells.Select(x => x.CellFormat), rowpad, fk);
    //         return new Formatter2<T>(spec, adapt(record));
    //     }

    //     public static ICsvFormatter create(Type record, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular, string delimiter = DefaultDelimiter)
    //     {
    //         var fields = TableDefs.cells(record).Index();
    //         var count = fields.Length;
    //         var buffer = sys.alloc<HeaderCell>(count);
    //         for(var i=0u; i<count; i++)
    //             sys.seek(buffer, i) = new HeaderCell(i, fields[i].CellName, fields[i].CellWidth);
    //         var header = new RowHeader(buffer, delimiter);
    //         var spec = CsvTables.rowspec(header, header.Cells.Select(x => x.CellFormat), rowpad, fk);
    //         return new CsvFormatter(record, spec, adapt(record));
    //     }

    //     internal class Formatter2<T> : ICsvFormatter<T>
    //         where T : struct
    //     {
    //         readonly RenderBuffers Buffers;

    //         public Formatter2(RowFormatSpec spec, RowAdapter adapter)
    //         {
    //             Buffers = RenderBuffers.create(spec.CellCount);
    //             FormatSpec = spec;
    //             Adapter = adapter;
    //         }

    //         public RowFormatSpec FormatSpec {get;}

    //         RowAdapter Adapter;

    //         public string Format(in T src)
    //         {
    //             adapt(src, ref Adapter);
    //             return CsvTables.format(FormatSpec, Buffers, Adapter.Adapted);
    //         }

    //         public string FormatHeader()
    //         {
    //             if(FormatSpec.FormatKind == RecordFormatKind.Tablular)
    //                 return FormatSpec.Header.Format();
    //             else
    //                 return string.Format(CsvTables.KvpPattern(FormatSpec), "Name", "Value");
    //         }
    //     }

    //     RowAdapter Adapter;

    //     public readonly RowFormatSpec FormatSpec;

    //     public readonly TableId TableId;

    //     readonly RenderBuffers Buffers;

    //     [MethodImpl(Inline)]
    //     internal CsvFormatter(Type record, RowFormatSpec spec, RowAdapter adapter)
    //     {
    //         TableId = TableId.identify(record);
    //         FormatSpec = spec;
    //         Adapter = adapter;
    //         Buffers = RenderBuffers.create(spec.CellCount);
    //     }

    //     public string Format<T>(in T src)
    //         where T : struct
    //     {
    //         adapt<T>(src, ref Adapter);
    //         return CsvTables.format(FormatSpec, Buffers, Adapter.Adapted);
    //     }

    //     public string FormatHeader()
    //     {
    //         if(FormatSpec.FormatKind == RecordFormatKind.Tablular)
    //             return FormatSpec.Header.Format();
    //         else
    //             return string.Format(CsvTables.KvpPattern(FormatSpec), "Name", "Value");
    //     }

    //     RowFormatSpec ICsvFormatter.FormatSpec
    //         => FormatSpec;

    //     TableId ICsvFormatter.TableId
    //         => TableId;

    //     /// <summary>
    //     /// Defines a row over a specified record type
    //     /// </summary>
    //     /// <typeparam name="T">The record type</typeparam>
    //     internal struct RowAdapter
    //     {
    //         internal uint Index;

    //         internal dynamic Source;

    //         internal DynamicRow Row;

    //         public readonly Type RowType;

    //         [MethodImpl(Inline)]
    //         internal RowAdapter(Type type, ClrTableCells fields)
    //         {
    //             RowType = type;
    //             Source = type;
    //             Index = 0;
    //             Row = TableDefs.dynarow(fields);
    //         }

    //         public readonly DynamicRow Adapted
    //         {
    //             [MethodImpl(Inline)]
    //             get => Row;
    //         }
    //     }
    // }
}