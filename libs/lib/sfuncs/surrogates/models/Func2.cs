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
        /// <summary>
        /// Defines a structured surrogate over a binary function delegate
        /// </summary>
        public readonly struct Func<X0,X1,R> : IFunc<X0,X1,R>
        {
            readonly System.Func<X0,X1,R> F;

            [MethodImpl(Inline)]
            internal Func(System.Func<X0,X1,R> f, OpIdentity id)
            {
                F = f;
                Id = id;
            }

            public OpIdentity Id {get;}

            [MethodImpl(Inline)]
            public R Invoke(X0 x0, X1 x1)
                => F(x0,x1);

            public System.Func<X0,X1,R> Subject
            {
                [MethodImpl(Inline)]
                get => F;
            }

            [MethodImpl(Inline)]
            public static implicit operator System.Func<X0,X1,R>(Func<X0,X1,R> src)
                => src.F;
        }
    }
}