//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;
using System.Linq;

using static sys;
using static XedModels;
using static XedRules;

public partial class XedImport : WfSvc<XedImport>
{     
    public void Run()
    {
        XedPaths.Imports().Delete();
        var ruleT = XedRuleTables.Empty;
        var instdefs = ReadOnlySeq<InstDef>.Empty;
        exec(true, 
            () => Emit(XedTables.Instructions()),
            () => ruleT = XedTables.RuleTables(),
            () => Emit(XedTables.RuleSeqImports()),
            () => Emit(XedTables.SeqReflected()),
            () => Emit(XedTables.MacroMatches()),
            () => instdefs = XedTables.EncInstDefs(),
            () => Emit(XedTables.MacroDefs()),
            () => Emit(XedTables.FieldImports()),
            () => Channel.TableEmit(XedRegMap.REntries, XedPaths.ImportTable<RegMapEntry>("rmap")),
            () => Channel.TableEmit(XedRegMap.XEntries, XedPaths.ImportTable<RegMapEntry>("xmap")),
            () => EmitChipCodes(Symbols.symkinds<ChipCode>()),
            () => Emit(XedTables.broadcasts(Symbols.kinds<BroadcastKind>())),
            () => Emit(CalcCpuIdDataset(XedPaths.CpuidSource())),
            () => {
                var chips = XedTables.ChipMap();
                Emit(chips);
                var forms = XedTables.FormImports();
                EmitFormImports(forms);
                Emit(XedTables.ChipInstructions(forms, chips));
            },
            () => {
                Emit(XedTables.Widths.Details);
                Emit(XedTables.Widths.Pointers.Where(x => x.Kind != 0).Map(x => x.ToRecord()));
            }
        );

        var patterns = XedTables.InstPatterns(instdefs);
        var cells = XedRuleCells.Empty;
        exec(true,
            () => EmitPages(ruleT),
            () => EmitPatternDocs(patterns),            
            () => Emit(XedTables.TableDefRows(ruleT)),
            () => cells = XedTables.RuleCells(ruleT),
            () => Emit(XedPatterns.layouts(patterns)),
            () => Emit(InstPattern.records(patterns.Storage)),
            () => Emit(XedPatterns.fieldrows(patterns.Storage)),
            () => {                
                EmitFlagEffects(patterns);
                Emit(XedTables.InstructionSigs(patterns));
                EmitInstAttribs(patterns);
                Emit(XedTables.OpCodes(patterns));
            }
        );
    
        var cellT = XedTables.CellTables(cells);
        var opdetail = XedTables.OpDetails(patterns);
        exec(true, 
            () => EmitRuleDocs(cellT),
            () => Emit(XedTables.FieldDeps(cellT)),
            () => Emit(CellTables.records(cellT)),
            () => EmitRuleMetrics(cellT),
            () => Emit(XedTables.Stats(cellT)),
            () => Emit(XedTables.OperandSpecs(opdetail)),
            () => Emit(XedTables.OpRows(opdetail)),
            () => Emit(XedTables.OperandClasses(opdetail))
        );
    }

    public void Emit(InstructionRules src)
    {
        Emit(src.Operands);
        Emit(src.Patterns);
    }

    void Emit(Pairings<InstPattern,InstSig> src)
    {
        const string HeaderPattern = "{0,-18} | {1,-6} | {2,-26} | {3}";
        const string RenderPattern = "{0,-18} | {1,-6} | {2,-26} | {3}({4})";
        var dst = text.emitter();
        dst.AppendLineFormat(HeaderPattern, "Instruction", "Lock", "OpCode", "Sig");
        for(var i=0; i<src.Count; i++)
        {
            ref readonly var pattern = ref src[i].Left;
            ref readonly var sig = ref src[i].Right;
            var @class = Xed.classifier(pattern.InstClass);
            dst.AppendLineFormat(RenderPattern,
                @class,
                pattern.Lock,
                pattern.OpCode,
                @class.Format().ToLower(),
                sig
                );
        }
        Channel.FileEmit(dst.Emit(), src.Count, XedPaths.Imports().Path("xed.inst.sigs", FileKind.Csv));
    }

    void Emit(ReadOnlySeq<FieldUsage> src)
    {
        var antecedants = dict<RuleIdentity,HashSet<RuleField>>();
        var consequents = dict<RuleIdentity,HashSet<RuleField>>();
        foreach(var usage in src)
        {
            if(usage.Kind == UsageKind.DecLeft || usage.Kind == UsageKind.EncLeft)
            {
                if(!antecedants.TryGetValue(usage.Rule, out _))
                    antecedants[usage.Rule] = hashset<RuleField>();
                antecedants[usage.Rule].Add(usage.Field);        
            }
            else if(usage.Kind == UsageKind.DecRight || usage.Kind == UsageKind.EncRight)
            {
                if(!consequents.TryGetValue(usage.Rule, out _))
                    consequents[usage.Rule] = hashset<RuleField>();
                consequents[usage.Rule].Add(usage.Field);        
            }
        }
                    
        var dst = text.emitter();
        var rules = antecedants.Keys.Array().Sort();
        foreach(var rule in rules)                    
        {
            dst.Append($"{rule,-48} | ");
            var af = antecedants[rule].Array().Sort();
            for(var i=0; i<af.Length; i++)
            {
                if(i != 0)
                    dst.Append(", ");                
                dst.Append(skip(af,i).Format());
            }

            if(consequents.TryGetValue(rule, out var cf))
            {
                dst.Append(" => ");
                var _cf = cf.Array().Sort();
                for(var i=0; i<_cf.Length; i++)
                {
                    if(i != 0)
                        dst.Append(", ");                
                    dst.Append(skip(_cf,i).Format());
                }
            }
    
            dst.AppendLine();
        }
        Channel.FileEmit(dst.Emit(), XedPaths.Imports().Path("xed.rules.fields.deps", FileKind.Csv));
    }

    static void EmitPage(in TableCriteria src)
    {
        var formatter = CsvTables.formatter<TableDefRow>();
        using var emitter = XedPaths.RuleTable(src.Rule).AsciEmitter();
        emitter.AppendLine(formatter.FormatHeader());
        var k=0u;
        for(var j=0u; j<src.RowCount; j++, k++)
        {
            ref readonly var spec = ref src[j];
            var specFormat = spec.Format();
            var row = TableDefRow.Empty;
            row.Seq = k;
            row.TableId = src.TableId;
            row.Index = j;
            row.Rule = src.Rule;
            row.Kind = src.TableKind;
            row.Name = src.TableName;
            row.Statement = specFormat;
            emitter.AppendLine(formatter.Format(row));
        }
        emitter.AppendLine();
        emitter.AppendLine();
        src.RenderLines(emitter);
    }

    void Emit(ChipMap map)
    {
        const string RowFormat = "{0,-12} | {1,-24} | {2}";
        var dst = text.emitter();
        var counter = 0u;
        dst.WriteLine(string.Format(RowFormat, "Sequence", "ChipCode", "Isa"));
        var codes = map.Codes;
        foreach(var code in codes)
        {
            var mapped = map[code];
            foreach(var kind in mapped)
                dst.WriteLine(string.Format(RowFormat, counter++ , code, kind));
        }

        Channel.FileEmit(dst.Emit(), counter, XedPaths.Imports().Path(FS.file("xed.chipmap", FS.Csv)));
    }

    void EmitRuleMetrics(CellTables src)
    {
        var dst = text.emitter();
        for(var i=0; i<src.TableCount; i++)
        {
            ref readonly var table = ref src[i];
            dst.AppendLine(string.Format("{0,-32} {1}", table.Identity, XedPaths.CheckedRulePage(table.Identity)));
            dst.AppendLine(RP.PageBreak120);
            dst.AppendLine();
            for(var j=0; j<table.RowCount; j++)
            {
                ref readonly var row = ref table[j];

                if(j != 0)
                    dst.AppendLine();

                var size = DataSize.Empty;
                dst.AppendLine(row.Expression);
                dst.AppendLine(RP.PageBreak120);
                for(var k=0; k<row.CellCount; k++)
                {
                    ref readonly var cell = ref row[k];
                    ref readonly var key = ref cell.Key;
                    dst.AppendLineFormat("{0} | {1} | {2,-26} | {3}", key, cell.Size.Format(2,2), XedRender.format(cell.Field), cell);
                }
            }

            dst.AppendLine();
            dst.AppendLine(RP.PageBreak120);

        }
        Channel.FileEmit(dst.Emit(), src.TableCount, XedPaths.Imports().Path("xed.rules.metrics", FileKind.Txt));
    }

    void Emit(ReadOnlySeq<XedTableStats> stats)
        => Channel.TableEmit(stats, XedPaths.ImportTable<XedTableStats>(), TextEncodingKind.Asci);

    void Emit(ReadOnlySeq<InstBlockOperand> src)
        => Channel.TableEmit(src, XedPaths.ImportTable<InstBlockOperand>());        

    void Emit(ReadOnlySeq<XedInstOpCode> src)
        => Channel.TableEmit(src, XedPaths.ImportTable<XedInstOpCode>());

    void Emit(ReadOnlySpan<InstOpRow> src)
        => Channel.TableEmit(src, XedPaths.ImportTable<InstOpRow>());

    void Emit(ReadOnlySpan<InstOpClass> src)
        => Channel.TableEmit(src, XedPaths.ImportTable<InstOpClass>());

    void Emit(ReadOnlySpan<RuleCellRecord> src)
        => Channel.TableEmit(src, XedPaths.ImportTable<RuleCellRecord>());

    void Emit(ReadOnlySeq<InstOpSpec> src)
        => Channel.TableEmit(src, XedPaths.ImportTable<InstOpSpec>());

    void Emit(InstBlockPatterns src)
        => Channel.TableEmit(src.View,XedPaths.ImportTable<InstBlockPattern>());

    void Emit(InstLayouts src)
        => Channel.TableEmit(src.Records.View, XedPaths.ImportTable<InstLayoutRecord>(), TextEncodingKind.Asci);

    void EmitPages(XedRuleTables src)
        => iter(src.Criteria(), table => EmitPage(table), PllExec);
    
    void Emit(ReadOnlySeq<AsmBroadcast> src)
        => Channel.TableEmit(src, XedPaths.ImportTable<AsmBroadcast>());

    void EmitFormImports(ReadOnlySeq<FormImport> src)
        => Channel.TableEmit(src, XedPaths.ImportTable<FormImport>());

    void Emit(ReadOnlySpan<PointerWidthInfo> src)
        => Channel.TableEmit(src, XedPaths.ImportTable<PointerWidthInfo>());

    void Emit(ReadOnlySpan<OpWidthDetail> src)
        => Channel.TableEmit(src, XedPaths.ImportTable<OpWidthDetail>());

    void Emit(ReadOnlySeq<InstFieldRow> src)
        => Channel.TableEmit(src, XedPaths.ImportTable<InstFieldRow>());

    void Emit(ReadOnlySeq<InstPatternRecord> src)
        => Channel.TableEmit(src, XedPaths.ImportTable<InstPatternRecord>());

    void Emit(CpuIdDataset src)
    {
        Channel.TableEmit(src.InstIsaSpecs, XedPaths.ImportTable<InstIsaSpec>());
        Channel.TableEmit(src.CpuIdSpecs, XedPaths.ImportTable<CpuIdSpec>());
    }

    void EmitChipCodes(ReadOnlySeq<SymKindRow> src)
        => Channel.TableEmit(src, XedPaths.Imports().Path("xed.chips", FileKind.Csv));

    void Emit(ReadOnlySpan<MacroMatch> src)
        => Channel.TableEmit(src, XedPaths.ImportTable<MacroMatch>());

    void Emit(ReadOnlySpan<MacroDef> src)
        => Channel.TableEmit(src, XedPaths.ImportTable<MacroDef>());

    void Emit(ChipInstructions src)
        => piter(src.Query(), kv => Channel.TableEmit(kv.Right, XedPaths.Imports().Sources("isaforms").Path(FS.file(string.Format("xed.isa.{0}", kv.Left), FS.Csv))));                    

    void Emit(ReadOnlySeq<RuleSeq> src)
    {
        var dst = text.buffer();
        iter(src, x => dst.AppendLine(x.Format()));
        Channel.FileEmit(dst.Emit(), src.Count, XedPaths.Imports().Path("xed.rules.seq", FS.Txt));
    }

    void Emit(ReadOnlySeq<TableDefRow> src)
        => Channel.TableEmit(src, XedPaths.ImportTable<TableDefRow>());

    void EmitPatternDocs(ReadOnlySeq<InstPattern> src)
    {
        EmitDetails(src);
        EmitSummary(src);
    }

    void EmitRuleDocs(CellTables src)
        => Channel.FileEmit(XedRuleDocRender.create(src).Format(), 1, XedPaths.DocTarget("rules", FileKind.Md), TextEncodingKind.Asci);

    void Emit(ReadOnlySpan<FieldImport> src)
        => Channel.TableEmit(src, XedPaths.ImportTable<FieldImport>());

    static CpuIdDataset CalcCpuIdDataset(FilePath src)
    {
        var parser = new CpuIdImportCalcs();
        parser.Run(src.ReadLines().Where(text.nonempty));
        return new (parser.Parsed.CpuIdSpecs, parser.Parsed.IsaSpecs);
    }

    void Emit(ReadOnlySeq<SeqDef> defs)
    {
        var dst = text.emitter();
        for(var i=0; i<defs.Count; i++)
        {
            dst.AppendLine();
            dst.AppendLine(defs[i].Format());
        }

        Channel.FileEmit(dst.Emit(), defs.Count, XedPaths.Imports().Path("xed.rules.seq.reflected", FS.Txt));
    }

    void EmitInstAttribs(ReadOnlySeq<InstPattern> src)
    {
        const byte BaseCount = 4;
        const byte AttribCount = 8;
        const sbyte AttribPad = -32;
        const string Sep = " | ";
        const byte CellCount = BaseCount + AttribCount;
        var j=z8;
        var k=z8;
        var slots = new string[CellCount];
        seek(slots,j++) = "{0,-10}";
        seek(slots,j++) = "{1,-18}";
        seek(slots,j++) = "{2,-26}";
        seek(slots,j++) = "{3,-12}";

        var headers = new string[CellCount];
        seek(headers,k++) = "PatternId";
        seek(headers,k++) = "InstClass";
        seek(headers,k++) = "OpCode";
        seek(headers,k++) = "AttribCount";

        var cells = new object[CellCount];

        for(byte i=0; i<AttribCount; i++,j++,k++)
        {
            seek(slots,j) = RP.slot(j, AttribPad);
            seek(headers,k) = string.Format("Attrib{0:D2}", i);
        }

        var render = slots.Intersperse(" | ").Concat();
        var header = string.Format(render, headers);
        var dst = text.buffer();
        dst.AppendLine(header);
        for(var i=0; i<src.Count; i++)
        {
            ref readonly var pattern = ref src[i];
            ref readonly var attribs = ref pattern.Attributes;
            var set = attribs.Bitset();
            if(pattern.Scalable)
                set.Include(InstAttribKind.SCALABLE);

            var acount = set.Count();
            Demand.lteq(acount, AttribCount);

            var m=0;
            seek(cells, m++) = pattern.PatternId;
            seek(cells, m++) = pattern.InstClass;
            seek(cells, m++) = pattern.OpCode;
            seek(cells, m++) = acount;
            if(set.IsNonEmpty)
            {
                var _attribs = set.Format("|").Split(Chars.Pipe);
                for(var q=z8; q < _attribs.Length && m<CellCount; q++,m++)
                    seek(cells,m) = skip(_attribs,q);

                for(var q=m; q<CellCount; q++,m++)
                    seek(cells,m) = EmptyString;
            }
            else
            {
                for(var q=m; q<CellCount; q++)
                    seek(cells,q) = EmptyString;
            }

            dst.AppendLineFormat(render, cells);

        }

        Channel.FileEmit(dst.Emit(), src.Count, XedPaths.Imports().Path(FS.file("xed.inst.attributes", FS.Csv)));
    }

    void EmitFlagEffects(ReadOnlySeq<InstPattern> src)
    {
        const string RenderPattern = "{0,-16} | {1,-4} | {2, -4}";
        var path = XedPaths.Imports().Path("xed.rules.flags", FS.Csv);
        var emitting = Channel.EmittingFile(path);
        using var writer = path.AsciWriter();
        writer.AppendLineFormat(RenderPattern, "Instruction",  "F", "E");
        var counter = 0u;

        for(var j=0; j<src.Count; j++)
        {
            ref readonly var pattern = ref src[j];
            ref readonly var effects = ref pattern.Effects;
            for(var k=0; k<effects.Count; k++)
            {
                ref readonly var e = ref effects[k];
                writer.AppendLineFormat(RenderPattern, XedRender.format(pattern.InstClass), e.Flag.ToString().ToLower(), XedRender.format(e.Effect));
                counter++;
            }
        }

        Channel.EmittedFile(emitting,counter);
    }

    void EmitSummary(ReadOnlySeq<InstPattern> src)
    {
        var dst = XedPaths.DocTarget("instructions", FileKind.Md);
        var inst = new XedInstDoc(src.Map(x => new InstDocPart(x)));
        Channel.FileEmit(inst.Format(), inst.Parts.Count, dst, TextEncodingKind.Asci);
    }

    void EmitDetails(ReadOnlySeq<InstPattern> src)
    {
        var dst = XedPaths.DocTarget("instructions.detail", FileKind.Txt);
        var formatter = XedInstPages.create();
        var emitting = Channel.EmittingFile(dst);
        using var writer = dst.AsciWriter();
        for(var j=0; j<src.Count; j++)
            writer.Write(formatter.Format(src[j]));
        Channel.EmittedFile(emitting, src.Count);
    }
}
