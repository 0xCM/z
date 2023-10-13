//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Linq;

using static XedModels;
using static sys;

public partial class XedZ
{        

    static bool parse(List<string> lines, out List<RuleAttribute> dst)
    {
        dst = new();
        foreach(var line in lines)
        {
            var i = text.index(line, Chars.Colon);
            if(i>=0)
            {
                var name = text.left(line,i);
                var value = text.trim(text.right(line,i));
                dst.Add(new(name,value));
            }
        }
        
        return true;
    }

    public static RuleBlocks rules(FilePath path)
    {
        using var src = MemoryFiles.map(path);
        var stats = AsciLines.stats(src.Bytes, 400000);
        var dst = new RuleBlocks();
        var ds = new BlockImportDatasets();
        var lines = Lines.lines(src);
        CalcBlockLines(lines, ds);
        CalcDatasets(lines, ds);
        dst.Stats = stats.ToArray();
        dst.BlockLines = ds.BlockLines;
        dst.LineMap = ds.MappedForms;
        dst.Imports = ds.BlockImports.Index().Sort().Resequence();
        var fds = forms(ds);
        dst.FormBlocks = fds.Descriptions;
        dst.FormHeaders = fds.Headers;
        dst.Forms = fds.Sorted;
        return dst;
    }

    public static void emit(IWfChannel channel, ReadOnlySeq<InstBlockPattern> src)
    {
        channel.TableEmit(src, XedPaths.ImportTable<InstBlockPattern>());
    }

    static void emit(IWfChannel channel, RuleBlocks src)
    {
        exec(true,
            () => channel.TableEmit(src.Imports, XedPaths.Imports().Table<InstBlockImport>()),
            () => EmitBlockDetail(channel, src),
            () => EmitLineMap(channel, src),
            () => EmitStats(channel, src.Stats));
    }

    static void EmitStats(IWfChannel channel, ReadOnlySpan<LineStats> src)
        => Emit(channel, src);

    static void EmitLineMap(IWfChannel channel, RuleBlocks src)
        => EmitLineMap(channel, src.LineMap);

    static void Emit(IWfChannel channel, ReadOnlySpan<LineStats> src)
        => AsciLines.emit(src, XedPaths.Imports().Path("xed.instblocks.stats", FileKind.Csv));

    static void EmitBlockDetail(IWfChannel channel, RuleBlocks src)
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
        channel.FileEmit(emitter.Emit(), count, path);
    }

    static void EmitLineMap(IWfChannel channel, LineMap<InstBlockLineSpec> data)
    {
        const string Pattern = "{0,-6} | {1,-12} | {2,-12} | {3,-12} | {4,-12} | {5,-6} | {6,-64} | {7}";
        var dst = XedPaths.Imports().Table<InstBlockLineSpec>();
        var formatter = CsvTables.formatter<InstBlockLineSpec>();
        var emitting = channel.EmittingTable<InstBlockLineSpec>(dst);
        using var writer = dst.AsciWriter();
        writer.WriteLine(formatter.FormatHeader());
        for(var i=0u; i<data.IntervalCount; i++)
            writer.WriteLine(formatter.Format(data[i].Id));
        channel.EmittedTable(emitting, data.IntervalCount);
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
        const string IFormMarker = "iform:";
        var fields = InstBlockLineSpec.Empty;
        var buffer = list<LineInterval<InstBlockLineSpec>>();
        var form = XedInstForm.Empty;
        var name = EmptyString;
        var value = EmptyString;
        var field = BlockFieldName.amd_3dnow_opcode;
        var counter = 0u;
        var min = 0u;
        var seq = 0u;

        for(var i=0u; i<src.Length; i++)
        {
            var line = text.trim(skip(src,i));
            counter += (uint)line.Length;
            if(split(line, out name, out value))
            {
                if(XedZ.parse(name, out field))
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
                fields.LineCount = fields.MaxLine - fields.MinLine + 1;
                dst.BlockLines.Add(fields);
                buffer.Add(new LineInterval<InstBlockLineSpec>(fields, fields.MinLine, fields.MaxLine));
                fields = InstBlockLineSpec.Empty;
                min = counter+1;
            }
            else
            {
                var j = text.index(line,IFormMarker);
                if(j >= 0)
                    XedParsers.parse(value, out fields.Form);
            }
        }

        dst.MappedForms = buffer.ToArray();
    }
    
    static void absorb(Attribute src, ref InstBlockImport dst)
    {
        switch(src.Field)
        {
            
            case BlockFieldName.iclass:
                XedParsers.parse(src.Value, out dst.Class);
            break;
            case BlockFieldName.opcode:
                HexParser.parse(src.Value, out dst.OpCodeValue);
            break;
            case BlockFieldName.space:
                parse(src.Value, out dst.OpCodeClass);
            break;
            case BlockFieldName.map:
                DataParser.parse(src.Value, out dst.OpCodeMap);
            break;

            case BlockFieldName.pattern:
            {
                try
                {
                    XedCells.parse(src.Value, out dst.Pattern);
                    dst.Pattern = XedCells.sort(dst.Pattern);
                    XedPatterns.mode(dst.Pattern, out dst.Mode);
                }
                catch(Exception e)
                {
                    term.warn(e.Message);
                }
            }
            break;
        }
    }
    
    static void CalcDatasets(ReadOnlySpan<string> src, BlockImportDatasets dst)
    {
        var map = dst.MappedForms;
        var k=0u;
        for(var i=0u; i<map.IntervalCount; i++)
        {
            ref readonly var range = ref map[i];
            var spec = range.Id;
            var form = spec.Form;
            var import = InstBlockImport.Empty;
            import.Form = form;
            import.Seq = i;
            var lines = list<string>();
            for(var m =0; m<range.LineCount; m++)
            {
                ref readonly var line = ref skip(src,k++);
                lines.Add(line);

                XedZ.parse(line, out Attribute attrib);
                absorb(attrib, ref import);
            }
            import.OpCodeKind = AsmOpCodes.kind(import.OpCodeClass, import.OpCodeMap);
            dst.BlockImports.Add(import);
            dst.FormData.TryAdd(form, lines);
        }
    }

    class FormImportDatasets
    {
        public ConcurrentDictionary<XedInstForm,List<string>> Descriptions = new();

        public ConcurrentDictionary<XedInstForm,string> Headers = new();

        public SortedLookup<XedInstForm,uint> Sorted;

        public void Include(XedInstForm form, BlockImportDatasets src)
        {
            if(form.IsNonEmpty)
            {
                var line = src.BlockLines[form];
                var dst = InstBlockImport.Empty;
                var content = src.FormData[form];
                var seq = Sorted[form];
                Descriptions[form] = content;
                Headers[form] = string.Format("{0,-64} | {1:D5} | {2:D2} | {3:D6} | {4:D6}", form, seq, line.LineCount, line.MinLine, line.MaxLine);
            }
            else
            {
                Descriptions[form] = list<string>();
                Headers[form] = EmptyString;
            }
        }
    }

    class BlockImportDatasets
    {
        public LineMap<InstBlockLineSpec> MappedForms = new();

        public InstBlockLines BlockLines = new();

        public ConcurrentBag<InstBlockImport> BlockImports = new();

        public ConcurrentDictionary<XedInstForm,List<string>> FormData = new();
     }
}
