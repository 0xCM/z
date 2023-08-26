//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

[ApiHost]
public partial class AsmCases
{
    [Op]
    public static AsmEncodingCase @case(uint seq, AsmMnemonic monic, ResText oc, ResText sig, ResText statement, ResText encoding)
    {
        var dst = AsmEncodingCase.Empty;
        dst.Seq = seq;
        dst.Mnemonic = monic;
        SdmOpCodes.parse(oc.Format(), out dst.OpCode);
        AsmBytes.parse(encoding.Format(), out dst.Encoding);
        AsmSigs.parse(sig.Format(), out dst.Sig);
        dst.Asm = statement.Format();
        return dst;
    }
}
