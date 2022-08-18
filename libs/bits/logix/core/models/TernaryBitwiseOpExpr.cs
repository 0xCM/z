//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a typed ternary bitwise operator expression
    /// </summary>
    public readonly struct TernaryBitwiseOpExpr<T> : ITernaryBitwiseOpExpr<T>
        where T : unmanaged
    {
        /// <summary>
        /// The operator kind
        /// </summary>
        public TernaryBitLogicKind ApiClass {get;}

        /// <summary>
        /// The first operand
        /// </summary>
        public ILogixExpr<T> First {get;}

        /// <summary>
        /// The second operand
        /// </summary>
        public ILogixExpr<T> Second {get;}

        /// <summary>
        /// The third operand
        /// </summary>
        public ILogixExpr<T> Third {get;}

        [MethodImpl(Inline)]
        public TernaryBitwiseOpExpr(TernaryBitLogicKind op, ILogixExpr<T> first, ILogixExpr<T> second, ILogixExpr<T> third)
        {
            ApiClass = op;
            First = first;
            Second = second;
            Third = third;
        }

        public string Format()
            => ApiClass.Format(First,Second,Third);

        public override string ToString()
            => Format();
    }
}