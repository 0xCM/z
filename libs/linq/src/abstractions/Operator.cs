//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.DynamicModels
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents an operator
    /// </summary>
    /// <typeparam name="F">The operator type</typeparam>
    public abstract class Operator<F> : IOperator<F>
        where F : Operator<F>
    {
        protected Operator(string Name, string Symbol)
        {
            this.Name = Name;
            this.Symbol = Symbol;
        }

        /// <summary>
        /// The name of the operator
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The symbol used to denote the opeator
        /// </summary>
        public string Symbol { get; }


        public override string ToString()
            => Symbol;

        public abstract string FormatApply(params object[] args);

        protected abstract IOperatorApplication DoApply(params object[] args);

        IOperatorApplication IOperator.Apply(params object[] args)
            => DoApply(args);
    }
}