//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static BroadcastTokens;
using static MachineModes;
using static sys;

using K = AsmSigTokenKind;
using T = AsmSigTokens;

public class AsmRender
{
    static EnumRender<Broadcast8> BCast8 = new();

    static EnumRender<Broadcast16> BCast16 = new();

    static EnumRender<Broadcast32> BCast32 = new();

    static EnumRender<Broadcast64> BCast64 = new();

    static EnumRender<MachineModeClass> ClassRender = new();

    public static string format(MachineModeClass src, DataFormatCode fc = DataFormatCode.Expr)
        => fc == DataFormatCode.BitWidth ? nsize((byte)src + 1) : EnumRender.format(ClassRender, src, fc);

    static string nsize<T>(T src)
        => ((NativeSize)((NativeSizeCode)u8(src))).Format();

    [Op]
    public static string format(RegClass src)
    {
        var symbols = Symbols.index<RegClassCode>();
        var index = (byte)src.Code;
        var symbol = symbols[index];
        return symbol.Expr.Format();
    }


    [Op]
    public static byte render(AsmHexCode src, Span<char> dst)
        => (byte)HexRender.render(LowerCase, src.Bytes, dst);

    [Op]
    public static string format(in AsmHexCode src)
    {
        var size = src.Size;
        Span<char> dst = stackalloc char[64];
        var count = HexRender.render(LowerCase, src.Bytes, dst);
        return sys.@string(slice(dst, 0, count));
    }

    public static string format(in EncodingOffsets src)
    {
        if(src.IsEmpty)
            return EmptyString;

        var dst = Z0.text.emitter();
        dst.Append(Chars.LBrace);
        dst.AppendFormat("{0}={1}", "opcode", src.OpCode);
        if(src.ModRm > 0)
            dst.AppendFormat(", {0}={1}", "modrm", src.ModRm);
        if(src.Sib > 0)
            dst.AppendFormat(", {0}={1}", "sib",  src.Sib);
        if(src.Disp > 0)
            dst.AppendFormat(", {0}={1}", "disp", src.Disp);
        if(src.Imm0 > 0)
            dst.AppendFormat(", {0}={1}", "imm0", src.Imm0);
        if(src.Imm1 > 0)
            dst.AppendFormat(", {0}={1}", "imm1", src.Imm1);
        dst.Append(Chars.RBrace);
        return dst.Emit();
    }

    public static string format(in AsmInstruction src)
    {
        var dst = text.buffer();
        ref readonly var ops = ref src.Operands;
        var count = ops.OpCount;
        dst.Append(src.Mnemonic.Format(MnemonicCase.Lowercase));
        if(count != 0)
        {
            dst.Append(Chars.Space);
            dst.Append(src.Operands.Format());
        }
        return dst.Emit();
    }

    [Op]
    public static uint render(AsmHexCode src, ref uint i, Span<char> dst)
    {
        var i0 = i;
        var count = src.Size;
        var bytes = src.Bytes;
        for(var j=0; j<count; j++)
        {
            HexRender.render(LowerCase, (Hex8)skip(bytes, j), ref i, dst);
            if(j != count - 1)
                seek(dst, i++) = Chars.Space;
        }
        return i - i0;
    }

    public static string format(in AsmOperandSet src)
    {
        var dst = EmptyString;
        switch(src.OpCount)
        {
            case 0:
            break;
            case 1:
                dst = string.Format("{0}", src.Op0);
            break;
            case 2:
                dst = string.Format("{0}, {1}", src.Op0, src.Op1);
            break;
            case 3:
                dst = string.Format("{0}, {1}, {2}", src.Op0, src.Op1, src.Op2);
            break;
            case 4:
                dst = string.Format("{0}, {1}, {2}, {3}", src.Op0, src.Op1, src.Op2, src.Op3);
            break;
        }
        return dst;
    }

    public static string format(in AsmSigToken src)
    {
        var dst = EmptyString;
        switch(src.Kind)
        {
            case K.Rel:
                EnumRender.format((T.RelToken)src.Value);
            break;

            case K.SysReg:
                EnumRender.format((T.SysRegToken)src.Value);
            break;

            case K.GpReg:
                EnumRender.format((T.GpRegToken)src.Value);
            break;

            case K.VReg:
                EnumRender.format((T.VRegToken)src.Value);
            break;

            case K.KReg:
                EnumRender.format((T.KRegToken)src.Value);
            break;

            case K.FpuReg:
                EnumRender.format((T.FpuRegToken)src.Value);
            break;

            case K.Mmx:
                EnumRender.format((T.MmxToken)src.Value);
            break;

            case K.Imm:
                EnumRender.format((T.ImmToken)src.Value);
            break;

            case K.Mem:
                EnumRender.format((T.MemToken)src.Value);
            break;

            case K.FpuInt:
                EnumRender.format((T.FpuIntToken)src.Value);
            break;

            case K.FpuMem:
                EnumRender.format((T.FpuMemToken)src.Value);
            break;

            case K.GpRm:
                EnumRender.format((T.GpRmToken)src.Value);
            break;

            case K.GpRegTriple:
                EnumRender.format((T.GpRegTriple)src.Value);
            break;

            case K.GpRmTriple:
                EnumRender.format((T.GpRmTriple)src.Value);
            break;

            case K.VecRm:
                EnumRender.format((T.VecRmToken)src.Value);
            break;

            case K.KRm:
                EnumRender.format((T.KRmToken)src.Value);
            break;

            case K.Moffs:
                EnumRender.format((T.MoffsToken)src.Value);
            break;

            case K.Ptr:
                EnumRender.format((T.PtrToken)src.Value);
            break;

            case K.Rounding:
                EnumRender.format((T.RoundingToken)src.Value);
            break;

            case K.MemPtr:
                EnumRender.format((T.MemPtrToken)src.Value);
            break;

            case K.MemPair:
                EnumRender.format((T.MemPairToken)src.Value);
            break;

            case K.Vsib:
                EnumRender.format((T.VsibToken)src.Value);
            break;

            case K.BCastComposite:
                EnumRender.format((T.BCastCompositeToken)src.Value);
            break;

            case K.BCastMem:
                EnumRender.format((T.BCastMemToken)src.Value);
            break;

            case K.OpMask:
                EnumRender.format((T.OpMaskToken)src.Value);
            break;

            case K.RegLiteral:
                EnumRender.format((T.RegLiteralToken)src.Value);
            break;

            case K.IntLiteral:
                EnumRender.format((T.IntLiteral)src.Value);
            break;

            case K.Dependent:
                EnumRender.format((T.DependentToken)src.Value);
            break;

            case K.Modifier:
                EnumRender.format((T.ModifierToken)src.Value);
            break;
        }
        return dst;
    }

    public static string format(Broadcast8 src)
        => BCast8.Format(src);

    public static string format(Broadcast16 src)
        => BCast16.Format(src);

    public static string format(Broadcast32 src)
        => BCast32.Format(src);

    public static string format(Broadcast64 src)
        => BCast64.Format(src);

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
