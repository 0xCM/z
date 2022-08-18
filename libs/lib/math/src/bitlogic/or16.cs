//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class math
    {
        /// <summary>
        /// Computes the bitwise or c := a | b for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Or]
        public static short or(short a, short b)
            => (short)(a | b);

        /// <summary>
        /// Computes the bitwise or c := a | b for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Or]
        public static ushort or(ushort a, ushort b)
            => (ushort)(a | b);

        /// <summary>
        /// Computes the bitwise or c := a | b for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Or]
        public static int or(int a, int b)
            => a | b;

        /// <summary>
        /// Computes the bitwise disjunction of the source operands
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        /// <param name="c">The third operand</param>
        [MethodImpl(Inline), Op]
        public static int or(int a, int b, int c)
            => a | b | c;

        /// <summary>
        /// Computes the bitwise or c := a | b for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Or]
        public static long or(long a, long b)
            => a | b;

        /// <summary>
        /// Computes the bitwise disjunction of the source operands
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        /// <param name="c">The third operand</param>
        [MethodImpl(Inline), Op]
        public static short or(short a, short b, short c)
            => (short)((int)a | (int)b | (int)c);

        /// <summary>
        /// Computes the bitwise disjunction of the source operands
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        /// <param name="c">The third operand</param>
        /// <param name="d">The fourth operand</param>
        [MethodImpl(Inline), Op]
        public static short or(short a, short b, short c, short d)
            => (short)((int)a | (int)b | (int)c | (int)d);

        /// <summary>
        /// Computes the bitwise disjunction of the source operands
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        /// <param name="c">The third operand</param>
        [MethodImpl(Inline), Op]
        public static ushort or(ushort a, ushort b, ushort c)
            => (ushort)((uint)a | (uint)b | (uint)c);

        /// <summary>
        /// Computes the bitwise disjunction of the source operands
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        /// <param name="c">The third operand</param>
        /// <param name="d">The fourth operand</param>
        [MethodImpl(Inline), Op]
        public static ushort or(ushort a, ushort b, ushort c, ushort d)
            => (ushort)((uint)a | (uint)b | (uint)c | (uint)d);

        [MethodImpl(Inline), Op]
        public static ushort or(ushort a, ushort b, ushort c, ushort d, ushort e)
            => (ushort)(a | b | c | d | e);

        [MethodImpl(Inline), Op]
        public static ushort or(ushort a, ushort b, ushort c, ushort d, ushort e, ushort f)
            => (ushort)(a | b | c | d | e | f);

        [MethodImpl(Inline), Op]
        public static ushort or(ushort a, ushort b, ushort c, ushort d, ushort e, ushort f, ushort g)
            => (ushort)(a | b | c | d | e | f | g);

        [MethodImpl(Inline), Op]
        public static ushort or(ushort a, ushort b, ushort c, ushort d, ushort e, ushort f, ushort g, ushort h)
            => (ushort)(a | b | c | d | e | f | g | h);
    }
}