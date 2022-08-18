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
        public readonly struct BinaryOp<T> : IBinaryOp<T>
        {
            readonly Z0.BinaryOp<T> F;

            public OpIdentity Id {get;}

            [MethodImpl(Inline)]
            internal BinaryOp(Z0.BinaryOp<T> f, OpIdentity id)
            {
                F = f;
                Id = id;
            }

            [MethodImpl(Inline)]
            internal BinaryOp(Z0.BinaryOp<T> f, string name)
            {
                F = f;
                Id = SFxIdentity.identity<T>(name);
            }

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => F(a, b);

            public Z0.BinaryOp<T> Subject
            {
                [MethodImpl(Inline)]
                get => F;
            }

            [MethodImpl(Inline)]
            public string Format()
                => Id;

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public Func<T,T,T> AsFunc()
                => SFx.surrogate(this);

            [MethodImpl(Inline)]
            public static implicit operator Func<T,T,T>(BinaryOp<T> src)
                => src.AsFunc();

            [MethodImpl(Inline)]
            public static implicit operator BinaryOp<T>(Func<T,T,T> src)
                => SFx.canonical(src);
        }
    }
}