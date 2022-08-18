//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a variable-dependent typed expression
    /// </summary>
    /// <typeparam name="T">The operand type</typeparam>
    public sealed class VariedExpr<T> : IVariedExpr<T>
        where T : unmanaged
    {
        /// <summary>
        /// A variable-dependent expression
        /// </summary>
        public ILogixExpr<T> BaseExpr {get;}

        /// <summary>
        /// The variables upon which the expression depends
        /// </summary>
        public ILogixVarExpr<T>[] Vars {get;}

        [MethodImpl(Inline)]
        public VariedExpr(ILogixExpr<T> baseExpr, params VariableExpr<T>[] variables)
        {
            BaseExpr = baseExpr;
            Vars = variables;
        }

        [MethodImpl(Inline)]
        public void SetVars(params T[] values)
            => VariedExpr.Set(this, values.Map(v => (new LogixLiteral<T>(v) as ILogixLiteral<T>)));

        [MethodImpl(Inline)]
        public void SetVars(params ILogixExpr<T>[] values)
            => VariedExpr.Set(this,values);

        public string Format()
            => string.Empty;

        [MethodImpl(Inline)]
        public void SetVars(params ILogixVarExpr<T>[] values)
            => VariedExpr.Set(this,values);
    }
}