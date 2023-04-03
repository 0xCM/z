//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public static class LogixEngine
    {
        const NumericKind Closure = UInt64k;

        /// <summary>
        /// Evaluates an untyped expression
        /// </summary>
        /// <param name="expr">The expression to evaluate</param>
        [Op]
        public static bit eval(ILogicExpr expr)
            => LogixLogicEval.eval(require(expr));

        /// <summary>
        /// Evaluates a typed logic expression
        /// </summary>
        /// <param name="expr">The expression to evaluate</param>
        [Op, Closures(Closure)]
        public static bit eval<T>(ILogicExpr<T> expr)
            where T : unmanaged
                => LogixLogicEval.eval(require(expr));

        /// <summary>
        /// Evaluates a typed scalar expression
        /// </summary>
        /// <param name="expr">The expression to evaluate</param>
        [Op, Closures(Closure)]
        public static LogixLiteral<T> eval<T>(ILogixExpr<T> expr)
            where T : unmanaged
                => LogixScalarEval.eval(require(expr));

        /// <summary>
        /// Evaluates a comparison expression, returning literal expression over the comparison type
        /// and the interpretation of this literal is type-dependent
        /// </summary>
        /// <param name="expr">The predicate to evaluate</param>
        /// <typeparam name="T">The type over which the comparison is defined</typeparam>
        [Op, Closures(Closure)]
        public static LogixLiteral<T> eval<T>(IComparisonExpr<T> expr)
            where T : unmanaged
                => LogixCmpEval.eval(require(expr));

        /// <summary>
        /// Evaluates a comparison expression over 128-bit intrinsic vectors
        /// </summary>
        /// <param name="expr">The expression to evaluate</param>
        /// <typeparam name="T">The cell type</typeparam>
        [Op, Closures(Closure)]
        public static LogixLiteral<Vector128<T>> eval<T>(IComparisonExpr<Vector128<T>> expr)
            where T : unmanaged
                => LogixCmpEval.eval(require(expr));

        /// <summary>
        /// Evaluates a comparison expression over 256-bit intrinsic vectors
        /// </summary>
        /// <param name="expr">The expression to evaluate</param>
        /// <typeparam name="T">The cell type</typeparam>
        [Op, Closures(Closure)]
        public static LogixLiteral<Vector256<T>> eval<T>(IComparisonExpr<Vector256<T>> expr)
            where T : unmanaged
                => LogixCmpEval.eval(require(expr));

        /// <summary>
        /// Evaluates a comparison predicate, returning an enabled bit if the comparison succeeds and
        /// a disabled bit otherwise
        /// </summary>
        /// <param name="expr">The predicate to evaluate</param>
        /// <typeparam name="T">The type over which the comparison is defined</typeparam>
        [Op, Closures(Closure)]
        public static bit eval<T>(IComparisonPredExpr<T> expr)
            where T : unmanaged
                => LogixCmpEval.eval(require(expr));

        /// <summary>
        /// Evaluates a typed scalar expression
        /// </summary>
        /// <param name="expr">The expression to evaluate</param>
        [Op, Closures(Closure)]
        public static LogixLiteral<T> eval<T>(IArithmeticExpr<T> expr)
            where T : unmanaged
                => LogixArithEval.eval(require(expr));

        /// <summary>
        /// Evaluates a typed 128-bit intrinsic expression
        /// </summary>
        /// <param name="expr">The expression to evaluate</param>
        [Op, Closures(Closure)]
        public static LogixLiteral<Vector128<T>> eval<T>(ILogixExpr<Vector128<T>> expr)
            where T : unmanaged
                => LogixVectorEval.eval(require(expr));

        /// <summary>
        /// Evaluates a typed 256-bit intrinsic expression
        /// </summary>
        /// <param name="expr">The expression to evaluate</param>
        [Op, Closures(Closure)]
        public static LogixLiteral<Vector256<T>> eval<T>(ILogixExpr<Vector256<T>> expr)
            where T : unmanaged
                => LogixVectorEval.eval(require(expr));

        /// <summary>
        /// Returns an enabled bit if the equality expression is satisfied with
        /// specified variable values and a disabled bit otherwise
        /// </summary>
        /// <param name="expr">The expression to test</param>
        /// <param name="a">The first variable value</param>
        /// <param name="b">The second variable value</param>
        [Op]
        public static bit satisfied(ComparisonExpr expr, bit a, bit b)
        {
            Require.invariant(expr.SetVars(a,b), () => "Unable to set variables");
            return LogixEngine.eval(expr);
        }

        /// <summary>
        /// Returns an enabled bit if the equality expression is satisfied with
        /// specified variable values and a disabled bit otherwise
        /// </summary>
        /// <param name="expr">The expression to test</param>
        /// <param name="a">The first variable value</param>
        /// <param name="b">The second variable value</param>
        [Op, Closures(Integers)]
        public static bit satisfied<T>(ComparisonExpr<T> expr, T a, T b)
            where T :unmanaged
        {
            Require.invariant(expr.VarCount >= 2, () => $"The source expression has {expr.VarCount} and the operation requires 2");
            expr.SetVars(a,b);
            return gmath.eq(LogixEngine.eval(expr).Value, Limits.maxval<T>());
        }

        /// <summary>
        /// Returns an enabled bit if the equality expression is satisfied with
        /// specified variable values and a disabled bit otherwise
        /// </summary>
        /// <param name="expr">The expression to test</param>
        /// <param name="a">The first variable value</param>
        /// <param name="b">The second variable value</param>
        [Op, Closures(Integers)]
        public static bit satisfied<T>(ComparisonExpr<Vector128<T>> expr, Vector128<T> a, Vector128<T> b)
            where T :unmanaged
        {
            expr.SetVars(a,b);
            var result = eval(expr);
            return gcpu.vtestc(result.Value, gcpu.vones<T>(n128));
        }

        /// <summary>
        /// Returns an enabled bit if the equality expression is satisfied with
        /// specified variable values and a disabled bit otherwise
        /// </summary>
        /// <param name="expr">The expression to test</param>
        /// <param name="a">The first variable value</param>
        /// <param name="b">The second variable value</param>
        [Op, Closures(Integers)]
        public static bit satisfied<T>(ComparisonExpr<Vector256<T>> expr, Vector256<T> a, Vector256<T> b)
            where T :unmanaged
        {
            expr.SetVars(a,b);
            var result = eval(expr);
            return gcpu.vtestc(result.Value, gcpu.vones<T>(n256));
        }

        /// <summary>
        /// Determines by exhaustion whether the left and right operands are equal
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [Op]
        public static bit equal(VariedLogicExpr a, VariedLogicExpr b)
        {
            var count = a.VarCount;
            foreach(var vars in BitLogicSpec.bitcombo(count))
            {
                a.SetVars(vars);
                var x = LogixEngine.eval(a);
                var y = LogixEngine.eval(b);
                if(x != y)
                    return bit.Off;
            }
            return bit.On;
        }

        [Op, Closures(Closure)]
        public static IReadOnlyList<T> solve<T>(ComparisonExpr<T> expr, Interval<T> domain, int varyix)
            where T : unmanaged, IEquatable<T>
        {
            var sln = new List<T>();
            var level0 = domain.Increments<T>();
            var ones = Limits.maxval<T>();
            for(var i=0; i<level0.Length; i++)
            {
                expr.SetVar(varyix, level0[i]);
                var result = LogixEngine.eval(expr);
                if(gmath.eq(result.Value, ones))
                    sln.Add(result);
            }
            return sln;
        }

        [Op, Closures(Closure)]
        public static IReadOnlyList<T> solve<T>(ComparisonExpr<T> expr, Interval<T> domain)
            where T : unmanaged, IEquatable<T>
        {
            var sln = new List<T>();
            var level0 = domain.Increments<T>();
            var level1 = domain.Increments<T>();
            var ones = Limits.maxval<T>();
            for(var i=0; i<level0.Length; i++)
            {
                expr.SetVar(0, level0[i]);
                for(var j=0; j<level1.Length; j++)
                {
                    expr.SetVar(1,level1[j]);

                    var result = LogixEngine.eval(expr);
                    if(gmath.eq(result.Value, ones))
                        sln.Add(result);
                }
            }
            return sln;
        }
    }
}