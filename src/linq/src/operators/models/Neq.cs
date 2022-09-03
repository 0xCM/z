//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;

    using static LinqXPress;

    partial struct ModelsDynamic
    {
        public static class Neq<T>
        {
            static readonly Func<T,T,bool> _OP
                = lambda<T, T, bool>(Expression.NotEqual).Compile();

            public static bool Apply(T x, T y)
                => _OP(x, y);

            public static MethodInfo Method => _OP.Method;
        }
    }
}