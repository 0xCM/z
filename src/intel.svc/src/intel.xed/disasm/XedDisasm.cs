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

    void EmitDetails(XedDisasmDoc src, IDbArchive dst)
    {
        var path = XedPaths.DisasmDetailPath(dst, src.SourcePath);
        var emitting = Channel.EmittingFile(path);
        var te = text.emitter();
        XedDisasmRender.render(src.DetailBlocks, te);
        using var ae = path.AsciEmitter();
        ae.Write(te.Emit());
        Channel.EmittedFile(emitting, src.DetailBlocks.Count);
    }
    
    public bool Import(XedDisasmDoc src, IDbArchive dst)
    {
        var path = src.SourcePath;
        var flow = Channel.Running($"Collecting disassembly content from {path.ToUri()}");
        EmitDetails(src, dst);
        EmitOps(src, dst);
        EmitSummaries(src, dst);
        EmitChecks(src, dst);
        Channel.Ran(flow,$"Collected disassembly content from {path.ToUri()}");
        return true;
    }

    public ParallelQuery<XedDisasmDoc> Import(IDbArchive root)
        => from path in sources(root)
            let d = doc(path)
            let success = Import(d, root)
            where success
            select d;

    public ParallelQuery<XedDisasmDoc> Collect(IDbArchive root)
    {
        var docs = Import(root);
        Consolidate(docs, root);
        return docs;
    }

    void EmitSummaries(XedDisasmDoc doc, IDbArchive project)
        => Channel.TableEmit(doc.Summary.Rows, XedPaths.DisasmSummaryPath(project, doc.SourcePath));

    const string OperandFormat = "{0} | {1,-20} | {2}";

    void EmitOps(XedDisasmDoc src, IDbArchive dst)
    {
        var path = XedPaths.DisasmOpsPath(dst, src.Detail.DataFile.Source);
        var doc = src.Detail;
        var emitting = Channel.EmittingFile(path);
        using var emitter = path.AsciEmitter();
        emitter.AppendLineFormat(RenderCol2, "DataSource", doc.Source.ToUri().Format());
        var counter = 0u;
        var count = doc.Count;
        for(var i=0; i<count;i++)
        {
            ref readonly var row = ref doc[i];
            ref readonly var detail = ref row.DetailRow;
            var inst = detail.Instruction;
            emitter.AppendLine(RP.PageBreak80);
            XedRender.describe(detail, emitter);
            operands(detail, emitter);
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

    void Consolidate(ParallelQuery<XedDisasmDoc> src, IDbArchive root)
    {
        var summaries = bag<XedDisasmRow>();
        var details = bag<XedDisasmDetailBlock>();
        piter(src, pair => {
            iter(pair.Summary.Rows, r => summaries.Add(r));
            iter(pair.Detail.Blocks, b => details.Add(b));
        });

        exec(PllExec,
            () => EmitOpClasses(root, src),
            () => EmitConsolidated(root, details.ToArray()),
            () => EmitConsolidated(root, summaries.ToArray()));
    }

    void EmitOpClasses(IDbArchive project, ParallelQuery<XedDisasmDoc> src)
    {
        Channel.TableEmit(opclasses(src).View, XedPaths.DisasmTargets(project).Table<InstOpClass>());
    }

    void EmitConsolidated(IDbArchive project, Index<XedDisasmDetailBlock> src)
    {
        var dst = XedPaths.DisasmTargets(project).Table<XedDisasmDetailRow>();
        var buffer = text.buffer();
        XedDisasmRender.render(resequence(src), buffer);
        var emitting = Channel.EmittingFile(dst);
        using var emitter = dst.AsciEmitter();
        emitter.Write(buffer.Emit());
        Channel.EmittedFile(emitting, src.Count);
    }

    void EmitConsolidated(IDbArchive project, Index<XedDisasmRow> src)
        => Channel.TableEmit(resequence(src), XedPaths.DisasmTargets(project).Table<XedDisasmRow>());

    public const string RenderCol2 = XedFieldRender.Columns;

    public void EmitChecks(XedDisasmDoc src, IDbArchive dst)
    {
        const string LabeledValue = "{0,-24} | {1}";
        var doc = src.Detail;
        ref readonly var file = ref doc.DataFile;
        var buffer = text.buffer();
        var count = doc.Count;
        var outpath = XedPaths.DisasmChecksPath(dst, file.Source);
        using var writer = outpath.AsciWriter();
        var emitting = Channel.EmittingFile(outpath);
        writer.AppendLineFormat(RenderCol2, "DataSource", doc.Source.ToUri().Format());

        var counter = 0;
        for(var j=0; j<count; j++)
        {
            var state = XedOperandState.Empty;
            buffer.Clear();

            ref readonly var detail = ref doc[j].DetailRow;
            ref readonly var ops = ref doc[j].Ops;
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
                writer.AppendLineFormat(LabeledValue, nameof(state.HINT), XedRender.format(Xed.hint(state)));

            if(state.REP != 0)
                writer.AppendLineFormat(LabeledValue, nameof(state.REP), XedRender.format(Xed.rep(state)));

            if(state.LOCK)
                writer.AppendLineFormat(LabeledValue, nameof(state.LOCK), state.LOCK);

            if(state.BRDISP_WIDTH != 0)
                writer.AppendLineFormat(LabeledValue, nameof(state.BRDISP_WIDTH), state.BRDISP_WIDTH);

            writer.AppendLineFormat(LabeledValue, nameof(state.EASZ), XedRender.format(Xed.easz(state)));
            writer.AppendLineFormat(LabeledValue, nameof(state.EOSZ), XedRender.format(Xed.eosz(state)));
            writer.AppendLineFormat(LabeledValue, nameof(state.MODE), AsmRender.format(Xed.mode(state)));
            writer.AppendLineFormat(LabeledValue, "OcMap", AsmOpCodes.kind(Xed.ocindex(state)));

            if(detail.PrefixSize != 0)
                writer.AppendLineFormat(LabeledValue, nameof(detail.PrefixSize), detail.PrefixSize);
            writer.AppendLineFormat(LabeledValue, nameof(detail.Offsets), detail.Offsets);
            writer.AppendLineFormat(LabeledValue, nameof(detail.Encoded), detail.Encoded);

            var ocbyte = Xed.ocbyte(state);
            var encoding  = Xed.encoding(state, asmhex);

            if(detail.PrefixSize != 0)
                writer.AppendLineFormat(LabeledValue, nameof(detail.PrefixBytes), slice(detail.PrefixBytes.Bytes,0, detail.PrefixSize).FormatHex());

            writer.AppendLineFormat(LabeledValue, "OpCode", string.Format("{0} [{1}]", XedRender.format(ocbyte), BitRender.format8x4(ocbyte)));

            if(state.SRM != 0)
                writer.AppendLineFormat(LabeledValue, nameof(state.SRM), string.Format("{0} [{1}]", XedRender.format((Hex8)state.SRM), BitRender.format8x4(state.SRM)));

            if(state.HAS_MODRM)
            {
                var modrm = Xed.modrm(state);
                writer.AppendLineFormat(LabeledValue, "ModRm", string.Format("{0} [{1}]", modrm.Format(), modrm.Bitstring()));
            }

            if(state.HAS_SIB)
                writer.AppendLineFormat(LabeledValue, "Sib", string.Format("{0} [{1}]",  Xed.sib(state).Format(), Xed.sib(state).Bitstring()));

            if(state.REX)
            {
                var rex = Xed.rex(state);
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
                writer.AppendLineFormat(LabeledValue, nameof(state.ROUNDC), XedRender.format(Xed.rounding(state)));

            var rc = (RoundingKind)state.ROUNDC;
            if(rc == 0 && state.LLRC != 0)
                writer.AppendLineFormat(LabeledValue, nameof(state.LLRC), XedRender.format((Hex8)state.LLRC));

            if(rc != 0)
            {
                var llrc = (LLRC)state.LLRC;
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

            var vc = Xed.vexclass(state);
            if(vc != 0)
            {
                var vk = Xed.vexkind(state);
                var vex5 = BitNumbers.join((uint3)state.VEXDEST210, state.VEXDEST4, state.VEXDEST3);
                var vexBits = string.Format("[{0} {1} {2}]", state.VEXDEST4, state.VEXDEST3, (uint3)state.VEXDEST210);
                var vexHex = XedRender.format((Hex8)(byte)vex5);
                writer.AppendLineFormat(LabeledValue, nameof(state.VEXVALID), XedRender.format(vc));
                writer.AppendLineFormat(LabeledValue, nameof(state.VEX_PREFIX), vk == 0 ? "VNP" : XedRender.format(vk));
                if(vc == XedVexClass.VV1)
                    writer.AppendLineFormat(LabeledValue, "Vex", detail.Vex);
                else if(vc == XedVexClass.EVV)
                    writer.AppendLineFormat(LabeledValue, "Evex", detail.Evex);
                writer.AppendLineFormat(LabeledValue, "VEXDEST", string.Format("{0} {1}", vexHex, vexBits));
                writer.AppendLineFormat(LabeledValue, "VL", XedRender.format(Xed.vl(state)));
            }

            if(state.ELEMENT_SIZE != 0)
                writer.AppendLineFormat(LabeledValue, nameof(state.ELEMENT_SIZE), XedRender.format(state.ELEMENT_SIZE));

            if(state.NELEM != 0)
                writer.AppendLineFormat(LabeledValue, nameof(state.NELEM), state.NELEM);

            if(state.BCAST != 0)
                writer.AppendLineFormat(LabeledValue, nameof(state.BCAST), Xed.broadcast(state));

            if(state.REXRR)
                writer.AppendLineFormat(LabeledValue, nameof(state.REXRR), state.REXRR);

            if(state.OUTREG != 0)
                writer.AppendLineFormat(LabeledValue, nameof(state.OUTREG), Xed.regop(state.OUTREG));

            operands(detail, buffer);
            writer.WriteLine(buffer.Emit());
        }

        Channel.EmittedFile(emitting,counter);
    }
}
