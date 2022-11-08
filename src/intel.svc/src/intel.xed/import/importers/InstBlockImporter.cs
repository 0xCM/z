//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedImport
    {
        public class InstBlockImporter : WfSvc<InstBlockImporter>
        {
            XedPaths XedPaths => Wf.XedPaths();

            public void EmitStats(ReadOnlySpan<LineStats> src)
                => Emit(src);

            public void Import(InstImportBlocks src)
            {
                XedPaths.Imports().Delete();
                exec(PllExec,
                    () => EmitRecords(src),
                    () => EmitBlockDetail(src),
                    () => EmitLineMap(src),
                    () => EmitStats(AsciLines.stats(src.DataSource, 400000))
                );
            }

            void EmitLineMap(InstImportBlocks src)
                => EmitLineMap(src.LineMap);

            void Emit(ReadOnlySpan<LineStats> src)
                => AsciLines.emit(src,XedPaths.Imports().Path("xed.instblocks.stats", FileKind.Csv));

            void EmitRecords(InstImportBlocks src)
            {
                TableEmit(src.Imports, XedPaths.Imports().Table<InstBlockImport>());
                var file = FS.file($"{Tables.filename<InstBlockImport>().WithoutExtension.Format()}.duplicates", FS.Csv);
                TableEmit(src.Duplicates, XedPaths.Imports().Path(file));
            }

            void EmitBlockDetail(InstImportBlocks src)
            {
                var path = XedPaths.Imports().Path("xed.instblocks.detail", FileKind.Txt);
                var emitter = text.emitter();
                var forms = src.Forms.Keys;
                var count = forms.Length;
                for(var i=0; i<count; i++)
                {
                    ref readonly var form = ref skip(forms,i);
                    if(form.IsEmpty)
                        continue;

                    emitter.AppendLine(src.Header(form));
                    emitter.WriteLine(RpOps.PageBreak120);
                    emitter.AppendLine(src.Description(form));
                    emitter.WriteLine();
                }
                FileEmit(emitter.Emit(), count, path);
            }

            void EmitLineMap(LineMap<InstBlockLineSpec> data)
            {
                const string Pattern = "{0,-6} | {1,-12} | {2,-12} | {3,-12} | {4,-12} | {5,-6} | {6,-64} | {7}";
                var dst = XedPaths.Imports().Table<InstBlockLineSpec>();
                var formatter = CsvChannels.formatter<InstBlockLineSpec>();
                var emitting = EmittingTable<InstBlockLineSpec>(dst);
                using var writer = dst.AsciWriter();
                writer.WriteLine(formatter.FormatHeader());
                for(var i=0u; i<data.IntervalCount; i++)
                    writer.WriteLine(formatter.Format(data[i].Id));
                EmittedTable(emitting, data.IntervalCount);
            }
        }
    }
}