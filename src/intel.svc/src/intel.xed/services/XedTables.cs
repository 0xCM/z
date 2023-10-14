//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using System.Linq;
using Asm;

using static XedModels;
using static sys;
using static MachineModes;
using static XedRules;
using static XedZ;

using M = XedModels;
using R = XedRules;
using B = ReadOnlySpan<bit>;
using U2 = ReadOnlySpan<uint2>;
using U3 = ReadOnlySpan<uint3>;

public class XedTables : AppService<XedTables>
{
    public enum DatasetName
    {
        InstDefs,

        InstPatterns,

        RuleTables,
        
        SeqReflected,

        RuleCells,

        OpCodes,

        InstBlocks,

        MacroMatches,

        MacroDefs,

        FormImports,

        CellTables,

        OpDetails,

        TableDefRows,

        ChipMap,

        ChipInstructions,

        FieldImports,
        
        FieldDeps,

        OpRows,

        RuleSeqImports
    }

    public static ChipMap ChipMap()
        => data(DatasetName.ChipMap,XedChips.Map);

    public static ReadOnlySeq<FieldImport> FieldImports()
        => data(DatasetName.FieldImports,CalcFieldImports);

    public static ReadOnlySeq<FormImport> FormImports()
        => data(DatasetName.FormImports,() => XedFormImports.calc(XedPaths.InstFormSource()));

    public static ReadOnlySeq<MacroDef> MacroDefs()
         => data(DatasetName.MacroDefs,RuleMacros.defs);

    public static ReadOnlySeq<MacroMatch> MacroMatches()
        => data(DatasetName.MacroMatches,CalcMacroMatches);

    public static ParallelQuery<InstBlockLineSpec> BlockLines()
        => XedZ.lines().AsParallel();
    
    public static ParallelQuery<InstBlockPattern> BlockPatterns(ParallelQuery<InstBlockLineSpec> lines)
        => data(DatasetName.InstBlocks,() => XedZ.patterns(lines));

    public static ReadOnlySeq<InstOpRow> OpRows(ReadOnlySeq<InstOpDetail> src)
        => data(DatasetName.OpRows, () => CalcOpRows(src));
        
    public static ChipInstructions ChipInstructions(ReadOnlySeq<FormImport> forms, ChipMap map)
        => data(DatasetName.ChipInstructions,() => XedChips.ChipInstructions(forms, map));

    public static ReadOnlySeq<TableDefRow> TableDefRows(XedRuleTables src)
        => data(DatasetName.TableDefRows,() => CalcDefRows(src));

    public static ReadOnlySeq<InstOpDetail> OpDetails(ReadOnlySeq<InstPattern> src)
        => data(DatasetName.OpDetails,() => XedPatterns.opdetails(src));

    public static ReadOnlySeq<FieldUsage> FieldDeps(CellTables src)
        => data(DatasetName.FieldDeps,() => CalcFieldDeps(src));
        
    public static CellTables CellTables(XedRuleCells src)
        => data(DatasetName.CellTables, () => new CellTables(src));

    static ReadOnlySeq<InstOpRow> CalcOpRows(ReadOnlySeq<InstOpDetail> src)
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

    static ReadOnlySeq<FieldUsage> CalcFieldDeps(CellTables src)
    {
        var buffer = sys.bag<FieldUsage>();
        iter(src.View, table => collect(table,buffer),true);
        return buffer.Index().Sort();
    }

    static void collect(in CellTable src, ConcurrentBag<FieldUsage> dst)
    {
        ref readonly var rows = ref src.Rows;
        var usage = hashset<FieldUsage>();
        var sig = src.Sig;
        for(var i=0; i<rows.Count; i++)
        {
            ref readonly var row = ref rows[i];
            var antecedants = row.Antecedants();
            for(var j=0; j<antecedants.Length; j++)
            {
                ref readonly var antecedant = ref skip(antecedants,j);
                if(antecedant.Field != 0)
                    usage.Add(FieldUsage.left(sig, antecedant.Field));
            }

            var consequents = row.Consequents();
            for(var j=0; j<consequents.Length; j++)
            {
                ref readonly var consequent = ref skip(consequents,j);
                if(consequent.Field != 0)
                    usage.Add(FieldUsage.right(sig, consequent.Field));
            }
        }

        iter(usage, u => dst.Add(u));
    }
        

    static ReadOnlySeq<FieldImport> CalcFieldImports()
    {
        var src = XedPaths.FieldSource();
        var dst = list<FieldImport>();
        var result = Outcome.Success;
        var line = EmptyString;
        var lines = src.ReadLines().Reader();
        while(lines.Next(out line))
        {
            var content = line.Trim();
            if(text.empty(content) || text.begins(content,Chars.Hash))
                continue;

            var cells = text.split(text.despace(content), Chars.Space).Reader();
            var record = FieldImport.Empty;
            record.Name = cells.Next();

            cells.Next();
            result = FieldTypes.ExprKind(cells.Next(), out XedFieldKind ft);
            if(result.Fail)
                Errors.Throw(AppMsg.ParseFailure.Format(nameof(record.FieldType), cells.Prior()));
            else
                record.FieldType = ft;

            result = DataParser.parse(cells.Next(), out record.Width);
            if(result.Fail)
                Errors.Throw(AppMsg.ParseFailure.Format(nameof(record.Width), cells.Prior()));

            if(!Visibilities.ExprKind(cells.Next(), out record.Visibility))
                Errors.Throw(AppMsg.ParseFailure.Format(nameof(record.Visibility), cells.Prior()));

            dst.Add(record);
        }

        return dst.ToArray().Sort();
    }


    public static ReadOnlySeq<RuleSeq> RuleSeqImports()
        => data(DatasetName.RuleSeqImports, XedCellParser.ruleseq);

    public static XedRuleTables RuleTables()
        => data(DatasetName.RuleTables,CalcRuleTables);

    public static ReadOnlySeq<SeqDef> SeqReflected()
        => data(DatasetName.SeqReflected,XedRuleSeq.defs);

    public static ReadOnlySeq<InstDef> EncInstDefs()
        => data(DatasetName.InstDefs, () => XedInstDefParser.parse(XedPaths.EncInstDef()));

    public static ReadOnlySeq<InstDef> DecInstDefs()
        => data(DatasetName.InstDefs, () => XedInstDefParser.parse(XedPaths.DecInstDef()));

    public static XedRuleCells RuleCells(XedRuleTables tables)
        => data(DatasetName.RuleCells, () => XedCells.cells(tables));

    public static Index<InstPattern> InstPatterns(ReadOnlySeq<InstDef> defs)
        => data(DatasetName.InstPatterns,() =>  CalcInstPatterns(defs));

    public static ReadOnlySeq<XedInstOpCode> OpCodes(ReadOnlySeq<InstPattern> src)
        => data(DatasetName.OpCodes, () => CalcOpCodes(src));

    static ReadOnlySeq<MacroMatch> CalcMacroMatches()
        => mapi(RuleMacros.matches().Values.ToArray().Sort(), (i,m) => m.WithSeq((uint)i));

    static ReadOnlySeq<TableDefRow> CalcDefRows(XedRuleTables src)
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

    static ReadOnlySeq<XedInstOpCode> CalcOpCodes(ReadOnlySeq<InstPattern> src)
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

    public static ReadOnlySpan<OpName> OpNames => _OpNames.View;

    public static ref readonly XedWidths Widths => ref _Widths;

    public static B DF32
    {
        [MethodImpl(Inline)]
        get => Bytes.sequential<bit>(0, 1);
    }

    public static B DF64
    {
        [MethodImpl(Inline)]
        get => Bytes.sequential<bit>(0, 1);
    }

    public static B NO_SCALE_DISP8
    {
        [MethodImpl(Inline)]
        get => Bytes.sequential<bit>(0, 1);
    }

    public static B BCRC
    {
        [MethodImpl(Inline)]
        get => Bytes.sequential<bit>(0, 1);
    }

    public static B CET
    {
        [MethodImpl(Inline)]
        get => Bytes.sequential<bit>(0, 1);
    }

    public static B CLDEMOE
    {
        [MethodImpl(Inline)]
        get => Bytes.sequential<bit>(0, 1);
    }

    public static ReadOnlySpan<ASZ> ASZ
    {
        [MethodImpl(Inline), Op]
        get => Bytes.sequential<ASZ>(0, (byte)M.ASZ.a64);
    }

    public static ReadOnlySpan<EASZ> EASZ
    {
        [MethodImpl(Inline), Op]
        get => Bytes.sequential<EASZ>(0, (byte)M.EASZ.EASZNot16);
    }

    public static ReadOnlySpan<EOSZ> EOSZ
    {
        [MethodImpl(Inline), Op]
        get => Bytes.sequential<EOSZ>(0, (byte)M.EOSZ.EOSZ64);
    }

    public static ReadOnlySpan<LegacyMapKind> BaseMapKind
    {
        [MethodImpl(Inline), Op]
        get => Bytes.sequential<LegacyMapKind>(0, (byte)LegacyMapKind.Amd3dNow);
    }

    public static ReadOnlySpan<InstCategory> InstCategories
    {
        [MethodImpl(Inline), Op]
        get => Bytes.sequential<InstCategory>(0, (byte)CategoryKind.XSAVEOPT);
    }

    public static ReadOnlySpan<InstAttrib> InstAttribs
    {
        [MethodImpl(Inline), Op]
        get => Bytes.sequential<InstAttrib>(0, (byte)InstAttribKind.XMM_STATE_W);
    }

    public static ReadOnlySpan<InstIsa> InstIsa
    {
        [MethodImpl(Inline), Op]
        get => Bytes.sequential<InstIsa>(0, (byte)M.InstIsaKind.XSAVES);
    }

    public static ReadOnlySpan<MaskReg> MaskRegs
    {
        [MethodImpl(Inline), Op]
        get => Bytes.sequential<MaskReg>(0, (byte)MaskReg.K7);
    }

    public static ReadOnlySpan<ModKind> ModKinds
    {
        [MethodImpl(Inline), Op]
        get => Bytes.sequential<ModKind>(0, (byte)ModKind.MOD3);
    }

    public static ReadOnlySpan<ElementType> ElementType
    {
        [MethodImpl(Inline), Op]
        get => Bytes.sequential<ElementType>(0, (byte)M.ElementKind.VAR);
    }

    public static ReadOnlySpan<SegPrefixKind> SegPrefixKinds
    {
        [MethodImpl(Inline), Op]
        get => Bytes.sequential<SegPrefixKind>(0, (byte)SegPrefixKind.SS);
    }

    public static ReadOnlySpan<DispWidth> DISP_WIDTH
    {
        [MethodImpl(Inline)]
        get => sys.recover<DispWidth>(_DISP_WIDTH);
    }

    public static ReadOnlySpan<MachineModeClass> MODE
    {
        [MethodImpl(Inline)]
        get => Bytes.sequential<MachineModeClass>(0, (byte)MachineModeClass.Default);
    }

    public static ReadOnlySpan<M.RepPrefix> REP
    {
        [MethodImpl(Inline), Op]
        get => Bytes.sequential<M.RepPrefix>(0, (byte)M.RepPrefix.REPF3);
    }

    public static ReadOnlySpan<SMODE> SMODE
    {
        [MethodImpl(Inline), Op]
        get => Bytes.sequential<SMODE>(0, (byte)M.SMODE.SMode64);
    }

    public static ReadOnlySpan<AsmVL> VL
    {
        [MethodImpl(Inline)]
        get => Bytes.sequential<AsmVL>(0, (byte)AsmVL.VL512);
    }

    public static ReadOnlySpan<BroadcastKind> BCAST
    {
        [MethodImpl(Inline)]
        get => Bytes.sequential<BroadcastKind>(0, (byte)BroadcastKind.BCast_1TO4_16);
    }

    public static ReadOnlySpan<RoundingKind> ROUNDC
    {
        [MethodImpl(Inline)]
        get => Bytes.sequential<RoundingKind>(0, (byte)RoundingKind.RzSae);
    }

    public static ReadOnlySpan<VsibKind> VsibKinds
    {
        [MethodImpl(Inline)]
        get => Bytes.sequential<VsibKind>(0, (byte)VsibKind.Zmm);
    }
    
    public static ReadOnlySpan<LLRC> LLRC
    {
        [MethodImpl(Inline)]
        get => Bytes.sequential<LLRC>(0, (byte)M.LLRC.LLRC3);
    }

    public static ReadOnlySpan<XedVexClass> VEXVALID
    {
        [MethodImpl(Inline)]
        get => Bytes.sequential<XedVexClass>(0, (byte)XedVexClass.XOPV);
    }

    public static ReadOnlySpan<XedVexKind> VEX_PREFIX
    {
        [MethodImpl(Inline)]
        get => Bytes.sequential<XedVexKind>(0, (byte)XedVexKind.VF3);
    }

    public static ReadOnlySpan<num2> DEFAULT_SEG
    {
        [MethodImpl(Inline)]
        get => Bytes.sequential<num2>(0, num2.MaxValue);
    }

    public static ReadOnlySpan<num2> FIRST_F2F3
    {
        [MethodImpl(Inline)]
        get => Bytes.sequential<num2>(0, num2.MaxValue);
    }

    public static ReadOnlySpan<num2> LAST_F2F3
    {
        [MethodImpl(Inline)]
        get => Bytes.sequential<num2>(0, num2.MaxValue);
    }

    public static ReadOnlySpan<RuleName> RuleNames
    {
        [MethodImpl(Inline), Op]
        get => R.RuleNames.View;
    }

    public static ReadOnlySpan<XedRegId> Regs
    {
        [MethodImpl(Inline), Op]
        get => _Regs.View;
    }

    public static U2 MOD
    {
        [MethodImpl(Inline)]
        get => Bytes.sequential<uint2>(0, uint2.MaxValue);
    }

    public static U3 REG
    {
        [MethodImpl(Inline)]
        get => Bytes.sequential<uint3>(0, uint3.MaxValue);
    }

    public static U3 RM
    {
        [MethodImpl(Inline)]
        get => Bytes.sequential<uint3>(0, uint3.MaxValue);
    }

    public static U3 SRM
    {
        [MethodImpl(Inline)]
        get => Bytes.sequential<uint3>(0, uint3.MaxValue);
    }

    public static U2 SIBSCALE
    {
        [MethodImpl(Inline)]
        get => Bytes.sequential<uint2>(0, uint2.MaxValue);
    }

    public static U3 SIBINDEX
    {
        [MethodImpl(Inline)]
        get => Bytes.sequential<uint3>(0, uint3.MaxValue);
    }

    public static U3 SIBBASE
    {
        [MethodImpl(Inline)]
        get => Bytes.sequential<uint3>(0, uint3.MaxValue);
    }

    public static B REXW
    {
        [MethodImpl(Inline)]
        get => Bytes.sequential<bit>(0, 1);
    }

    public static B REXR
    {
        [MethodImpl(Inline)]
        get => Bytes.sequential<bit>(0, 1);
    }

    public static B REXX
    {
        [MethodImpl(Inline)]
        get => Bytes.sequential<bit>(0, 1);
    }

    public static B REXB
    {
        [MethodImpl(Inline)]
        get => Bytes.sequential<bit>(0, 1);
    }

    public static B REXRR
    {
        [MethodImpl(Inline)]
        get => Bytes.sequential<bit>(0, 1);
    }

    public static B VEXDEST4
    {
        [MethodImpl(Inline)]
        get => Bytes.sequential<bit>(0, 1);
    }

    public static B VEXDEST3
    {
        [MethodImpl(Inline)]
        get => Bytes.sequential<bit>(0, 1);
    }

    public static U3 VEXDEST210
    {
        [MethodImpl(Inline)]
        get => Bytes.sequential<uint3>(0, uint3.MaxValue);
    }

    public static B ZEROING
    {
        [MethodImpl(Inline)]
        get => Bytes.sequential<bit>(0, 1);
    }

    public static B SAE
    {
        [MethodImpl(Inline)]
        get => Bytes.sequential<bit>(0, 1);
    }

    public static B UBIT
    {
        [MethodImpl(Inline)]
        get => Bytes.sequential<bit>(0, 1);
    }

    public static B WBNOINVD
    {
        [MethodImpl(Inline)]
        get => Bytes.sequential<bit>(0, 1);
    }

    public static B NO_RETURN
    {
        [MethodImpl(Inline)]
        get => Bytes.sequential<bit>(0, 1);
    }

    public static ref readonly Index<AsmBroadcast> Broadcasts
    {
        [MethodImpl(Inline), Op]
        get => ref _BroadcastDefs;
    }

    public static Index<AsmBroadcast> broadcasts(ReadOnlySpan<BroadcastKind> src)
    {
        var dst = alloc<AsmBroadcast>(src.Length);
        for(var j=0; j<src.Length; j++)
            seek(dst,j) = asm.broadcast(skip(src,j));
        return dst;
    }    

    static Index<InstPattern> CalcInstPatterns(ReadOnlySeq<InstDef> defs)
    {
        var count = 0u;
        iter(defs, def => count += def.PatternSpecs.Count);
        var dst = alloc<InstPattern>(count);
        var k=0u;
        for(var i=0; i<defs.Count; i++)
        {
            ref readonly var def = ref defs[i];
            var specs = def.PatternSpecs;
            for(var j=0; j<specs.Count; j++, k++)
            {
                ref var spec = ref specs[j];
                var cells = XedCells.sort(spec.Body);
                spec.Body = cells;
                seek(dst,k) = new InstPattern(spec, XedCells.usage(cells));
            }
        }
        return dst.Sort();
    }

    static XedRuleTables CalcRuleTables()
    {
       var enc = Seq<TableCriteria>.Empty;
       var dec = Seq<TableCriteria>.Empty;
        exec(PllExec,
            () => enc = XedCells.criteria(RuleTableKind.ENC),
            () => dec = XedCells.criteria(RuleTableKind.DEC)
            );

        var dst = enc.Storage.Append(dec.Storage).Where(x => x.IsNonEmpty).Sort().ToSeq();
        for(var i=0u; i<dst.Count; i++)
            dst[i] = dst[i].WithId(i);
        return new XedRuleTables(dst, XedCells.tables(dst));
    }

    static readonly ReadOnlySeq<OpName> _OpNames = Symbols.index<OpNameKind>().Kinds.Map(x => new OpName(x));

    static readonly ReadOnlySeq<XedRegId> _Regs = Symbols.index<XedRegId>().Kinds.ToArray();

    static ReadOnlySpan<byte> _DISP_WIDTH => new byte[]{(byte)DispWidth.None, (byte)DispWidth.DW8, (byte)DispWidth.DW16, (byte)DispWidth.DW32, (byte)DispWidth.DW64};

    static readonly Index<AsmBroadcast> _BroadcastDefs = XedTables.broadcasts(Symbols.kinds<BroadcastKind>());

    static XedWidths _Widths = XedWidths.FromSource(XedPaths.WidthSource());

    static readonly Symbols<XedFieldKind> FieldTypes = Symbols.index<XedFieldKind>();

    static readonly Symbols<VisibilityKind> Visibilities = Symbols.index<VisibilityKind>();

}
