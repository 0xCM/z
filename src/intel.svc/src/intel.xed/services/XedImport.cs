//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static sys;
using static XedModels;
using static XedRules;
using static XedZ;

using CK = XedRules.RuleCellKind;

public class XedImport : WfSvc<XedImport>
{     
    class XedRuleBuffers
    {
        public readonly ConcurrentDictionary<RuleTableKind,Index<TableCriteria>> Target = new();
    }

    XedFlows DataFlow => Wf.XedFlows();

    static IDbArchive Targets
        => XedPaths.Imports();

    static uint bitwidth(NativeTypeWidth src)
    {
        var dst = (uint)src;
        if(dst == 1)
            dst = 8;
        return dst;
    }

    const byte FieldCount = 128;

    static uint width(Type src)
    {
        var result = z32;
        var attrib = src.Tag<DataWidthAttribute>();
        if(src.IsEnum)
            result = bitwidth(PrimalBits.width(Enums.@base(src)));
        else if(attrib.IsSome())
            result = attrib.MapRequired(w => w.NativeWidth == 0 ?  (uint)w.PackedWidth: (uint)w.NativeWidth);
        if(result != 0)
            return result;
        if(src == typeof(bit) || src == typeof(byte))
            result = 8;
        else if(src == typeof(ushort))
            result = 16;
        return result;
    }

    public ReadOnlySeq<TableCriteria> RuleCriteria(RuleTableKind kind)
        => XedRuleSpecs.criteria(kind);

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
                buffer[code] = XedModels.InstIsaKinds.Empty;
        }
        return new ChipMap(buffer);
    }

    public static FieldDefs fields()
    {
        var fields = typeof(XedOperandState).InstanceFields().Tagged<RuleFieldAttribute>();
        var count = fields.Length;
        var defs = new FieldDefs(sys.alloc<FieldDef>(FieldCount), sys.alloc<FieldDef>(FieldCount));
        var positioned = defs.ByPos;
        var indexed = defs.Indexed;
        var packed = z32;
        var aligned = z32;

        for(var i=z8; i<count; i++)
        {
            ref readonly var field = ref skip(fields,i);
            ref var dst = ref positioned[i + 1];

            var tag = field.Tag<RuleFieldAttribute>().Require();
            var awidth = width(field.FieldType);
            var pwidth = tag.Width;
            var index = (byte)tag.Kind;
            dst.Pos = i;
            dst.Field = tag.Kind;
            dst.Index = index;
            dst.DataType = tag.EffectiveType.DisplayName();
            dst.NativeType = field.FieldType.DisplayName();
            dst.PackedWidth = pwidth;
            dst.AlignedWidth = awidth;
            dst.PackedOffset = packed;
            dst.AlignedOffset = aligned;
            dst.Description = tag.Description;
            indexed[(FieldKind)index] = dst;
            packed += pwidth;
            aligned += awidth;
        }

        defs.SortIndex();
        return defs;
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
                    var size = XedFields.size(key.Field, key.CellType);
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

    public static Index<RuleCellRecord> records(CellTables src)
    {
        var seq = z16;
        var dst = alloc<RuleCellRecord>(src.CellCount);
        for(var i=0; i<src.TableCount; i++)
        {
            ref readonly var table = ref src[i];
            for(var j=z16; j<table.RowCount; j++)
            {
                ref readonly var row = ref table[j];
                for(var k=0; k<row.CellCount; k++, seq++)
                    seek(dst,seq) = record(seq, row[k]);
            }
        }
        return dst;
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

    static RuleCellRecord record(ushort seq, in RuleCell cell)
    {
        ref readonly var value = ref cell.Value;
        var dst = RuleCellRecord.Empty;
        dst.Seq = seq++;
        dst.Index = cell.Key.Index;
        dst.Table = cell.TableIndex;
        dst.Row = cell.RowIndex;
        dst.Col = cell.CellIndex;
        dst.Logic = cell.Logic;
        dst.Type = value.CellKind;
        dst.Kind = cell.TableKind;
        dst.Rule = cell.Rule.TableName;
        dst.Field = cell.Field;
        dst.Value = value;
        dst.Expression = XedRender.format(cell.Value);
        dst.Op = cell.Operator();
        return dst;
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

    public ChipInstructions CalcChipInstructions(ReadOnlySeq<FormImport> forms, ChipMap map)
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

    static XedRuleTables CalcRuleTables()
    {
        var tables = new XedRuleTables();
        var dst = new XedRuleBuffers();
        exec(PllExec,
            () => dst.Target.TryAdd(RuleTableKind.ENC, XedRuleSpecs.criteria(RuleTableKind.ENC)),
            () => dst.Target.TryAdd(RuleTableKind.DEC, XedRuleSpecs.criteria(RuleTableKind.DEC))
            );

        return XedImport.tables(dst);
    }


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
            () => DataFlow.EmitChipCodes(Symbols.symkinds<ChipCode>()),
            () => DataFlow.EmitBroadcastDefs(Xed.broadcasts(Symbols.kinds<BroadcastKind>())),
            () => DataFlow.EmitCpuIdDataset(DataFlow.CalcCpuIdDataset(XedPaths.DocSource(XedDocKind.CpuId))),
            () => {
                var chips = Chips(XedPaths.DocSource(XedDocKind.ChipMap));
                Emit(chips);
                var forms = XedFormImports.calc(XedPaths.DocSource(XedDocKind.FormData));
                DataFlow.EmitFormImports(forms);
                var inst = CalcChipInstructions(forms, chips);
                Emit(inst);
            },
            () => {
                var widths = XedImport.Widths;
                DataFlow.EmitOpWidths(widths.Details);
                DataFlow.EmitPointerWidths(widths.Pointers.Where(x => x.Kind != 0).Map(x => x.ToRecord()));
            }
        );

        var defs = XedInstDefParser.parse(XedPaths.DocSource(XedDocKind.EncInstDef));
        var patterns = InstPattern.load(defs);
        //var tables = CalcRuleTables();
        //var cds = datasets(tables);
        var fields = XedImport.fields();
        Emit(fields.Positioned);
        // var ct = CellTables.from(cds);
        // var cr = XedRuleTables.records(ct);
        // Emit(cr);        
    }

    void Emit(ChipInstructions src)
    {
        piter(src.Query(), kv => Channel.TableEmit(kv.Right, XedPaths.Imports().Sources("isaforms").Path(FS.file(string.Format("xed.isa.{0}", kv.Left), FS.Csv))));                    
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

        Channel.FileEmit(dst.Emit(), counter, Targets.Path(FS.file("xed.chipmap", FS.Csv)));
    }

    void Emit(ReadOnlySpan<RuleCellRecord> src)
        => Channel.TableEmit(src, XedPaths.RuleTable<RuleCellRecord>());

    public void Emit(ReadOnlySpan<FieldDef> src)
        => Channel.TableEmit(src, XedPaths.Table<FieldDef>());
}
