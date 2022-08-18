//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a typed unary arithmetic operator expression
    /// </summary>
    public readonly struct UnaryArithmeticOpExpr<T> : IUnaryArithmeticOpExpr<T>
        where T : unmanaged
    {
        /// <summary>
        /// The operator kind
        /// </summary>
        public ApiUnaryArithmeticClass ApiClass {get;}

        /// <summary>
        /// The operand
        /// </summary>
        public ILogixExpr<T> Arg {get;}

        [MethodImpl(Inline)]
        public UnaryArithmeticOpExpr(ApiUnaryArithmeticClass op, ILogixExpr<T> operand)
        {
            ApiClass = op;
            Arg = operand;
        }

        public string Format()
            => ApiClass.Format(Arg);

        public override string ToString()
            => Format();
    }
}