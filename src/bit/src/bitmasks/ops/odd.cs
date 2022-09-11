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
        /// [10101010]
        /// </summary>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <param name="t">A mask type representative</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T odd<T>(N2 f = default, N1 d = default)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return force<byte,T>(Odd8);
            else if(typeof(T) == typeof(ushort))
                return force<ushort,T>(Odd16);
            else if(typeof(T) == typeof(uint))
                return force<uint,T>(Odd32);
            else if(typeof(T) == typeof(ulong))
                return force<ulong,T>(Odd64);
            else
                throw no<T>();
        }

        /// <summary>
        /// [11001100]
        /// </summary>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <param name="t">A mask type representative</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T odd<T>(N2 f, N2 d)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return force<byte,T>(Odd8x2);
            else if(typeof(T) == typeof(ushort))
                return force<ushort,T>(Odd16x2);
            else if(typeof(T) == typeof(uint))
                return force<uint,T>(Odd32x2);
            else if(typeof(T) == typeof(ulong))
                return force<ulong,T>(Odd64x2);
            else
                throw no<T>();
        }
    }
}