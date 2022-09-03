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
        public static sbyte or(sbyte a, sbyte b)
            => (sbyte)(a | b);

        /// <summary>
        /// Computes the bitwise disjunction of the source operands
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        /// <param name="c">The third operand</param>
        [MethodImpl(Inline), Op]
        public static sbyte or(sbyte a, sbyte b, sbyte c)
            => (sbyte)((int)a | (int)b | (int)c);

        /// <summary>
        /// Computes the bitwise disjunction of the source operands
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        /// <param name="c">The third operand</param>
        /// <param name="d">The fourth operand</param>
        [MethodImpl(Inline), Op]
        public static sbyte or(sbyte a, sbyte b, sbyte c, sbyte d)
            => (sbyte)((int)a | (int)b | (int)c | (int)d);

        /// <summary>
        /// Computes the bitwise or c := a | b for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Or]
        public static byte or(byte a, byte b)
            => (byte)(a | b);

        [MethodImpl(Inline), Op]
        public static byte or(byte a, byte b, byte c)
            => (byte)((uint)a | (uint)b | (uint)c);

        [MethodImpl(Inline), Op]
        public static byte or(byte a, byte b, byte c, byte d)
            => (byte)((uint)a | (uint)b | (uint)c | (uint)d);

        [MethodImpl(Inline), Op]
        public static byte or(byte a, byte b, byte c, byte d, byte e)
            => (byte)(a | b | c | d | e);

        [MethodImpl(Inline), Op]
        public static byte or(byte a, byte b, byte c, byte d, byte e, byte f)
            => (byte)(a | b | c | d | e | f);

        [MethodImpl(Inline), Op]
        public static byte or(byte a, byte b, byte c, byte d, byte e, byte f, byte g)
            => (byte)(a | b | c | d | e | f | g);

        [MethodImpl(Inline), Op]
        public static byte or(byte a, byte b, byte c, byte d, byte e, byte f, byte g, byte h)
            => (byte)(a | b | c | d | e | f | g | h);
   }
}