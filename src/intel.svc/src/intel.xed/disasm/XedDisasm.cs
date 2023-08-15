//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Linq;

using static sys;
using static XedModels;
using static XedRules;
using static XedOps;
using static XedFields;

using K = XedRules.FieldKind;

public partial class XedDisasm : WfSvc<XedDisasm>
{
    const string disasm = "xed.disasm";

    static long DisasmTokens;

    [MethodImpl(Inline)]
    public static XedDisasmToken token()
        => (uint)inc(ref DisasmTokens);

    public void EmitBreakdowns(IProject project, ParallelQuery<XedDisasmDoc> docs)
        => iter(docs, doc => EmitBreakdowns(project, doc), PllExec);

    public void EmitBreakdowns(IProject project, XedDisasmDoc doc)
    {
        exec(PllExec,
                () => EmitDetails(project, doc),
                () => EmitOps(project, doc),
                () => EmitChecks(project, doc)
                );
    }

    public void EmitDetails(IProject project, XedDisasmDoc doc)
    {
        var target = XedPaths.DisasmDetailPath(project, doc.SourcePath);
        var emitting = Channel.EmittingFile(target);
        var dst = text.emitter();
        XedDisasmRender.render(doc.DetailBlocks, dst);
        using var emitter = target.AsciEmitter();
        emitter.Write(dst.Emit());
        Channel.EmittedFile(emitting, doc.DetailBlocks.Count);
    }

    void CollectIndividuals(IProject project, ParallelQuery<XedDisasmDoc> docs)
    {
        piter(docs, doc => {
            var path = doc.SourcePath;
            var flow = Channel.Running($"Collecting disassembly content from {path.ToUri()}");
            EmitDetails(project, doc);
            EmitOps(project, doc);
            EmitSummaries(project, doc);
            EmitChecks(project,doc);
            Channel.Ran(flow,$"Collected disassembly content from {path.ToUri()}");
        });

    }
    public void Collect(IProject project)
    {
        var docs = XedDisasm.docs(project.Root);
        exec(PllExec,
            () => Consolidate(project, docs),
            () => CollectIndividuals(project, docs)
            );
    }

    public void EmitSummaries(IProject project, XedDisasmDoc doc)
        => Channel.TableEmit(doc.Summary.Rows, XedPaths.DisasmSummaryPath(project, doc.SourcePath));

    public void EmitOps(IProject project, XedDisasmDoc src)
    {
        var doc = src.Detail;
        var outpath = XedPaths.DisasmOpsPath(project, doc.DataFile.Source);
        var emitting = Channel.EmittingFile(outpath);
        using var dst = outpath.AsciEmitter();
        dst.AppendLineFormat(RenderCol2, "DataSource", doc.Source.ToUri().Format());
        var counter = 0u;
        var count = doc.Count;
        for(var i=0; i<count;i++)
        {
            ref readonly var row = ref doc[i];
            ref readonly var detail = ref row.DetailRow;
            var inst = detail.Instruction;
            dst.AppendLine(RP.PageBreak80);
            XedRender.describe(detail, dst);
            ref readonly var ops = ref detail.Ops;
            dst.AppendLine("Operands");
            var specs = ops.Map(x => x.Spec);
            for(var j=0; j<specs.Length; j++)
                dst.AppendLine(OpSpec.specifier(skip(specs,j)));
            dst.WriteLine();
        }

        Channel.EmittedFile(emitting,counter);
    }
    
    public void EmitFields(IProject project, XedDisasmDoc src)
        => EmitFieldReport(project, src.Detail);

    void EmitFieldReport(IProject project, XedDisasmDetail src)
    {
        var emitter = new FieldEmitter();
        var dst = text.emitter();
        var count = emitter.EmitFields(src, dst);
        Channel.FileEmit(dst.Emit(), count, XedPaths.DisasmFieldsPath(project, src.Path));
    }

    public static ReadOnlySeq<XedDisasmRow> summaries(IProject project, string name)
    {
        const byte FieldCount = XedDisasmRow.FieldCount;
        var src = project.TablePath<XedDisasmRow>(name);
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
            result = AsmParsers.parse(skip(cells, j++), out dst.InstructionId);
            result = DataParser.parse(skip(cells, j++), out dst.IP);
            result = AsmBytes.parse(skip(cells, j++), out dst.Encoded);
            result = DataParser.parse(skip(cells, j++), out dst.Size);
            result = AsmExpr.parse(skip(cells, j++), out dst.Asm);
            result = DataParser.parse(skip(cells, j++), out dst.Source);
        }
        return buffer;
    }

    public void Consolidate(IProject project, ParallelQuery<XedDisasmDoc> src)
    {
        var summaries = bag<XedDisasmRow>();
        var details = bag<XedDisasmDetailBlock>();
        piter(src, pair => {
            iter(pair.Summary.Rows, r => summaries.Add(r));
            iter(pair.Detail.Blocks, b => details.Add(b));
        });

        exec(PllExec,
            () => EmitOpClasses(project, src),
            () => EmitConsolidated(project, details.ToArray()),
            () => EmitConsolidated(project, summaries.ToArray()));
    }

    void EmitOpClasses(IProject project, ParallelQuery<XedDisasmDoc> src)
    {
        Channel.TableEmit(opclasses(src).View, XedPaths.DisasmTargets(project).Table<InstOpClass>());
    }

    void EmitConsolidated(IProject project, Index<XedDisasmDetailBlock> src)
    {
        var dst = XedPaths.DisasmTargets(project).Table<XedDisasmDetailRow>();
        var buffer = text.buffer();
        XedDisasmRender.render(resequence(src), buffer);
        var emitting = Channel.EmittingFile(dst);
        using var emitter = dst.AsciEmitter();
        emitter.Write(buffer.Emit());
        Channel.EmittedFile(emitting, src.Count);
    }

    void EmitConsolidated(IProject project, Index<XedDisasmRow> src)
        => Channel.TableEmit(resequence(src), XedPaths.DisasmTargets(project).Table<XedDisasmRow>());


    public const string RenderCol2 = FieldRender.Columns;

    public readonly struct FieldEmitter
    {
        readonly HashSet<FieldKind> Exclusions;

        readonly FieldRender Render;

        public FieldEmitter()
        {
            Exclusions = hashset<FieldKind>(K.TZCNT,K.LZCNT,K.MAX_BYTES);
            Render = XedFields.render();
        }

        public uint EmitFields(XedDisasmDetail src, ITextEmitter dst)
        {
            var fields = XedDisasm.fields();
            ref readonly var data = ref src.DataFile;
            dst.AppendLineFormat(RenderCol2, "DataSource", src.Source.ToUri().Format());
            var counter = 0u;
            for(var i=0u; i<data.LineCount; i++)
            {
                ref readonly var block = ref src[i];
                XedDisasm.fields(block, ref fields);

                dst.AppendLine(RP.PageBreak240);
                dst.AppendLine(block.Lines.Format());
                dst.AppendLine(RP.PageBreak100);

                XedRender.describe(fields, dst);
                dst.AppendLine(RP.PageBreak100);

                var kinds = fields.Selected;
                for(var k=0; k<kinds.Length; k++)
                {
                    ref readonly var kind = ref skip(kinds,k);
                    if(Exclusions.Contains(kind))
                        continue;

                    dst.AppendLineFormat(RenderCol2, kind, Render[kind](fields.Fields[kind]));
                    counter++;
                }

                XedOps.render(block.Ops.Map(o => o.Spec), dst);
                if(i!=data.LineCount -1)
                    dst.AppendLine();
            }

            return counter;
        }
    }

    public void EmitChecks(IProject project, XedDisasmDoc src)
    {
        const string RenderPattern = "{0,-24} | {1}";
        var doc = src.Detail;
        ref readonly var file = ref doc.DataFile;
        var buffer = text.buffer();
        var count = doc.Count;
        var outpath = XedPaths.DisasmChecksPath(project, file.Source);
        using var dst = outpath.AsciWriter();
        var emitting = Channel.EmittingFile(outpath);
        dst.AppendLineFormat(RenderCol2, "DataSource", doc.Source.ToUri().Format());

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
            ref readonly var asmtxt = ref summary.Asm;
            ref readonly var ip = ref summary.IP;
            var cells = update(lines, ref state);
            var ocindex = XedOps.View.ocindex(state);
            var ockind = AsmOpCodeMaps.kind(ocindex);
            var encoding  = XedCode.encoding(state, asmhex);
            var ocbyte = View.ocbyte(state);
            var ochex = XedRender.format(ocbyte);
            var ocbits = BitRender.format8x4(ocbyte);

            dst.WriteLine(RP.PageBreak240);
            dst.AppendLine(lines.Format());
            dst.WriteLine(RP.PageBreak80);

            dst.AppendLineFormat(RenderPattern, nameof(detail.Instruction), detail.Instruction);
            dst.AppendLineFormat(RenderPattern, nameof(summary.InstructionId), summary.InstructionId);
            dst.AppendLineFormat(RenderPattern, nameof(detail.Form), detail.Form);
            dst.AppendLineFormat("{0,-24} | {1,-5} {2}", asmhex, ip, asmtxt);
            dst.AppendLineFormat(RenderPattern, "OcMap", ockind);
            dst.AppendLine(encoding.Format());
            dst.WriteLine(RP.PageBreak80);

            if(state.OSZ)
            {
                Require.invariant(state.PREFIX66);
                dst.AppendLineFormat(RenderPattern, nameof(state.OSZ), "0x66");
            }

            if(state.ASZ)
                dst.AppendLineFormat(RenderPattern, nameof(state.ASZ), "0x67");

            if(state.DF64)
                dst.AppendLineFormat(RenderPattern, nameof(state.DF64), "64");

            if(state.DF32)
                dst.AppendLineFormat(RenderPattern, nameof(state.DF32), "32");

            if(detail.PSZ != 0)
                dst.AppendLineFormat(RenderPattern, nameof(detail.PSZ), detail.PSZ);

            if(state.NSEG_PREFIXES != 0)
                dst.AppendLineFormat(RenderPattern, nameof(state.NSEG_PREFIXES), state.NSEG_PREFIXES);

            if(state.HINT != 0)
                dst.AppendLineFormat(RenderPattern, nameof(state.HINT), XedRender.format(View.hint(state)));

            if(state.REP != 0)
                dst.AppendLineFormat(RenderPattern, nameof(state.REP), XedRender.format(View.rep(state)));

            if(state.LOCK)
                dst.AppendLineFormat(RenderPattern, nameof(state.LOCK), state.LOCK);

            if(state.BRDISP_WIDTH != 0)
                dst.AppendLineFormat(RenderPattern, nameof(state.BRDISP_WIDTH), state.BRDISP_WIDTH);

            dst.AppendLineFormat(RenderPattern, nameof(state.EASZ), XedRender.format(View.easz(state)));
            dst.AppendLineFormat(RenderPattern, nameof(state.EOSZ), XedRender.format(View.eosz(state)));
            dst.AppendLineFormat(RenderPattern, nameof(state.MODE), MachineModes.format(View.mode(state)));
            dst.AppendLineFormat(RenderPattern, "OpCode", string.Format("{0} [{1}]", ochex, ocbits));

            if(state.SRM != 0)
            {
                var srmHex = XedRender.format((Hex8)state.SRM);
                var srmBits = BitRender.format8x4(state.SRM);
                dst.AppendLineFormat(RenderPattern, nameof(state.SRM), string.Format("{0} [{1}]", srmHex, srmBits));
            }

            if(state.HAS_MODRM)
            {
                var modrm = View.modrm(state);
                dst.AppendLineFormat(RenderPattern, "ModRm", string.Format("{0} [{1}]", modrm.Format(), modrm.ToBitString()));
            }

            if(state.HAS_SIB)
            {
                var sib = View.sib(state);
                dst.AppendLineFormat(RenderPattern, "Sib", string.Format("{0} [{1}]",  sib.Format(), sib.ToBitString()));
            }

            if(state.FIRST_F2F3 != 0)
                dst.AppendLineFormat(RenderPattern, nameof(state.FIRST_F2F3), state.FIRST_F2F3);

            if(state.ILD_F2 != 0)
                dst.AppendLineFormat(RenderPattern, nameof(state.ILD_F2), state.ILD_F2);

            if(state.ILD_F3 != 0)
                dst.AppendLineFormat(RenderPattern, nameof(state.ILD_F3), state.ILD_F3);

            if(state.LAST_F2F3!= 0)
                dst.AppendLineFormat(RenderPattern, nameof(state.LAST_F2F3), state.LAST_F2F3);

            if(state.REX)
            {
                var rex = View.rex(state);
                Require.invariant(state.NREXES != 0);
                dst.AppendLineFormat(RenderPattern, "Rex", string.Format("{0} [{1}]", rex, rex.ToBitString()));
                dst.AppendLineFormat(RenderPattern, "RexBits", string.Format("[0100 | W:{0} | R:{1} | X:{2} | B:{3}]", state.REXW, state.REXR, state.REXX, state.REXB));
            }

            if(encoding.Disp != 0)
            {
                dst.AppendLineFormat(RenderPattern, nameof(state.DISP_WIDTH), state.DISP_WIDTH);
                dst.AppendLineFormat(RenderPattern, nameof(encoding.Disp), encoding.Disp);
            }

            if(state.MEM0)
                dst.AppendLineFormat(RenderPattern, nameof(state.MEM0), state.MEM0);

            if(state.MEM1)
                dst.AppendLineFormat(RenderPattern, nameof(state.MEM1), state.MEM1);

            if(state.NEED_MEMDISP !=0)
                dst.AppendLineFormat(RenderPattern, nameof(state.NEED_MEMDISP), state.NEED_MEMDISP);

            if(state.UBIT)
                dst.AppendLineFormat(RenderPattern, nameof(state.UBIT), state.UBIT);

            if(state.IMM0)
            {
                dst.AppendLineFormat(RenderPattern, nameof(state.IMM_WIDTH), state.IMM_WIDTH);
                dst.AppendLineFormat(RenderPattern, nameof(encoding.Imm), encoding.Imm);
            }

            if(state.IMM1)
                dst.AppendLineFormat(RenderPattern, nameof(encoding.Imm1), encoding.Imm1);

            if(state.SAE)
                dst.AppendLineFormat(RenderPattern, nameof(state.SAE), state.SAE);

            if(state.ESRC != 0)
                dst.AppendLineFormat(RenderPattern, nameof(state.ESRC), XedRender.format((Hex8)state.ESRC));

            if(state.ROUNDC != 0)
                dst.AppendLineFormat(RenderPattern, nameof(state.ROUNDC), XedRender.format(View.rounding(state)));

            var rc = (RoundingKind)state.ROUNDC;
            if(rc == 0 && state.LLRC != 0)
                dst.AppendLineFormat(RenderPattern, nameof(state.LLRC), XedRender.format((Hex8)state.LLRC));

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

            var vc = XedOps.View.vexclass(state);
            if(vc != 0)
            {
                var vk = XedOps.View.vexkind(state);
                var vex5 = BitNumbers.join((uint3)state.VEXDEST210, state.VEXDEST4, state.VEXDEST3);
                var vexBits = string.Format("[{0} {1} {2}]", state.VEXDEST4, state.VEXDEST3, (uint3)state.VEXDEST210);
                var vexHex = XedRender.format((Hex8)(byte)vex5);
                dst.AppendLineFormat(RenderPattern, nameof(state.VEXVALID), XedRender.format(vc));
                dst.AppendLineFormat(RenderPattern, nameof(state.VEX_PREFIX), vk == 0 ? "VNP" : XedRender.format(vk));
                if(vc == XedVexClass.VV1)
                    dst.AppendLineFormat(RenderPattern, "Vex", detail.Vex);
                else if(vc == XedVexClass.EVV)
                    dst.AppendLineFormat(RenderPattern, "Evex", detail.Evex);
                dst.AppendLineFormat(RenderPattern, "VEXDEST", string.Format("{0} {1}", vexHex, vexBits));
            }

            if(state.ELEMENT_SIZE != 0)
                dst.AppendLineFormat(RenderPattern, "VexSize", string.Format("{0}x{1}", XedRender.format(View.vl(state)), XedRender.format(state.ELEMENT_SIZE)));

            if(state.NELEM != 0)
                dst.AppendLineFormat(RenderPattern, nameof(state.NELEM), state.NELEM);

            if(state.BCAST != 0)
                dst.AppendLineFormat(RenderPattern, nameof(state.BCAST), View.broadcast(state));

            if(state.REXRR)
                dst.AppendLineFormat(RenderPattern, nameof(state.REXRR), state.REXRR);

            if(state.OUTREG != 0)
            {
                dst.AppendLineFormat(RenderPattern, nameof(state.OUTREG), XedRegMap.map(state.OUTREG));
            }

            XedDisasmRender.render(ops, buffer);
            dst.WriteLine(buffer.Emit());
        }

        Channel.EmittedFile(emitting,counter);
    }
}
