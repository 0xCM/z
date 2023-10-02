//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static sys;
using static XedModels;
using static XedRules;

using CK = XedRules.RuleCellKind;

public class XedImport : WfSvc<XedImport>
{     
    class XedRuleBuffers
    {
        public readonly ConcurrentDictionary<RuleTableKind,Index<TableCriteria>> Target = new();
    }


    XedFlows DataFlow => Wf.XedFlows();

    static XedPaths XedPaths => XedPaths.Service;

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

    static XedWidths ParseWidths(FilePath src)
    {
        var buffer = dict<WidthCode,OpWidthDetail>();
        var symbols = Symbols.index<WidthCode>();
        using var reader = src.Utf8LineReader();
        var result = Outcome.Success;
        while(reader.Next(out var line))
        {
            var content = text.trim(line.Content);
            if(text.empty(content) || content.StartsWith(Chars.Hash))
                continue;

            var i = text.index(content, Chars.Hash);
            if(i>0)
                content = text.left(content,i);

            var cells = text.split(text.despace(content), Chars.Space);
            if(cells.Length < 3)
            {
                result = (false, content);
                break;
            }

            ref readonly var code = ref skip(cells,0);
            ref readonly var xtype = ref skip(cells,1);
            ref readonly var wdefault = ref skip(cells,2);

            var dst = OpWidthDetail.Empty;
            result = XedParsers.parse(code, out dst.Code);

            if(result.Fail)
            {
                result = (false, Msg.ParseFailure.Format(nameof(dst.Code), code));
                break;
            }

            if(dst.Code == 0)
                continue;

            symbols.MapKind(dst.Code, out var sym);
            dst.Name = sym.Expr.Format();
            result = XedParsers.parse(xtype, out dst.ElementType);
            if(result.Fail)
            {
                result = (false,Msg.ParseFailure.Format(nameof(dst.ElementType), xtype));
                break;
            }

            dst.ElementWidth = XedWidths.width(dst.Code, dst.ElementType);

            result = ParseWidthValue(wdefault, out dst.Width16);
            if(result.Fail)
            {
                result = (false,Msg.ParseFailure.Format(nameof(dst.Width16), wdefault));
                break;
            }
            else
            {
                dst.Width32 = dst.Width16;
                dst.Width64 = dst.Width16;
            }

            if(cells.Length >= 4)
                result = ParseWidthValue(skip(cells,3), out dst.Width32);

            if(result.Fail)
            {
                result = (false,Msg.ParseFailure.Format(nameof(dst.Width32), skip(cells,3)));
                break;
            }

            if(cells.Length >= 5)
                result = ParseWidthValue(skip(cells,4), out dst.Width64);

            if(result.Fail)
            {
                result = (false,Msg.ParseFailure.Format(nameof(dst.Width64), skip(cells,4)));
                break;
            }

            dst.SegType = BitSegType.define(Xed.nclass(dst.Code), dst.Width64, dst.ElementWidth);
            buffer.TryAdd(dst.Code, dst);
        }

        if(!result)
            sys.@throw(result.Message);
            
        return new(buffer);
    }

    static bool ParseWidthValue(string src, out ushort bits)
    {
        var result = true;
        bits = 0;
        var i = text.index(src, "bits");
        if(i > 0)
            result = DataParser.parse(text.left(src,i), out bits);
        else
        {
            result = DataParser.parse(src, out ushort bytes);
            if(result)
                bits = (ushort)(bytes*8);
        }
        return result;
    }        

    static XedWidths _Widths;

    static XedImport Instance;

    static XedImport()
    {
        Instance = new();
        _Widths = ParseWidths(XedPaths.DocSource(XedDocKind.Widths));
    }
    
    public static bool detail(WidthCode code, out OpWidthDetail dst)
        => _Widths.Detail(code, out dst);

    public static ref readonly XedWidths Widths => ref _Widths;

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
            () => XedZ.emit(Channel, XedZ.rules(XedPaths.DocSource(XedDocKind.RuleBlocks))),
            () => Channel.TableEmit(XedRegMap.Service.REntries, XedPaths.Targets().Table<RegMapEntry>("rmap")),
            () => Channel.TableEmit(XedRegMap.Service.XEntries, XedPaths.Targets().Table<RegMapEntry>("xmap")),
            () => DataFlow.EmitChipCodes(Symbols.symkinds<ChipCode>()),
            () => DataFlow.EmitBroadcastDefs(Xed.broadcasts(Symbols.kinds<BroadcastKind>())),
            () => DataFlow.EmitCpuIdDataset(DataFlow.CalcCpuIdDataset(XedPaths.DocSource(XedDocKind.CpuId))),
            () => {
                var chips = DataFlow.CalcChipMap(XedPaths.DocSource(XedDocKind.ChipMap));
                DataFlow.EmitChipMap(chips);
                var forms = DataFlow.CalcFormImports(XedPaths.DocSource(XedDocKind.FormData));
                DataFlow.EmitFormImports(forms);
                var inst = DataFlow.CalcChipInstructions(forms, chips);
                DataFlow.EmitChipInstructions(inst);
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


    void Emit(ReadOnlySpan<RuleCellRecord> src)
        => Channel.TableEmit(src, XedPaths.RuleTable<RuleCellRecord>());

    public void Emit(ReadOnlySpan<FieldDef> src)
        => Channel.TableEmit(src, XedPaths.Table<FieldDef>());

}
