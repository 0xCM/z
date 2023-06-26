//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    partial struct SdmOps
    {
        public static ReadOnlySeq<SdmForm> forms(ReadOnlySpan<SdmOpCodeDetail> src)
        {
            var count = src.Length;
            var dst = alloc<SdmForm>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = form(skip(src,i));
            return dst;
        }

        public static SdmForm form(in SdmOpCodeDetail src)
        {
            var result = AsmSigs.parse(src.AsmSig.View, out AsmSig sig);
            if(result.Fail)
                Errors.Throw(result.Message);

            result = SdmOpCodes.parse(src.OpCodeExpr, out AsmOpCodeSpec opcode);
            if(result.Fail)
                Errors.Throw(result.Message);

            return SdmForms.form(sig,opcode);
        }
    }
}