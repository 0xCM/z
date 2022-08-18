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
        [ApiComplete("dynamic.ops.32u")]
        public readonly struct Ops32u
        {
            public static Expression<Func<uint,uint>> Abs
                = f((uint x) => x);

            public static Expression<Func<uint,uint,uint>> Add
                = f<uint>((x, y) => (uint)(x + y));

            public static Expression<Func<uint,uint,uint>> Mul
                = f<uint>((x, y) => (uint)(x * y));

            public static Expression<Func<uint,uint,uint>> Sub
                = f<uint>((x, y) => (uint)(x - y));

            public static Expression<Func<uint,uint,uint>> And
                = f<uint>((x, y) => (uint)(x & y));

            public static Expression<Func<uint,uint,uint>> Or
                = f<uint>((x, y) => (uint)(x | y));

            public static Func<uint,uint,uint> Xor
                = (x,y) => (uint)(x ^ y);

            public static Expression<Func<uint,uint>> Inc
                = f((uint x) => ++x);

            public static Expression<Func<uint,uint>> Dec
                = f((uint x) => --x);

            public static Expression<Func<uint,uint,bool>> LT
                = f((uint x, uint y) => x < y);

            public static Expression<Func<uint,uint,bool>> LTEQ
                = f((uint x, uint y) => x <= y);

            public static Expression<Func<uint,uint,bool>> GT
                = f((uint x, uint y) => x > y);

            public static Expression<Func<uint,uint,bool>> GtEq
                = f((uint x, uint y) => x >= y);
        }
    }
}