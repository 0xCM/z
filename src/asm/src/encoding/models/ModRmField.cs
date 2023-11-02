//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

public readonly record struct ModRmField
{
    public static ModRmField Mod => new(2,'m','m');

    public static ModRmField Reg => new(1,'r', 'r', 'r');

    public static ModRmField Rm => new(0,'m', 'm', 'm');

    readonly AsciSymbol B0;

    readonly AsciSymbol B1;

    readonly AsciSymbol B2;

    readonly byte Index;

    [MethodImpl(Inline)]
    ModRmField(byte index, char b0, char b1)
    {
        B0 = b0;
        B1 = b1;
        B2 = AsciSymbol.Empty;
    }

    [MethodImpl(Inline)]
    ModRmField(byte index, char b0, char b1, char b2)
    {
        B0 = b0;
        B1 = b1;
        B2 = b2;
    }

    public bool IsMod
    {
        [MethodImpl(Inline)]
        get => Index == 2;
    }

    public bool IsReg
    {
        [MethodImpl(Inline)]
        get => Index == 1;
    }

    public bool IsRm
    {
        [MethodImpl(Inline)]
        get => Index == 0;
    }

    [MethodImpl(Inline)]
    public ModRmField Set(bit? b0 = null, bit? b1 = null, bit? b2 =null)
    {
        var f0 = b0 != null ? (b0.Value ? AsciSymbols.d1 : AsciSymbols.d2) : AsciSymbol.Empty;
        var f1 = b1 != null ? (b1.Value ? AsciSymbols.d1 : AsciSymbols.d2) : AsciSymbol.Empty;
        var f2 = b2 != null ? (b2.Value ? AsciSymbols.d1 : AsciSymbols.d2) : AsciSymbol.Empty;
        return new(Index, f0,f1,f1);
    }

    [MethodImpl(Inline)]
    public ModRmField Set(num3 src)
    {
        return new(
            Index,
            (char)(src[0] ? BinaryDigitSym.b1 : BinaryDigitSym.b0),
            (char)(src[1] ? BinaryDigitSym.b1 : BinaryDigitSym.b0),
            (char)(src[2] ? BinaryDigitSym.b1 : BinaryDigitSym.b0)
            );
    }

    [MethodImpl(Inline)]
    public ModRmField Set(num2 src)
    {
        return new(
            Index,
            (char)(src[0] ? BinaryDigitSym.b1 : BinaryDigitSym.b0),
            (char)(src[1] ? BinaryDigitSym.b1 : BinaryDigitSym.b0)
            );
    }
    
    public string Format()
        => B2.IsEmpty ? $"{B1}{B0}" : $"{B2}{B1}{B0}";

    public override string ToString()
        => Format();            
}
