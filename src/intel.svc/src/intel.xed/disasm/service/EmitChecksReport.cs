//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;
    using static XedDisasm;
    using static XedDisasmModels;
    using static XedOps;

    partial class XedDisasmSvc
    {
        public void EmitChecksReport(ProjectContext context, DisasmDoc src)
            => EmitChecksReport(context, src.Detail);

        void EmitChecksReport(ProjectContext context, DisasmDetail doc)
        {
            const string RenderPattern = "{0,-24} | {1}";
            ref readonly var file = ref doc.DataFile;
            var buffer = text.buffer();
            var count = doc.Count;
            var outpath = XedPaths.DisasmChecksPath(context.Project.Name,file.Source);
            using var dst = outpath.AsciWriter();
            var emitting = EmittingFile(outpath);
            dst.AppendLineFormat(RenderCol2, "DataSource", doc.Source.Path.ToUri().Format());

            var counter = 0;
            for(var j=0; j<count; j++)
            {
                var state = OperandState.Empty;
                buffer.Clear();

                ref readonly var detail = ref doc[j].DetailRow;
                ref readonly var ops = ref doc[j].Ops;
                ref readonly var block = ref doc[j].SummaryLines;
                ref readonly var summary = ref block.Row;
                ref readonly var lines = ref block.Block;
                ref readonly var asmhex = ref summary.Encoded;
                ref readonly var asmtxt = ref summary.Asm;
                ref readonly var ip = ref summary.IP;
                var cells = XedDisasm.update(lines, ref state);
                var ocindex = XedOps.View.ocindex(state);
                var ockind = AsmOpCodeMaps.kind(ocindex);
                var encoding  = XedCode.encoding(state, asmhex);
                var ocbyte = View.ocbyte(state);
                var ochex = XedRender.format(ocbyte);
                var ocbits = BitRender.format8x4(ocbyte);

                dst.WriteLine(RpOps.PageBreak240);
                dst.AppendLine(lines.Format());
                dst.WriteLine(RpOps.PageBreak80);

                dst.AppendLineFormat(RenderPattern, nameof(detail.Instruction), detail.Instruction);
                dst.AppendLineFormat(RenderPattern, nameof(summary.InstructionId), summary.InstructionId);
                dst.AppendLineFormat(RenderPattern, nameof(detail.Form), detail.Form);
                dst.AppendLineFormat("{0,-24} | {1,-5} {2}", asmhex, ip, asmtxt);
                dst.AppendLineFormat(RenderPattern, "OcMap", ockind);
                dst.AppendLine(encoding.Format());
                dst.WriteLine(RpOps.PageBreak80);

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

                DisasmRender.render(ops, buffer);
                dst.WriteLine(buffer.Emit());
            }

            EmittedFile(emitting,counter);
        }
    }
}