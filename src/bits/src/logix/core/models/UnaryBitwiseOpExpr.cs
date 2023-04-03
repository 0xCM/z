//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a unary bitwise operator expression
    /// </summary>
    public readonly struct UnaryBitwiseOpExpr<T> : IUnaryBitwiseOpExpr<T>
        where T : unmanaged
    {
        /// <summary>
        /// The operator kind
        /// </summary>
        public UnaryBitLogicKind ApiClass {get;}

        /// <summary>
        /// The operand
        /// </summary>
        public ILogixExpr<T> Operand {get;}

        [MethodImpl(Inline)]
        public UnaryBitwiseOpExpr(UnaryBitLogicKind op, ILogixExpr<T> operand)
        {
            ApiClass = op;
            Operand = operand;
        }

        public string Format()
            => ApiClass.Format(Operand);

        public override string ToString()
            => Format();
    }
}