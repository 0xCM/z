//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct UInt128
    {
        /// <summary>
        /// Test cases, adapted from https://github.com/chfast/intx/blob/99708e6852e8e5308369cd4ef8bc6bbb264d0a8c/test/unittests/test_int128.cpp
        /// </summary>
        public readonly partial struct Tests
        {
            public struct ArithmeticCase
            {
                public UInt128 X;

                public UInt128 Y;

                public UInt128 Sum;

                public UInt128 Difference;

                public UInt128 Product;

                public static implicit operator ArithmeticCase((UInt128 x, UInt128 y, UInt128 sum, UInt128 diff, UInt128 prod) src)
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
