//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct ModelsDynamic
    {
        public readonly struct And<T> : IFunc<T,T,T>
        {
            readonly Func<T,T,T> F;

            [MethodImpl(Inline)]
            public static implicit operator Func<T,T,T>(And<T> src)
                => src.F;

            [MethodImpl(Inline)]
            internal And(Func<T,T,T> f)
                => F = f;

            [MethodImpl(Inline)]
            public T Invoke(T x,T y)
                => F(x,y);

            public MethodInfo Method
            {
                [MethodImpl(Inline)]
                get => F.Method;
            }
        }
    }
}