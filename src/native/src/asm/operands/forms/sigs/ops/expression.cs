//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmSigs
    {
        public static AsmSigOpExpr expression(in AsmSigOp src)
        {
            var dst = format(src.Token);
            if(src.Modifier != 0)
            {
                if(_Datasets.Modifers.MapKind(src.Modifier, out var mod))
                    dst = $"{dst} {mod.Expr}";
            }
            return dst;
            // if(_Datasets.Expressions.Find(src.Token.Id, out var xpr))
            // {
            //     if(src.Modifier != 0)
            //     {
            //         if(_Datasets.Modifers.MapKind(src.Modifier, out var mod))
            //             return string.Format("{0} {1}", xpr, mod.Expr);
            //         else
            //             return RP.Error;
            //     }
            //     else
            //         return xpr;
            // }
            // else
            //     return RP.Error;
        }

        // public static AsmSigOpExpr expression(in AsmSigToken src)
        // {
        //     if(_Datasets.Expressions.Find(src.Id, out var x))
        //         return x;

        //     return RP.Error;
        // }

        public static AsmSigExpr expression(string src)
        {
            var dst = AsmSigExpr.Empty;
            var result = Outcome.Success;
            var sig = text.trim(src);
            var j = text.index(text.trim(sig), Chars.Space);
            var mnemonic = AsmMnemonic.Empty;
            dst = AsmSigExpr.Empty;
            if(j>0)
            {
                mnemonic = text.left(sig,j);
                var operands = text.right(sig,j);
                if(text.contains(sig, Chars.Comma))
                    dst = AsmSigs.expression(mnemonic, text.trim(text.split(operands, Chars.Comma)));
                else
                    dst = AsmSigs.expression(mnemonic, operands);
            }
            else
            {
                mnemonic = sig;
                dst = AsmSigs.expression(mnemonic);
            }

            return dst;
        }

        [MethodImpl(Inline)]
        public static AsmSigExpr expression(AsmMnemonic mnemonic)
            =>  new AsmSigExpr(mnemonic);

        [MethodImpl(Inline), Op]
        public static AsmSigExpr expression(AsmMnemonic mnemonic, AsmSigOpExpr op0)
            => new AsmSigExpr(mnemonic, op0);

        [MethodImpl(Inline), Op]
        public static AsmSigExpr expression(AsmMnemonic mnemonic, AsmSigOpExpr op0, AsmSigOpExpr op1)
            => new AsmSigExpr(mnemonic, op0, op1);

        [MethodImpl(Inline), Op]
        public static AsmSigExpr expression(AsmMnemonic mnemonic, AsmSigOpExpr op0, AsmSigOpExpr op1, AsmSigOpExpr op2)
            => new AsmSigExpr(mnemonic, op0, op1, op2);

        [MethodImpl(Inline), Op]
        public static AsmSigExpr expression(AsmMnemonic mnemonic, AsmSigOpExpr op0, AsmSigOpExpr op1, AsmSigOpExpr op2, AsmSigOpExpr op3)
            => new AsmSigExpr(mnemonic, op0, op1, op2, op3);

        [MethodImpl(Inline), Op]
        public static AsmSigExpr expression(AsmMnemonic mnemonic, AsmSigOpExpr op0, AsmSigOpExpr op1, AsmSigOpExpr op2, AsmSigOpExpr op3, AsmSigOpExpr op4)
            => new AsmSigExpr(mnemonic, op0, op1, op2, op3, op4);

        [Op]
        public static AsmSigExpr expression(AsmMnemonic mnemonic, ReadOnlySpan<string> ops)
        {
            var count = min(ops.Length, AsmSigExpr.MaxOpCount);
            switch(count)
            {
                case 1:
                    return expression(mnemonic, skip(ops, 0));
                case 2:
                    return expression(mnemonic, skip(ops, 0), skip(ops, 1));
                case 3:
                    return expression(mnemonic, skip(ops, 0), skip(ops, 1), skip(ops, 2));
                case 4:
                    return expression(mnemonic, skip(ops, 0), skip(ops, 1), skip(ops, 2), skip(ops, 3));
                case 5:
                    return expression(mnemonic, skip(ops, 0), skip(ops, 1), skip(ops, 2), skip(ops, 3), skip(ops, 4));
            }

            return expression(mnemonic);
        }
    }
}