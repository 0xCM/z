//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris MoNote, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ScalarOps
    {        
        [StructLayout(LayoutKind.Sequential)]
        public readonly struct Not<T> : IUnaryBitLogicOp<Not<T>,T>
            where T : IExpr
        {
            public T Operand {get;}

            [MethodImpl(Inline)]
            public Not(T a)
            {
                Operand = a;
            }

            public Identifier OpName
                => "not<{0}>";

            public UnaryBitLogicKind Kind
                => UnaryBitLogicKind.Not;

            [MethodImpl(Inline)]
            public Not<T> Create(T a0)
                => new Not<T>(a0);

            public Not Untyped()
                => new Not(Operand);

            [MethodImpl(Inline)]
            public string Format()
                => Untyped().Format();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator Not<T>((T a, T b) src)
                => new Not<T>(src.a);

            [MethodImpl(Inline)]
            public static implicit operator Not(Not<T> src)
                => src.Untyped();
        }
    }
}