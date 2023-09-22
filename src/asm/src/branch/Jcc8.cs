//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static ConditionTokens;

[StructLayout(LayoutKind.Sequential, Pack=1)]
public readonly record struct Jcc8 : IAsmInstruction<Jcc8>
{
   readonly byte Data;

    public readonly Disp8 Disp;

    [MethodImpl(Inline)]
    public Jcc8(Jcc8Code code, Disp8 src)
    {
        Data = (byte)code;
        Disp = src;
    }

    [MethodImpl(Inline)]
    public Jcc8(Jcc8AltCode code, Disp8 src)
    {
        Data = bits.enable((byte)code, 7);
        Disp = src;
    }

    bit Alt
    {
        [MethodImpl(Inline)]
        get  =>  bits.test(Data,7);
    }

    public JccKind Kind
    {
        [MethodImpl(Inline)]
        get =>  Alt ? JccKind.Jcc8Alt : JccKind.Jcc8;
    }

    public Hex8 JccCode
    {
        [MethodImpl(Inline)]
        get => Alt ? bits.disable(Data,7) : Data;
    }
}
