//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;
using static sys;

partial class XedFlows
{
    public XedRuleBlocks CalcRuleBlocks(FilePath path)
    {
        using var src = MemoryFiles.map(path);
        var stats = AsciLines.stats(src.Bytes, 400000);
        var dst = new XedRuleBlocks();
        var ds = new BlockImportDatasets();
        var lines = Lines.lines(src);
        CalcBlockLines(lines, ds);
        CalcDatasets(lines, ds);
        dst.Stats = stats.ToArray();
        dst.BlockLines = ds.BlockLines;
        dst.LineMap = ds.MappedForms;
        dst.Imports = ds.BlockImports.Index().Sort().Resequence();
        dst.Duplicates = calc(dst.Imports, out dst.ImportLookup);
        var fds = forms(ds);
        dst.FormBlocks = fds.Descriptions;
        dst.FormHeaders = fds.Headers;
        dst.Forms = fds.Sorted;
        return dst;
    }

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
            emitter.AppendLine(src.Description(form));
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

    static FormImportDatasets forms(BlockImportDatasets src, bool pll = true)
    {
        var dst = new FormImportDatasets();
        var keys = src.FormData.Keys.Index().Sort();
        var forms = dict<XedInstForm,uint>();
        for(var i=0u; i<keys.Count; i++)
            forms[keys[i]] = i;
        dst.Sorted = forms;
        iter(keys, form => dst.Include(form, src), pll);
        return dst;
    }

    static Index<InstBlockImport> calc(Index<InstBlockImport> src, out SortedLookup<string,InstBlockImport> dst)
    {
        var dupes = list<InstBlockImport>();
        var lookup = cdict<string,InstBlockImport>();
        for(var i=0; i<src.Count; i++)
        {
            ref readonly var import = ref src[i];
            if(!lookup.TryAdd(import.Form.Format(), import))
                dupes.Add(import);
        }
        dst = lookup;
        return dupes.ToIndex().Sort();
    }

    static bool split(string src, out string name, out string value)
    {
        var result = false;
        var i = text.index(src,Chars.Colon);
        if(i > 0)
        {
            name = text.trim(text.left(src,i));
            value = text.trim(text.right(src,i));
            result = true;
        }
        else
        {
            name = EmptyString;
            value = EmptyString;
        }
        return result;
    }

    static void CalcBlockLines(ReadOnlySpan<string> src, BlockImportDatasets dst)
    {
        const string FirstItemMarker = "amd_3dnow_opcode:";
        const string LastItemMarker = "EOSZ_LIST:";
        const string Pattern = "{0,-6} | {1,-6} | {2,-6} | {3,-6} | {4,-64}";
        const string Marker = "iform:";
        var fields = InstBlockLineSpec.Empty;
        var buffer = list<LineInterval<InstBlockLineSpec>>();
        var form = XedInstForm.Empty;
        var name = EmptyString;
        var value = EmptyString;
        var field = InstBlockField.amd_3dnow_opcode;
        var counter = 0u;
        var min = 0u;
        var seq = 0u;
        for(var i=0u; i<src.Length; i++)
        {
            var line = text.trim(skip(src,i));
            counter += (uint)line.Length;
            if(split(line, out name, out value))
            {
                if(XedParsers.parse(name, out field))
                    fields.Fields[field] = bit.On;
            }
            if(text.begins(line,FirstItemMarker))
                fields.MinLine = i;
            else if(text.begins(line, LastItemMarker))
            {
                fields.MaxLine = i;
                fields.MinChar = min;
                fields.MaxChar = counter;
                fields.Seq = seq++;
                fields.Lines = fields.MaxLine - fields.MinLine + 1;
                dst.BlockLines.Add(fields);
                buffer.Add(new LineInterval<InstBlockLineSpec>(fields, fields.MinLine, fields.MaxLine));
                fields = InstBlockLineSpec.Empty;
                min = counter+1;
            }
            else
            {
                var j = text.index(line,Marker);
                if(j >= 0)
                    XedParsers.parse(value, out fields.Form);
            }
        }

        dst.MappedForms = buffer.ToArray();
    }

    static void CalcDatasets(ReadOnlySpan<string> src, BlockImportDatasets dst)
    {
        var emitter = text.emitter();
        var map = dst.MappedForms;
        var k=0u;
        for(var i=0u; i<map.IntervalCount; i++)
        {
            ref readonly var range = ref map[i];
            var spec = range.Id;
            var form = spec.Form;
            var import = InstBlockImport.Empty;
            var name = EmptyString;
            var value = EmptyString;
            var bf = InstBlockField.amd_3dnow_opcode;
            import.Form = form;
            import.Seq = i;
            for(var m =0; m<range.LineCount; m++)
            {
                ref readonly var line = ref skip(src,k++);
                emitter.AppendLine(line);

                split(line, out name, out value);
                XedParsers.parse(name, out bf);

                if(bf == InstBlockField.iclass)
                    XedParsers.parse(value, out import.Class);
                else if(bf == InstBlockField.pattern)
                {
                    split(line, out _, out value);
                    try
                    {
                        XedInstParser.parse(value, out import.Pattern);
                        var fields = XedCells.sort(import.Pattern.Cells);
                        import.Pattern = new (fields);
                        XedPatterns.mode(import.Pattern, out import.Mode);
                    }
                    catch(Exception e)
                    {
                        term.warn(e.Message);
                    }
                }
            }
            dst.BlockImports.Add(import);
            dst.FormData.TryAdd(form, emitter.Emit());
        }
    }

    class BlockImportDatasets
    {
        public LineMap<InstBlockLineSpec> MappedForms = new();

        public InstBlockLines BlockLines = new();

        public ConcurrentBag<InstBlockImport> BlockImports = new();

        public ConcurrentDictionary<XedInstForm,string> FormData = new();
     }
}