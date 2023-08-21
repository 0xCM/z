﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static LinqXPress;

    partial struct ModelsDynamic
    {
        public static class AndAlso<T>
        {
            static readonly Func<T,T,bool> _OP
                = lambda<T,T,bool>(Expression.AndAlso).Compile();

            public static bool Apply(T x, T y)
                => _OP(x, y);

            public static MethodInfo Method => _OP.Method;
        }
    }
}