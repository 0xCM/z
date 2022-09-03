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
        [ApiComplete("dynamic.ops.32f")]
        public readonly struct Ops32f
        {
            public static Expression<Func<float,float,float>> Add
                = f<float>((x, y) => (float)(x + y));

            public static Expression<Func<float, float, float>> Sub
                = f<float>((x, y) => (float)(x - y));

            public static Expression<Func<float, float, float>> Mul
                = f<float>((x, y) => (float)(x * y));

            public static Expression<Func<float, float, float>> Div
                = f<float>((x, y) => (float)(x / y));

            public static Expression<Func<float, float, float>> Mod
                = f<float>((x, y) => (float)(x % y));

            public static Expression<Func<float, float>> Inc
                = f((float x) => ++x);

            public static Expression<Func<float, float>> Dec
                = f((float x) => --x);

            public static Expression<Func<float, float>> Abs
                = f((float x) => x);

            public static Expression<Func<float, float, bool>> LT
                = f((float x, float y) => x < y);

            public static Expression<Func<float, float, bool>> LTEQ
                = f((float x, float y) => x <= y);

            public static Expression<Func<float, float, bool>> GT
                = f((float x, float y) => x > y);

            public static Expression<Func<float, float, bool>> GTEQ
                = f((float x, float y) => x >= y);
        }
    }
}