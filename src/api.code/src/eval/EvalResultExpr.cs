//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct EvalResultExpr
    {
        [MethodImpl(Inline)]
        public static Eq<T> eq<T>(T a, T b, bit state)
            => new Eq<T>(a,b,state);

        public readonly struct Eq<T>
        {
            public T A {get;}

            public T B {get;}

            public bit State {get;}

            [MethodImpl(Inline)]
            public Eq(T a, T b, bit state)
            {
                A = a;
                B = b;
                State = state;
            }

            public string Format()
                => string.Format("{0} {1} {2}", A, State ? "=" : "!=", B);

            public override string ToString()
                => Format();
        }
    }
}