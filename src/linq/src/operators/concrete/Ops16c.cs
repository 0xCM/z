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
        public readonly struct Ops16c
        {
            public static Expression<Func<char, char>> Abs
                = f((char x) => x);

            public static Expression<Func<char, char, char>> Add
                = f<char>((x, y) => (char)(x + y));

            public static Expression<Func<char, char, char>> Mul
                = f<char>((x, y) => (char)(x * y));

            public static Expression<Func<char, char, char>> Sub
                = f<char>((x, y) => (char)(x - y));

            public static Expression<Func<char, char>> Inc
                = f((char x) => ++x);

            public static Expression<Func<char, char>> Dec
                = f((char x) => --x);

            public static Expression<Func<char, char, bool>> LT
                = f((char x, char y) => x < y);

            public static Expression<Func<char, char, bool>> LTEQ
                = f((char x, char y) => x <= y);

            public static Expression<Func<char, char, bool>> GT
                = f((char x, char y) => x > y);

            public static Expression<Func<char, char, bool>> GTEQ
                = f((char x, char y) => x >= y);
        }
    }
}