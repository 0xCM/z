//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;

public readonly struct CallRel32 : IAsmRelInst<Disp32>
{
    [MethodImpl(Inline), Op]
    public static byte encode(AsmRip src, MemoryAddress dst, ref byte hex)
    {
        const byte Size = 5;
        seek(hex, 0) = OpCode;
        i32(seek(hex, 1)) = AsmRel.disp32(src, dst);
        return InstSize;
    }

    [MethodImpl(Inline), Op]
    public static AsmHexCode encode(AsmRip rip, MemoryAddress dst)
    {
        var encoded = AsmHexCode.Empty;
        var bytes = encoded.Bytes;
        seek(bytes,15) = encode(rip, dst, ref first(bytes));
        return encoded;
    }

    public const byte OpCode = 0xE8;

    public const byte InstSize = 5;

    public readonly LocatedSymbol Source;

    public readonly LocatedSymbol Target;

    [MethodImpl(Inline)]
    public CallRel32(LocatedSymbol src, LocatedSymbol dst)
    {
        Source = src;
        Target = dst;
    }

    [MethodImpl(Inline)]
    public CallRel32(AsmRip src, LocatedSymbol dst)
    {
        Source = src.Address - (uint)InstSize;
        Target = dst;
    }

    public AsmRip Rip
    {
        [MethodImpl(Inline)]
        get => (Source.Location, InstSize);
    }

    public MemoryAddress SourceAddress
    {
        [MethodImpl(Inline)]
        get => Source.Location;
    }

    public MemoryAddress TargetAddress
    {
        [MethodImpl(Inline)]
        get => Target.Location;
    }

    public Disp32 Disp
    {
        [MethodImpl(Inline)]
        get => AsmRel.disp32(Rip, TargetAddress);
    }

    public AsmHexCode Encoding
    {
        [MethodImpl(Inline)]
        get => AsmRel.encode(this);
    }

    public AsmMnemonic Mnemonic
    {
        [MethodImpl(Inline)]
        get => "call";
    }

    LocatedSymbol IAsmRelInst.Source
        => Source;

    LocatedSymbol IAsmRelInst.Target
        => Target;

    public string Format()
        => string.Format("call:{0} -> {1}", Source, Target);

    public override string ToString()
        => Format();
}
