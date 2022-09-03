//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.DynamicModels
{
    using System;
    using System.Collections.Generic;

    public sealed class UnaryOperatorApplication<F,T> : OperatorApplication<F>
        where F : UnaryOperator<F>
    {
        public UnaryOperatorApplication(UnaryOperator<F> f, T x)
            : base(f, x)
        {

        }

        public T Operand => (T)Operands[0];

        public override string ToString()
            => $"{Operator}({Operand})";
    }
}
