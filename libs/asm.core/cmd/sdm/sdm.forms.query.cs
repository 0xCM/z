//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static core;

    partial class AsmCoreCmd
    {
        [CmdOp("sdm/check/opcodes")]
        Outcome CheckAsmOpCodes(CmdArgs args)
        {
            var result = Outcome.Success;
            var src = Sdm.LoadOcDetails();
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var detail = ref src[i];
                ref readonly var input = ref detail.OpCodeExpr;
                SdmOpCodes.parse(detail.OpCodeExpr, out var opcode).Require();
                result = CheckEquality(input.Format(), opcode);
                if(result.Fail)
                {
                    result = (false, string.Format("Equality check failed for <{0}>", input.Format().Trim()));
                    break;
                }

                Write(string.Format("{0,-6} | {1,-16} | {2,-28} | {3}", detail.OpCodeKey, opcode.OcValue(), opcode, detail.AsmSig));
            }

            return result;
        }

        static bool CheckEquality(in CharBlock36 input, in SdmOpCode parsed)
            => input.Format().Trim().Equals(parsed.Format());

        [CmdOp("sdm/check/sigs")]
        Outcome CheckAsmSigs(CmdArgs args)
        {
            var details = Sdm.LoadOcDetails();
            var count = details.Count;
            var buffer = text.buffer();
            for(var i=0; i<count; i++)
            {
                ref readonly var detail = ref details[i];
                AsmSigs.parse(detail.AsmSig, out var sig);
                buffer.Append(sig.Mnemonic.Format());
                if(sig.OpCount != 0)
                {
                    buffer.Append("<");
                    for(var j=0; j<sig.OpCount; j++)
                    {
                        if(j != 0)
                            buffer.Append(", ");

                        buffer.Append(AsmSigs.identify(sig[j]));
                    }
                    buffer.Append(">");
                }

                Write(buffer.Emit());
            }

            return true;
        }

        [CmdOp("sdm/forms/query")]
        Outcome AsmFormQuery(CmdArgs args)
        {
            var forms = Sdm.CalcForms();
            var count = forms.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var form = ref forms[i];
                ref readonly var opcode = ref form.OpCode;
                if(SdmOpCodes.imm(opcode, out var token))
                    Write(string.Format("{0} | {1}", token, form));
            }

            return true;
        }
    }
}