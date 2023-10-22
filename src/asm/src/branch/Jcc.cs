//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static ConditionTokens;

using K = JccKind;

public class Jcc
{
    [MethodImpl(Inline), Op]
    public static Jcc32 jcc32(Jcc32Code code, Disp32 disp)
        => new (code, disp);

    [MethodImpl(Inline), Op]
    public static Jcc32 jcc32(Jcc32AltCode code, Disp32 disp)
        => new (code, disp);

    [MethodImpl(Inline), Op]
    public static Jcc8 jcc8(Jcc8Code code, Disp8 disp)
        => new (code, disp);

    [MethodImpl(Inline), Op]
    public static Jcc8 jcc8(Jcc8AltCode code, Disp8 disp)
        => new (code, disp);

    [MethodImpl(Inline), Op]
    public static AsmHexCode encode(AsmRip rip, Jcc8 jcc, AsmHexWriter dst)
        => dst.Write(jcc.JccCode, AsmRel.target(rip, jcc.Disp));

    [MethodImpl(Inline), Op]
    public static AsmHexCode encode(AsmRip rip, Jcc32 jcc, AsmHexWriter dst)
        => dst.Write(jcc.JccCode, AsmRel.target(rip, jcc.Disp));

    public static K kind(ReadOnlySpan<char> src)
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
