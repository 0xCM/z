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
using static XedFlows;
using static XedZ;

using CK = XedRules.RuleCellKind;

public class XedImport : WfSvc<XedImport>
{     
    public void Run()
    {
        exec(true, 
            () => {
                var blocks = XedZ.rules(XedPaths.DocSource(XedDocKind.RuleBlocks));
                XedZ.emit(Channel, blocks);
                var domain = XedZ.domain(blocks);
                Channel.FileEmit(domain.Format(), XedPaths.Targets().Path("xed.instblocks.domain", FS.ext("txt")));
            },
            () => Channel.TableEmit(XedRegMap.Service.REntries, XedPaths.Targets().Table<RegMapEntry>("rmap")),
            () => Channel.TableEmit(XedRegMap.Service.XEntries, XedPaths.Targets().Table<RegMapEntry>("xmap")),
            () => EmitChipCodes(Symbols.symkinds<ChipCode>()),
            () => EmitBroadcastDefs(Xed.broadcasts(Symbols.kinds<BroadcastKind>())),
            () => EmitCpuIdDataset(CalcCpuIdDataset(XedPaths.DocSource(XedDocKind.CpuId))),
            () => {
                var chips = Chips(XedPaths.DocSource(XedDocKind.ChipMap));
                Emit(chips);
                var forms = XedFormImports.calc(XedPaths.DocSource(XedDocKind.FormData));
                EmitFormImports(forms);
                var inst = CalcChipInstructions(forms, chips);
                Emit(inst);
            },
            () => {
                var widths = XedImport.Widths;
                EmitOpWidths(widths.Details);
                EmitPointerWidths(widths.Pointers.Where(x => x.Kind != 0).Map(x => x.ToRecord()));
            }
        );

        var instdefs = XedInstDefParser.parse(XedPaths.DocSource(XedDocKind.EncInstDef));
        var patterns = InstPattern.load(instdefs);
        var tables = CalcRuleTables();

        var cds = datasets(tables);
        var ct = CellTables.tables(cds);
        var usage = Xed.fields(ct);
        Emit(usage);
        Emit(CellTables.records(ct));
        EmitSeq();
        EmitRuleTables(tables);
        Emit(CalcDefRows(tables));

        var layouts = LayoutCalcs.layouts(patterns);    
        EmitLayouts(patterns);

        //var groups = XedPatterns.groups(patterns).Values.ToArray().Sort();
        //EmitInstGroups(groups);
        Channel.TableEmit(InstPattern.records(patterns), Targets.Table<InstPatternRecord>());

        var instfields = XedPatterns.fieldrows(patterns);
        var opdetail = Xed.opdetails(patterns);
        var specs = alloc<InstOpSpec>(opdetail.Count);
        for(var i=0; i<opdetail.Count; i++)
            seek(specs,i) = Xed.spec(opdetail[i]);
        Emit(specs);
        EmitFlagEffects(patterns);
        EmitRuleSchema(ct);
        Emit(opcodes(patterns));
        Emit(CalcInstOpRows(opdetail));
        Emit(CalcOpClasses(opdetail));
        EmitInstSigs(patterns);
        EmitInstAttribs(patterns);
        Emit(MacroMatches());
        Emit(MacroDefs());
        Emit(RuleExpressions(ct));
    }

    void Emit(AsmOpCodeClass @class, ReadOnlySpan<InstGroupSeq> src)
        => Channel.TableEmit(src, XedPaths.ImportTable<InstGroupSeq>(@class.ToString().ToLower()));

    void EmitInstGroups(Index<InstGroup> src)
    {
        iter(Xed.CalcInstGroupLookup(src,PllExec), kvp => Emit(kvp.Key, kvp.Value), PllExec);

        const string RenderPattern = "{0,-8} | {1,-12} | {2,-18} | {3,-8} | {4,-8} | {5,-6} | {6,-6} | {7,-6} | {8,-6} | {9,-26} | {10,-22} | {11}";
        var counter = 0u;
        var dst = text.buffer();
        var k=0u;
        dst.AppendLineFormat(RenderPattern, "Seq", "PatternId", "Instruction", "Mod", "Lock", "Mode", "RexW", "Rep", "Index", "OpCode", "OpCodeBytes", "Form");
        for(var i=0; i<src.Count; i++)
        {
            ref readonly var group = ref src[i];
            var opcode = AsmOpCode.Empty;
            foreach(var member in group.Members)
            {
                if(opcode.IsEmpty)
                    opcode = member.OpCode;

                if(opcode != member.OpCode)
                {
                    dst.AppendLine();
                    opcode = member.OpCode;
                }

                dst.AppendLineFormat(RenderPattern,
                    k++,
                    member.PatternId,
                    member.Class,
                    member.Mod,
                    member.Lock,
                    member.Mode,
                    member.RexW,
                    member.Rep,
                    member.Index,
                    member.OpCode,
                    member.OpCode.Value,
                    member.InstForm
                    );

                counter++;
            }

            dst.AppendLine();
        }
        Channel.FileEmit(dst.Emit(), counter, XedPaths.Imports().Path("xed.inst.groups", FileKind.Csv));
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
        const string RenderPattern = "{0,-6} | {1,-6} | {2,-6} | {3,-3} | {4,-32} | {5,-32}";
        var headers = new string[]{"Seq", "Index", "Kind", "C", "Rule", "Field"};
        var dst = text.emitter();
        dst.AppendLineFormat(RenderPattern, headers);
        var j=z8;
        var rule = src.First.Rule;
        for(var i=0; i<src.Count; i++,j++)
        {
            ref readonly var u = ref src[i];
            if(u.Rule != rule)
            {
                j=0;
                rule = u.Rule;
            }

            dst.AppendLineFormat(RenderPattern, i, j, u.TableKind, u.Consequent, u.RuleName, u.Field);
        }

        Channel.FileEmit(dst.Emit(), XedPaths.Imports().Path("xed.rules.fields.deps", FileKind.Csv));
    }


    void Emit(ReadOnlySeq<InstOpSpec> src)
    {
        Channel.TableEmit(src, Targets.Table<InstOpSpec>());
    }

    void EmitInstPatterns(XedRuleBlocks blocks)
    {
        var path =  XedPaths.DocSource(XedDocKind.RuleBlocks);
        var patterns = bag<XedInstPattern>();
        XedZ.BlockLines(path, spec => {
            var attribs = list<Attribute>();
            var result = true;
            var pattern = new XedInstPattern{Form = spec.Form};
            patterns.Add(pattern);

            foreach(var line in spec.Lines)
            {                
                if(XedZ.parse(line, out Attribute attrib))
                {
                    attribs.Add(attrib);
                    switch(attrib.Field)
                    {
                        case InstBlockField.iclass:
                        {
                            XedParsers.parse(attrib.Value, out pattern.Instruction);
                        }
                        break;
                        case InstBlockField.pattern:
                        {
                            result = XedInstParser.parse(attrib.Value, out pattern.Body);
                        }
                        break;
                        
                        case InstBlockField.operands:
                        break;
                    }
                }
                if(!result)                
                {
                    Channel.Error(line);
                    break;
                }                
            }
        });

        var records = patterns.OrderBy(x => x.Form).ThenBy(x => x.Body.CellCount).Array().Sort();
        var form = XedInstForm.Empty;
        var j=z8;
        for(var i=0u; i<records.Length; i++)
        {
            ref var record = ref seek(records,i);
            if(record.Form != form)
            {
                j=0;
                form = record.Form;
            }
            record.Seq = i;
            record.Index=j++;
        }

        Channel.TableEmit(records, XedPaths.ImportTable<XedInstPattern>());
    }

    void EmitLayouts(ReadOnlySeq<InstPattern> src)
        => Emit(CalcLayouts(src));

    void Emit(InstLayouts src)
    {
        Channel.TableEmit(src.Records.View, XedPaths.ImportTable<InstLayoutRecord>(), TextEncodingKind.Asci);
    }

    public InstLayouts CalcLayouts(ReadOnlySeq<InstPattern> src)
        => LayoutCalcs.layouts(src);

    void EmitRuleSchema(CellTables tables)
    {
        exec(PllExec,
            () => EmitRuleMetrics(tables),
            () => EmitTableStats(tables)
            //() => EmitGrids(tables)
            );
    }

    class XedRuleBuffers
    {
        public readonly ConcurrentDictionary<RuleTableKind,Index<TableCriteria>> Target = new();
    }

    static IDbArchive Targets
        => XedPaths.Imports();

    public ChipMap Chips(FilePath src)
    {
        var kinds = Symbols.index<InstIsaKind>();
        var chip = ChipCode.INVALID;
        var chips = dict<ChipCode,ChipIsaKinds>();
        using var reader = src.LineReader(TextEncodingKind.Asci);
        while(reader.Next(out var line))
        {
            if(line.StartsWith(Chars.Hash))
                continue;

            var i = line.Index(Chars.Colon);
            if(i != -1)
            {
                var name = line.Left(i).Trim();
                if(blank(name))
                    continue;

                if(XedParsers.parse(name, out chip))
                {
                    if(!chips.TryAdd(chip, new ChipIsaKinds(chip)))
                        Errors.Throw(Msg.DuplicateChipCode.Format(chip));
                }
                else
                    Errors.Throw(Msg.ChipCodeNotFound.Format(name));
            }
            else
            {
                var isaKinds = line.Content.SplitClean(Chars.Tab).Trim().Select(x => Enums.parse<InstIsaKind>(x,0)).Where(x => x != 0).Array();
                chips[chip].Add(isaKinds);
                if(chips.TryGetValue(chip, out var entry))
                    entry.Add(isaKinds);
            }
        }
        var codes = Symbols.index<ChipCode>();
        var buffer = dict<ChipCode,InstIsaKinds>();
        for(var i=0; i<codes.Count; i++)
        {
            var code = codes[i].Kind;
            if(chips.TryGetValue(code, out var entry))
                buffer[code] = entry.Kinds;
            else
                buffer[code] = InstIsaKinds.Empty;
        }
        return new ChipMap(buffer);
    }

    public static XedRuleCells datasets(XedRuleTables tables)
    {
        var lix = z16;
        var emitter = text.emitter();
        emitter.AppendLine(string.Format("{0,-5} | {1,-5} | {2,-48} | {3}", "Seq", "Lix", "Key", "Value"));
        ref readonly var src = ref tables.Specs();
        var sigs = src.Keys;
        var dst = dict<RuleSig,Index<RuleCell>>();
        for(var i=z16; i<sigs.Length; i++)
        {
            ref readonly var sig = ref skip(sigs,i);
            var kcells = list<RuleCell>();
            var table = src[sig];
            ref readonly var rows = ref table.Rows;
            for(var j=z16; j<rows.Count; j++)
            {
                ref readonly var row = ref rows[j];
                ref readonly var keys = ref row.Keys;
                for(var k=z8; k<row.CellInfo.Count; k++)
                {
                    ref readonly var info = ref row.CellInfo[k];
                    ref readonly var data = ref info.Data;
                    ref readonly var logic = ref info.Logic;
                    ref readonly var key = ref keys[k];
                    var size = FieldDefs.size(key.Field, key.CellType);
                    var result = false;
                    var cell = RuleCell.Empty;

                    switch(info.Kind)
                    {
                        case CK.BitLit:
                        {
                            result = XedParsers.parse(data, out uint5 value);
                            cell = new RuleCell(key, value, size);
                        }
                        break;

                        case CK.IntVal:
                        {
                            result = XedParsers.parse(data, out ushort value);
                            cell = new RuleCell(key, value, size);
                        }
                        break;

                        case CK.HexLit:
                        {
                            result = XedParsers.parse(data, out Hex8 value);
                            cell = new RuleCell(key, value, size);
                        }
                        break;

                        case CK.Keyword:
                        {
                            result = XedParsers.parse(data, out RuleKeyword value);
                            cell = new RuleCell(key, value, size);
                        }
                        break;

                        case CK.SegVar:
                        {
                            result = XedParsers.parse(data, out SegVar value);
                            cell = new RuleCell(key, value, size);
                        }
                        break;

                        case CK.WidthVar:
                        {
                            result = XedParsers.parse(data, out WidthVar wv);
                            cell = new RuleCell(key, wv, size);
                        }
                        break;

                        case CK.NtCall:
                        {
                            result = XedParsers.parse(data, out Nonterminal value);
                            cell = new RuleCell(key, value, size);
                        }
                        break;

                        case CK.Operator:
                        {
                            if(info.Operator.IsNonEmpty && info.Field == 0)
                            {
                                result = true;
                                cell = new RuleCell(key, OperatorKind.Impl, size);
                            }
                            else
                            {
                                result = XedRuleSpecs.ruleop(data, out RuleOperator value);
                                cell = new RuleCell(key, value, size);
                            }
                        }
                        break;

                        case CK.FieldSeg:
                        {
                            result = seg(data, out FieldSeg value);
                            cell = new RuleCell(key, value, size);
                        }
                        break;
                        case CK.InstSeg:
                        {
                            result = CellParser.parse(data, out InstFieldSeg value);
                            cell = new RuleCell(key, value, size);
                        }
                        break;

                        case CK.NtExpr:
                        case CK.EqExpr:
                        case CK.NeqExpr:
                        {
                            result = CellParser.expr(data, out CellExpr value);
                            if(value.Field == 0)
                                term.warn(AppMsg.ParseFailure.Format(nameof(FieldKind), data));
                            cell = new RuleCell(key, value, size);
                        }
                        break;

                        default:
                            Errors.Throw(AppMsg.UnhandledCase.Format(info.Kind));
                        break;
                    }

                    if(!result)
                        Errors.Throw(info.Field.ToString() + ":="  + keys[k].Format() + $":{info.Kind}" + "='" + data + "'");

                    emitter.AppendLineFormat(format(cell));
                    kcells.Add(cell);
                }
            }

            dst.Add(sig, kcells.ToIndex());
        }

        return XedRuleCells.create(dst, emitter.Emit());
    }

    static bool seg(string src, out FieldSeg dst)
    {
        dst = FieldSeg.Empty;
        var i = text.index(src, Chars.LBracket);
        var j = text.index(src, Chars.RBracket);
        var result = i>0 && j>i;
        if(result)
        {
            XedParsers.parse(text.left(src,i), out FieldKind field);
            XedParsers.segdata(src, out var data);
            result = field != 0 && text.nonempty(data);
            if(result)
            {
                var literal = XedParsers.IsBinaryLiteral(data);
                if(literal)
                    dst = FieldSeg.literal(field, data);
                else
                    dst = FieldSeg.symbolic(field, data);
            }
        }
        else
        {
            dst = FieldSeg.symbolic(src);
            result = true;
        }

        return result;
    }

    static string format(in RuleCell cell)
        => string.Format("{0:D5} | {1:D5} | {2,-48} | {3}", cell.Key.Index, cell.Key.Index, cell.Key.Format(), cell.Format());
 
    static XedRuleTables tables(XedRuleBuffers buffers)
    {
        ref readonly var src = ref buffers.Target;
        var enc = src[RuleTableKind.ENC];
        var dec = src[RuleTableKind.DEC];
        var dst = enc.Append(dec).Where(x => x.IsNonEmpty).Sort();
        for(var i=0u; i<dst.Count; i++)
            dst[i] = dst[i].WithId(i);
        return new XedRuleTables(dst, XedRuleSpecs.tables(dst));
    }

    static XedWidths _Widths;

    static XedImport Instance;

    static XedImport()
    {
        Instance = new();
        _Widths = XedWidths.FromSource(XedPaths.DocSource(XedDocKind.Widths));
    }
    
    public static bool detail(WidthCode code, out OpWidthDetail dst)
        => _Widths.Detail(code, out dst);

    public static ref readonly XedWidths Widths => ref _Widths;

    ChipInstructions CalcChipInstructions(ReadOnlySeq<FormImport> forms, ChipMap map)
    {
        var codes = Symbols.index<ChipCode>();
        var formisa = forms.Select(x => (x.InstForm.Kind, x.IsaKind)).ToDictionary();
        var isakinds = formisa.Values.ToHashSet();
        var isaforms = cdict<InstIsaKind,HashSet<FormImport>>();
        var dst = cdict<ChipCode,ReadOnlySeq<FormImport>>();
        iter(isakinds, k => isaforms[k] = new());
        iter(forms, f => isaforms[f.IsaKind].Add(f));
        iter(codes.Kinds, chip => {
            var kinds = map[chip];
            var matches = sys.bag<FormImport>();
            iter(kinds, k => {
                if(isaforms.TryGetValue(k, out var forms))
                    matches.AddRange(forms);
            });
                dst.TryAdd(chip,matches.ToArray().Sort().Resequence());         
            }
        ,true);
        return new (dst);
    }

    static void EmitRulePage(in TableCriteria src)
    {
        var formatter = CsvTables.formatter<TableDefRow>();
        using var emitter = XedPaths.RuleTable(src.Sig).AsciEmitter();
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

    void EmitRuleTables(XedRuleTables src)
        => iter(src.Criteria(), table => EmitRulePage(table), PllExec);
    
    static XedRuleTables CalcRuleTables()
    {
       var dst = new XedRuleBuffers();
        exec(PllExec,
            () => dst.Target.TryAdd(RuleTableKind.ENC, XedRuleSpecs.criteria(RuleTableKind.ENC)),
            () => dst.Target.TryAdd(RuleTableKind.DEC, XedRuleSpecs.criteria(RuleTableKind.DEC))
            );

        return tables(dst);
    }

    void EmitBroadcastDefs(ReadOnlySeq<AsmBroadcast> src)
        => Channel.TableEmit(src, Targets.Table<AsmBroadcast>());

    void EmitFormImports(ReadOnlySeq<FormImport> src)
        => Channel.TableEmit(src, Targets.Table<FormImport>());

    void Emit(ReadOnlySpan<FieldImport> src)
        => Channel.TableEmit(src, XedPaths.Imports().Table<FieldImport>());

    void EmitPointerWidths(ReadOnlySpan<PointerWidthInfo> src)
        => Channel.TableEmit(src, Targets.Table<PointerWidthInfo>());

    void EmitOpWidths(ReadOnlySpan<OpWidthDetail> src)
        => Channel.TableEmit(src, Targets.Table<OpWidthDetail>());

    void EmitIsaSpecs(ReadOnlySeq<InstIsaSpec> src)
        => Channel.TableEmit(src, Targets.Table<InstIsaSpec>());

    void EmitCpuIdDataset(CpuIdDataset src)
    {
        EmitIsaSpecs(src.InstIsaSpecs);
        Channel.TableEmit(src.CpuIdSpecs, Targets.Table<CpuIdSpec>());
    }

    void EmitChipCodes(ReadOnlySeq<SymKindRow> src)
        => Channel.TableEmit(src, Targets.Path("xed.chips", FileKind.Csv));

    static CpuIdDataset CalcCpuIdDataset(FilePath src)
    {
        var parser = new CpuIdImportCalcs();
        parser.Run(src.ReadLines().Where(text.nonempty));
        return new (parser.Parsed.CpuIdSpecs, parser.Parsed.IsaSpecs);
    }

    void Emit(ChipInstructions src)
        => piter(src.Query(), kv => Channel.TableEmit(kv.Right, XedPaths.Imports().Sources("isaforms").Path(FS.file(string.Format("xed.isa.{0}", kv.Left), FS.Csv))));                    

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

        Channel.FileEmit(dst.Emit(), counter, Targets.Path(FS.file("xed.chipmap", FS.Csv)));
    }

    void Emit(ReadOnlySpan<RuleCellRecord> src)
        => Channel.TableEmit(src, XedPaths.ImportTable<RuleCellRecord>());

    public void Emit(ReadOnlySpan<FieldDef> src)
        => Channel.TableEmit(src, XedPaths.ImportTable<FieldDef>());

    public void EmitSeq()
    {
        exec(PllExec,
            () => EmitSeq(CellParser.ruleseq()),
            () => Emit(XedRuleSeq.controls(), XedRuleSeq.defs())
            );
    }

    void EmitSeq(Index<RuleSeq> src)
    {
        var dst = text.buffer();
        iter(src, x => dst.AppendLine(x.Format()));
        Channel.FileEmit(dst.Emit(), src.Count, Targets.Path("rules.seq", FS.Txt));
    }

    void Emit(Index<SeqControl> controls, Index<SeqDef> defs)
    {
        var dst = text.emitter();
        for(var i=0; i<controls.Count; i++)
        {
            if(i != 1)
                dst.AppendLine();

            dst.AppendLine(controls[i].Format());
        }

        for(var i=0; i<defs.Count; i++)
        {
            dst.AppendLine();
            dst.AppendLine(defs[i].Format());
        }

        Channel.FileEmit(dst.Emit(), controls.Count + defs.Count, Targets.Path("rules.seq.reflected", FS.Txt));
    }

    void EmitRuleMetrics(CellTables src)
    {
        var dst = text.emitter();
        for(var i=0; i<src.TableCount; i++)
            dst.AppendLine(CalcTableMetrics(src[i]));
        Channel.FileEmit(dst.Emit(), src.TableCount, XedPaths.DbTarget("rules.metrics", FileKind.Txt));
    }

    string CalcTableMetrics(in CellTable table)
    {
        var dst = text.emitter();
        dst.AppendLine(string.Format("{0,-32} {1}", table.Sig, XedPaths.CheckedRulePage(table.Sig)));
        dst.AppendLine(RP.PageBreak120);
        dst.AppendLine();
        for(var i=0; i<table.RowCount; i++)
        {
            ref readonly var row = ref table[i];

            if(i != 0)
                dst.AppendLine();

            var size = DataSize.Empty;
            dst.AppendLine(RP.PageBreak120);
            for(var j=0; j<row.CellCount; j++)
            {
                ref readonly var cell = ref row[j];
                ref readonly var key = ref cell.Key;
                dst.AppendLineFormat("{0} | {1} | {2,-26} | {3}", key, cell.Size.Format(2,2), XedRender.format(cell.Field), cell);
            }

            dst.AppendLine(RP.PageBreak120);
            dst.AppendLine(row.Expression);
        }

        dst.AppendLine();
        dst.AppendLine(RP.PageBreak120);

        return dst.Emit();
    }

    void EmitTableStats(CellTables src)
    {
        const string RulePattern = "{0:D2} | {1,-12} | {2,-8} | {3,-32} | ";
        const string FieldPattern = "{0,-12} {1,-24}";
        var grids = XedGrids.grids(src);
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

    void Emit(ReadOnlySeq<XedInstOpCode> src)
        => Channel.TableEmit(src, XedPaths.ImportTable<XedInstOpCode>());

    public static Index<XedInstOpCode> opcodes(Index<InstPattern> src)
    {
        var count = src.Count;
        var buffer = alloc<XedInstOpCode>(count);

        for(var i=0u; i<count; i++)
        {
            ref var dst = ref seek(buffer,i);
            poc(src[i], out seek(buffer,i));
        }

        buffer.Sort(new PatternOrder(true));

        var oc = AsmOpCode.Empty;
        var @class = XedInstClass.Empty;
        var oci = z8;
        for(var i=0u; i<count; i++)
        {
            ref var dst = ref seek(buffer,i);
            if(i == 0)
            {
                oc = dst.OpCode;
                @class = dst.InstClass;
            }

            if(oc != dst.OpCode || @class != dst.InstClass)
            {
                oc = dst.OpCode;
                @class = dst.InstClass;
                oci = z8;
            }

            dst.Index = oci++;
        }

        buffer.Sort(new PatternOrder());
        for(var i=0u; i<count; i++)
            seek(buffer,i).Seq = i;

        return buffer;
    }

    static void poc(InstPattern src, out XedInstOpCode dst)
    {
        dst.Seq = 0u;
        dst.Index = z8;
        dst.PatternId = (ushort)src.PatternId;
        dst.MapName = AsmOpCodes.name(src.OpCode.Kind);
        dst.Value = src.OpCode.Value;
        dst.InstClass = src.InstClass.Classifier;
        dst.Mode = XedCells.mode(src.Cells);
        dst.Lock = XedCells.@lock(src.Cells);
        dst.Mod = XedCells.mod(src.Cells);
        dst.RexW = XedCells.rexw(src.Cells);
        dst.Rep = XedCells.rep(src.Cells);
        dst.Layout = src.Layout;
        dst.Expr = src.Expr;
        dst.OpCode = src.OpCode;
    }

    static ReadOnlySeq<InstOpRow> CalcInstOpRows(ReadOnlySeq<InstOpDetail> src)
    {
        var count = src.Count;
        var rows = alloc<InstOpRow>(count);
        for(var i=0; i<count; i++)
        {
            ref readonly var detail = ref src[i];
            ref var dst = ref rows[i];
            Require.invariant(detail.InstClass.Kind != 0);
            dst.Pattern = detail.Pattern;
            dst.InstClass = Xed.classifier(detail.InstClass);
            dst.OpCode = detail.OpCode;
            dst.Mode = detail.Mode;
            dst.Lock = detail.Lock;
            dst.Mod = detail.Mod;
            dst.RexW = detail.RexW;
            dst.OpCount = detail.OpCount;
            dst.Index = detail.Index;
            dst.Name = detail.Name;
            dst.Kind = detail.Kind;
            dst.Action = detail.Action;
            dst.WidthCode = detail.WidthCode;
            dst.EType = detail.ElementType;
            dst.EWidth = detail.ElementWidth;
            dst.RegLit = detail.RegLit;
            dst.Modifier = detail.Modifier;
            dst.Visibility = detail.Visibility;
            dst.NonTerminal = detail.Rule;
            dst.BitWidth = detail.BitWidth;
            dst.GprWidth = detail.GrpWidth;
            dst.SegInfo = detail.SegInfo;
            dst.ECount = detail.ElementCount;
            dst.SourceExpr = detail.SourceExpr;
        }
        return rows;
    }    

    static ReadOnlySeq<InstOpClass> CalcOpClasses(ReadOnlySeq<InstOpDetail> src)
    {
        var buffer = sys.bag<InstOpClass>();
        iter(src, op => buffer.Add(Xed.opclass(op)), true);
        var dst = buffer.Array().Distinct().Sort();
        for(var i=0u; i<dst.Length; i++)
            seek(dst,i).Seq = i;
        return dst;
    }    

    void Emit(ReadOnlySpan<InstOpRow> src)
        => Channel.TableEmit(src, XedPaths.ImportTable<InstOpRow>());

    void Emit(ReadOnlySpan<InstOpClass> src)
        => Channel.TableEmit(src, XedPaths.ImportTable<InstOpClass>());

    void EmitInstAttribs(Index<InstPattern> src)
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

    void Emit(ReadOnlySpan<MacroMatch> src)
        => Channel.TableEmit(src, XedPaths.ImportTable<MacroMatch>());

    void Emit(ReadOnlySpan<MacroDef> src)
        => Channel.TableEmit(src, XedPaths.ImportTable<MacroDef>());

    void Emit(ReadOnlySpan<RuleExpr> src)
        => Channel.TableEmit(src, XedPaths.ImportTable<RuleExpr>());

    void EmitPatternRecords(Index<InstPattern> src)
        => Channel.TableEmit(InstPattern.records(src), XedPaths.ImportTable<InstPatternRecord>());

    static ReadOnlySeq<MacroMatch> MacroMatches()
        => mapi(RuleMacros.matches().Values.ToArray().Sort(), (i,m) => m.WithSeq((uint)i));

    void EmitFlagEffects(Index<InstPattern> src)
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
                writer.AppendLineFormat(RenderPattern,
                    XedRender.format(pattern.InstClass),
                    e.Flag.ToString().ToLower(),
                    XedRender.format(e.Effect)
                    );
                counter++;
            }
        }

        Channel.EmittedFile(emitting,counter);
    }

    static ReadOnlySeq<MacroDef> MacroDefs()
    {
        var src = RuleMacros.specs();
        var count = src.Length;
        var buffer = alloc<MacroDef>(count);
        for(var i=0u; i<count; i++)
        {
            ref readonly var m = ref src[i];
            var expansions = m.Expansions;
            var j=0;
            var k = m.Expansions.Count;
            ref var dst = ref seek(buffer,i);
            dst.Seq = i;
            dst.Fields = (byte)expansions.Count;
            dst.MacroName = m.Name;
            if(k >= 1)
            {
                var e = expansions[j++];
                dst.E0 = new MacroExpansion(e.Field, e.Operator, e.Value);
            }
            if(k >= 2)
            {
                var e = expansions[j++];
                dst.E1 = new MacroExpansion(e.Field, e.Operator, e.Value);
            }
            if(k >= 3)
            {
                var e = expansions[j++];
                dst.E2 = new MacroExpansion(e.Field, e.Operator, e.Value);
            }
            if(k >= 4)
            {
                var e = expansions[j++];
                dst.E3 = new MacroExpansion(e.Field, e.Operator, e.Value);

            }
            if(k >= 5)
            {
                var e = expansions[j++];
                dst.E4 = new MacroExpansion(e.Field, e.Operator, e.Value);
            }
        }

        return buffer;
    }


    static Index<RuleExpr> RuleExpressions(CellTables src)
    {
        var dst = sys.alloc<RuleExpr>(src.RowCount);
        var k=z16;
        for(var i=0; i<src.TableCount; i++)
        {
            ref readonly var table = ref src[i];
            for(var j=0; j<table.RowCount; j++, k++)
            {
                ref readonly var row = ref table[j];
                seek(dst,k) = new RuleExpr(k, table.Sig, (byte)row.RowIndex, row.Expression.Format());
            }
        }

        return dst;
    }

    static Index<TableDefRow> CalcDefRows(XedRuleTables src)
    {
        var buffer = list<TableDefRow>();
        ref readonly var specs = ref src.Specs();
        var k=0u;
        for(var i=0u; i<specs.TableCount; i++)
        {
            ref readonly var spec = ref specs[i];
            for(var j=0u; j<spec.RowCount; j++, k++)
            {
                ref readonly var row = ref spec[j];
                var dst = TableDefRow.Empty;
                dst.Seq = k;
                dst.TableId = spec.TableId;
                dst.Index = j;
                dst.Kind = spec.TableKind;
                dst.Name = spec.Name;
                dst.Statement = row.Format();
                buffer.Add(dst);
            }
        }
        return buffer.ToArray();
    }

    void Emit(ReadOnlySeq<TableDefRow> src)
        => Channel.TableEmit(src, XedPaths.ImportTable<TableDefRow>());
}
