//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.DynamicModels
{
    using System;
    using System.Linq;

    /// <summary>
    /// Represents a binary operator
    /// </summary>
    /// <typeparam name="F"></typeparam>
    public abstract class BinaryOperator<F> : Operator<F>, IBinaryOperator<F>
        where F : BinaryOperator<F>
    {
        protected BinaryOperator(string Name, string Symbol)
            : base(Name, Symbol)
        { }

        public BinaryOperatorApplication<F,T> Apply<T>(T Left, T Right)
            => new BinaryOperatorApplication<F,T>(this, Left, Right);

        protected override IOperatorApplication DoApply(params object[] args)
            => Apply(args[0], args[1]);

        public override string FormatApply(params object[] args)
            => $"{args.FirstOrDefault()} {Symbol} {args.SecondOrDefault()}";

        IOperatorApplication IBinaryOperator.Apply(object Left, object Right)
            => DoApply(Left, Right);
    }
}