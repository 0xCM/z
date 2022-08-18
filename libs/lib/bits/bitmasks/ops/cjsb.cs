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
        /// [10011001]
        /// </summary>
        /// <param name="f">The repetition frequency</param>
        /// <param name="cd">The central bit density</param>
        /// <param name="jsbd">The jsb bit density</param>
        /// <param name="t">The mask type representative</param>
        /// <typeparam name="T">The mask data type</typeparam>
        /// <remarks>CJSB := jsb | csb (8x2x1)</remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T cjsb<T>(N8 f, N2 cd, N1 jsbd, T t = default)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return force<byte,T>(CJsb8x8x2x1);
            else if(typeof(T) == typeof(ushort))
                return force<ushort,T>(CJsb16x8x2x1);
            else if(typeof(T) == typeof(uint))
                return force<uint,T>(CJsb32x8x2x1);
            else if(typeof(T) == typeof(ulong))
                return force<ulong,T>(CJsb64x8x2x1);
            else
                throw no<T>();
        }

        /// <summary>
        /// [11011011]
        /// </summary>
        /// <param name="f">The repetition frequency</param>
        /// <param name="cd">The central bit density</param>
        /// <param name="jsbd">The jsb bit density</param>
        /// <param name="t">The mask type representative</param>
        /// <typeparam name="T">The mask data type</typeparam>
        /// <remarks>CJSB := jsb | csb (8x2x2)</remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T cjsb<T>(N8 f, N2 cd, N2 jsbd, T t = default)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return force<byte,T>(CJsb8x8x2x2);
            else if(typeof(T) == typeof(ushort))
                return force<ushort,T>(CJsb16x8x2x2);
            else if(typeof(T) == typeof(uint))
                return force<uint,T>(CJsb32x8x2x2);
            else if(typeof(T) == typeof(ulong))
                return force<ulong,T>(CJsb64x8x2x2);
            else
                throw no<T>();
        }

        /// <summary>
        /// [10111101]
        /// </summary>
        /// <param name="f">The frequency selector</param>
        /// <param name="cd">The central bit density</param>
        /// <param name="t">The mask type representative</param>
        /// <typeparam name="T">The mask data type</typeparam>
        /// <remarks>CJSB := jsb | csb (8x4x1)</remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T cjsb<T>(N8 f, N4 cd, N1 jsbd, T t = default)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return force<byte,T>(CJsb8x8x4x1);
            else if(typeof(T) == typeof(ushort))
                return force<ushort,T>(CJsb16x8x4x1);
            else if(typeof(T) == typeof(uint))
                return force<uint,T>(CJsb32x8x4x1);
            else if(typeof(T) == typeof(ulong))
                return force<ulong,T>(CJsb64x8x4x1);
            else
                throw no<T>();
        }
    }
}