//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static sys;

public class SdmFormDescriptor
{
    static AsmBitModeKind mode(in SdmOpCodeDetail src)
    {
        var mode = AsmBitModeKind.None;
        if(src.Mode32.Format().Trim() == "Valid")
            mode |= AsmBitModeKind.Mode32;
        if(src.Mode64.Format().Trim() == "Valid")
            mode |= AsmBitModeKind.Mode64;
        return mode;
    }

    public readonly SdmForm Form;

    public readonly SdmOpCodeDetail OcDetail;

    public readonly AsmBitModeKind Mode;

    public readonly TextBlock Description;

    [MethodImpl(Inline)]
    public SdmFormDescriptor(SdmForm form, SdmOpCodeDetail oc)
    {
        Form = form;
        OcDetail = oc;
        Mode = mode(oc);
        Description = oc.Description.Format().Trim();
    }

    public Hash32 Hash
    {
        [MethodImpl(Inline)]
        get => Name.Hash;
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

    public ref readonly AsmOpCodeSpec OpCode
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
        => new (Form.WithName(name), OcDetail);
}
