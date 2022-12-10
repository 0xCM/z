//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static LogicSig;

    using UAR = ApiUnaryArithmeticClass;

    public class LogixArithEval
    {
        const NumericKind Closure = UInt64k;

        [Op, NumericClosures(Closure)]
        public static LogixLiteral<T> eval<T>(IArithmeticExpr<T> expr)
            where T : unmanaged
        {
            switch(expr)
            {
                case ILogixLiteral<T> x:
                    return x.Value;
                case ILogixVarExpr<T> x:
                    return eval(x);
                case IArithmeticOpExpr<T> x:
                    return eval(x);
                default: throw Unsupported.define<T>();
            }
        }

        [Op, Closures(Closure)]
        static LogixLiteral<T> eval<T>(ILogixExpr<T> expr)
            where T : unmanaged
        {
            switch(expr)
            {
                case IArithmeticExpr<T> x: return eval(x);
                default:
                    throw Unsupported.define<T>();
            }
        }

       [Op, Closures(Closure)]
       static LogixLiteral<T> eval<T>(ILogixVarExpr<T> expr)
            where T : unmanaged
        {
            switch(expr.Value)
            {
                case ILogixLiteral<T> x:
                    return x.Value;
                default:
                    return eval(expr.Value);
            }
        }

        [Op, Closures(Closure)]
        static LogixLiteral<T> eval<T>(IArithmeticOpExpr<T> expr)
            where T : unmanaged
        {
            switch(expr)
            {
                case IUnaryArithmeticOpExpr<T> x:
                    return eval(x);
                case IBinaryArithmeticOpExpr<T> x:
                    return eval(x);
                default: throw new NotSupportedException(expr.GetType().Name);
            }
        }

        [Op, NumericClosures(Closure)]
        static LogixLiteral<T> eval<T>(IBinaryArithmeticOpExpr<T> expr)
            where T : unmanaged
        {
            switch(expr)
            {
                case IComparisonExpr<T> x:
                    return eval(x);
                default:
                    switch(expr.ApiClass)
                    {
                        case ApiBinaryArithmeticClass.Add: return add(expr);
                        case ApiBinaryArithmeticClass.Sub: return sub(expr);
                        default: throw new NotSupportedException(sig<T>(expr.ApiClass));
                    }
            }
        }

        [Op, NumericClosures(Closure)]
        static LogixLiteral<T> eval<T>(IUnaryArithmeticOpExpr<T> expr)
            where T : unmanaged
        {
            switch(expr.ApiClass)
            {
                case UAR.Inc: return inc(expr);
                case UAR.Dec: return dec(expr);
                case UAR.Negate: return negate(expr);
                default: throw new NotSupportedException(sig<T>(expr.ApiClass));
            }
        }

        [Op, NumericClosures(Closure)]
        static LogixLiteral<T> eval<T>(IComparisonExpr<T> expr)
            where T : unmanaged
                => LogixPredicateEval.eval(expr.ComparisonKind, eval(expr.Left).Value, eval(expr.Right).Value);

        [Op, NumericClosures(Closure)]
        static LogixLiteral<T> inc<T>(IUnaryArithmeticOpExpr<T> a)
            where T : unmanaged
                => NumericLogixOps.inc(eval(a).Value);

        [Op, NumericClosures(Closure)]
        static LogixLiteral<T> dec<T>(IUnaryArithmeticOpExpr<T> a)
            where T : unmanaged
                => NumericLogixOps.dec(eval(a).Value);

        [Op, NumericClosures(Closure)]
        static LogixLiteral<T> negate<T>(IUnaryArithmeticOpExpr<T> a)
            where T : unmanaged
                => NumericLogixOps.negate(eval(a).Value);

        [Op, NumericClosures(Closure)]
        static LogixLiteral<T> add<T>(IBinaryArithmeticOpExpr<T> expr)
            where T : unmanaged
                => NumericLogixOps.add(eval(expr.Left).Value, eval(expr.Right).Value);

        [Op, NumericClosures(Closure)]
        static LogixLiteral<T> sub<T>(IBinaryArithmeticOpExpr<T> expr)
            where T : unmanaged
                => NumericLogixOps.sub(eval(expr.Left).Value, eval(expr.Right).Value);
    }
}