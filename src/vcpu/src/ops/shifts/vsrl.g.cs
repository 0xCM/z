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
        [MethodImpl(Inline), Srl, Closures(Integers)]
        public static Vector128<T> vsrl<T>(Vector128<T> x, [Imm] byte count)
            where T : unmanaged
                => vsrl_u(x,count);

        [MethodImpl(Inline), Srl, Closures(Integers)]
        public static Vector256<T> vsrl<T>(Vector256<T> x, [Imm] byte count)
            where T : unmanaged
                => vsrl_u(x,count);

        /// <summary>
        /// Shifts each source vector component rightwards by a specified offset via the register-based shift-right instruction
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset amount</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Srl, Closures(Integers)]
        public static Vector128<T> vsrl<T>(Vector128<T> x, T count)
            where T : unmanaged
                => vsrl_u(x,count);

        /// <summary>
        /// Shifts each source vector component rightwards by a specified offset via the register-based shift-right instruction
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset amount</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Srl, Closures(Integers)]
        public static Vector256<T> vsrl<T>(Vector256<T> x, T count)
            where T : unmanaged
                => vsrl_u(x,count);

        /// <summary>
        /// A register-based shift (as opposed to immediate-based) that shifts each source vector component rightwards
        /// by an amount specified in the first component of the offset vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset vector</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Srl, Closures(Integers)]
        public static Vector128<T> vsrl<T>(Vector128<T> x, Vector128<T> count)
            where T : unmanaged
                => vsrl_u(x,count);

        /// <summary>
        /// A register-based shift (as opposed to immediate-based) that shifts each source vector component rightwards
        /// by an amount specified in the first component of the offset vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset vector</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Srl, Closures(Integers)]
        public static Vector256<T> vsrl<T>(Vector256<T> x, Vector256<T> count)
            where T : unmanaged
                => vsrl_u(x,count);

        [MethodImpl(Inline)]
        static Vector128<T> vsrl_u<T>(Vector128<T> x, byte count)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(vcpu.vsrl(v8u(x), count));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(vcpu.vsrl(v16u(x), count));
            else if(typeof(T) == typeof(uint))
                return generic<T>(vcpu.vsrl(v32u(x), count));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(vcpu.vsrl(v64u(x), count));
            else
                return vsrl_i(x,count);
        }

        [MethodImpl(Inline)]
        static Vector128<T> vsrl_i<T>(Vector128<T> x, byte count)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(vcpu.vsrl(v8i(x), count));
            else if(typeof(T) == typeof(short))
                return generic<T>(vcpu.vsrl(v16i(x), count));
            else if(typeof(T) == typeof(int))
                return generic<T>(vcpu.vsrl(v32i(x), count));
            else if(typeof(T) == typeof(long))
                return generic<T>(vcpu.vsrl(v64i(x), count));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static Vector256<T> vsrl_u<T>(Vector256<T> x, byte count)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(vcpu.vsrl(v8u(x), count));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(vcpu.vsrl(v16u(x), count));
            else if(typeof(T) == typeof(uint))
                return generic<T>(vcpu.vsrl(v32u(x), count));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(vcpu.vsrl(v64u(x), count));
            else
                return vsrl_i(x,count);
       }

        [MethodImpl(Inline)]
        static Vector256<T> vsrl_i<T>(Vector256<T> x, byte count)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(vcpu.vsrl(v8i(x), count));
            else if(typeof(T) == typeof(short))
                return generic<T>(vcpu.vsrl(v16i(x), count));
            else if(typeof(T) == typeof(int))
                return generic<T>(vcpu.vsrl(v32i(x), count));
            else if(typeof(T) == typeof(long))
                return generic<T>(vcpu.vsrl(v64i(x), count));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static Vector128<T> vsrl_u<T>(Vector128<T> x, Vector128<T> count)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(vcpu.vsrl(v8u(x), v8u(count)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(vcpu.vsrl(v16u(x), v16u(count)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(vcpu.vsrl(v32u(x), v32u(count)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(vcpu.vsrl(v64u(x), v64u(count)));
            else
                return vsrl_i(x,count);
        }

        [MethodImpl(Inline)]
        static Vector128<T> vsrl_i<T>(Vector128<T> x, Vector128<T> offset)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(vcpu.vsrl(v8i(x), v8i(offset)));
            else if(typeof(T) == typeof(short))
                return generic<T>(vcpu.vsrl(v16i(x), v16i(offset)));
            else if(typeof(T) == typeof(int))
                return generic<T>(vcpu.vsrl(v32i(x), v32i(offset)));
            else if(typeof(T) == typeof(long))
                return generic<T>(vcpu.vsrl(v64i(x), v64i(offset)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static Vector256<T> vsrl_u<T>(Vector256<T> x, Vector256<T> offset)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(vcpu.vsrl(v8u(x), v8u(vlo(offset))));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(vcpu.vsrl(v16u(x), v16u(vlo(offset))));
            else if(typeof(T) == typeof(uint))
                return generic<T>(vcpu.vsrl(v32u(x), v32u(vlo(offset))));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(vcpu.vsrl(v64u(x), v64u(vlo(offset))));
            else
                return vsrl_i(x,offset);
        }

        [MethodImpl(Inline)]
        static Vector256<T> vsrl_i<T>(Vector256<T> x, Vector256<T> offset)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(vcpu.vsrl(v8i(x), v8i(vlo(offset))));
            else if(typeof(T) == typeof(short))
                return generic<T>(vcpu.vsrl(v16i(x), v16i(vlo(offset))));
            else if(typeof(T) == typeof(int))
                return generic<T>(vcpu.vsrl(v32i(x), v32i(vlo(offset))));
            else if(typeof(T) == typeof(long))
                return generic<T>(vcpu.vsrl(v64i(x), v64i(vlo(offset))));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static Vector128<T> vsrl_u<T>(Vector128<T> x, T offset)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(vcpu.vsrlr(v8u(x), uint8(offset)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(vcpu.vsrlr(v16u(x), uint16(offset)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(vcpu.vsrlr(v32u(x), uint32(offset)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(vcpu.vsrlr(v64u(x), uint64(offset)));
            else
                return vsrl_i(x,offset);
        }

        [MethodImpl(Inline)]
        static Vector128<T> vsrl_i<T>(Vector128<T> x, T offset)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(vcpu.vsrlr(v8i(x), int8(offset)));
            else if(typeof(T) == typeof(short))
                return generic<T>(vcpu.vsrlr(v16i(x), int16(offset)));
            else if(typeof(T) == typeof(int))
                return generic<T>(vcpu.vsrlr(v32i(x), int32(offset)));
            else if(typeof(T) == typeof(long))
                return generic<T>(vcpu.vsrlr(v64i(x), int64(offset)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static Vector256<T> vsrl_u<T>(Vector256<T> x, T offset)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(vcpu.vsrlr(v8u(x), uint8(offset)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(vcpu.vsrlr(v16u(x), uint16(offset)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(vcpu.vsrlr(v32u(x), uint32(offset)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(vcpu.vsrlr(v64u(x), uint64(offset)));
            else
                return vsrl_i(x,offset);
        }

        [MethodImpl(Inline)]
        static Vector256<T> vsrl_i<T>(Vector256<T> x, T offset)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(vcpu.vsrlr(v8i(x), int8(offset)));
            else if(typeof(T) == typeof(short))
                return generic<T>(vcpu.vsrlr(v16i(x), int16(offset)));
            else if(typeof(T) == typeof(int))
                return generic<T>(vcpu.vsrlr(v32i(x), int32(offset)));
            else if(typeof(T) == typeof(long))
                return generic<T>(vcpu.vsrlr(v64i(x), int64(offset)));
            else
                throw no<T>();
        }
    }
}