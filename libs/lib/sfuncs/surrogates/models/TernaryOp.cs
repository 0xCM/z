//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class Surrogates
    {
        public readonly struct TernaryOp<T> : ITernaryOp<T>
        {
            readonly Z0.TernaryOp<T> F;

            public OpIdentity Id {get;}

            [MethodImpl(Inline)]
            internal TernaryOp(Z0.TernaryOp<T> f, OpIdentity id)
            {
                F = f;
                Id = id;
            }

            [MethodImpl(Inline)]
            internal TernaryOp(Z0.TernaryOp<T> f, string name)
            {
                F = f;
                Id = SFxIdentity.identity<T>(name);
            }

            [MethodImpl(Inline)]
            public T Invoke(T a, T b, T c) => F(a, b, c);

            public Z0.TernaryOp<T> Subject
            {
                [MethodImpl(Inline)]
                get => F;
            }

            [MethodImpl(Inline)]
            public Func<T,T,T,T> AsFunc()
                => SFx.surrogate(this);

            [MethodImpl(Inline)]
            public static implicit operator Func<T,T,T,T>(TernaryOp<T> src)
                => src.AsFunc();

            [MethodImpl(Inline)]
            public static implicit operator TernaryOp<T>(Func<T,T,T,T> src)
                => SFx.canonical(src);
        }
    }
}