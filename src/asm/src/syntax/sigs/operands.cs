//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    partial class AsmSigs
    {
        [MethodImpl(Inline)]
        public static AsmSigOp operand(AsmSigToken token, AsmModifierKind mod = 0)
            => new AsmSigOp(token.Kind, token.Value, mod);

        public static bool operand(AsmSigOpExpr src, out AsmSigOp dst)
        {
            dst = AsmSigOp.Empty;
            return true;
            //if(opmask(src, out var op, out var mask))
            // {
            //     if(_Datasets.OpsByExpression.Find(op, out dst))
            //     {
            //         dst = dst.WithModifier(modifier(mask));
            //         return true;
            //     }
            //     else
            //     {
            //         Errors.Throw(string.Format("Token not found for <{0}>", src));
            //         return false;
            //     }
            // }
            // else
            //     return _Datasets.OpsByExpression.Find(src.Text, out dst);
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static AsmSigOp operand<T>(AsmSigTokenKind kind, T value)
            where T : unmanaged
                => new AsmSigOp(kind, bw8(value));

        [MethodImpl(Inline), Op]
        public static ref readonly AsmSigOpExpr operand(in AsmSigExpr src, byte i)
        {
            if(i==0)
                return ref src.Op0;
            if(i==1)
                return ref src.Op1;
            if(i==2)
                return ref src.Op2;
            if(i==3)
                return ref src.Op3;
            return ref src.Op4;
        }

        [Op]
        public static uint operands(in AsmSigExpr src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            var count = src.OpCount;
            for(byte j=0; j<count; j++)
            {
                ref readonly var op = ref operand(src,j);
                if(op.IsEmpty)
                    break;

                if(j != 0)
                {
                    seek(dst,i++) = Chars.Comma;
                    seek(dst,i++) = Chars.Space;
                }

                text.copy(op.Text, ref i, dst);
            }

            return i - i0;
        }

        [Op]
        internal static byte operands(AsmSigExpr src, Span<AsmSigOpExpr> dst)
        {
            if(src.OpCount >= 1)
            {
                seek(dst,0) = src.Op0;
                if(src.OpCount >= 2)
                {
                    seek(dst,1) = src.Op1;
                    if(src.OpCount >= 3)
                    {
                        seek(dst,2) = src.Op2;

                        if(src.OpCount >= 4)
                        {
                            seek(dst,3) = src.Op3;

                            if(src.OpCount >= 5)
                                seek(dst,4) = src.Op4;
                        }
                    }
                }
            }

            return src.OpCount;
        }
    }
}