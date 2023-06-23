//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static sys;
    using static XedModels;
    using static XedOps;
    using static XedRules;

    partial class XedDisasm
    {
        static Dictionary<OpNameKind,OpData> ops(in XedDisasmState state, in AsmHexCode code)
        {
            var dst = dict<OpNameKind,OpData>();
            var values = XedCode.ops(state.RuleState, code);
            var count = values.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var value = ref values[i];
                dst.TryAdd(value.Name, new OpData(value));
            }

            if(state.RELBRVal.IsNonZero)
                dst[OpNameKind.RELBR] = new OpData(OpNameKind.RELBR, state.RELBRVal);
            if(state.MEM0Val.IsNonEmpty)
                dst[OpNameKind.MEM0] = new OpData(OpNameKind.MEM0, state.MEM0Val);
            if(state.MEM1Val.IsNonEmpty)
                dst[OpNameKind.MEM1] = new OpData(OpNameKind.MEM1, state.MEM1Val);
            if(state.AGENVal.IsNonEmpty)
                dst[OpNameKind.AGEN] = new OpData(OpNameKind.AGEN, state.AGENVal);
            return dst;
        }

        static XedDisasmDetailRow row(in XedDisasmLines src)
        {
            ref readonly var lines = ref src.Block;
            ref readonly var summary = ref src.Row;
            ref readonly var code = ref summary.Encoded;
            var inst = Instruction.Empty;
            parse(src, out inst);

            var dst = XedDisasmDetailRow.Empty;
            dst.Seq = summary.Seq;
            dst.DocSeq = summary.DocSeq;
            dst.OriginId = summary.OriginId;
            dst.OriginName = summary.OriginName;
            dst.EncodingId = summary.EncodingId;
            dst.InstructionId = asm.instid(summary.OriginId, summary.IP, code.Bytes);
            dst.IP = summary.IP;
            dst.Encoded = summary.Encoded;
            dst.Asm = summary.Asm;
            dst.Form = inst.Form;
            dst.Instruction = inst.Class;
            dst.SourceName = text.remove(summary.Source.Path.FileName.Format(), "." + ApiAtomic.xeddisasm_raw);
            var dstate = new XedDisasmFieldParser().Parse(inst.Props);
            var opsLU = ops(dstate, code);
            ref readonly var state = ref dstate.RuleState;
            dst.Offsets = XedCode.offsets(state);
            dst.OpCode = state.NOMINAL_OPCODE;
            dst.Ops = new OpDetails(alloc<OpDetail>(src.Block.OpCount));
            var ocpos = state.POS_NOMINAL_OPCODE;
            var opcode = state.NOMINAL_OPCODE;
            var ocsrm = math.and((byte)state.SRM, opcode);
            Require.equal(state.SRM, ocsrm);

            if(opcode != code[ocpos])
                Errors.Throw(string.Format("Extracted opcode value {0} differs from parsed opcode value {1}", state.NOMINAL_OPCODE, state.MODRM_BYTE));

            for(var k=0; k<lines.OpCount; k++)
            {
                ref var operand = ref dst.Ops[k];
                var result = parse(skip(lines.Ops, k).Content, out operand.Spec);
                if(result.Fail)
                    Errors.Throw(result.Message);

                var spec = operand.Spec;
                var winfo = XedOps.describe(spec.WidthCode);
                operand.OpWidth = winfo;
                operand.OpName = spec.Name;
                var optxt = EmptyString;
                if(opsLU.TryGetValue(spec.Name, out var opval))
                {
                    operand.Def = opval;
                    optxt = opval.Format();
                    operand.RuleDescription = optxt;
                }

                operand.DefDescription = string.Format(XedDisasmRender.OpDetailPattern,
                    string.Format("Op{0}", k),
                    spec.Name,
                    optxt,
                    spec.Action,
                    spec.Visibility,
                    winfo.Width64,
                    winfo.Name,
                    OpSpec.specifier(spec)
                    );
            }

            if(opsLU.TryGetValue(OpNameKind.DISP, out var disp))
                dst.Disp = (Disp)disp;

            var prefix = ocpos != 0 ? slice(code.Bytes,0,ocpos) : default;
            dst.PSZ = (byte)prefix.Length;

            var legacyskip = z8;
            for(var k=0; k<prefix.Length; k++)
            {
                ref readonly var b = ref skip(prefix,k);
                if(AsmPrefixTests.opsz(b))
                {
                    dst.SZOV = AsmPrefix.opsz();
                    legacyskip++;
                }
                else if(AsmPrefixTests.adsz(b))
                {
                    dst.SZOV = AsmPrefix.adsz();
                    legacyskip++;
                }
            }

            if(state.REX)
                dst.Rex = View.rex(state);

            if(state.HAS_MODRM)
            {
                var modrm = View.modrm(state);
                dst.ModRm = modrm;
                if(modrm != code[state.POS_MODRM])
                {
                    var msg = string.Format("Derived ModRM value {0} differs from encoded value {1}", modrm, code[state.POS_MODRM]);
                    Errors.Throw(msg);
                }
            }

            if(state.HAS_SIB)
            {
                var sib = View.sib(state);
                dst.Sib = sib;
                var sibenc = Sib.init(code[state.POS_SIB]);
                if(sibenc.Value() != sib)
                {
                    var msg = string.Format("Derived Sib value {0} differs from encoded value {1}", sib, sibenc);
                    Errors.Throw(msg);
                }
            }

            if(state.VEXVALID == (byte)XedVexClass.VV1)
            {
                var vexcode = VexPrefix.code(prefix);
                var vexsize = VexPrefix.size(vexcode.Value);
                var vexbytes = slice(prefix, vexcode.Offset, vexsize);
                var vexdest = (uint5)((uint3)state.VEXDEST210 | (byte)state.VEXDEST3 << 3 | (byte)state.VEXDEST4 << 4);
                Require.equal(vexbytes.Length, vexsize);

                if(vexcode.Value == AsmPrefixCodes.VexPrefixCode.C4)
                    dst.Vex = VexPrefix.define(AsmPrefixCodes.VexPrefixKind.xC4,skip(vexbytes, 1), skip(vexbytes,2));
                else if(vexcode.Value == AsmPrefixCodes.VexPrefixCode.C5)
                    dst.Vex = VexPrefix.define(AsmPrefixCodes.VexPrefixKind.xC5,skip(vexbytes, 1));

            }
            else if(state.VEXVALID == (byte)XedVexClass.EVV)
                dst.Evex = EvexPrefix.define(slice(prefix,legacyskip));

            if(state.IMM0)
                dst.Imm = asm.imm(code, state.POS_IMM, state.IMM0SIGNED, Sizes.native(state.IMM_WIDTH));

            dst.EASZ = Sizes.native(XedOps.width((EASZ)state.EASZ));
            dst.EOSZ = Sizes.native(XedOps.bitwidth((EOSZ)state.EOSZ));
            return dst;
        }
    }
}