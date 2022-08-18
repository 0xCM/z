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
        public class Ops64i
        {
            public static Expression<Func<long, long>> Abs
                = f((long x) => x);

            public static Expression<Func<long, long, long>> Add
                = f<long>((x, y) => (long)(x + y));

            public static Expression<Func<long, long, long>> Mul
                = f<long>((x, y) => (long)(x * y));

            public static Expression<Func<long, long, long>> Sub
                = f<long>((x, y) => (long)(x - y));

            public static Expression<Func<long, long>> Inc
                = f((long x) => ++x);

            public static Expression<Func<long, long>> Dec
                = f((long x) => --x);

            public static Expression<Func<long, long, bool>> LT
                = f((long x, long y) => x < y);

            public static Expression<Func<long, long, bool>> LTEQ
                = f((long x, long y) => x <= y);

            public static Expression<Func<long, long, bool>> GT
                = f((long x, long y) => x > y);

            public static Expression<Func<long, long, bool>> GTEQ
                = f((long x, long y) => x >= y);
        }
    }
}