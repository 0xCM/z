//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;

[StructLayout(LayoutKind.Sequential, Pack=1)]
public readonly record struct JccOperand
{
    readonly OpKind Kind;

    readonly ByteBlock16 Storage;

    [MethodImpl(Inline)]
    public JccOperand(StringRef label)
    {
        Kind = OpKind.Label;
        @as<StringRef>(Storage.Bytes) = label;
    }

    [MethodImpl(Inline)]
    public JccOperand(Disp8 disp)
    {
        Kind = OpKind.Label;
        @as<Disp8>(Storage.Bytes) = disp;
    }

    [MethodImpl(Inline)]
    public JccOperand(Disp32 disp)
    {
        Kind = OpKind.Label;
        @as<Disp32>(Storage.Bytes) = disp;
    }

    enum OpKind : byte
    {
        None,

        Label,

        Disp8,

        Disp32
    }
}
