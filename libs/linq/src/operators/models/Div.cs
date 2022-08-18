//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq.Expressions;

    using static LinqXPress;

    partial struct ModelsDynamic
    {
        public static class Divide<T>
        {
            static readonly Func<T, T, T> _OP
                = lambda<T, T, T>(Expression.Divide).Compile();

            public static T Apply(T x, T y)
                => _OP(x, y);
        }
    }
}