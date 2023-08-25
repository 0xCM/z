//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;

using K = AsmOcTokenKind;

partial class SdmOpCodes
{
    [MethodImpl(Inline), Op]
    public static bool rex(in AsmOpCodeSpec src)
    {
        var result = false;
        var count = min(src.TokenCount,(byte)4);

        for(var i=0; i<count; i++)
        {
            ref readonly var token = ref src[i];
            var kind = token.Kind;
            if(kind == K.Rex || kind == K.RexB)
            {
                result = true;
                break;
            }
        }
        return result;
    }

    [MethodImpl(Inline), Op]
    public static bool evex(in AsmOpCodeSpec src)
    {
        var result = false;
        if(src.IsNonEmpty)
            result = src[0].Kind == K.Evex;
        return result;
    }

    [MethodImpl(Inline), Op]
    public static bool vex(in AsmOpCodeSpec src)
    {
        var result = false;
        if(src.IsNonEmpty)
            result = src[0].Kind == K.Vex;
        return result;
    }

    [MethodImpl(Inline), Op]
    public static bool hex8(in AsmOpCodeSpec src, out AsmOcToken dst)
        => query(src, t => t.Kind == K.Hex8, out dst);

    [MethodImpl(Inline), Op]
    public static bool rex(in AsmOpCodeSpec src, out AsmOcToken dst)
        => query(src, t => t.Kind == K.Rex || t.Kind == K.RexB, out dst);

    [MethodImpl(Inline), Op]
    public static bool imm(in AsmOpCodeSpec src, out AsmOcToken dst)
        => query(src, t => t.Kind == K.ImmSize, out dst);

    [MethodImpl(Inline), Op]
    public static bool vex(in AsmOpCodeSpec src, out AsmOcToken dst)
        => query(src, t => t.Kind == K.Vex, out dst);

    [MethodImpl(Inline), Op]
    public static bool evex(in AsmOpCodeSpec src, out AsmOcToken dst)
        => query(src, t => t.Kind == K.Evex, out dst);

    [MethodImpl(Inline), Op]
    public static bool regdigit(in AsmOpCodeSpec src, out AsmOcToken dst)
        => query(src, t => t.Kind == K.RegDigit, out dst);

    [MethodImpl(Inline), Op]
    public static bool query(in AsmOpCodeSpec src, Func<AsmOcToken,bool> predicate, out AsmOcToken dst)
    {
        var count = src.TokenCount;
        var result = false;
        dst = default;
        for(var i=0; i<count; i++)
        {
            ref readonly var token = ref src[i];
            if(predicate(token))
            {
                result = true;
                dst = token;
                break;
            }
        }
        return result;
    }

    public static bool rex(string src)
        => text.index(src, AsmOcSymbols.Rex) >=0;

    public static bool evex(string src)
        => text.index(src, AsmOcSymbols.Evex) == 0;

    public static bool vex(string src)
        => !evex(src) && text.index(src, AsmOcSymbols.Vex) >= 0;

    public static bool rexw(string src)
        => text.index(src, AsmOcSymbols.RexW) ==0;

    public static bool np(string src)
        => text.index(src, AsmOcSymbols.NP) == 0;

    public static bool x66(string src)
        => text.index(src, AsmOcSymbols.x66) == 0;

    public static bool f2(string src)
        => text.index(src, AsmOcSymbols.F2) == 0;

    public static bool f3(string src)
        => text.index(src, AsmOcSymbols.F3) == 0;

    public static bool x0f(string src)
        => text.index(src, AsmOcSymbols.x0F) >= 0;

    public static bool x660f(string src)
        => x66(src) && x0f(src);

    public static bool np0f(string src)
        => np(src) && x0f(src);
}
