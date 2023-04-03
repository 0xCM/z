//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct LogixLogicEval
    {
        static BitLogix bitlogix => BitLogix.Service;

        [Op]
        internal static bit eval(ILogicExpr expr)
        {
            switch(expr)
            {
                case ILogicVarExpr x:
                    return eval(x.Value);
                case IVariedLogicExpr x:
                    return eval(x.BaseExpr);
                case ILogicLiteralExpr x:
                    return x.Value;
                case ILogicOpExpr x:
                    return eval(x);
                case IComparisonExpr x:
                    return eval(x.Left) == eval(x.Right);
               default: throw new NotSupportedException(expr.GetType().Name);
             }
        }

        /// <summary>
        /// Evaluates a logical operator expression
        /// </summary>
        /// <param name="expr">The expression to evaluate</param>
        [Op]
        static bit eval(ILogicOpExpr expr)
        {
            switch(expr)
            {
                case IUnaryLogicOpExpr x:
                    return bitlogix.Evaluate(x.ApiClass, eval(x.Operand));
                case IBinaryLogicOpExpr x:
                    return bitlogix.Evaluate(x.ApiClass, eval(x.Left), eval(x.Right));
                case ITernaryLogicOpExpr x:
                    return bitlogix.Evaluate(x.ApiClass, eval(x.First), eval(x.Second), eval(x.Third));
               default: throw new NotSupportedException(expr.GetType().Name);
            }
        }
    }
}