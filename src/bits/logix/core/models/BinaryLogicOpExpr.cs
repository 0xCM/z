//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Definesan untyped binary logical operator expression
    /// </summary>
    public readonly struct BinaryLogicOpExpr : IBinaryLogicOpExpr
    {
        /// <summary>
        /// The operator kind
        /// </summary>
        public BinaryBitLogicKind ApiClass {get;}

        /// <summary>
        /// The left operand
        /// </summary>
        public ILogicExpr Left {get;}

        /// <summary>
        /// The right operand
        /// </summary>
        public ILogicExpr Right {get;}

        [MethodImpl(Inline)]
        public BinaryLogicOpExpr(BinaryBitLogicKind op, ILogicExpr lhs, ILogicExpr rhs)
        {
            ApiClass = op;
            Left = lhs;
            Right = rhs;
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

        public string Format()
            => ApiClass.Format(Left,Right);

        public override string ToString()
            => Format();
    }
}