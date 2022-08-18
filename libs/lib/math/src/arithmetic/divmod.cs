//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class math
    {
        /// <summary>
        /// Computes dst = (div(a,b), mod(a,b))
        /// </summary>
        /// <param name="a">The dividend</param>
        /// <param name="b">The divisor</param>
        [MethodImpl(Inline), DivMod]
        public static ConstPair<sbyte> divmod(sbyte a, sbyte b)
        {
            var d = (sbyte)(a/b);
            var m = (sbyte)(a - (d * b));
            return (d,m);
        }

        /// <summary>
        /// Computes dst = (div(a,b), mod(a,b))
        /// </summary>
        /// <param name="a">The dividend</param>
        /// <param name="b">The divisor</param>
        [MethodImpl(Inline), DivMod]
        public static ConstPair<byte> divmod(byte a, byte b)
        {
            var d = (byte)(a/b);
            var m = (byte)(a - (d * b));
            return (d,m);
        }

        /// <summary>
        /// Computes dst = (div(a,b), mod(a,b))
        /// </summary>
        /// <param name="a">The dividend</param>
        /// <param name="b">The divisor</param>
        [MethodImpl(Inline), DivMod]
        public static ConstPair<short> divmod(short a, short b)
        {
            var d = (short)(a/b);
            var m = (short)(a - (d * b));
            return (d,m);
        }

        /// <summary>
        /// Computes dst = (div(a,b), mod(a,b))
        /// </summary>
        /// <param name="a">The dividend</param>
        /// <param name="b">The divisor</param>
        [MethodImpl(Inline), DivMod]
        public static ConstPair<ushort> divmod(ushort a, ushort b)
        {
            var d = (ushort)(a/b);
            var m = (ushort)(a - (d * b));
            return (d,m);
        }

        /// <summary>
        /// Computes dst = (div(a,b), mod(a,b))
        /// </summary>
        /// <param name="a">The dividend</param>
        /// <param name="b">The divisor</param>
        [MethodImpl(Inline), DivMod]
        public static ConstPair<int> divmod(int a, int b)
        {
            var d = a/b;
            var m = a - (d * b);
            return (d,m);
        }

        /// <summary>
        /// Computes dst = (div(a,b), mod(a,b))
        /// </summary>
        /// <param name="a">The dividend</param>
        /// <param name="b">The divisor</param>
        [MethodImpl(Inline), DivMod]
        public static ConstPair<uint> divmod(uint a, uint b)
        {
            var d = a/b;
            var m = a - (d * b);
            return (d,m);
        }

        /// <summary>
        /// Computes dst = (div(a,b), mod(a,b))
        /// </summary>
        /// <param name="a">The dividend</param>
        /// <param name="b">The divisor</param>
        [MethodImpl(Inline), DivMod]
        public static ConstPair<long> divmod(long a, long b)
        {
            var d = a/b;
            var m = a - (d * b);
            return (d,m);
        }

        /// <summary>
        /// Computes dst = (div(a,b), mod(a,b))
        /// </summary>
        /// <param name="a">The dividend</param>
        /// <param name="b">The divisor</param>
        [MethodImpl(Inline), DivMod]
        public static ConstPair<ulong> divmod(ulong a, ulong b)
        {
            var d = a/b;
            var m = a - (d * b);
            return (d,m);
        }

        /// <summary>
        /// Computes div/mod for the source operands
        /// </summary>
        /// <param name="a">The dividend</param>
        /// <param name="b">The divisor</param>
        [MethodImpl(Inline), DivMod]
        public static void divmod(byte a, byte b, out byte d, out byte m)
        {
            d = (byte)(a/b);
            m = (byte)(a - (d * b));
        }

        /// <summary>
        /// Computes div/mod for the source operands
        /// </summary>
        /// <param name="a">The dividend</param>
        /// <param name="b">The divisor</param>
        [MethodImpl(Inline), DivMod]
        public static void divmod(sbyte a, sbyte b, out sbyte d, out sbyte m)
        {
            d = (sbyte)(a/b);
            m = (sbyte)(a - (d * b));
        }

        /// <summary>
        /// Computes div/mod for the source operands
        /// </summary>
        /// <param name="a">The dividend</param>
        /// <param name="b">The divisor</param>
        [MethodImpl(Inline), DivMod]
        public static void divmod(ushort a, ushort b, out ushort d, out ushort m)
        {
            d = (ushort)(a/b);
            m = (ushort)(a - (d * b));
        }

        /// <summary>
        /// Computes div/mod for the source operands
        /// </summary>
        /// <param name="a">The dividend</param>
        /// <param name="b">The divisor</param>
        [MethodImpl(Inline), DivMod]
        public static void divmod(short a, short b, out short d, out short m)
        {
            d = (short)(a/b);
            m = (short)(a - (d * b));
        }

        /// <summary>
        /// Computes div/mod for the source operands
        /// </summary>
        /// <param name="a">The dividend</param>
        /// <param name="b">The divisor</param>
        [MethodImpl(Inline), DivMod]
        public static void divmod(int a, int b, out int d, out int m)
        {
            d = a/b;
            m = a - (d * b);
        }

        /// <summary>
        /// Computes div/mod for the source operands
        /// </summary>
        /// <param name="a">The dividend</param>
        /// <param name="b">The divisor</param>
        [MethodImpl(Inline), DivMod]
        public static void divmod(long a, long b, out long d, out long m)
        {
            d = a/b;
            m = a - (d * b);
        }

        /// <summary>
        /// Computes div/mod for the source operands
        /// </summary>
        /// <param name="a">The dividend</param>
        /// <param name="b">The divisor</param>
        [MethodImpl(Inline), DivMod]
        public static void divmod(uint a, uint b, out uint d, out uint m)
        {
            d = a/b;
            m = a - (d * b);
        }

        /// <summary>
        /// Computes div/mod for the source operands
        /// </summary>
        /// <param name="a">The dividend</param>
        /// <param name="b">The divisor</param>
        [MethodImpl(Inline), DivMod]
        public static void divmod(ulong a, ulong b, out ulong d, out ulong m)
        {
            d = a/b;
            m = a - (d * b);
        }

        /// <summary>
        /// Computes div/mod for the source operands
        /// </summary>
        /// <param name="a">The dividend</param>
        /// <param name="b">The divisor</param>
        [MethodImpl(Inline), DivMod]
        public static void divmod(float a, float b, out float d, out float m)
        {
            d = a/b;
            m = a - (d * b);
        }

    }
}