//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a typed binary logical operator expression
    /// </summary>
    public readonly struct BinaryLogicOpExpr<T> : IBinaryLogicOpExpr<T>
        where T : unmanaged
    {
        /// <summary>
        /// The left operand
        /// </summary>
        public ILogicExpr<T> Left {get;}

        /// <summary>
        /// The right operand
        /// </summary>
        public ILogicExpr<T> Right {get;}

        /// <summary>
        /// The operator kind
        /// </summary>
        public BinaryBitLogicKind ApiClass {get;}

        [MethodImpl(Inline)]
        public BinaryLogicOpExpr(BinaryBitLogicKind op, ILogicExpr<T> left, ILogicExpr<T> right)
        {
            ApiClass = op;
            Left = left;
            Right = right;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => ApiClass == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => ApiClass != 0;
        }

        ILogicExpr IBinaryOpExpr<ILogicExpr>.Left
            => Left;

        ILogicExpr IBinaryOpExpr<ILogicExpr>.Right
            => Right;

        public string Format()
            => ApiClass.Format(Left,Right);

        public override string ToString()
            => Format();
    }
}