//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;
    using static core;

    partial struct gcpu
    {
        /// <summary>
        /// Effects the reversal of the byte-level representation of each component in the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op, Closures(UInt16x32x64k)]
        public static Vector128<T> vbyteswap<T>(Vector128<T> x)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return x;
            else if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.vbyteswap(v16u(x)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(cpu.vbyteswap(v32u(x)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(cpu.vbyteswap(v64u(x)));
            else
                throw no<T>();
        }

        /// <summary>
        /// Effects the reversal of the byte-level representation of each component in the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op, Closures(UInt16x32x64k)]
        public static Vector256<T> vbyteswap<T>(Vector256<T> x)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return x;
            else if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.vbyteswap(v16u(x)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(cpu.vbyteswap(v32u(x)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(cpu.vbyteswap(v64u(x)));
            else
                throw no<T>();
        }
    }
}