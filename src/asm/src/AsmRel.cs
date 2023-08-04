//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static sys;

[ApiHost]
public readonly struct AsmRel
{
    [MethodImpl(Inline), Op]
    public static Disp8 disp8(MemoryAddress rip, MemoryAddress dst)
        => (sbyte)(dst - rip);

    [MethodImpl(Inline), Op]
    public static Disp16 disp16(MemoryAddress rip, MemoryAddress dst)
        => (short)(dst - rip);

    [MethodImpl(Inline), Op]
    public static Disp32 disp32(MemoryAddress rip, MemoryAddress dst)
        => (int)(dst - rip);

    [MethodImpl(Inline), Op]
    public static Disp64 disp64(MemoryAddress rip, MemoryAddress dst)
        => (long)(dst - rip);

    [MethodImpl(Inline), Op]
    public static Disp8 disp8(AsmRip rip, MemoryAddress dst)
        => (sbyte)((long)dst - (long)rip);

    [MethodImpl(Inline), Op]
    public static Disp16 disp16(AsmRip rip, MemoryAddress dst)
        => (Disp16)((long)dst - (long)rip);

    [MethodImpl(Inline), Op]
    public static Disp32 disp32(AsmRip rip, MemoryAddress dst)
        => (Disp32)((long)dst - (long)rip);

    [MethodImpl(Inline), Op]
    public static Disp64 disp64(AsmRip rip, MemoryAddress dst)
        => (Disp64)((long)dst - (long)rip);

    [MethodImpl(Inline), Op]
    public static bool isCall32(ReadOnlySpan<byte> encoding)
        => encoding.Length >= CallRel32.InstSize && sys.first(encoding) == CallRel32.OpCode;

    [MethodImpl(Inline), Op]
    public static bool isJmp8(ReadOnlySpan<byte> encoding)
        => encoding.Length >= JmpRel8.InstSize && first(encoding) == JmpRel8.OpCode;

    [MethodImpl(Inline), Op]
    public static Disp8 disp8(ReadOnlySpan<byte> encoding)
        => skip(encoding,1);

    [MethodImpl(Inline), Op]
    public static Disp32 disp32(ReadOnlySpan<byte> encoding)
        => @as<Disp32>(slice(encoding,1,4));

    [MethodImpl(Inline), Op]
    public static CallRel32 call(AsmRip rip, Disp32 disp)
        => new (rip, target(rip,disp));

    [MethodImpl(Inline), Op]
    public static AsmHexCode encode(CallRel32 spec)
    {
        var encoding = AsmHexCode.Empty;
        var buffer = encoding.Bytes;
        seek(buffer,0) = CallRel32.OpCode;
        @as<Disp32>(seek(buffer,1)) = disp32(spec.Rip, spec.TargetAddress);
        seek(buffer,15) = CallRel32.InstSize;
        return encoding;
    }

    [MethodImpl(Inline), Op]
    public static MemoryAddress target(AsmRip rip, Disp8 disp)
        => (MemoryAddress)((long)rip + (sbyte)disp);

    [MethodImpl(Inline), Op]
    public static AsmHexCode encode(JmpRel8 spec)
    {
        var encoding = AsmHexCode.Empty;
        var buffer = encoding.Bytes;
        seek(buffer,0) = JmpRel8.OpCode;
        seek(buffer,1) = AsmRel.disp8(spec.SourceAddress + JmpRel8.InstSize, spec.TargetAddress);
        return encoding;
    }

    [MethodImpl(Inline), Op]
    public static MemoryAddress target(MemoryAddress src, ReadOnlySpan<byte> encoding)
    {
        var rip = src + JmpRel8.InstSize;
        var dx = disp8(encoding);
        return rip + dx;
    }

    [MethodImpl(Inline), Op]
    public static MemoryAddress target(AsmRip rip, Disp32 disp)
        => (MemoryAddress)((long)rip + (long)disp);

    [MethodImpl(Inline), Op]
    public static MemoryAddress target(AsmRip rip, ReadOnlySpan<byte> encoding)
        => (MemoryAddress)((long)rip + (int)disp32(encoding));

    [MethodImpl(Inline), Op]
    public static Address32 target(Disp32 disp)
        => (Address32)((int)disp + (int)JmpRel32.InstSize);

    [MethodImpl(Inline), Op]
    public static JmpStub stub32(MemoryAddress src, MemoryAddress dst)
        => new (JmpRel32.OpCode, disp32((src, JmpRel32.InstSize), dst), JmpRel32.InstSize, src, dst, JmpRel32.encode((src, JmpRel32.InstSize), dst));

    [MethodImpl(Inline), Op]
    public static JmpStub stub8(MemoryAddress src, MemoryAddress dst)
        => new (JmpRel8.OpCode, disp8((src, JmpRel8.InstSize) ,dst), JmpRel8.InstSize, src, dst, default);

    [MethodImpl(Inline)]
    public static AsmRip rip(MemoryAddress callsite, byte instsize)
        => new (callsite, instsize);

    [MethodImpl(Inline), Op]
    public static AsmOpKind kind(NativeSize size)
        => AsmOps.kind(AsmOpClass.Rel, size);

    [MethodImpl(Inline), Op]
    public static JmpRel32 jmp32(AsmRip src, MemoryAddress dst)
        => new (src, dst);

    [MethodImpl(Inline), Op]
    public static JmpRel32 jmp32(LocatedSymbol src, LocatedSymbol dst)
        => new (src, dst);

    [MethodImpl(Inline), Op]
    public static JmpRel32 jmp32(AsmRip rip, Disp32 disp)
        => new (rip.Address, AsmRel.target(rip, disp));
}
