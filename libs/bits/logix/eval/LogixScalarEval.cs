//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct LogixScalarEval
    {
        const NumericKind Closure = UInt64k;

        [Op, Closures(Closure)]
        public static LogixLiteral<T> eval<T>(ILogixExpr<T> expr)
            where T : unmanaged
        {
            switch(expr)
            {
                case ILogixLiteral<T> x:
                    return x.Value;
                case IVariedExpr<T> x:
                    return eval(x.BaseExpr);
                case ILogixVarExpr<T> x:
                    return eval(x.Value);
                case IOperatorExpr<T> x:
                    return eval(x);
                case IComparisonExpr<T> x:
                    return gmath.xnor(eval(x.Left).Value, eval(x.Right).Value);
                default: throw new NotSupportedException(expr.GetType().Name);
            }
        }

        [Op, Closures(Closure)]
        static LogixLiteral<T> eval<T>(IOperatorExpr<T> expr)
            where T : unmanaged
        {
            switch(expr)
            {
                case IUnaryBitwiseOpExpr<T> x:
                    return NumericLogixHost.eval(x.ApiClass, eval(x.Operand).Value);

                case IBinaryBitwiseOpExpr<T> x:
                    return NumericLogixHost.eval(x.ApiClass,
                        eval(x.Left).Value, eval(x.Right).Value);

                case IShiftOpExpr<T> x:
                    return NumericLogixHost.eval(x.ApiClass,
                        eval(x.Subject).Value, eval(x.Offset).Value);

                case ITernaryBitwiseOpExpr<T> x:
                    return NumericLogixHost.eval(x.ApiClass,
                        eval(x.First).Value, eval(x.Second).Value, eval(x.Second).Value);

                default: throw new NotSupportedException(expr.GetType().Name);
            }
        }
    }
}