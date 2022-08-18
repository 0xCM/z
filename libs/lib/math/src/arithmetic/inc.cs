//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class math
    {
        /// <summary>
        /// Increments the source value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Inc]
        public static sbyte inc(sbyte src)
            => ++src;

        /// <summary>
        /// Increments the source value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Inc]
        public static byte inc(byte src)
            => ++src;

        /// <summary>
        /// Increments the source value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Inc]
        public static short inc(short src)
            => ++src;

        /// <summary>
        /// Increments the source value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Inc]
        public static ushort inc(ushort src)
            => ++src;

        /// <summary>
        /// Increments the source value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Inc]
        public static int inc(int src)
            => ++src;

        /// <summary>
        /// Increments the source value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Inc]
        public static uint inc(uint src)
            => ++src;

        /// <summary>
        /// Increments the source value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Inc]
        public static long inc(long src)
            => ++src;

        /// <summary>
        /// Increments the source value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Inc]
        public static ulong inc(ulong src)
            => ++src;

        /// <summary>
        /// Increments the operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Inc]
        public static float inc(float src)
            => ++src;

        /// <summary>
        /// Increments the operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Inc]
        public static double inc(double src)
            => ++src;

        /// <summary>
        /// Decrements the input value
        /// </summary>
        /// <param name="io">The input value</param>
        [MethodImpl(Inline), Inc]
        public static ref sbyte inc(ref sbyte io)
        {
            ++io;
            return ref io;
        }

        /// <summary>
        /// Decrements the input value
        /// </summary>
        /// <param name="io">The input value</param>
        [MethodImpl(Inline), Inc]
        public static ref byte inc(ref byte io)
        {
            ++io;
            return ref io;
        }

        /// <summary>
        /// Decrements the input value
        /// </summary>
        /// <param name="io">The input value</param>
        [MethodImpl(Inline), Inc]
        public static ref short inc(ref short io)
        {
            ++io;
            return ref io;
        }

        /// <summary>
        /// Decrements the input value
        /// </summary>
        /// <param name="io">The input value</param>
        [MethodImpl(Inline), Inc]
        public static ref ushort inc(ref ushort io)
        {
            ++io;
            return ref io;
        }

        /// <summary>
        /// Decrements the input value
        /// </summary>
        /// <param name="io">The input value</param>
        [MethodImpl(Inline), Inc]
        public static ref int inc(ref int io)
        {
            ++io;
            return ref io;
        }

        /// <summary>
        /// Decrements the input value
        /// </summary>
        /// <param name="io">The input value</param>
        [MethodImpl(Inline), Inc]
        public static ref uint inc(ref uint io)
        {
            ++io;
            return ref io;
        }

        /// <summary>
        /// Decrements the input value
        /// </summary>
        /// <param name="io">The input value</param>
        [MethodImpl(Inline), Inc]
        public static ref long inc(ref long io)
        {
            ++io;
            return ref io;
        }

        /// <summary>
        /// Decrements the input value
        /// </summary>
        /// <param name="io">The input value</param>
        [MethodImpl(Inline), Inc]
        public static ref ulong inc(ref ulong io)
        {
            ++io;
            return ref io;
        }

        /// <summary>
        /// Decrements the input value
        /// </summary>
        /// <param name="io">The input value</param>
        [MethodImpl(Inline), Inc]
        public static ref float inc(ref float io)
        {
            ++io;
            return ref io;
        }

        /// <summary>
        /// Decrements the input value
        /// </summary>
        /// <param name="io">The input value</param>
        [MethodImpl(Inline), Inc]
        public static ref double inc(ref double io)
        {
            ++io;
            return ref io;
        }
    }
}