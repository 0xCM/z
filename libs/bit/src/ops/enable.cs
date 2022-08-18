//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct bit
    {
        /// <summary>
        /// Enables a specified source bit
        /// </summary>
        /// <param name="src">The source value to manipulate</param>
        /// <param name="pos">The position of the bit to enable</param>
        [MethodImpl(Inline), Enable]
        public static sbyte enable(sbyte src, byte pos)
            => src |= (sbyte)(1 << pos);

        /// <summary>
        /// Enables a specified source bit
        /// </summary>
        /// <param name="src">The source value to manipulate</param>
        /// <param name="pos">The position of the bit to enable</param>
        [MethodImpl(Inline), Enable]
        public static byte enable(byte src, byte pos)
            => src |= (byte)(1 << pos);

        /// <summary>
        /// Enables a specified source bit
        /// </summary>
        /// <param name="src">The source value to manipulate</param>
        /// <param name="pos">The position of the bit to enable</param>
        [MethodImpl(Inline), Enable]
        public static short enable(short src, byte pos)
            => src |= (short)(1 << pos);

        /// <summary>
        /// Enables a specified source bit
        /// </summary>
        /// <param name="src">The source value to manipulate</param>
        /// <param name="pos">The position of the bit to enable</param>
        [MethodImpl(Inline), Enable]
        public static ushort enable(ushort src, byte pos)
            => src |= (ushort)(1 << pos);

        /// <summary>
        /// Enables a specified source bit
        /// </summary>
        /// <param name="src">The source value to manipulate</param>
        /// <param name="pos">The position of the bit to enable</param>
        [MethodImpl(Inline), Enable]
        public static int enable(int src, byte pos)
            => src |= (1 << pos);

        /// <summary>
        /// Enables a specified source bit
        /// </summary>
        /// <param name="src">The source value to manipulate</param>
        /// <param name="pos">The position of the bit to enable</param>
        [MethodImpl(Inline), Enable]
        public static uint enable(uint src, byte pos)
            => src |= (1u << pos);

        /// <summary>
        /// Enables a specified source bit
        /// </summary>
        /// <param name="src">The source value to manipulate</param>
        /// <param name="pos">The position of the bit to enable</param>
        [MethodImpl(Inline), Enable]
        public static long enable(long src, byte pos)
            => src |= (1L << pos);

        /// <summary>
        /// Enables a specified source bit
        /// </summary>
        /// <param name="src">The source value to manipulate</param>
        /// <param name="pos">The position of the bit to enable</param>
        [MethodImpl(Inline), Enable]
        public static ulong enable(ulong src, byte pos)
            => src |= (1ul << pos);

        /// <summary>
        /// Enables a specified source bit
        /// </summary>
        /// <param name="src">The source value to manipulate</param>
        /// <param name="pos">The position of the bit to enable</param>
        [MethodImpl(Inline), Enable]
        public void enable(ref sbyte src, byte pos)
            => src |= (sbyte)(1 << pos);

        /// <summary>
        /// Enables a specified source bit
        /// </summary>
        /// <param name="src">The source value to manipulate</param>
        /// <param name="pos">The position of the bit to enable</param>
        [MethodImpl(Inline), Enable]
        public static void enable(ref byte src, byte pos)
            => src |= (byte)(1 << pos);

        /// <summary>
        /// Enables a specified source bit
        /// </summary>
        /// <param name="src">The source value to manipulate</param>
        /// <param name="pos">The position of the bit to enable</param>
        [MethodImpl(Inline), Enable]
        public static void enable(ref short src, byte pos)
            => src |= (short)(1 << pos);

        /// <summary>
        /// Enables a specified source bit
        /// </summary>
        /// <param name="src">The source value to manipulate</param>
        /// <param name="pos">The position of the bit to enable</param>
        [MethodImpl(Inline), Enable]
        public static void enable(ref ushort src, byte pos)
            => src |= (ushort)(1 << pos);

        /// <summary>
        /// Enables a specified source bit
        /// </summary>
        /// <param name="src">The source value to manipulate</param>
        /// <param name="pos">The position of the bit to enable</param>
        [MethodImpl(Inline), Enable]
        public static void enable(ref int src, byte pos)
            =>  src |= (1 << pos);

        /// <summary>
        /// Enables a specified source bit
        /// </summary>
        /// <param name="src">The source value to manipulate</param>
        /// <param name="pos">The position of the bit to enable</param>
        [MethodImpl(Inline), Enable]
        public static void enable(ref uint src, byte pos)
            =>  src |= (1u << pos);

        /// <summary>
        /// Enables a specified source bit
        /// </summary>
        /// <param name="src">The source value to manipulate</param>
        /// <param name="pos">The position of the bit to enable</param>
        [MethodImpl(Inline), Enable]
        public static void enable(ref long src, byte pos)
            =>  src |= (1L << pos);

        /// <summary>
        /// Enables a specified source bit
        /// </summary>
        /// <param name="src">The source value to manipulate</param>
        /// <param name="pos">The position of the bit to enable</param>
        [MethodImpl(Inline), Enable]
        public static void enable(ref ulong src, byte pos)
            =>  src |= (1ul << pos);
    }
}