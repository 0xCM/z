//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.DynamicModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents the application of an operator to a set of operands
    /// </summary>
    /// <typeparam name="O"></typeparam>
    public abstract class OperatorApplication<O> : IOperatorApplication
        where O : Operator<O>
    {
        protected OperatorApplication(IOperator Operator, params object[] Operands)
        {
            this.Operator = Operator;
            this.Operands = Operands.ToList();
        }

        /// <summary>
        /// Specifies the operator
        /// </summary>
        public IOperator Operator { get; }

        /// <summary>
        /// Specivies the operands
        /// </summary>
        public IReadOnlyList<object> Operands { get; }

        public override string ToString()
            => $"{Operator}(" + string.Join(",", Operands) + ")";
    }
}