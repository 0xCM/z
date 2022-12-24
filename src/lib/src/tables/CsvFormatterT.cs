// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     public struct CsvFormatter<T> : ICsvFormatter<T>
//         where T : struct
//     {
//         public readonly RowFormatSpec FormatSpec;

//         internal RowAdapter<T> Adapter;

//         ITextBuffer Buffer;

//         [MethodImpl(Inline)]
//         internal CsvFormatter(RowFormatSpec spec, RowAdapter<T> adapter)
//         {
//             FormatSpec = spec;
//             Adapter = adapter;
//             Buffer = text.buffer();
//         }

//         RowFormatSpec ICsvFormatter.FormatSpec
//             => FormatSpec;

//         public string Format(in T src)
//             => FormatRecord(src, FormatSpec.FormatKind);

//         public string Format(in T src, RecordFormatKind kind)
//             => FormatRecord(src, kind);

//         public string FormatHeader()
//         {
//             if(FormatSpec.FormatKind == RecordFormatKind.Tablular)
//                 return FormatSpec.Header.Format();
//             else
//             {
//                 return string.Format(CsvTables.KvpPattern(FormatSpec), "Name", "Value");
//             }
//         }

//         string FormatRecord(in T src, RecordFormatKind fk)
//         {
//             TableDefs.adapt(src, ref Adapter);

//             if(fk == RecordFormatKind.Tablular)
//                 return Adapter.Adapted.Format(FormatSpec);
//             else
//             {
//                 Buffer.Clear();
//                 CsvTables.pairs(FormatSpec, Adapter, Buffer);
//                 return Buffer.Emit();
//             }
//         }
//     }
// }