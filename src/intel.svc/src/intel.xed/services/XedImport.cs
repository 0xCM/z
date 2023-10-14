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
        var ruleT = XedRuleTables.Empty;
        var instdefs = ReadOnlySeq<InstDef>.Empty;
        exec(true, 
            () => Emit(XedTables.BlockPatterns(XedTables.BlockLines())),
            () => ruleT = XedTables.RuleTables(),
            () => Emit(XedTables.RuleSeq()),
            () => Emit(XedTables.SeqReflected()),
            () => Emit(XedTables.MacroMatches()),
            () => instdefs = XedTables.InstDefs(),
            () => Emit(XedTables.MacroDefs()),
            () => Emit(XedTables.FieldImports()),
            () => Channel.TableEmit(XedRegMap.Service.REntries, XedPaths.ImportTable<RegMapEntry>("rmap")),
            () => Channel.TableEmit(XedRegMap.Service.XEntries, XedPaths.ImportTable<RegMapEntry>("xmap")),
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
            () => EmitRuleTables(ruleT),
            () => EmitPatternDocs(patterns),            
            () => Emit(XedTables.TableDefRows(ruleT)),
            () => cells = XedTables.RuleCells(ruleT),
            () => Emit(XedPatterns.layouts(patterns)),
            () => Emit(InstPattern.records(patterns.Storage)),
            () => Emit(XedPatterns.fieldrows(patterns.Storage)),
            () => {                
                EmitFlagEffects(patterns);
                EmitInstSigs(patterns);
                EmitInstAttribs(patterns);
                Emit(XedTables.OpCodes(patterns));
            }
        );
    
        var cellT = XedTables.CellTables(cells);
        var opdetail = XedTables.OpDetails(patterns);
        exec(true, 
            () => Emit(grids(cellT)),
            () => EmitRuleDocs(cellT),
            () => Emit(XedTables.FieldDeps(cellT)),
            () => Emit(CellTables.records(cellT)),
            () => EmitRuleMetrics(cellT),
            () => EmitTableStats(cellT),
            () => Emit(CalcOpSpecs(opdetail)),
            () => Emit(XedTables.OpRows(opdetail)),
            () => Emit(CalcOpClasses(opdetail))
        );
    }

    static InstOpSpec spec(in InstOpDetail src)
    {
        var dst = InstOpSpec.Empty;
        dst.Form = src.InstForm;
        dst.Index = src.Index;
        dst.Name = src.Name;
        dst.ElementType = src.ElementType;
        dst.Width = new OpWidth(src.WidthCode, src.BitWidth);
        dst.BitWidth = src.BitWidth;
        dst.RegLit = src.RegLit;
        dst.Rule = src.Rule;
        dst.GprWidth = src.GrpWidth;
        var wi = XedWidths.describe(src.WidthCode);
        if(wi.SegType.CellCount > 1)
            dst.Seg = new InstOpSpec.Segmentation(wi.SegType.DataWidth, wi.SegType.CellWidth, src.ElementType.Indicator, wi.SegType.CellCount);
        return dst;
    }

    static ReadOnlySeq<InstOpSpec> CalcOpSpecs(ReadOnlySeq<InstOpDetail> src)
    {
        var dst = alloc<InstOpSpec>(src.Count);
        for(var i=0; i<src.Count; i++)
            seek(dst,i) = spec(src[i]);
        return dst;
    }

    void EmitInstSigs(Index<InstPattern> src)
    {
        const string RenderPattern = "{0,-18} | {1,-6} | {2,-26} | {3}";
        var dst = text.emitter();
        render(XedSigs.sigs(src), dst);
        Channel.FileEmit(dst.Emit(), src.Count, XedPaths.Imports().Path("xed.inst.sigs", FileKind.Csv));
    }

    static void render(Pairings<InstPattern,InstSig> src, ITextEmitter dst)
    {
        const string HeaderPattern = "{0,-18} | {1,-6} | {2,-26} | {3}";
        const string RenderPattern = "{0,-18} | {1,-6} | {2,-26} | {3}({4})";
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
                {
                    antecedants[usage.Rule] = hashset<RuleField>();
                }
                antecedants[usage.Rule].Add(usage.Field);        
            }
            else if(usage.Kind == UsageKind.DecRight || usage.Kind == UsageKind.EncRight)
            {
                if(!consequents.TryGetValue(usage.Rule, out _))
                {
                    consequents[usage.Rule] = hashset<RuleField>();
                }
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

    static void EmitRulePage(in TableCriteria src)
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
            dst.AppendLine(string.Format("{0,-32} {1}", table.Sig, XedPaths.CheckedRulePage(table.Sig)));
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

    void EmitTableStats(CellTables src)
    {
        const string RulePattern = "{0:D2} | {1,-12} | {2,-8} | {3,-32} | ";
        const string FieldPattern = "{0,-12} {1,-24}";
        var grids = XedCells.grids(src);
        var stats = alloc<XedTableStats>(src.TableCount);
        for(var i=0u; i<src.TableCount; i++)
        {
            var rows = grids.Rows(i);
            ref readonly var rule = ref grids[i].Rule;

            var pw = 0u;
            var aw = 0u;
            var mpw = 0u;
            var maw = 0u;
            var mcc = 0u;
            var cc = z16;

            var widths = rows.Select(x => x.Size());
            for(var j=z16; j<rows.Count; j++)
            {
                ref readonly var row = ref rows[j];
                ref readonly var width = ref widths[j];

                if(row.ColCount > mcc)
                    mcc = row.ColCount;
                if(width.PackedWidth > mpw)
                    mpw = width.PackedWidth;
                if(width.NativeWidth> maw)
                    maw = width.NativeWidth;

                pw += width.PackedWidth;
                aw += width.NativeWidth;
                cc += row.ColCount;
            }

            seek(stats,i) = new XedTableStats(i, rule, new DataSize(pw, aw), new DataSize(mpw,maw),(ushort)rows.Count, cc, (byte)mcc);
        }

        Channel.TableEmit(stats, XedPaths.ImportTable<XedTableStats>(), TextEncodingKind.Asci);
    }     


    static InstOpClass opclass(in InstOpDetail src)
    {
        var dst = InstOpClass.Empty;
        dst.Kind = src.Kind;
        dst.BitWidth = src.BitWidth;
        dst.ElementType = src.ElementType;
        dst.ElementCount = src.SegInfo.CellCount;
        dst.IsRegLit = src.IsRegLit;
        dst.IsRule = src.IsNonterm;
        dst.WidthCode = src.WidthCode;
        return dst;
    }

    static ReadOnlySeq<InstOpClass> CalcOpClasses(ReadOnlySeq<InstOpDetail> src)
    {
        var buffer = sys.bag<InstOpClass>();
        iter(src, op => buffer.Add(opclass(op)), true);
        var dst = buffer.Array().Distinct().Sort();
        for(var i=0u; i<dst.Length; i++)
            seek(dst,i).Seq = i;
        return dst;
    }    

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

    void Emit(ParallelQuery<XedZ.InstBlockPattern> src)
        => XedZ.emit(Channel,src);

    void Emit(InstLayouts src)
        => Channel.TableEmit(src.Records.View, XedPaths.ImportTable<InstLayoutRecord>(), TextEncodingKind.Asci);

    void EmitRuleTables(XedRuleTables src)
        => iter(src.Criteria(), table => EmitRulePage(table), PllExec);
    
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
            seek(cells,m++) = pattern.PatternId;
            seek(cells,m++) = pattern.InstClass;
            seek(cells,m++) = pattern.OpCode;
            seek(cells,m++) = acount;
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

    static Index<RuleGrid> grids(CellTables src)
    {
        var kGrid = src.TableCount;
        var grids = alloc<RuleGrid>(kGrid);
        var gt=0u;
        var gr=0u;
        for(var i=0; i<kGrid; i++)
        {
            ref readonly var cTable = ref src[i];
            ref readonly var sig = ref cTable.Sig;
            var kCol = XedCells.cols(cTable);
            var kRow = cTable.RowCount;
            var kCells = kRow*kCol;
            var gRowCols = alloc<Index<GridCol>>(kRow);
            seek(grids,i) = XedCells.grid(sig, (ushort)kRow, (byte)kCol, alloc<GridCell>(kCells));
            ref readonly var gCells = ref skip(grids,i).Cells;
            for(ushort j=0,gc=0; j<kRow; j++)
            {
                ref readonly var cRow = ref cTable[j];
                seek(gRowCols, j) = alloc<GridCol>(cRow.CellCount);

                for(var k=0; k<cRow.CellCount; k++, gc++)
                {
                    ref readonly var cell = ref cRow[k];
                    gCells[gc] = GridCell.from(cell);
                    gRowCols[j][k] = gCells[gc].Def;
                }
            }
        }
        return grids;
    }    

    void Emit(ReadOnlySeq<RuleGrid> src)
    {
        var kGrid = src.Count;
        var dst = text.emitter();
        var counter = 0u;
        for(var i=0; i<kGrid; i++)
        {
            ref readonly var grid = ref src[i];
            ref readonly var kRows = ref grid.RowCount;
            ref readonly var kCols = ref grid.ColCount;
            ref readonly var cells = ref grid.Cells;
            var gc = 0;
            for(var j=0; j<kRows; j++)
            {
                for(var k=0; k<kCols; k++,gc++, counter++)
                {
                    ref readonly var cell = ref cells[gc];
                    if(cell.IsEmpty)
                        continue;

                    dst.WriteLine(cell.Format());
                }
            }
        }
        Channel.FileEmit(dst.Emit(), counter, XedPaths.Imports().Path("xed.rules.grids", FileKind.Csv));
    }    
}
