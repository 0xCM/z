//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Linq;
using Asm;

using static sys;
using static XedModels;
using static XedRules;

public partial class XedDisasm : WfSvc<XedDisasm>
{
    static long DisasmTokens;    

    static readonly BpDef ModRmPattern = AsmBitPatterns.ModRm.Def;

    static readonly BpDef SibPattern = AsmBitPatterns.Sib.Def;

    static readonly BpDef VexC4Pattern = AsmBitPatterns.VexC4.Def;

    static readonly BpDef VexC5Pattern = AsmBitPatterns.VexC5.Def;

    static readonly BpDef RexPattern = AsmBitPatterns.Rex.Def;

    static readonly BpDef EvexPattern = AsmBitPatterns.Evex.Def;

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

    public void EmitDetails(XedDisasmContext context, XedDisasmDoc src, FilePath? dst = null)
    {
        var path = dst ?? context.DisasmDetailPath(src.SourcePath);
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
        Consolidate(context);
        return docs;
    }

    void EmitSummaries(XedDisasmContext context, XedDisasmDoc doc, FilePath? dst = null)
        => Channel.TableEmit(doc.Summary.Rows, dst ?? context.DisasmSummaryPath(doc.SourcePath));

    const string OperandFormat = "{0} | {1,-20} | {2}";

    public void EmitOps(XedDisasmContext context, XedDisasmDoc src, FilePath? dst = null)
    {
        var path = dst ?? context.DisasmOpsPath(src.Detail.DataFile.Source);
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

    public static ParallelQuery<Instruction> consolidate(XedDisasmContext context)
        => (from b in context.Blocks select b.Instruction).AsParallel().OrderBy(x => x.Form).ThenBy(x => x.Asm);

    void Consolidate(XedDisasmContext context)
    {
        var dst = context.ProjectRoot.Scoped("build");
        exec(PllExec,
            () => EmitConsolidated(resequence(context.Blocks.ToArray()), dst),
            () => EmitConsolidated(resequence((from block in context.Blocks select block.SummaryRow).ToArray()), dst));
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

    static string format(ReadOnlySpan<FieldValue> src)
    {
        var dst = text.emitter();
        dst.Append(Chars.LBrace);
        for(var i=0; i<src.Length; i++)
        {
            if(i!=0)
                dst.Append(", ");
            dst.Append($"{src[i].Field}:{src[i].Format()}");
        }
        dst.Append(Chars.RBrace);
        return dst.Emit();        
    }

    public void EmitChecks(XedDisasmContext context, XedDisasmDoc src, FilePath? dst = null)
    {
        const string LabeledValue = "{0,-24} | {1}";
        var detail = src.Detail;
        var buffer = text.buffer();
        var count = detail.Count;
        var outpath = dst ?? context.DisasmChecksPath(detail.DataFile.Source);
        using var writer = outpath.AsciWriter();
        var emitting = Channel.EmittingFile(outpath);
        writer.AppendLineFormat(RenderCol2, "DataSource", detail.Source.ToUri().Format());
        var counter = 0;
        var fields = span<FieldValue>(148);
        for(var j=0; j<count; j++)
        {
            var state = XedFieldState.Empty;
            buffer.Clear();
            fields.Clear();

            ref readonly var row = ref detail[j].DetailRow;
            ref readonly var block = ref detail[j].SummaryLines;
            ref readonly var summary = ref block.Row;
            ref readonly var lines = ref block.Block;
            ref readonly var asmhex = ref summary.Encoded;
            ref readonly var ip = ref summary.IP;
            var fieldcount = update(lines, fields, ref state);

            writer.WriteLine(RP.PageBreak240);
            for(var i=0; i<lines.Lines.Count; i++)
                writer.AppendLineFormat("# {0}", text.despace(lines.Lines[i].Content));
            
            writer.WriteLine(RP.PageBreak80);

            writer.AppendLineFormat(LabeledValue, nameof(row.Instruction), row.Instruction);            
            writer.AppendLineFormat(LabeledValue, nameof(row.Form), row.Form);
            writer.AppendLineFormat(LabeledValue, nameof(row.IP), row.IP);
            writer.AppendLineFormat(LabeledValue, nameof(row.Asm), row.Asm);

            var pattern = context.InstPatterns.Match(row.Form, context.Mode).FirstOrDefault();
            if(pattern != null)
            {
                writer.AppendLineFormat(LabeledValue, "Pattern", pattern.Body.Format());
                var ops = pattern.Operands;
                for(var i=0; i<ops.Count; i++)
                {
                    ref readonly var op = ref ops[i];
                    var opspec = $"{i} {op.Name.Format()}:{op.Kind}";
                    if(op.Register.IsNonEmpty)
                        opspec += $":{op.Register.Format()}";
                    if(op.Width.Bits != 0)
                        opspec += $":w{op.Width.Bits}";
                    else if(op.Width.Code != 0)
                        opspec += $":{op.Width.Code}";                    
                    writer.AppendLineFormat(LabeledValue, EmptyString, opspec);
                }
            }
            else
                writer.AppendLineFormat(LabeledValue, $"Pattern", "<error>");

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
            writer.AppendLineFormat(LabeledValue, "OpCode", AsmOpCodes.opcode(context.Mode, XedFields.ocindex(state), XedFields.opcode(state)));

            var offsets = row.Offsets;
            var encoding  = XedFields.encoding(state, asmhex);
            if(row.PrefixSize != 0)
                writer.AppendLineFormat(LabeledValue, nameof(row.PrefixSize), row.PrefixSize);
            writer.AppendLineFormat(LabeledValue, nameof(row.Offsets), offsets);
            writer.AppendLineFormat(LabeledValue, nameof(row.Encoded), row.Encoded);
            writer.AppendLineFormat(LabeledValue, EmptyString, row.Encoded.BitString);

            var prefix = slice(row.PrefixBytes.Bytes, 0, row.PrefixSize);
            if(row.PrefixSize != 0)
                writer.AppendLineFormat(LabeledValue, nameof(row.PrefixBytes), prefix.FormatHex());

            if(state.SRM != 0)
                writer.AppendLineFormat(LabeledValue, nameof(state.SRM), string.Format("{0} [{1}]", state.SRM.Hex(), state.SRM.Bitstring()));

            if(state.HAS_MODRM)
            {
                var modrm = Require.equal(XedFields.modrm(state), row.ModRm);
                writer.AppendLineFormat(LabeledValue, "ModRm", modrm.Format());
                writer.AppendLineFormat(LabeledValue, EmptyString, ModRmPattern.Symbolic());
                writer.AppendLineFormat(LabeledValue, EmptyString, ModRmPattern.BitString(modrm));
            }

            if(state.HAS_SIB)
            {
                var sib = Require.equal(XedFields.sib(state), row.Sib);
                writer.AppendLineFormat(LabeledValue, "Sib", sib.Format());
                writer.AppendLineFormat(LabeledValue, EmptyString, SibPattern.Symbolic());
                writer.AppendLineFormat(LabeledValue, EmptyString, SibPattern.BitString(sib));
            }

            if(state.REX)
            {
                var rex = XedFields.rex(state);
                Require.invariant(state.NREXES != 0);
                writer.AppendLineFormat(LabeledValue, "Rex", rex);
                writer.AppendLineFormat(LabeledValue, EmptyString, RexPattern.Symbolic());
                writer.AppendLineFormat(LabeledValue, EmptyString, RexPattern.BitString(rex));
                writer.AppendLineFormat(LabeledValue, nameof(state.REXW), state.REXW);
                writer.AppendLineFormat(LabeledValue, nameof(state.REXR), state.REXR);
                writer.AppendLineFormat(LabeledValue, nameof(state.REXX), state.REXX);
                writer.AppendLineFormat(LabeledValue, nameof(state.REXB), state.REXB);
            }

            writer.AppendLineFormat(LabeledValue, nameof(state.REXRR), state.REXRR);
            
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

            var vc = XedFields.vexvalid(state);
            if(vc != 0)
            {
                var vex5 = Numbers.pack((num3)(byte)state.VEXDEST210, state.VEXDEST4, state.VEXDEST3);
                if(vc == VexValid.VV1)
                {
                    IBitPattern vp = row.VexPrefix.VexKind == VexPrefixKind.xC4 ? VexC4Pattern : VexC5Pattern;
                    writer.AppendLineFormat(LabeledValue, nameof(row.VexPrefix.VexKind), row.VexPrefix.VexKind);
                    writer.AppendLineFormat(LabeledValue, nameof(row.VexPrefix), vp.Symbolic());
                    writer.AppendLineFormat(LabeledValue, EmptyString, vp.BitString(row.VexPrefix));

                }
                else if(vc == VexValid.EVV)
                {
                    if(prefix.Length < 4)
                    {
                        writer.AppendLineFormat(LabeledValue, "Evex", "<evex:error>");
                    }
                    else
                    {
                         var evex = @as<EvexPrefix>(prefix);
                         writer.AppendLineFormat(LabeledValue, "Evex",  evex.Format());
                         writer.AppendLineFormat(LabeledValue, EmptyString, EvexPattern.Symbolic());
                         writer.AppendLineFormat(LabeledValue, EmptyString, EvexPattern.BitString(evex));
                    }
                }
                writer.AppendLineFormat(LabeledValue, "VEXDEST", string.Format("{0} {1}", vex5.Hex(), vex5.Bitstring()));
                writer.AppendLineFormat(LabeledValue, "VL", XedRender.format(XedFields.vl(state)));
            }
            
            if(state.ELEMENT_SIZE != 0)
                writer.AppendLineFormat(LabeledValue, nameof(state.ELEMENT_SIZE), XedRender.format(state.ELEMENT_SIZE));

            if(state.NELEM != 0)
                writer.AppendLineFormat(LabeledValue, nameof(state.NELEM), state.NELEM);

            if(state.BCAST != 0)
                writer.AppendLineFormat(LabeledValue, nameof(state.BCAST), XedFields.broadcast(state));


            if(state.OUTREG != 0)
                writer.AppendLineFormat(LabeledValue, nameof(state.OUTREG), XedPatterns.regop(state.OUTREG));

            operands(row, buffer);
            writer.WriteLine(buffer.Emit());
        }

        Channel.EmittedFile(emitting,counter);
    }
}
