//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.DynamicModels
{
    public sealed class BinaryOperatorApplication<F,T> : OperatorApplication<F>
        where F : BinaryOperator<F>
    {
        public BinaryOperatorApplication(BinaryOperator<F> f, T x, T y)
            : base(f, x, y)
        {
        }

        public T Left => (T)Operands[0];

        public T Right => (T)Operands[1];

        public override string ToString()
            => $"{Left} {Operator} {Right}";
    }
}
