//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.DynamicModels
{
    using System;
    using System.Linq;

    public abstract class UnaryOperator<F> : Operator<F>
        where F : UnaryOperator<F>
    {
        protected UnaryOperator(string Name, string Symbol)
            : base(Name, Symbol)
        { }

        public UnaryOperatorApplication<F,T> Apply<T>(T Operand)
            => new UnaryOperatorApplication<F,T>(this, Operand);

        protected override IOperatorApplication DoApply(params object[] args)
            => Apply(args.First());

        public override string FormatApply(params object[] args)
            => $"{Symbol}({args.FirstOrDefault()}";
    }
}
