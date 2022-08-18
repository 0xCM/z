//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class math
    {
        /// <summary>
        /// math::dec:i8->i8 Decrements the source value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Dec]
        public static sbyte dec(sbyte src)
            => --src;

        /// <summary>
        /// Decrements the source value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Dec]
        public static byte dec(byte src)
            => --src;

        /// <summary>
        /// Decrements the source value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Dec]
        public static short dec(short src)
            => --src;

        /// <summary>
        /// Decrements the source value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Dec]
        public static ushort dec(ushort src)
            => --src;

        /// <summary>
        /// Decrements the source value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Dec]
        public static int dec(int src)
            => --src;

        /// <summary>
        /// Decrements the source value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Dec]
        public static uint dec(uint src)
            => --src;

        /// <summary>
        /// Decrements the source value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Dec]
        public static long dec(long src)
            => --src;

        /// <summary>
        /// Decrements the source value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Dec]
        public static ulong dec(ulong src)
            => --src;

        /// <summary>
        /// Decrements the source value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Dec]
        public static float dec(float src)
            => --src;

        /// <summary>
        /// Decrements the source value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Dec]
        public static double dec(double src)
            => --src;

        /// <summary>
        /// math::dec:ref(i8)-> ref(i8) Decrements the input value
        /// </summary>
        /// <param name="io">The input value</param>
        [MethodImpl(Inline), Dec]
        public static ref sbyte dec(ref sbyte io)
        {
            --io;
            return ref io;
        }

        /// <summary>
        /// Decrements the input value
        /// </summary>
        /// <param name="io">The input value</param>
        [MethodImpl(Inline), Dec]
        public static ref byte dec(ref byte io)
        {
            --io;
            return ref io;
        }

        /// <summary>
        /// Decrements the input value
        /// </summary>
        /// <param name="io">The input value</param>
        [MethodImpl(Inline), Dec]
        public static ref short dec(ref short io)
        {
            --io;
            return ref io;
        }

        /// <summary>
        /// Decrements the input value
        /// </summary>
        /// <param name="io">The input value</param>
        [MethodImpl(Inline), Dec]
        public static ref ushort dec(ref ushort io)
        {
            --io;
            return ref io;
        }

        /// <summary>
        /// Decrements the input value
        /// </summary>
        /// <param name="io">The input value</param>
        [MethodImpl(Inline), Dec]
        public static ref int dec(ref int io)
        {
            --io;
            return ref io;
        }

        /// <summary>
        /// Decrements the input value
        /// </summary>
        /// <param name="io">The input value</param>
        [MethodImpl(Inline), Dec]
        public static ref uint dec(ref uint io)
        {
            --io;
            return ref io;
        }

        /// <summary>
        /// Decrements the input value
        /// </summary>
        /// <param name="io">The input value</param>
        [MethodImpl(Inline), Dec]
        public static ref long dec(ref long io)
        {
            --io;
            return ref io;
        }

        /// <summary>
        /// Decrements the input value
        /// </summary>
        /// <param name="io">The input value</param>
        [MethodImpl(Inline), Dec]
        public static ref ulong dec(ref ulong io)
        {
            --io;
            return ref io;
        }

        /// <summary>
        /// Decrements the input value
        /// </summary>
        /// <param name="io">The input value</param>
        [MethodImpl(Inline), Dec]
        public static ref float dec(ref float io)
        {
            --io;
            return ref io;
        }

        /// <summary>
        /// Decrements the input value
        /// </summary>
        /// <param name="io">The input value</param>
        [MethodImpl(Inline), Dec]
        public static ref double dec(ref double io)
        {
            --io;
            return ref io;
        }
    }
}