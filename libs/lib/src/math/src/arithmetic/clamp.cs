//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class math
    {
        /// <summary>
        /// Clamps the source value to an inclusive maximum
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="max">The maximum value</param>
        [MethodImpl(Inline), Clamp]
        public static sbyte clamp(sbyte src, sbyte max)
            => src > max ? max : src;

        /// <summary>
        /// Clamps the source value to an inclusive maximum
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="max">The maximum value</param>
        [MethodImpl(Inline), Clamp]
        public static byte clamp(byte src, byte max)
            => src > max ? max : src;

        /// <summary>
        /// Clamps the source value to an inclusive maximum
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="max">The maximum value</param>
        [MethodImpl(Inline), Clamp]
        public static short clamp(short src, short max)
            => src > max ? max : src;

        /// <summary>
        /// Clamps the source value to an inclusive maximum
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="max">The maximum value</param>
        [MethodImpl(Inline), Clamp]
        public static ushort clamp(ushort src, ushort max)
            => src > max ? max : src;

        /// <summary>
        /// Clamps the source value to an inclusive maximum
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="max">The maximum value</param>
        [MethodImpl(Inline), Clamp]
        public static int clamp(int src, int max)
            => src > max ? max : src;

        /// <summary>
        /// Clamps the source value to an inclusive maximum
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="max">The maximum value</param>
        [MethodImpl(Inline), Clamp]
        public static uint clamp(uint src, uint max)
            => src > max ? max : src;

        /// <summary>
        /// Clamps the source value to an inclusive maximum
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="max">The maximum value</param>
        [MethodImpl(Inline), Clamp]
        public static long clamp(long src, long max)
            => src > max ? max : src;

        /// <summary>
        /// Clamps the source value to an inclusive maximum
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="max">The maximum value</param>
        [MethodImpl(Inline), Clamp]
        public static ulong clamp(ulong src, ulong max)
            => src > max ? max : src;
    }
}