//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[StructLayout(LayoutKind.Sequential,Pack=1)]
public readonly record struct SdmForm : IDataType<SdmForm>, IExpr
{
    public readonly Hex32 Id;

    public readonly asci64 Name;

    public readonly AsmSig Sig;

    public readonly AsmOpCodeSpec OpCode;

    [MethodImpl(Inline)]
    public SdmForm(asci64 name, AsmSig sig, AsmOpCodeSpec oc)
    {
        Id = name.Hash | sig.Hash | oc.Hash;
        Name = name;
        Sig = sig;
        OpCode = oc;
    }

    [MethodImpl(Inline)]
    public SdmForm WithName(in asci64 name)
        => SdmForms.form(name, Sig, OpCode);

    public bool IsEmpty
    {
        [MethodImpl(Inline)]
        get => Name.IsNull;
    }

    public bool IsNonEmpty
    {
        [MethodImpl(Inline)]
        get => !Name.IsNull;
    }

    public AsmMnemonic Mnemonic
    {
        [MethodImpl(Inline)]
        get => Sig.Mnemonic;
    }

    public byte OpCount
    {
        [MethodImpl(Inline)]
        get => Sig.OpCount;
    }

    public Hash32 Hash
    {
        [MethodImpl(Inline)]
        get => (uint)Id;
    }

    public AsmSigOps Operands
    {
        [MethodImpl(Inline)]
        get => Sig.Operands;
    }

    [MethodImpl(Inline)]
    public bool Equals(SdmForm src)
        => Name == src.Name && Sig == src.Sig && OpCode == src.OpCode;

    public override int GetHashCode()
        => Hash;

    public int CompareTo(SdmForm src)
    {
        var result = Sig.CompareTo(src.Sig);
        if(result == 0)
            result = OpCode.Format().CompareTo(src.OpCode.Format());
        return result;
    }

    public string Format()
        => string.Format("{0,-48} | {1}", Sig, OpCode);

    public override string ToString()
        => Format();

    public static SdmForm Empty => default;
}
