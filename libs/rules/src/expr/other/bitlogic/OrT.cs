//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Scalar
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Or<T> : IBinaryBitLogicOp<Or<T>,T>
        where T : IExpr
    {
        public T Left {get;}

        public T Right {get;}

        [MethodImpl(Inline)]
        public Or(T a, T b)
        {
            Left = a;
            Right = b;
        }

        public Identifier OpName
            => "or<{0}>";

        public BinaryBitLogicKind Kind
            => BinaryBitLogicKind.Or;

        [MethodImpl(Inline)]
        public Or<T> Create(T a0, T a1)
            => new Or<T>(a0, a1);

        public Or Untyped()
            => new Or(Left,Right);

        [MethodImpl(Inline)]
        public string Format()
            => Untyped().Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Or<T>((T a, T b) src)
            => new Or<T>(src.a, src.b);

        [MethodImpl(Inline)]
        public static implicit operator Or(Or<T> src)
            => src.Untyped();
    }
}