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
        /// Computes x^(x >> offset)
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The amount by which to shift each component</param>
        [MethodImpl(Inline), XorSr, Closures(Closure)]
        public static Vector128<T> vxorsr<T>(Vector128<T> x, [Imm] byte count)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(cpu.vxorsr(v8u(x), count));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.vxorsr(v16u(x), count));
            else if(typeof(T) == typeof(uint))
                return generic<T>(cpu.vxorsr(v32u(x), count));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(cpu.vxorsr(v64u(x), count));
            else
                throw no<T>();
        }

        /// <summary>
        /// Computes x^(x >> offset)
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The amount by which to shift each component</param>
        [MethodImpl(Inline), XorSr, Closures(Closure)]
        public static Vector256<T> vxorsr<T>(Vector256<T> x, [Imm] byte count)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(cpu.vxorsr(v8u(x), count));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.vxorsr(v16u(x), count));
            else if(typeof(T) == typeof(uint))
                return generic<T>(cpu.vxorsr(v32u(x), count));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(cpu.vxorsr(v64u(x), count));
            else
                throw no<T>();
        }
    }
}