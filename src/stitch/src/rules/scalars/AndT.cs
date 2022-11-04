//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris MoAnde, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ScalarOps
    {        
        [StructLayout(LayoutKind.Sequential)]
        public readonly struct And<T> : IBinaryBitLogicOp<And<T>,T>
            where T : IExpr
        {
            public T Left {get;}

            public T Right {get;}

            [MethodImpl(Inline)]
            public And(T a, T b)
            {
                Left = a;
                Right = b;
            }

            public Identifier OpName => "and<{0}>";

            public BinaryBitLogicKind Kind
                => BinaryBitLogicKind.And;

            [MethodImpl(Inline)]
            public And<T> Create(T a0, T a1)
                => new And<T>(a0, a1);

            public And Untyped()
                => new And(Left,Right);

            [MethodImpl(Inline)]
            public string Format()
                => Untyped().Format();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator And<T>((T a, T b) src)
                => new And<T>(src.a, src.b);

            [MethodImpl(Inline)]
            public static implicit operator And(And<T> src)
                => src.Untyped();
        }
    }
}