//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;
using static sys;
using static XedZ;

partial class XedFlows
{
    public void EmitRules(XedRuleBlocks src)
    {
        exec(PllExec,
            () => EmitRecords(src),
            () => EmitBlockDetail(src),
            () => EmitLineMap(src),
            () => EmitStats(src.Stats));
    }

    void EmitStats(ReadOnlySpan<LineStats> src)
        => Emit(src);

    void EmitLineMap(XedRuleBlocks src)
        => EmitLineMap(src.LineMap);

    void Emit(ReadOnlySpan<LineStats> src)
        => AsciLines.emit(src,XedPaths.Imports().Path("xed.instblocks.stats", FileKind.Csv));

    void EmitRecords(XedRuleBlocks src)
    {
        Channel.TableEmit(src.Imports, XedPaths.Imports().Table<InstBlockImport>());
        var file = FS.file($"{CsvTables.filename<InstBlockImport>().WithoutExtension.Format()}.duplicates", FS.Csv);
        Channel.TableEmit(src.Duplicates, XedPaths.Imports().Path(file));
    }

    void EmitBlockDetail(XedRuleBlocks src)
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
            emitter.WriteLine(RP.PageBreak120);
            foreach(var line in src.Description(form))
                emitter.AppendLine(line);
            emitter.WriteLine();
        }
        Channel.FileEmit(emitter.Emit(), count, path);
    }

    void EmitLineMap(LineMap<InstBlockLineSpec> data)
    {
        const string Pattern = "{0,-6} | {1,-12} | {2,-12} | {3,-12} | {4,-12} | {5,-6} | {6,-64} | {7}";
        var dst = XedPaths.Imports().Table<InstBlockLineSpec>();
        var formatter = CsvTables.formatter<InstBlockLineSpec>();
        var emitting = Channel.EmittingTable<InstBlockLineSpec>(dst);
        using var writer = dst.AsciWriter();
        writer.WriteLine(formatter.FormatHeader());
        for(var i=0u; i<data.IntervalCount; i++)
            writer.WriteLine(formatter.Format(data[i].Id));
        Channel.EmittedTable(emitting, data.IntervalCount);
    }
}