//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

[StructLayout(LayoutKind.Sequential, Pack=1)]
public readonly record struct Jcc8 : IAsmInstruction<Jcc8>
{
    public readonly Jcc8Code JccCode;

    public readonly Disp8 Disp;

    [MethodImpl(Inline)]
    public Jcc8(Jcc8Code code, Disp8 src)
    {
        JccCode = code;
        Disp = src;
    }
}
