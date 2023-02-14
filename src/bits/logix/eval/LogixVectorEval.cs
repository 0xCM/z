//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct LogixVectorEval
    {
        const NumericKind Closure = UInt64k;

        [Op, Closures(Closure)]
         public static LogixLiteral<Vector128<T>> eval<T>(ILogixExpr<Vector128<T>> expr)
            where T : unmanaged
        {
            switch(expr)
            {
                case ILogixLiteral<Vector128<T>> x:
                    return x.Value;
                case ILogixVarExpr<Vector128<T>> x:
                    return eval(x.Value);
                case IVariedExpr<Vector128<T>> x:
                    return eval(x.BaseExpr);
                case IOperatorExpr<Vector128<T>> x:
                    return eval(x);
                case IComparisonExpr<Vector128<T>> x:
                    return gcpu.vxnor(eval(x.Left).Value, eval(x.Right).Value);
                default: throw new NotSupportedException(expr.GetType().Name);
            }
        }

        [Op, Closures(Closure)]
        public static LogixLiteral<Vector256<T>> eval<T>(ILogixExpr<Vector256<T>> expr)
            where T : unmanaged
        {
            switch(expr)
            {
                case ILogixLiteral<Vector256<T>> x:
                    return x.Value;
                case ILogixVarExpr<Vector256<T>> x:
                    return eval(x.Value);
                case IVariedExpr<Vector256<T>> x:
                    return eval(x.BaseExpr);
                case IOperatorExpr<Vector256<T>> x:
                    return eval(x);
                case IComparisonExpr<Vector256<T>> x:
                    return gcpu.vxnor(eval(x.Left).Value, eval(x.Right).Value);
                default: throw new NotSupportedException(expr.GetType().Name);
            }
        }

        [Op, Closures(Closure)]
        static LogixLiteral<Vector128<T>> eval<T>(IOperatorExpr<Vector128<T>> expr)
            where T : unmanaged
        {
            switch(expr)
            {
                case IUnaryBitwiseOpExpr<Vector128<T>> x:
                    return VLogixOps.eval(x.ApiClass, eval(x.Operand).Value);
                case IBinaryBitwiseOpExpr<Vector128<T>> x:
                    return VLogixOps.eval(x.ApiClass, eval(x.Left).Value, eval(x.Right).Value);
                case IShiftOpExpr<Vector128<T>> x:
                    return VLogixOps.eval(x.ApiClass, eval(x.Subject).Value, LogixScalarEval.eval(x.Offset).Value);
                case ITernaryBitwiseOpExpr<Vector128<T>> x:
                    return VLogixOps.eval(x.ApiClass, eval(x.First).Value, eval(x.Second).Value, eval(x.Third));
                default: throw new NotSupportedException(expr.GetType().Name);
            }
        }

       [Op, Closures(Closure)]
       static LogixLiteral<Vector256<T>> eval<T>(IOperatorExpr<Vector256<T>> expr)
            where T : unmanaged
        {
            switch(expr)
            {
                case IUnaryBitwiseOpExpr<Vector256<T>> x:
                    return VLogixOps.eval(x.ApiClass, eval(x.Operand).Value);
                case IBinaryBitwiseOpExpr<Vector256<T>> x:
                    return VLogixOps.eval(x.ApiClass, eval(x.Left).Value, eval(x.Right).Value);
                case IShiftOpExpr<Vector256<T>> x:
                    return VLogixOps.eval(x.ApiClass, eval(x.Subject).Value, LogixScalarEval.eval(x.Offset).Value);
                case ITernaryBitwiseOpExpr<Vector256<T>> x:
                    return VLogixOps.eval(x.ApiClass, eval(x.First).Value, eval(x.Second).Value, eval(x.Third));
                default: throw new NotSupportedException(expr.GetType().Name);
            }
        }
    }
}