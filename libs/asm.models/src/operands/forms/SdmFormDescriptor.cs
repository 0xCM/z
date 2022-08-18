//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    public class SdmFormDescriptor
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

        static AsmBitModeKind mode(in SdmOpCodeDetail src)
        {
            var mode = AsmBitModeKind.None;
            if(src.Mode32.Format().Trim() == "Valid")
                mode |= AsmBitModeKind.Mode32;
            if(src.Mode64.Format().Trim() == "Valid")
                mode |= AsmBitModeKind.Mode64;
            return mode;
        }

        public readonly Hex32 Id;

        public readonly SdmForm Form;

        readonly SdmOpCodeDetail OcDetail;

        public readonly AsmBitModeKind Mode;

        public readonly TextBlock Description;

        [MethodImpl(Inline)]
        public SdmFormDescriptor(SdmForm form, SdmOpCodeDetail oc)
        {
            Id = form.Id;
            Form = form;
            OcDetail = oc;
            Mode = mode(oc);
            Description = oc.Description.Format().Trim();
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => (uint)Id;
        }

        public ref readonly asci64 Name
        {
            [MethodImpl(Inline)]
            get => ref Form.Name;
        }

        public ref readonly AsmSig Sig
        {
            [MethodImpl(Inline)]
            get => ref Form.Sig;
        }

        public ref readonly SdmOpCode OpCode
        {
            [MethodImpl(Inline)]
            get => ref Form.OpCode;
        }

        public ref readonly AsmMnemonic Mnemonic
        {
            [MethodImpl(Inline)]
            get => ref Sig.Mnemonic;
        }

        [MethodImpl(Inline)]
        public SdmFormDescriptor WithName(in asci64 name)
            => new SdmFormDescriptor(Form.WithName(name), OcDetail);
    }
}