//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.DynamicModels
{
    /// <summary>
    /// Represents a comparison operator
    /// </summary>
    /// <typeparam name="F"></typeparam>
    public abstract class ComparisonOperator<F> : BinaryOperator<F>, IComparisonOperator<F>
        where F : ComparisonOperator<F>
    {
        protected ComparisonOperator(string Name, string Symbol)
            : base(Name, Symbol)
        { }

        public new ComparisonOperatorApplication<F,T> Apply<T>(T Left, T Right)
            => new ComparisonOperatorApplication<F,T>(this, Left, Right);

        protected override IOperatorApplication DoApply(params object[] args)
            => Apply(args[0], args[1]);
    }
}
