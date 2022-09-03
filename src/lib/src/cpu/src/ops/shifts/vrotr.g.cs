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
        /// Rotates each component in the source vector rightwards by a constant offset
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">The magnitude of the rotation</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<T> vrotr<T>(Vector128<T> x, [Imm] byte count)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(cpu.vrotr(v8u(x), count));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.vrotr(v16u(x), count));
            else if(typeof(T) == typeof(uint))
                return generic<T>(cpu.vrotr(v32u(x), count));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(cpu.vrotr(v64u(x), count));
            else
                throw no<T>();
        }

        /// <summary>
        /// Rotates each component in the source vector rightwards by a constant offset
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">The magnitude of the rotation</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> vrotr<T>(Vector256<T> x, [Imm] byte count)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(cpu.vrotr(v8u(x), count));
            if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.vrotr(v16u(x), count));
            if(typeof(T) == typeof(uint))
                return generic<T>(cpu.vrotr(v32u(x), count));
            if(typeof(T) == typeof(ulong))
                return generic<T>(cpu.vrotr(v64u(x), count));
            else
                throw no<T>();
        }
    }
}