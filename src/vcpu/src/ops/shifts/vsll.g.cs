//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static vcpu;

    partial class vgcpu
    {
        /// <summary>
        /// Shifts each source vector component leftwards by a specified number of bits
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The shift offset</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Sll, Closures(Integers)]
        public static Vector128<T> vsll<T>(Vector128<T> x, [Imm] byte count)
            where T : unmanaged
                => vsll_u(x,count);

        /// <summary>
        /// Shifts each source vector component leftwards by a specified number of bits
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The shift offset</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Sll, Closures(Integers)]
        public static Vector256<T> vsll<T>(Vector256<T> x, [Imm] byte count)
            where T : unmanaged
            => vsll_u(x,count);

        /// <summary>
        /// A register-based shift (as opposed to immediate-based) that shifts each source vector component rightwards
        /// by an amount specified in the first component of the offset vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="offset">The offset vector</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Sll, Closures(Integers)]
        public static Vector128<T> vsll<T>(Vector128<T> x, Vector128<T> offset)
            where T : unmanaged
                => vsll_u(x,offset);

        /// <summary>
        /// A register-based shift (as opposed to immediate-based) that shifts each source vector component rightwards
        /// by an amount specified in the first component of the offset vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="offset">The offset vector</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Sll, Closures(Integers)]
        public static Vector256<T> vsll<T>(Vector256<T> x, Vector256<T> offset)
            where T : unmanaged
                => vsll_u(x,offset);

        /// <summary>
        /// Shifts each source vector component rightwards by a specified offset via the register-based shift-right instruction
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="offset">The offset amount</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Sll, Closures(Integers)]
        public static Vector128<T> vsll<T>(Vector128<T> x, T offset)
            where T : unmanaged
                => vsll_u(x,offset);

        /// <summary>
        /// Shifts each source vector component rightwards by a specified offset via the register-based shift-right instruction
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="offset">The offset amount</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Sll, Closures(Integers)]
        public static Vector256<T> vsll<T>(Vector256<T> x, T offset)
            where T : unmanaged
                => vsll_u(x,offset);

        [MethodImpl(Inline)]
        static Vector128<T> vsll_u<T>(Vector128<T> x, byte count)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(vcpu.vsll(v8u(x), count));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(vcpu.vsll(v16u(x), count));
            else if(typeof(T) == typeof(uint))
                return generic<T>(vcpu.vsll(v32u(x), count));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(vcpu.vsll(v64u(x), count));
            else
                return vsll_i(x,count);
        }

        [MethodImpl(Inline)]
        static Vector128<T> vsll_i<T>(Vector128<T> x, byte count)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(vcpu.vsll(v8i(x), count));
            else if(typeof(T) == typeof(short))
                return generic<T>(vcpu.vsll(v16i(x), count));
            else if(typeof(T) == typeof(int))
                return generic<T>(vcpu.vsll(v32i(x), count));
            else if(typeof(T) == typeof(long))
                return generic<T>(vcpu.vsll(v64i(x), count));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static Vector256<T> vsll_u<T>(Vector256<T> x, byte count)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(vcpu.vsll(v8u(x), count));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(vcpu.vsll(v16u(x), count));
            else if(typeof(T) == typeof(uint))
                return generic<T>(vcpu.vsll(v32u(x), count));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(vcpu.vsll(v64u(x), count));
            else
                return vsll_i(x,count);
        }

        [MethodImpl(Inline)]
        static Vector256<T> vsll_i<T>(Vector256<T> x, byte count)
            where T : unmanaged
        {
             if(typeof(T) == typeof(sbyte))
                return generic<T>(vcpu.vsll(v8i(x), count));
            else if(typeof(T) == typeof(short))
                return generic<T>(vcpu.vsll(v16i(x), count));
            else if(typeof(T) == typeof(int))
                return generic<T>(vcpu.vsll(v32i(x), count));
            else if(typeof(T) == typeof(long))
                return generic<T>(vcpu.vsll(v64i(x), count));
            else
                throw no<T>();
       }

        [MethodImpl(Inline)]
        static Vector128<T> vsll_u<T>(Vector128<T> x, Vector128<T> offset)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(vcpu.vsll(v8u(x), v8u(offset)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(vcpu.vsll(v16u(x), v16u(offset)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(vcpu.vsll(v32u(x), v32u(offset)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(vcpu.vsll(v64u(x), v64u(offset)));
            else
                return vsll_i(x,offset);
        }

        [MethodImpl(Inline)]
        static Vector128<T> vsll_i<T>(Vector128<T> x, Vector128<T> offset)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(vcpu.vsll(v8i(x), v8i(offset)));
            else if(typeof(T) == typeof(short))
                return generic<T>(vcpu.vsll(v16i(x), v16i(offset)));
            else if(typeof(T) == typeof(int))
                return generic<T>(vcpu.vsll(v32i(x), v32i(offset)));
            else if(typeof(T) == typeof(long))
                return generic<T>(vcpu.vsll(v64i(x), v64i(offset)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static Vector128<T> vsll_u<T>(Vector128<T> x, T offset)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(vcpu.vsllr(v8u(x), uint8(offset)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(vcpu.vsllr(v16u(x), uint16(offset)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(vcpu.vsllr(v32u(x), uint32(offset)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(vcpu.vsllr(v64u(x), uint64(offset)));
            else
                return vsll_i(x,offset);
        }

        [MethodImpl(Inline)]
        static Vector128<T> vsll_i<T>(Vector128<T> x, T offset)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(vcpu.vsllr(v8i(x), int8(offset)));
            else if(typeof(T) == typeof(short))
                return generic<T>(vcpu.vsllr(v16i(x), int16(offset)));
            else if(typeof(T) == typeof(int))
                return generic<T>(vcpu.vsllr(v32i(x), int32(offset)));
            else if(typeof(T) == typeof(long))
                return generic<T>(vcpu.vsllr(v64i(x), int64(offset)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static Vector256<T> vsll_u<T>(Vector256<T> x, T offset)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(vcpu.vsllr(v8u(x), uint8(offset)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(vcpu.vsllr(v16u(x), uint16(offset)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(vcpu.vsllr(v32u(x), uint32(offset)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(vcpu.vsllr(v64u(x), uint64(offset)));
            else
                return vsll_i(x,offset);
        }

        [MethodImpl(Inline)]
        static Vector256<T> vsll_i<T>(Vector256<T> x, T offset)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(vcpu.vsllr(v8i(x), int8(offset)));
            else if(typeof(T) == typeof(short))
                return generic<T>(vcpu.vsllr(v16i(x), int16(offset)));
            else if(typeof(T) == typeof(int))
                return generic<T>(vcpu.vsllr(v32i(x), int32(offset)));
            else if(typeof(T) == typeof(long))
                return generic<T>(vcpu.vsllr(v64i(x), int64(offset)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static Vector256<T> vsll_u<T>(Vector256<T> x, Vector256<T> offset)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(vcpu.vsll(v8u(x), v8u(vgcpu.vlo(offset))));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(vcpu.vsll(v16u(x), v16u(vgcpu.vlo(offset))));
            else if(typeof(T) == typeof(uint))
                return generic<T>(vcpu.vsll(v32u(x), v32u(vgcpu.vlo(offset))));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(vcpu.vsll(v64u(x), v64u(vgcpu.vlo(offset))));
            else
                return vsll_i(x,offset);
        }

        [MethodImpl(Inline)]
        static Vector256<T> vsll_i<T>(Vector256<T> x, Vector256<T> offset)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(vcpu.vsll(v8i(x), v8i(vgcpu.vlo(offset))));
            else if(typeof(T) == typeof(short))
                return generic<T>(vcpu.vsll(v16i(x), v16i(vgcpu.vlo(offset))));
            else if(typeof(T) == typeof(int))
                return generic<T>(vcpu.vsll(v32i(x), v32i(vgcpu.vlo(offset))));
            else if(typeof(T) == typeof(long))
                return generic<T>(vcpu.vsll(v64i(x), v64i(vgcpu.vlo(offset))));
            else
                throw no<T>();
        }
    }
}