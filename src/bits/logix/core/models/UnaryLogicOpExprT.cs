//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct UnaryLogicOpExpr<T> :  IUnaryLogicOpExpr<T>
        where T : unmanaged
    {
        public UnaryBitLogicKind ApiClass {get;}

        public ILogicExpr<T> Operand {get;}

        [MethodImpl(Inline)]
        public UnaryLogicOpExpr(UnaryBitLogicKind kind, ILogicExpr<T> arg)
        {
            Operand = arg;
            ApiClass = kind;
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

        ILogicExpr IUnaryOpExpr<ILogicExpr>.Operand
            => Operand;

        public string Format()
            => ApiClass.Format(Operand);
    }
}