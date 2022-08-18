//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class math
    {
        /// <summary>
        /// Saturate 16i -> 8u
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static byte sat8u(short src)
            => src < 0 ? z8 : (byte)(src < 0xFF ? src : 0xFF);

        /// <summary>
        /// Saturate 32i -> 16i
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static sbyte sat8i(short src)
            => src > sbyte.MaxValue ? sbyte.MaxValue : src < sbyte.MinValue ? sbyte.MinValue : (sbyte)src;

        /// <summary>
        /// Saturate 32i -> 16u
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static ushort sat16u(int src)
            => src > ushort.MaxValue ? ushort.MaxValue : (ushort)src;

        /// <summary>
        /// Saturate 32i -> 16i
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static short sat16i(int src)
            => src > short.MaxValue ? short.MaxValue : src < short.MinValue ? short.MinValue : (short)src;
    }
}