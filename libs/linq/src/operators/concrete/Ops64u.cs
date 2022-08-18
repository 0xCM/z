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
        public readonly struct Ops64u
        {
            public static Expression<Func<ulong, ulong>> Abs
                = f((ulong x) => x);

            public static Expression<Func<ulong, ulong, ulong>> Add
                = f<ulong>((x, y) => (ulong)(x + y));

            public static Expression<Func<ulong, ulong, ulong>> Mul
                = f<ulong>((x, y) => (ulong)(x * y));

            public static Expression<Func<ulong, ulong, ulong>> Sub
                = f<ulong>((x, y) => (ulong)(x - y));

            public static Expression<Func<ulong,ulong,ulong>> And
                = f<ulong>((x, y) => (ulong)(x & y));

            public static Expression<Func<ulong,ulong,ulong>> Or
                = f<ulong>((x, y) => (ulong)(x | y));

            public static Func<ulong,ulong,ulong> Xor
                = (x,y) => (ulong)(x ^ y);

            public static Expression<Func<ulong,ulong,ulong>> XorX
                = f<ulong>(Xor);

            public static Expression<Func<ulong, ulong>> Inc
                = f((ulong x) => ++x);

            public static Expression<Func<ulong, ulong>> Dec
                = f((ulong x) => --x);

            public static Expression<Func<ulong, ulong, bool>> LT
                = f((ulong x, ulong y) => x < y);

            public static Expression<Func<ulong, ulong, bool>> LTEQ
                = f((ulong x, ulong y) => x <= y);

            public static Expression<Func<ulong, ulong, bool>> GT
                = f((ulong x, ulong y) => x > y);

            public static Expression<Func<ulong, ulong, bool>> GtEq
                = f((ulong x, ulong y) => x >= y);
        }
    }
}