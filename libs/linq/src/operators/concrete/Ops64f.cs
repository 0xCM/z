//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using static LinqXFunc;

    partial struct ModelsDynamic
    {
        public readonly struct DynamicOps64u
        {
            public static Expression<Func<double, double>> Abs64f
                => f((double x) => x);

            public static Expression<Func<double, double, double>> Add64f
                => f<double>((x, y) => (double)(x + y));

            public static Expression<Func<double, double, double>> Mul64f
                => f<double>((x, y) => (double)(x * y));

            public static Expression<Func<double, double, double>> Sub64f
                => f<double>((x, y) => (double)(x - y));

            public static Expression<Func<double, double>> Inc64f
                => f((double x) => ++x);

            public static Expression<Func<double, double>> Dec64f
                => f((double x) => --x);

            public static Expression<Func<double, double, bool>> Lt64f
                => f((double x, double y) => x < y);

            public static Expression<Func<double, double, bool>> LtEq64f
                => f((double x, double y) => x <= y);

            public static Expression<Func<double, double, bool>> Gt64f
                => f((double x, double y) => x > y);

            public static Expression<Func<double, double, bool>> GtEq64f
                => f((double x, double y) => x >= y);
        }
    }
}