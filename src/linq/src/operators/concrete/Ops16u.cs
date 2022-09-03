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
        public readonly struct Ops16u
        {
            public static Expression<Func<ushort, ushort>> Abs
                = f((ushort x) => x);

            public static Expression<Func<ushort, ushort, ushort>> Add
                = f<ushort>((x, y) => (ushort)(x + y));

            public static Expression<Func<ushort, ushort, ushort>> Mul
                = f<ushort>((x, y) => (ushort)(x * y));

            public static Expression<Func<ushort, ushort, ushort>> Sub
                = f<ushort>((x, y) => (ushort)(x - y));

            public static Expression<Func<ushort,ushort,ushort>> And
                = f<ushort>((x, y) => (ushort)(x & y));

            public static Expression<Func<ushort,ushort,ushort>> Or
                = f<ushort>((x, y) => (ushort)(x | y));

            public static Expression<Func<ushort,ushort,ushort>> Xor
                = (x,y) => (ushort)(x ^ y);

            public static Expression<Func<ushort, ushort>> Inc
                = f((ushort x) => ++x);

            public static Expression<Func<ushort, ushort>> Dec
                = f((ushort x) => --x);

            public static Expression<Func<ushort, ushort, bool>> LT
                = f((ushort x, ushort y) => x < y);

            public static Expression<Func<ushort, ushort, bool>> LtEq
                = f((ushort x, ushort y) => x <= y);

            public static Expression<Func<ushort, ushort, bool>> GT
                = f((ushort x, ushort y) => x > y);

            public static Expression<Func<ushort,ushort,bool>> GtEq
                = f((ushort x, ushort y) => x >= y);
        }

        public readonly struct Ops16uC
        {
            public static Func<ushort, ushort> Abs
                = Ops16u.Abs.Compile();

            public static Func<ushort,ushort,ushort> Add
                = Ops16u.Add.Compile();

            public static Func<ushort,ushort,ushort> Mul
                = Ops16u.Mul.Compile();

            public static Func<ushort,ushort,ushort> Sub
                = Ops16u.Sub.Compile();

            public static Func<ushort,ushort,ushort> And
                = Ops16u.And.Compile();

            public static Func<ushort,ushort,ushort> Or
                = Ops16u.Or.Compile();

            public static Func<ushort,ushort,ushort> Xor
                = Ops16u.Xor.Compile();

            public static Func<ushort, ushort> Inc
                = Ops16u.Inc.Compile();

            public static Func<ushort, ushort> Dec
                = Ops16u.Dec.Compile();

            public static Func<ushort,ushort,bool> LT
                = Ops16u.LT.Compile();

            public static Func<ushort,ushort,bool> LtEq
                = Ops16u.LtEq.Compile();

            public static Func<ushort,ushort,bool> GT
                = Ops16u.GT.Compile();

            public static Func<ushort,ushort,bool> GtEq
                = Ops16u.GtEq.Compile();
        }
    }
}