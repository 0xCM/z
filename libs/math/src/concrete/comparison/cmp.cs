//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    partial class math
    {
        /// <summary>
        /// Compares two operands via their <see cref='IComparable'> implementations
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Op]
        public static int cmp(sbyte a, sbyte b)
            => a.CompareTo(b);

        /// <summary>
        /// Compares two operands via their <see cref='IComparable'> implementations
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Op]
        public static int cmp(byte a, byte b)
            => a.CompareTo(b);

        /// <summary>
        /// Compares two operands via their <see cref='IComparable'> implementations
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Op]
        public static int cmp(short a, short b)
            => a.CompareTo(b);

        /// <summary>
        /// Compares two operands via their <see cref='IComparable'> implementations
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Op]
        public static int cmp(ushort a, ushort b)
            => a.CompareTo(b);

        /// <summary>
        /// Compares two operands via their <see cref='IComparable'> implementations
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Op]
        public static int cmp(int a, int b)
            => a.CompareTo(b);

        /// <summary>
        /// Compares two operands via their <see cref='IComparable'> implementations
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Op]
        public static int cmp(uint a, uint b)
            => a.CompareTo(b);

        /// <summary>
        /// Compares two operands via their <see cref='IComparable'> implementations
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Op]
        public static int cmp(long a, long b)
            => a.CompareTo(b);

        /// <summary>
        /// Compares two operands via their <see cref='IComparable'> implementations
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Op]
        public static int cmp(ulong a, ulong b)
            => a.CompareTo(b);

        /// <summary>
        /// Compares two operands via their <see cref='IComparable'> implementations
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Op]
        public static int cmp(float a, float b)
            => a.CompareTo(b);

        /// <summary>
        /// Compares two operands via their <see cref='IComparable'> implementations
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Op]
        public static int cmp(double a, double b)
            => a.CompareTo(b);
    }
}