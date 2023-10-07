//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;
using static AsmSigTokens;
using K = AsmSigTokenKind;

partial class AsmSigs
{
    public static string format(in AsmSigOp src)
    {
        var dst = EmptyString;
        switch(src.Kind)
        {
            case K.Rel:
                dst = TokenRender.RelToken.Format((RelToken)src.Value);
            break;

            case K.SysReg:
                dst = TokenRender.SysRegToken.Format((SysRegToken)src.Value);
            break;

            case K.GpReg:
                dst = TokenRender.GpRegToken.Format((GpRegToken)src.Value);
            break;

            case K.VReg:
                dst = TokenRender.VRegToken.Format((VRegToken)src.Value);
            break;

            case K.KReg:
                dst = TokenRender.KRegToken.Format((KRegToken)src.Value);
            break;

            case K.FpuReg:
                dst = TokenRender.FpuRegToken.Format((FpuRegToken)src.Value);
            break;

            case K.Mmx:                
                dst = TokenRender.MmxRmToken.Format((MmxToken)src.Value);
            break;

            case K.Imm:                
                dst = TokenRender.ImmToken.Format((ImmToken)src.Value);
            break;

            case K.Mem:
                dst = TokenRender.MemToken.Format((MemToken)src.Value);
            break;

            case K.FpuInt:
                dst = TokenRender.FpuIntToken.Format((FpuIntToken)src.Value);
            break;

            case K.FpuMem:
                dst = TokenRender.FpuMemToken.Format((FpuMemToken)src.Value);
            break;

            case K.GpRm:
                dst = TokenRender.GpRmToken.Format((GpRmToken)src.Value);
            break;

            case K.GpRegTriple:
                dst = TokenRender.GpRegTriple.Format((GpRegTriple)src.Value);
            break;

            case K.GpRmTriple:
                dst = TokenRender.GpRmTriple.Format((GpRmTriple)src.Value);
            break;

            case K.VecRm:
                dst = TokenRender.VecRmToken.Format((VecRmToken)src.Value);
            break;

            case K.KRm:
                dst = TokenRender.KRmToken.Format((KRmToken)src.Value);
            break;

            case K.Moffs:
                dst = TokenRender.MoffsToken.Format((MoffsToken)src.Value);
            break;

            case K.Ptr:
                dst = TokenRender.PtrToken.Format((PtrToken)src.Value);
            break;

            case K.Rounding:
                dst = TokenRender.RoundingToken.Format((RoundingToken)src.Value);
            break;

            case K.MemPtr:
                dst = TokenRender.MemPtrToken.Format((MemPtrToken)src.Value);
            break;

            case K.MemPair:
                dst = TokenRender.MemPairToken.Format((MemPairToken)src.Value);
            break;

            case K.Vsib:
                dst = TokenRender.VsibToken.Format((VsibToken)src.Value);
            break;

            case K.BCastComposite:
                dst = TokenRender.BCastCompositeToken.Format((BCastCompositeToken)src.Value);
            break;

            case K.BCastMem:
                dst = TokenRender.BCastMemToken.Format((BCastMemToken)src.Value);
            break;

            case K.OpMask:
                dst = TokenRender.OpMaskToken.Format((OpMaskToken)src.Value);
            break;

            case K.RegLiteral:
                dst = TokenRender.RegLiteralToken.Format((RegLiteralToken)src.Value);
            break;

            case K.IntLiteral:
                dst = TokenRender.IntLiteral.Format((IntLiteral)src.Value);
            break;

            case K.Dependent:
                dst = TokenRender.DependentToken.Format((DependentToken)src.Value);
            break;

            case K.Modifier:
                dst = TokenRender.ModifierToken.Format((ModifierToken)src.Value);
            break;
        }

        return dst;
    }

    public static string format(in AsmSigExpr src)
    {
        Span<char> dst =  stackalloc char[64];
        var i=0u;
        text.copy(src.Mnemonic.Format(MnemonicCase.Lowercase), ref i, dst);
        var count = src.OpCount;

        if(count != 0)
            seek(dst,i++) = Chars.Space;

        operands(src, ref i, dst);

        return sys.@string(slice(dst,0,i));
    }

    public static string format(in AsmSig src)
    {
        if(src.IsEmpty)
            return EmptyString;

        var dst = text.buffer();
        dst.Append(src.Mnemonic.Format(MnemonicCase.Lowercase));
        var count = src.OpCount;
        for(byte i=0; i<count; i++)
        {
            if(i != 0)
                dst.Append(", ");
            else
                dst.Append(Chars.Space);

            dst.Append(format(src[i]));
        }
        return dst.Emit();
    }
}
