//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free, ApiHost]
    public class SdmForms
    {
        public static SdmForm form(in AsmSig sig, in AsmOpCodeSpec opcode)
            => new SdmForm(asci64.Null,sig, opcode);

        public static SdmForm form(in asci64 name, in AsmSig sig, in AsmOpCodeSpec opcode)
            => new SdmForm(name, sig, opcode);
    }
}