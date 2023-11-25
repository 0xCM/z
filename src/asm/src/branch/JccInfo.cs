//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

[StructLayout(LayoutKind.Sequential, Pack=1)]
public readonly record struct JccInfo
{
    public readonly asci8 Name;

    public readonly NativeSize Size;

    public readonly byte Code;

    [MethodImpl(Inline)]
    public JccInfo(Jcc8Code code, asci8 name)
    {
        Code = (byte)code;
        Name = name;
        Size = NativeSizeCode.W8;
    }

    [MethodImpl(Inline)]
    public JccInfo(Jcc32Code code, asci8 name)
    {
        Code = (byte)code;
        Name = name;
        Size = NativeSizeCode.W32;
    }

}
