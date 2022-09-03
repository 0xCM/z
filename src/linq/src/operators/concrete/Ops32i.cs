//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using System;
    using System.Linq.Expressions;

    using static LinqXFunc;

    partial struct ModelsDynamic
    {
        [ApiComplete("dynamic.ops.32i")]
        public readonly struct Ops32i
        {
            public static Expression<Func<int, int>> Abs
                = f((int x) => x);

            public static Expression<Func<int, int, int>> Add
                = f<int>((x, y) => (int)(x + y));

            public static Expression<Func<int, int, int>> Mul
                = f<int>((x, y) => (int)(x * y));

            public static Expression<Func<int, int, int>> Sub
                = f<int>((x, y) => (int)(x - y));

            public static Expression<Func<int, int>> Inc
                = f((int x) => ++x);

            public static Expression<Func<int, int>> Dec
                = f((int x) => --x);

            public static Expression<Func<int, int, bool>> LT
                = f((int x, int y) => x < y);

            public static Expression<Func<int, int, bool>> LTEQ
                = f((int x, int y) => x <= y);

            public static Expression<Func<int, int, bool>> GT
                = f((int x, int y) => x > y);

            public static Expression<Func<int, int, bool>> GTEQ
                = f((int x, int y) => x >= y);
        }
    }
}