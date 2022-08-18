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
        /// <summary>
        /// [10000001] | JSB := (msb | lsb)(f,d) where f := 8 and d := 1
        /// </summary>
        /// <param name="f">The frequency selector</param>
        /// <param name="d">The bit density</param>
        /// <param name="t">A mask type representative</param>
        /// <typeparam name="T">The mask data type</typeparam>
        /// <remarks>JSB := msb | lsb (8x1)</remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T jsb<T>(N8 f, N1 d, T t = default)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return force<byte,T>(Jsb8x8x1);
            else if(typeof(T) == typeof(ushort))
                return force<ushort,T>(Jsb16x8x1);
            else if(typeof(T) == typeof(uint))
                return force<uint,T>(Jsb32x8x1);
            else if(typeof(T) == typeof(ulong))
                return force<ulong,T>(Jsb64x8x1);
            else
                throw no<T>();
        }

        /// <summary>
        /// [11000011] | JSB := (msb | lsb)(f,d) where f := 8 and d := 2
        /// </summary>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <param name="t">A mask type representative</param>
        /// <typeparam name="T">The mask data type</typeparam>
        /// <remarks>JSB := msb | lsb (8x2)</remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T jsb<T>(N8 f, N2 d, T t = default)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return force<byte,T>(Jsb8x8x2);
            else if(typeof(T) == typeof(ushort))
                return force<ushort,T>(Jsb16x8x2);
            else if(typeof(T) == typeof(uint))
                return force<uint,T>(Jsb32x8x2);
            else if(typeof(T) == typeof(ulong))
                return force<ulong,T>(Jsb64x8x2);
            else
                throw no<T>();
        }

        /// <summary>
        /// [11100111] | JSB := (msb | lsb)(f,d) where f := 3 and d := 3
        /// </summary>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <param name="t">A mask type representative</param>
        /// <typeparam name="T">The mask data type</typeparam>
        /// <remarks>JSB := msb | lsb (8x3)</remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T jsb<T>(N8 f, N3 d, T t = default)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return force<byte,T>(Jsb8x8x3);
            else if(typeof(T) == typeof(ushort))
                return force<ushort,T>(Jsb16x8x3);
            else if(typeof(T) == typeof(uint))
                return force<uint,T>(Jsb32x8x3);
            else if(typeof(T) == typeof(ulong))
                return force<ulong,T>(Jsb64x8x3);
            else
                throw no<T>();
        }
    }
}