//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines an untyped unary logic operator expression
    /// </summary>
    public readonly struct UnaryLogicOpExpr : IUnaryLogicOpExpr
    {
        /// <summary>
        /// The operator kind
        /// </summary>
        public UnaryBitLogicKind ApiClass {get;}

        /// <summary>
        /// The operand
        /// </summary>
        public ILogicExpr Operand {get;}

        [MethodImpl(Inline)]
        public UnaryLogicOpExpr(UnaryBitLogicKind op, ILogicExpr arg)
        {
            ApiClass = op;
            Operand = arg;
        }

        public string Format()
            => ApiClass.Format(Operand);
    }

}