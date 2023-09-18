//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    using Asm;

    using static sys;

    [Free, ApiHost]
    public class SdmForms
    {
        public static Index<SdmFormDescriptor> unmodify(ReadOnlySpan<SdmFormDescriptor> src)
        {
            var count = src.Length;
            var buffer = alloc<SdmFormDescriptor>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var form = ref skip(src,i);
                ref var dst = ref seek(buffer,i);
                if(AsmSigs.modified(form.Sig))
                    dst = new SdmFormDescriptor(SdmForms.form(AsmSigs.unmodify(form.Sig), form.OpCode), form.OcDetail);
                else
                    dst = form;
            }
            return buffer;
        }

        public static SdmForm form(in AsmSig sig, in AsmOpCodeSpec opcode)
            => new (asci64.Null,sig, opcode);

        public static SdmForm form(in asci64 name, in AsmSig sig, in AsmOpCodeSpec opcode)
            => new (name, sig, opcode);
    }
}