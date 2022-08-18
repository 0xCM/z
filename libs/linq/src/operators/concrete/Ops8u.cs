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
        [ApiComplete("dynamic.ops.8u")]
        public readonly struct Ops8u
        {
            public static Expression<Func<byte,byte,byte>> Add
                = f<byte>((x, y) => (byte)(x + y));

            public static Expression<Func<byte,byte,byte>> Sub
                = f<byte>((x, y) => (byte)(x - y));

            public static Expression<Func<byte,byte,byte>> Mul
                = f<byte>((x, y) => (byte)(x * y));

            public static Expression<Func<byte,byte,byte>> Div
                = f<byte>((x, y) => (byte)(x / y));

            public static Expression<Func<byte,byte,byte>> Mod
                = f<byte>((x, y) => (byte)(x % y));

            public static Func<byte,byte,byte> And
                = (x,y) => (byte)(x & y);

            public static Func<byte,byte,byte> Or
                = (x,y) => (byte)(x | y);

            public static Func<byte,byte,byte> Xor
                = (x,y) => (byte)(x ^ y);

            public static Expression<Func<byte,byte>> Inc
                = f((byte x) => ++x);

            public static Expression<Func<byte,byte>> Dec
                = f((byte x) => --x);

            public static Expression<Func<byte,byte>> Abs
                = f((byte x) => x);

            public static Expression<Func<byte,byte,bool>> LT
                = f((byte x, byte y) => x < y);

            public static Expression<Func<byte,byte,bool>> LtEq
                = f((byte x, byte y) => x <= y);

            public static Expression<Func<byte,byte,bool>> GT
                = f((byte x, byte y) => x > y);

            public static Expression<Func<byte,byte,bool>> GtEq
                = f((byte x, byte y) => x >= y);
        }
    }
}