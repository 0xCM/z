//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using static Root;
    using static LinqXFunc;

    partial struct ModelsDynamic
    {
        public readonly struct Ops16i
        {
            public static Expression<Func<short, short>> Abs
                => f((short x) => x);

            public static Expression<Func<short, short, short>> Add
                => f<short>((x, y) => (short)(x + y));

            public static Expression<Func<short, short, short>> Mul
                => f<short>((x, y) => (short)(x * y));

            public static Expression<Func<short, short, short>> Sub
                => f<short>((x, y) => (short)(x - y));

            public static Expression<Func<short, short>> Inc
                => f((short x) => ++x);

            public static Expression<Func<short, short>> Dec
                => f((short x) => --x);

            public static Expression<Func<short, short, bool>> LT
                => f((short x, short y) => x < y);

            public static Expression<Func<short, short, bool>> LtEq
                => f((short x, short y) => x <= y);

            public static Expression<Func<short, short, bool>> GT
                => f((short x, short y) => x > y);

            public static Expression<Func<short, short, bool>> GtEq
                => f((short x, short y) => x >= y);
        }
    }
}