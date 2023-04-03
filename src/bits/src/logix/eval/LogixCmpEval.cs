//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public static class LogixCmpEval
    {
        const NumericKind Closure = UInt64k;

        [Op, Closures(Closure)]
        public static LogixLiteral<T> eval<T>(IComparisonExpr<T> expr)
            where T : unmanaged
                => LogixPredicateEval.eval(expr.ComparisonKind, eval(expr.Left).Value, eval(expr.Right).Value);

        [Op, Closures(Closure)]
        public static bit eval<T>(IComparisonPredExpr<T> expr)
            where T : unmanaged
                => NumericLogixHost.eval(expr.ComparisonKind, eval(expr.Left).Value, eval(expr.Right).Value);

        [Op, Closures(Closure)]
        public static LogixLiteral<Vector128<T>> eval<T>(IComparisonExpr<Vector128<T>> expr)
            where T : unmanaged
                => VLogixOps.eval(expr.ComparisonKind, eval(expr.Left).Value, eval(expr.Right).Value);

        [Op, Closures(Closure)]
        public static LogixLiteral<Vector256<T>> eval<T>(IComparisonExpr<Vector256<T>> expr)
            where T : unmanaged
                => VLogixOps.eval(expr.ComparisonKind, eval(expr.Left).Value, eval(expr.Right).Value);

        [Op, Closures(Closure)]
        static LogixLiteral<T> eval<T>(ILogixExpr<T> expr)
            where T : unmanaged
        {
            switch(expr)
            {
                case IArithmeticExpr<T> x: return LogixArithEval.eval(x);
                default: return LogixEngine.eval(expr);
            }
        }

        [Op, Closures(Closure)]
        static LogixLiteral<Vector128<T>> eval<T>(ILogixExpr<Vector128<T>> expr)
            where T : unmanaged
                => LogixEngine.eval(expr);

        [Op, Closures(Closure)]
        static LogixLiteral<Vector256<T>> eval<T>(ILogixExpr<Vector256<T>> expr)
            where T : unmanaged
                => LogixEngine.eval(expr);
    }
}