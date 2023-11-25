//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;
[StructLayout(LayoutKind.Sequential, Pack=1)]
public readonly record struct Jcc32 : IAsmInstruction<Jcc32>
{
    public readonly Jcc32Code JccCode;

    public readonly Disp32 Disp;

    [MethodImpl(Inline)]
    public Jcc32(Jcc32Code code, Disp32 src)
    {
        JccCode = code;
        Disp = src;
    }
}
