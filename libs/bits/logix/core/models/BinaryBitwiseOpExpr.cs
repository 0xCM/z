//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Captures a binary bitwise operator along with with its operands
    /// </summary>
    public readonly struct BinaryBitwiseOpExpr<T> : IBinaryBitwiseOpExpr<T>
        where T : unmanaged
    {
        /// <summary>
        /// The operator kind
        /// </summary>
        public BinaryBitLogicKind ApiClass {get;}

        /// <summary>
        /// The left operand
        /// </summary>
        public ILogixExpr<T> Left {get;}

        /// <summary>
        /// The right operand
        /// </summary>
        public ILogixExpr<T> Right {get;}

        [MethodImpl(Inline)]
        public BinaryBitwiseOpExpr(BinaryBitLogicKind op, ILogixExpr<T> left, ILogixExpr<T> right)
        {
            ApiClass = op;
            Left = left;
            Right = right;
        }

        /// <summary>
        /// Renders the expression in canonical form
        /// </summary>
        public string Format()
            => ApiClass.Format(Left, Right);

        public override string ToString()
            => Format();
    }
}