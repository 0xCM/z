//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;

    using static Z0.LinqXPress;

    partial struct ModelsDynamic
    {
        public static class Eq<T>
        {
            static readonly Func<T, T, bool> _OP
                = lambda<T, T, bool>(Expression.Equal).Compile();

            public static bool Apply(T x, T y)
                => _OP(x, y);

            public static MethodInfo Method => _OP.Method;
        }
    }
}