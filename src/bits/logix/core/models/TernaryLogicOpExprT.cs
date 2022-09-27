//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a typed ternary logic operator expression
    /// </summary>
    public sealed class TernaryLogicOpExpr<T> : ITernaryLogicOpExpr<T>
        where T : unmanaged
    {
        /// <summary>
        /// The operator kind
        /// </summary>
        public TernaryBitLogicKind ApiClass {get;}

        /// <summary>
        /// The first operand
        /// </summary>
        public ILogicExpr<T> First {get;}

        /// <summary>
        /// The second operand
        /// </summary>
        public ILogicExpr<T> Second {get;}

        /// <summary>
        /// The third operand
        /// </summary>
        public ILogicExpr<T> Third {get;}

        [MethodImpl(Inline)]
        public TernaryLogicOpExpr(TernaryBitLogicKind op, ILogicExpr<T> arg1, ILogicExpr<T> arg2, ILogicExpr<T> arg3)
        {
            this.ApiClass = op;
            this.First = arg1;
            this.Second = arg2;
            this.Third = arg3;
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

        ILogicExpr ITernaryOpExpr<ILogicExpr>.First
            => First;

        ILogicExpr ITernaryOpExpr<ILogicExpr>.Second
            => Second;

        ILogicExpr ITernaryOpExpr<ILogicExpr>.Third
            => Third;

        public string Format()
            => ApiClass.Format(First,Second,Third);

        public override string ToString()
            => Format();
    }
}