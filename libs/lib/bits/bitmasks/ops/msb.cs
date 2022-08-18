//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Numeric;
    using static BitMaskLiterals;

    partial class BitMasks
    {
        [MethodImpl(Inline), Op]
        public static byte msb8f(byte density)
            => (byte)(byte.MaxValue << (8 - density));

        /// <summary>
        /// [10000000 00000000]
        /// The greatest bit of each 16-bit segment over 64 bits of data is enabled
        /// </summary>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        [MethodImpl(Inline), Op]
        public static ulong msb(N64 w, N16 f, N1 d)
            => Msb64x16x1;

        /// <summary>
        /// [10000000 00000000 00000000 0000000]
        /// The greatest bit of each 32-bit segment over 64 bits of data is enabled
        /// </summary>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op]
        public static ulong msb64(N64 w, N32 f, N1 d)
            => Msb64x32x1;

        /// <summary>
        /// [1000...0000]
        /// The greatest bit, relative to the data type, is enabled
        /// </summary>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <param name="t">A mask data type representative</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T msb<T>(N1 f, N1 d, T t = default)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return force<byte,T>(Msb8x8x1);
            else if(typeof(T) == typeof(ushort))
                return force<ushort,T>(Msb16x16x1);
            else if(typeof(T) == typeof(uint))
                return force<uint,T>(Msb32x32x1);
            else if(typeof(T) == typeof(ulong))
                return force<ulong,T>(Msb64x64x1);
            else
                throw no<T>();
        }

        /// <summary>
        /// [10]
        /// The greatest bit of each 2-bit segment is enabled
        /// </summary>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T msb<T>(N2 f, N1 d, T t = default)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return force<byte,T>(Msb8x2x1);
            else if(typeof(T) == typeof(ushort))
                return force<ushort,T>(Msb16x2x1);
            else if(typeof(T) == typeof(uint))
                return force<uint,T>(Msb32x2x1);
            else if(typeof(T) == typeof(ulong))
                return force<ulong,T>(Msb64x2x1);
            else
                throw no<T>();
        }

        /// <summary>
        /// [1000]
        /// The greatest bit of each 4-bit segment is enabled
        /// </summary>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T msb<T>(N4 f, N1 d, T t = default)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return force<byte,T>(Msb8x4x1);
            else if(typeof(T) == typeof(ushort))
                return force<ushort,T>(Msb16x4x1);
            else if(typeof(T) == typeof(uint))
                return force<uint,T>(Msb32x4x1);
            else if(typeof(T) == typeof(ulong))
                return force<ulong,T>(Msb64x4x1);
            else
                throw no<T>();
        }

        /// <summary>
        /// [10000000]
        /// The greatest bit of each 8-bit segment is enabled
        /// </summary>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T msb<T>(N8 f, N1 d, T t = default)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return force<byte,T>(Msb8x8x1);
            else if(typeof(T) == typeof(ushort))
                return force<ushort,T>(Msb16x8x1);
            else if(typeof(T) == typeof(uint))
                return force<uint,T>(Msb32x8x1);
            else if(typeof(T) == typeof(ulong))
                return force<ulong,T>(Msb64x8x1);
            else
                throw no<T>();
        }

        /// <summary>
        /// [10000000 00000000]
        /// The greatest bit of each 16-bit segment is enabled
        /// </summary>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T msb<T>(N16 f, N1 d, T t = default)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return default;
            else if(typeof(T) == typeof(ushort))
                return force<ushort,T>(Msb16x16x1);
            else if(typeof(T) == typeof(uint))
                return force<uint,T>(Msb32x16x1);
            else if(typeof(T) == typeof(ulong))
                return force<ulong,T>(Msb64x16x1);
            else
                throw no<T>();
        }

        /// <summary>
        /// [11000000]
        /// The greatest 2 bits of each 8-bit segment are enabled
        /// </summary>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T msb<T>(N8 f, N2 d, T t = default)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return force<byte,T>(Msb8x8x2);
            else if(typeof(T) == typeof(ushort))
                return force<ushort,T>(Msb16x8x2);
            else if(typeof(T) == typeof(uint))
                return force<uint,T>(Msb32x8x2);
            else if(typeof(T) == typeof(ulong))
                return force<ulong,T>(Msb64x8x2);
            else
                throw no<T>();
        }

        /// <summary>
        /// [11100000]
        /// The greatest 3 bits of each 8-bit segment are enabled
        /// </summary>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T msb<T>(N8 f, N3 d, T t = default)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return force<byte,T>(Msb8x8x3);
            else if(typeof(T) == typeof(ushort))
                return force<ushort,T>(Msb16x8x3);
            else if(typeof(T) == typeof(uint))
                return force<uint,T>(Msb32x8x3);
            else if(typeof(T) == typeof(ulong))
                return force<ulong,T>(Msb64x8x3);
            else
                throw no<T>();
        }

        /// <summary>
        /// [11110000]
        /// The greatest 4 bits of each 8-bit segment are enabled
        /// </summary>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T msb<T>(N8 f, N4 d, T t = default)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return force<byte,T>(Msb8x8x4);
            else if(typeof(T) == typeof(ushort))
                return force<ushort,T>(Msb16x8x4);
            else if(typeof(T) == typeof(uint))
                return force<uint,T>(Msb32x8x4);
            else if(typeof(T) == typeof(ulong))
                return force<ulong,T>(Msb64x8x4);
            else
                throw no<T>();
        }

        /// <summary>
        /// [11111000]
        /// The greatest 5 bits of each 8-bit segment are enabled
        /// </summary>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T msb<T>(N8 f, N5 d, T t = default)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return force<byte,T>(Msb8x8x5);
            else if(typeof(T) == typeof(ushort))
                return force<ushort,T>(Msb16x8x5);
            else if(typeof(T) == typeof(uint))
                return force<uint,T>(Msb32x8x5);
            else if(typeof(T) == typeof(ulong))
                return force<ulong,T>(Msb64x8x5);
            else
                throw no<T>();
        }

        /// <summary>
        /// [11111100]
        /// The greatest 6 bits of each 8-bit segment are enabled
        /// </summary>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T msb<T>(N8 f, N6 d, T t = default)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return force<byte,T>(Msb8x8x6);
            else if(typeof(T) == typeof(ushort))
                return force<ushort,T>(Msb16x8x6);
            else if(typeof(T) == typeof(uint))
                return force<uint,T>(Msb32x8x6);
            else if(typeof(T) == typeof(ulong))
                return force<ulong,T>(Msb64x8x6);
            else
                throw no<T>();
        }

        /// <summary>
        /// [11111110]
        /// The greatest 7 bits of each 8-bit segment are enabled
        /// </summary>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <param name="t">A mask type representative</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T msb<T>(N8 f, N7 d, T t = default)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return force<byte,T>(Msb8x8x7);
            else if(typeof(T) == typeof(ushort))
                return force<ushort,T>(Msb16x8x7);
            else if(typeof(T) == typeof(uint))
                return force<uint,T>(Msb32x8x7);
            else if(typeof(T) == typeof(ulong))
                return force<ulong,T>(Msb64x8x7);
            else
                throw no<T>();
        }


        [MethodImpl(Inline)]
        static ulong msb_2x1_a<W>(W w, N2 f, N1 d)
            where W : unmanaged, ITypeNat
        {
            if(typeof(W) == typeof(N4))
                return Msb4x2x1;
            else if(typeof(W) == typeof(N6))
                return Msb6x2x1;
            else if(typeof(W) == typeof(N8))
                return Msb8x2x1;
            else if(typeof(W) == typeof(N10))
                return Msb10x2x1;
            else if(typeof(W) == typeof(N12))
                return Msb12x2x1;
            else if(typeof(W) == typeof(N14))
                return Msb14x2x1;
            else if(typeof(W) == typeof(N16))
                return Msb16x2x1;
            else if(typeof(W) == typeof(N18))
                return Msb18x2x1;
            else if(typeof(W) == typeof(N32))
                return Msb32x2x1;
            else if(typeof(W) == typeof(N64))
                return Msb64x2x1;
            else
                throw no<W>();
        }
    }
}