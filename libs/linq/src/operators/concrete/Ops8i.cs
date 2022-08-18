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
        public readonly struct Ops8i
        {
            public static Expression<Func<sbyte, sbyte, sbyte>> Add
                = f<sbyte>((x, y) => (sbyte)(x + y));

            public static Expression<Func<sbyte, sbyte, sbyte>> Mul
                = f<sbyte>((x, y) => (sbyte)(x * y));

            public static Expression<Func<sbyte, sbyte, sbyte>> Sub
                = f<sbyte>((x, y) => (sbyte)(x - y));

            public static Expression<Func<sbyte,sbyte,sbyte>> And
                = f<sbyte>((x, y) => (sbyte)(x & y));

            public static Expression<Func<sbyte,sbyte,sbyte>> Or
                = f<sbyte>((x, y) => (sbyte)(x | y));

            public static Expression<Func<sbyte,sbyte,sbyte>> Xor
                = f<sbyte>((x, y) => (sbyte)(x ^ y));

            public static Expression<Func<sbyte, sbyte>> Abs
                = f((sbyte x) => x < 0 ? (sbyte) -x : x);

            public static Expression<Func<sbyte, sbyte>> Inc
                = f((sbyte x) => ++x);

            public static Expression<Func<sbyte, sbyte>> Dec
                = f((sbyte x) => --x);

            public static Expression<Func<sbyte, sbyte, bool>> Gt
                = f((sbyte x, sbyte y) => x > y);

            public static Expression<Func<sbyte, sbyte, bool>> GtEq
                = f((sbyte x, sbyte y) => x >= y);

            public static Expression<Func<sbyte, sbyte, bool>> Lt
                = f((sbyte x, sbyte y) => x < y);

            public static Expression<Func<sbyte, sbyte, bool>> LtEq
                = f((sbyte x, sbyte y) => x <= y);
        }
    }
}