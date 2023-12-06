//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct zUInt128
    {
        /// <summary>
        /// Test cases, adapted from https://github.com/chfast/intx/blob/99708e6852e8e5308369cd4ef8bc6bbb264d0a8c/test/unittests/test_int128.cpp
        /// </summary>
        public readonly partial struct Tests
        {
            public struct ArithmeticCase
            {
                public zUInt128 X;

                public zUInt128 Y;

                public zUInt128 Sum;

                public zUInt128 Difference;

                public zUInt128 Product;

                public static implicit operator ArithmeticCase((zUInt128 x, zUInt128 y, zUInt128 sum, zUInt128 diff, zUInt128 prod) src)
                {
                    var dst = new ArithmeticCase();
                    dst.X = src.x;
                    dst.Y = src.y;
                    dst.Sum = src.sum;
                    dst.Difference = src.diff;
                    dst.Product = src.prod;
                    return dst;
                }
            }

            public static ArithmeticCase[] AritmeticCases = new ArithmeticCase[]{
                (0, 0, 0, 0, 0),

            };
        }
    }
}
