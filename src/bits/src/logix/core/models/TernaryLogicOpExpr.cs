//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines the application of an untyped ternary logic operator
    /// </summary>
    public readonly struct TernaryLogicOpExpr : ITernaryLogicOpExpr
    {
        /// <summary>
        /// The operator kind
        /// </summary>
        public TernaryBitLogicKind ApiClass {get;}

        /// <summary>
        /// The first operand
        /// </summary>
        public ILogicExpr First {get;}

        /// <summary>
        /// The second operand
        /// </summary>
        public ILogicExpr Second {get;}

        /// <summary>
        /// The third operand
        /// </summary>
        public ILogicExpr Third {get;}

        [MethodImpl(Inline)]
        public TernaryLogicOpExpr(TernaryBitLogicKind op, ILogicExpr arg1, ILogicExpr arg2, ILogicExpr arg3)
        {
            ApiClass = op;
            First = arg1;
            Second = arg2;
            Third = arg3;
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
            => ApiClass.Format(First,Second,Third);

        public override string ToString()
            => Format();
    }
}