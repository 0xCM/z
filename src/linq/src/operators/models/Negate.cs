//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;

    using static Root;
    using static LinqXPress;

    partial struct ModelsDynamic
    {
        public readonly struct Negate<T> : IFunc<T,T>
        {
            readonly Func<T,T> F;

            [MethodImpl(Inline)]
            internal Negate(Func<T,T> f)
                => F = f;

            [MethodImpl(Inline)]
            public T Invoke(T x)
                => F(x);
        }

        public static class NegateChecked<T>
        {
            static readonly Func<T,T> _OP
                = lambda<T,T>(Expression.NegateChecked).Compile();

            public static T Apply(T x)
                => _OP(x);
        }
    }
}