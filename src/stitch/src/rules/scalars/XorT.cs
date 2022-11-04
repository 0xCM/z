//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ScalarOps
    {        
        [StructLayout(LayoutKind.Sequential)]
        public readonly struct Xor<T> : IBinaryBitLogicOp<Xor<T>,T>
            where T : IExpr
        {
            public T Left {get;}

            public T Right {get;}

            [MethodImpl(Inline)]
            public Xor(T a, T b)
            {
                Left = a;
                Right = b;
            }

            public Identifier OpName
                => "xor<{0}>";

            public BinaryBitLogicKind Kind
                => BinaryBitLogicKind.Xor;

            [MethodImpl(Inline)]
            public Xor<T> Create(T a0, T a1)
                => new Xor<T>(a0, a1);

            public Xor Untyped()
                => new Xor(Left,Right);

            [MethodImpl(Inline)]
            public string Format()
                => Untyped().Format();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator Xor<T>((T a, T b) src)
                => new Xor<T>(src.a, src.b);

            [MethodImpl(Inline)]
            public static implicit operator Xor(Xor<T> src)
                => src.Untyped();
        }
    }
}