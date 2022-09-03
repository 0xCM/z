//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    using K = AsmSigTokenKind;
    using T = AsmSigTokens;
    partial class AsmSigs
    {
        public static string format(in AsmSigOp src)
            => src.IsEmpty ? EmptyString : expression(src).Text;

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

                case K.MmxRm:
                    EnumRender.format((T.MmxRmToken)src.Value);
                break;

                case K.MmxReg:
                    EnumRender.format((T.MmxRegToken)src.Value);
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
                    EnumRender.format((T.BCastComposite)src.Value);
                break;

                case K.BCastMem:
                    EnumRender.format((T.BCastMem)src.Value);
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

        public static string format(in AsmSigExpr src)
        {
            var storage = CharBlock64.Null;
            var dst = storage.Data;
            var i=0u;
            text.copy(src.Mnemonic.Format(MnemonicCase.Lowercase), ref i, dst);
            var count = src.OpCount;

            if(count != 0)
                seek(dst,i++) = Chars.Space;

            operands(src, ref i, dst);
            return storage.Format().Trim();
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

                dst.Append(expression(src[i]).Text);
            }
            return dst.Emit();
        }
    }
}