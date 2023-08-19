//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static sys;

public class AsmRender
{
    public static string format(in RegMask src)
    {
        var dst = EmptyString;
        if(src.MaskKind == RegMaskKind.k1)
            dst = string.Format("{0} {{1}}", src.Target, AsmRegs.rK(src.Mask));
        else if(src.MaskKind == RegMaskKind.k1z)
            dst = string.Format("{0} {{{1}}{{2}}", src.Target, AsmRegs.rK(src.Mask), Chars.z);
        return dst;
    }

    [Op]
    public static string format(in AsmOperand src)
    {
        switch(src.OpClass)
        {
            case AsmOpClass.Mem:
                return src.Mem.Format();
            case AsmOpClass.Reg:
                return src.Reg.Format();
            case AsmOpClass.Imm:
                return src.Imm.Format();
            case AsmOpClass.Disp:
                return src.Disp.Format();
            case AsmOpClass.RegMask:
                return src.RegMask.Format();
            default:
                return EmptyString;
        }
    }

    public static string format(in AsmAddress src)
    {
        Span<char> dst = stackalloc char[64];
        var i=0u;
        var count = render(src, ref i, dst);
        return text.format(dst, count);
    }

    [Op]
    static uint render(in AsmAddress src, ref uint i, Span<char> dst)
    {
        var i0 = i;
        var @base = src.Base.Format();
        var index = src.Index.Format();
        text.copy(@base, ref i, dst);
        var scale = src.Scale.Format();
        if(src.Scale.IsNonZero)
        {
            seek(dst,i++) = Chars.Space;
            seek(dst,i++) = Chars.Plus;
            seek(dst,i++) = Chars.Space;
            if(src.Scale.IsNonUnital)
            {
                text.copy(scale,ref i, dst);
                seek(dst,i++) = Chars.Star;
            }
            text.copy(index, ref i, dst);
        }

        if(src.Disp.Value != 0)
        {
            seek(dst,i++) = Chars.Space;
            text.copy(Disp.format(src.Disp,true), ref i, dst);
        }

        return i - i0;
    }
}
