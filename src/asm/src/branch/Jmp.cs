//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using K = JccKind;

using static sys;

[Free]
public class Jmp
{
    [MethodImpl(Inline), Op]
    public static uint encode<T>(JmpRip64<T> src, Span<byte> dst)
        where T :unmanaged, IDisplacement
    {
        @as<JmpRip64<T>>(dst) = src;
        return JmpRip64<T>.InsructionSize;
    }

    [MethodImpl(Inline), Op]
    public static bool decode<T>(ReadOnlySpan<byte> src, out JmpRip64<T> dst)
        where T :unmanaged, IDisplacement
    {
        dst = JmpRip64<T>.Empty;
        if(src.Length < JmpRip64<T>.InsructionSize)
            return false;

        var i=0u;
        ref readonly var opcode = ref skip(src,i++);

        if(opcode != JmpRip64<T>.OpCodeValue)
            return false;

        ref readonly var modrm = ref skip(src,i++);
        if(modrm != JmpRip64<T>.ModRmValue)
            return false;

        dst = @as<JmpRip64<T>>(src);
        return dst.IsNonEmpty;
    }

    [MethodImpl(Inline), Op]
    public static JmpRip64<T> rip<T>(T disp)
        where T :unmanaged, IDisplacement
            => new(disp);

    [MethodImpl(Inline), Op]
    public static Jcc8 jcc8(Jcc8Code code, Disp8 disp)
        => new (code, disp);

    [MethodImpl(Inline), Op]
    public static Jcc32 jcc32(Jcc32Code code, Disp32 disp)
        => new (code, disp);
    
    [MethodImpl(Inline), Op]
    public static Jcc32 jz(Disp32 disp)
        => new (Jcc32Code.JZ, disp);

    [MethodImpl(Inline), Op]
    public static Jcc32 je(Disp32 disp)
        => new (Jcc32Code.JE, disp);

    [MethodImpl(Inline), Op]
    public static Jcc32 jl(Disp32 disp)
        => new (Jcc32Code.JL, disp);

    [MethodImpl(Inline), Op]
    public static Jcc32 jle(Disp32 disp)
        => new (Jcc32Code.JLE, disp);

    [MethodImpl(Inline), Op]
    public static Jcc32 jg(Disp32 disp)
        => new (Jcc32Code.JG, disp);

    [MethodImpl(Inline), Op]
    public static Jcc32 jge(Disp32 disp)
        => new (Jcc32Code.JGE, disp);

    [MethodImpl(Inline), Op]
    public static AsmHexCode encode(MemoryAddress ip, Jcc8 jcc, AsmHexWriter? writer = null)
    {
        const byte Size = 2;
        var dst = writer?.Clear() ?? AsmHexWriter.create();
        dst.Write(jcc.JccCode);
        dst.Write(AsmRel.target(AsmRel.rip(ip, Size), jcc.Disp));
        return dst.Target;
    }

    [MethodImpl(Inline), Op]
    public static AsmHexCode encode(MemoryAddress ip, Jcc32 jcc, AsmHexWriter? writer = null)
    {
        const byte Size = 6;
        var dst = writer?.Clear() ?? AsmHexWriter.create();
        dst.Write(0x0f);
        dst.Write(jcc.JccCode);
        dst.Write(AsmRel.target(AsmRel.rip(ip, Size), jcc.Disp));
        return dst.Target;
    }

    public static K JccKind(ReadOnlySpan<char> src)
    {
        var kind = K.None;
        switch(src)
        {
            case "jmp":
                kind = K.JMP;
                break;

            case "jo":
                kind = K.JO;
                break;
            case "jno":
                kind = K.JNO;
                break;

            case "jc":
                kind = K.JC;
                break;
            case "jnc":
                kind = K.JNC;
                break;

            case "jnae":
                kind = K.JNAE;
                break;

            case "ja":
                kind = K.JA;
                break;
            case "jna":
                kind = K.JNA;
                break;

            case "jae":
                kind = K.JAE;
                break;

            case "jnb":
                kind = K.JNB;
            break;

            case "jnbe":
                kind = K.JNBE;
            break;

            case "jb":
                kind = K.JB;
                break;
            case "jbe":
                kind = K.JBE;
                break;

            case "jcxz":
                kind = K.JCXZ;
                break;

            case "je":
                kind = K.JE;
                break;
            case "jne":
                kind = K.JNE;
                break;

            case "jnl":
                kind = K.JNL;
                break;
            case "jnle":
                kind = K.JNLE;
                break;

            case "jz":
                kind = K.JZ;
                break;
            case "jnz":
                kind = K.JNZ;
                break;

            case "jg":
                kind = K.JG;
                break;
            case "jge":
                kind = K.JGE;
                break;

            case "jl":
                kind = K.JL;
                break;
            case "jle":
                kind = K.JLE;
                break;

            case "jp":
                kind= K.JP;
                break;
            case "jnp":
                kind = K.JNP;
                break;

            case "js":
                kind= K.JS;
                break;
            case "jns":
                kind = K.JNS;
                break;

            default:
            break;
        }
        return kind;
    }
}
