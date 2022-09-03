//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.DynamicModels
{
    using System;
    using System.Collections.Generic;

    public class PredicateApplication<F,T> : IPredicateApplication
        where F : Operator<F>
    {

        public PredicateApplication(F f)
        {
            this.Operator = f;
        }
        public F Operator { get; }

        protected virtual IReadOnlyList<object> Operands
            => new object[] { };

        IOperator IOperatorApplication.Operator
            => Operator;

        IReadOnlyList<object> IOperatorApplication.Operands
            => Operands;
    }
}
