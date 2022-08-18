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
        /// [01010101]
        /// </summary>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <param name="t">A mask type representative</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T even<T>(N2 f, N1 d, T t = default)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return force<byte,T>(Even8);
            else if(typeof(T) == typeof(ushort))
                return force<ushort,T>(Even16);
            else if(typeof(T) == typeof(uint))
                return force<uint,T>(Even32);
            else if(typeof(T) == typeof(ulong))
                return force<ulong,T>(Even64);
            else
                throw no<T>();
        }

        /// <summary>
        /// [00110011]
        /// </summary>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <param name="t">A mask type representative</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T even<T>(N2 f, N2 d, T t = default)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return force<byte,T>(Even8x2);
            else if(typeof(T) == typeof(ushort))
                return force<ushort,T>(Even16x2);
            else if(typeof(T) == typeof(uint))
                return force<uint,T>(Even32x2);
            else if(typeof(T) == typeof(ulong))
                return force<ulong,T>(Even64x2);
            else
                throw no<T>();
        }
    }
}