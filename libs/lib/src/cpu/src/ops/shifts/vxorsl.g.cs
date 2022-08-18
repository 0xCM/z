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
        /// Computes z := x^(x << offset)
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">The shift offset</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), XorSl, Closures(Closure)]
        public static Vector128<T> vxorsl<T>(Vector128<T> x, [Imm] byte count)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(cpu.vxorsl(v8u(x), count));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.vxorsl(v16u(x), count));
            else if(typeof(T) == typeof(uint))
                return generic<T>(cpu.vxorsl(v32u(x), count));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(cpu.vxorsl(v64u(x), count));
            else
                throw no<T>();
        }

        /// <summary>
        /// Computes z := x^(x << offset)
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">The shift offset</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), XorSl, Closures(UnsignedInts)]
        public static Vector256<T> vxorsl<T>(Vector256<T> x, [Imm] byte count)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(cpu.vxorsl(v8u(x), count));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.vxorsl(v16u(x), count));
            else if(typeof(T) == typeof(uint))
                return generic<T>(cpu.vxorsl(v32u(x), count));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(cpu.vxorsl(v64u(x), count));
            else
                throw no<T>();
        }
    }
}