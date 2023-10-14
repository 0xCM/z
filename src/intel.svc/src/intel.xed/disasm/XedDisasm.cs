//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Linq;
using Asm;

using static sys;
using static XedModels;

public partial class XedDisasm : WfSvc<XedDisasm>
{
    static long DisasmTokens;    

    public static ParallelQuery<FilePath> sources(IDbArchive src)
        => src.Files(FileKind.XedRawDisasm).AsParallel();        

    [MethodImpl(Inline)]
    public static XedDisasmToken token()
        => (uint)inc(ref DisasmTokens);

    public static XedDisasmDoc doc(FilePath src)
    {
        var summary = XedDisasm.summary(datafile(src));
        return new XedDisasmDoc(summary, detail(summary));
    }

    public XedDisasmDoc Import(XedDisasmContext context, XedDisasmDoc src)
    {
        exec(true, 
            () => EmitDetails(context, src),
            () => EmitOps(context, src),
            () => EmitSummaries(context, src),
            () => EmitChecks(context, src)
            );
        return src;
    }

    public void EmitDetails(XedDisasmContext context, XedDisasmDoc src)
    {
        var path = XedPaths.DisasmDetailPath(src.SourcePath);
        var emitting = Channel.EmittingFile(path);
        var te = text.emitter();
        iter(src.DetailBlocks, detail => context.Blocks.Add(detail));
        XedDisasmRender.render(src.DetailBlocks, te);
        using var ae = path.AsciEmitter();
        ae.Write(te.Emit());
        Channel.EmittedFile(emitting, src.DetailBlocks.Count);
    }
    
    public ParallelQuery<XedDisasmDoc> Import(XedDisasmContext context)
        => from path in sources(context.ProjectRoot) select Import(context, doc(path));

    public ParallelQuery<XedDisasmDoc> Collect(IDbArchive root)
    {
        var context = new XedDisasmContext(root);
        var docs = Import(context);
        piter(docs, doc => {});
        Consolidate(context, docs);
        return docs;
    }

    void EmitSummaries(XedDisasmContext context, XedDisasmDoc doc)
        => Channel.TableEmit(doc.Summary.Rows, XedPaths.DisasmSummaryPath(doc.SourcePath));

    const string OperandFormat = "{0} | {1,-20} | {2}";

    public void EmitOps(XedDisasmContext context, XedDisasmDoc src)
    {
        var path = XedPaths.DisasmOpsPath(src.Detail.DataFile.Source);
        var doc = src.Detail;
        var emitting = Channel.EmittingFile(path);
        using var emitter = path.AsciEmitter();
        emitter.AppendLineFormat(RenderCol2, "DataSource", doc.Source.ToUri().Format());
        var counter = 0u;
        var count = doc.Count;
        for(var i=0; i<count;i++)
        {
            ref readonly var block = ref doc[i];
            ref readonly var row = ref block.DetailRow;
            emitter.AppendLine(RP.PageBreak80);
            XedRender.describe(row, emitter);
            operands(row, emitter);
            emitter.WriteLine();
        }

        Channel.EmittedFile(emitting,counter);
    }
    
    static void operands(in XedDisasmDetailRow src, ITextEmitter dst)
    {
        dst.AppendLine("Operands");
        ref readonly var ops = ref src.Ops;
        for(var j=0; j<ops.Count; j++)
        {
            ref readonly var op = ref ops[j];
            dst.AppendLineFormat(OperandFormat, j, nameof(op.OpName), op.OpName);
            dst.AppendLineFormat(OperandFormat, j, nameof(op.OpWidth), op.OpWidth);
            dst.AppendLineFormat(OperandFormat, j, nameof(op.Def.Value), op.Def.Value);
        }
    }

    public static ReadOnlySeq<XedDisasmRow> summaries(IDbArchive root, string name)
    {
        const byte FieldCount = XedDisasmRow.FieldCount;
        var src = root.Table<XedDisasmRow>(name);
        var lines = slice(src.ReadNumberedLines().View,1);
        var count = lines.Length;
        var buffer = alloc<XedDisasmRow>(count);
        var result = Outcome.Success;
        for(var i=0; i<count; i++)
        {
            var cells = text.trim(skip(lines,i).Content.Split(Chars.Pipe));
            if(cells.Length != FieldCount)
            {
                result = (false, Tables.FieldCountMismatch.Format(cells.Length, FieldCount));
                break;
            }

            ref var dst = ref seek(buffer,i);

            var j = 0;
            result = DataParser.parse(skip(cells, j++), out dst.Seq);
            result = DataParser.parse(skip(cells, j++), out dst.DocSeq);
            result = EncodingId.parse(skip(cells, j++), out dst.EncodingId);
            result = InstructionId.parse(skip(cells, j++), out dst.InstructionId);
            result = DataParser.parse(skip(cells, j++), out dst.IP);
            result = AsmBytes.parse(skip(cells, j++), out dst.Encoded);
            result = DataParser.parse(skip(cells, j++), out dst.Size);
            result = AsmExpr.parse(skip(cells, j++), out dst.Asm);
            result = DataParser.parse(skip(cells, j++), out dst.Source);
        }
        return buffer;
    }

    void Consolidate(XedDisasmContext context, ParallelQuery<XedDisasmDoc> src)
    {
        var dst = context.ProjectRoot.Scoped("build");
        var summaries = from block in context.Blocks select block.SummaryRow;
        exec(PllExec,
            () => EmitConsolidated(resequence(context.Blocks.ToArray()), dst),
            () => EmitConsolidated(resequence(summaries.ToArray()), dst));
    }

    void EmitConsolidated(ReadOnlySeq<XedDisasmDetailBlock> src, IDbArchive dst)
    {
        var path = dst.Table<XedDisasmDetailRow>();
        var buffer = text.buffer();
        XedDisasmRender.render(src, buffer);
        var emitting = Channel.EmittingFile(path);
        using var emitter = path.AsciEmitter();
        emitter.Write(buffer.Emit());
        Channel.EmittedFile(emitting, src.Count);
    }

    void EmitConsolidated(ReadOnlySeq<XedDisasmRow> src, IDbArchive dst)
        => Channel.TableEmit(src, dst.Table<XedDisasmRow>());

    public const string RenderCol2 = XedFieldRender.Columns;

    public void EmitChecks(XedDisasmContext context, XedDisasmDoc src)
    {
        const string LabeledValue = "{0,-24} | {1}";
        var doc = src.Detail;
        ref readonly var file = ref doc.DataFile;
        var buffer = text.buffer();
        var count = doc.Count;
        var outpath = XedPaths.DisasmChecksPath(file.Source);
        using var writer = outpath.AsciWriter();
        var emitting = Channel.EmittingFile(outpath);
        writer.AppendLineFormat(RenderCol2, "DataSource", doc.Source.ToUri().Format());
        var counter = 0;
        for(var j=0; j<count; j++)
        {
            var state = XedFieldState.Empty;
            buffer.Clear();

            ref readonly var detail = ref doc[j].DetailRow;
            ref readonly var block = ref doc[j].SummaryLines;
            ref readonly var summary = ref block.Row;
            ref readonly var lines = ref block.Block;
            ref readonly var asmhex = ref summary.Encoded;
            ref readonly var ip = ref summary.IP;
            update(lines, ref state);

            writer.WriteLine(RP.PageBreak240);
            for(var i=0; i<lines.Lines.Count; i++)
                writer.AppendLineFormat("# {0}", text.despace(lines.Lines[i].Content));
            
            writer.WriteLine(RP.PageBreak80);

            writer.AppendLineFormat(LabeledValue, nameof(detail.InstructionId), detail.InstructionId);
            writer.AppendLineFormat(LabeledValue, nameof(detail.Instruction), detail.Instruction);
            writer.AppendLineFormat(LabeledValue, nameof(detail.Form), detail.Form);
            writer.AppendLineFormat(LabeledValue, nameof(detail.IP), detail.IP);
            writer.AppendLineFormat(LabeledValue, nameof(detail.Asm), detail.Asm);

            if(state.OSZ)
            {
                Require.invariant(state.PREFIX66);
                writer.AppendLineFormat(LabeledValue, nameof(state.OSZ), "0x66");
            }

            if(state.ASZ)
                writer.AppendLineFormat(LabeledValue, nameof(state.ASZ), "0x67");

            if(state.DF64)
                writer.AppendLineFormat(LabeledValue, nameof(state.DF64), "64");

            if(state.DF32)
                writer.AppendLineFormat(LabeledValue, nameof(state.DF32), "32");

            if(state.NSEG_PREFIXES != 0)
                writer.AppendLineFormat(LabeledValue, nameof(state.NSEG_PREFIXES), state.NSEG_PREFIXES);

            if(state.HINT != 0)
                writer.AppendLineFormat(LabeledValue, nameof(state.HINT), XedRender.format(XedFields.hint(state)));

            if(state.REP != 0)
                writer.AppendLineFormat(LabeledValue, nameof(state.REP), XedRender.format(XedFields.rep(state)));

            if(state.LOCK)
                writer.AppendLineFormat(LabeledValue, nameof(state.LOCK), state.LOCK);

            if(state.BRDISP_WIDTH != 0)
                writer.AppendLineFormat(LabeledValue, nameof(state.BRDISP_WIDTH), state.BRDISP_WIDTH);

            writer.AppendLineFormat(LabeledValue, nameof(state.EASZ), XedRender.format(XedFields.easz(state)));
            writer.AppendLineFormat(LabeledValue, nameof(state.EOSZ), XedRender.format(XedFields.eosz(state)));
            writer.AppendLineFormat(LabeledValue, nameof(state.MODE), AsmRender.format(XedFields.mode(state)));
            writer.AppendLineFormat(LabeledValue, "OcMap", AsmOpCodes.kind(XedFields.ocindex(state)));

            var offsets = detail.Offsets;
            if(detail.PrefixSize != 0)
                writer.AppendLineFormat(LabeledValue, nameof(detail.PrefixSize), detail.PrefixSize);
            writer.AppendLineFormat(LabeledValue, nameof(detail.Offsets), offsets);
            writer.AppendLineFormat(LabeledValue, nameof(detail.Encoded), detail.Encoded);
            writer.AppendLineFormat(LabeledValue, EmptyString, detail.Encoded.BitString);

            var ocbyte = XedFields.opcode(state);
            var encoding  = XedFields.encoding(state, asmhex);

            var prefix = slice(detail.PrefixBytes.Bytes,0, detail.PrefixSize);
            if(detail.PrefixSize != 0)
                writer.AppendLineFormat(LabeledValue, nameof(detail.PrefixBytes), prefix.FormatHex());

            writer.AppendLineFormat(LabeledValue, "OpCode", string.Format("{0} [{1}]", XedRender.format(ocbyte), BitRender.format8x4(ocbyte)));

            if(state.SRM != 0)
                writer.AppendLineFormat(LabeledValue, nameof(state.SRM), string.Format("{0} [{1}]", XedRender.format(state.SRM), BitRender.format8x4(state.SRM)));

            if(state.HAS_MODRM)
            {
                var modrm = Require.equal(XedFields.modrm(state), detail.ModRm);
                writer.AppendLineFormat(LabeledValue, "ModRm", string.Format("{0} [{1}]", modrm.Format(), modrm.Bitstring()));
            }

            if(state.HAS_SIB)
                writer.AppendLineFormat(LabeledValue, "Sib", string.Format("{0} [{1}]",  XedFields.sib(state).Format(), XedFields.sib(state).Bitstring()));

            if(state.REX)
            {
                var rex = XedFields.rex(state);
                Require.invariant(state.NREXES != 0);
                writer.AppendLineFormat(LabeledValue, "Rex", string.Format("{0} [{1}]", rex, rex.ToBitString()));
                writer.AppendLineFormat(LabeledValue, "RexBits", string.Format("[0100 | W:{0} | R:{1} | X:{2} | B:{3}]", state.REXW, state.REXR, state.REXX, state.REXB));
            }

            if(encoding.Disp != 0)
            {
                writer.AppendLineFormat(LabeledValue, nameof(state.DISP_WIDTH), state.DISP_WIDTH);
                writer.AppendLineFormat(LabeledValue, nameof(encoding.Disp), encoding.Disp);
            }

            if(state.MEM0)
                writer.AppendLineFormat(LabeledValue, nameof(state.MEM0), state.MEM0);

            if(state.MEM1)
                writer.AppendLineFormat(LabeledValue, nameof(state.MEM1), state.MEM1);

            if(state.NEED_MEMDISP !=0)
                writer.AppendLineFormat(LabeledValue, nameof(state.NEED_MEMDISP), state.NEED_MEMDISP);

            if(state.UBIT)
                writer.AppendLineFormat(LabeledValue, nameof(state.UBIT), state.UBIT);

            if(state.IMM0)
            {
                writer.AppendLineFormat(LabeledValue, nameof(state.IMM_WIDTH), state.IMM_WIDTH);
                writer.AppendLineFormat(LabeledValue, nameof(encoding.Imm), encoding.Imm);
            }

            if(state.IMM1)
                writer.AppendLineFormat(LabeledValue, nameof(encoding.Imm1), encoding.Imm1);

            if(state.SAE)
                writer.AppendLineFormat(LabeledValue, nameof(state.SAE), state.SAE);

            if(state.ESRC != 0)
                writer.AppendLineFormat(LabeledValue, nameof(state.ESRC), XedRender.format((Hex8)state.ESRC));

            if(state.ROUNDC != 0)
                writer.AppendLineFormat(LabeledValue, nameof(state.ROUNDC), XedRender.format(XedFields.rounding(state)));

            var rc = (RoundingKind)state.ROUNDC;
            if(rc == 0 && state.LLRC != 0)
                writer.AppendLineFormat(LabeledValue, nameof(state.LLRC), XedRender.format(state.LLRC));

            if(rc != 0)
            {
                var llrc = state.LLRC;
                Require.equal(state.BCRC, bit.On);
                switch(rc)
                {
                    case RoundingKind.RnSae:
                        Require.invariant(llrc == LLRC.LLRC0);
                        Require.invariant(state.SAE);
                    break;
                    case RoundingKind.RdSae:
                        Require.invariant(llrc == LLRC.LLRC1);
                        Require.invariant(state.SAE);
                    break;
                    case RoundingKind.RuSae:
                        Require.invariant(llrc == LLRC.LLRC2);
                        Require.invariant(state.SAE);
                    break;
                    case RoundingKind.RzSae:
                        Require.invariant(llrc == LLRC.LLRC3);
                        Require.invariant(state.SAE);
                    break;
                }
            }

            var vc = XedFields.vexclass(state);
            if(vc != 0)
            {
                var vex5 = BitNumbers.join(state.VEXDEST210, state.VEXDEST4, state.VEXDEST3);
                var vexBits = string.Format("[{0} {1} {2}]", state.VEXDEST4, state.VEXDEST3, (uint3)state.VEXDEST210);
                var vexHex = XedRender.format((Hex8)(byte)vex5);
                if(vc == XedVexClass.VV1)
                {
                    writer.AppendLineFormat(LabeledValue, nameof(detail.VexPrefix.VexKind), detail.VexPrefix.VexKind);
                    writer.AppendLineFormat(LabeledValue, nameof(detail.VexPrefix), 
                        detail.VexPrefix.VexKind == AsmPrefixTokens.VexPrefixKind.xC4 ? AsmBitPatterns.VexC4 : AsmBitPatterns.VexC5);
                    writer.AppendLineFormat(LabeledValue, EmptyString, detail.VexPrefix.Bitstring());
                }
                else if(vc == XedVexClass.EVV)
                {
                    if(prefix.Length < 4)
                    {
                        writer.AppendLineFormat(LabeledValue, "Evex", "<evex:error>");
                    }
                    else
                    {
                        var evex = @as<EvexPrefix>(prefix);
                        writer.AppendLineFormat(LabeledValue, "Evex",  AsmBitPatterns.Evex);
                        var dat = @as<EvexPrefix,uint>(evex) >> 8;                                                
                        writer.AppendLineFormat(LabeledValue, "", string.Format("0x{0} [{1} {2} {3} {4}] [{5} {6} {7} {8}] [{9} {10} {11} {12} {13}]", evex[0], 
                            // mmm[2:0]                   0[3]              q[4]              RXB[7:5] 
                            (uint3)bits.extract(dat,0,2), bits.test(dat,3), ~bits.test(dat,4), ~(uint3)bits.extract(dat,5,7),
                            // pp[9:8]             1[10]              vvvv[14:11]                     W[15]                             
                            bits.extract(dat,8,9), bits.test(dat,10), ~(uint4)bits.extract(dat,11,14), bits.test(dat,15),
                            // aaa[18:16]                   f[19]              b[20]              VL[22:21]                      z[23]
                            (uint3)bits.extract(dat,16,18), ~bits.test(dat,19), bits.test(dat,20), (uint2)bits.extract(dat,21,22), bits.test(dat,23)
                            ));
                    }
                }
                writer.AppendLineFormat(LabeledValue, "VEXDEST", string.Format("{0} {1}", vexHex, vexBits));
                writer.AppendLineFormat(LabeledValue, "VL", XedRender.format(XedFields.vl(state)));
            }

            if(state.ELEMENT_SIZE != 0)
                writer.AppendLineFormat(LabeledValue, nameof(state.ELEMENT_SIZE), XedRender.format(state.ELEMENT_SIZE));

            if(state.NELEM != 0)
                writer.AppendLineFormat(LabeledValue, nameof(state.NELEM), state.NELEM);

            if(state.BCAST != 0)
                writer.AppendLineFormat(LabeledValue, nameof(state.BCAST), XedFields.broadcast(state));

            if(state.REXRR)
                writer.AppendLineFormat(LabeledValue, nameof(state.REXRR), state.REXRR);

            if(state.OUTREG != 0)
                writer.AppendLineFormat(LabeledValue, nameof(state.OUTREG), XedPatterns.regop(state.OUTREG));

            operands(detail, buffer);
            writer.WriteLine(buffer.Emit());
        }

        Channel.EmittedFile(emitting,counter);
    }
}
