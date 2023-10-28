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
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> vblend<T>(Vector128<T> x, Vector128<T> y, Vector128<T> spec)
            where T : unmanaged
                => vblend_u(x,y,spec);

        /// <summary>
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector256<T> vblend<T>(Vector256<T> x, Vector256<T> y, Vector256<T> spec)
            where T : unmanaged
                => vblend_u(x,y,spec);

        /// <summary>
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector512<T> vblend<T>(Vector512<T> x, Vector512<T> y, Vector512<T> spec)
            where T : unmanaged
                => vblend_u(x,y,spec);

        /// <summary>
        /// Forms a vector z[i] = testbit(spec[i],7) ? x[i] : y[i] where i = 0,...15
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> vblend<T>(Vector128<T> x, Vector128<T> y, Vector128<byte> spec)
            where T : unmanaged
                => vblend_u(x,y,spec);

        /// <summary>
        /// Forms a vector z[i] = testbit(spec[i],7) ? x[i] : y[i] where i = 0,...31
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector256<T> vblend<T>(Vector256<T> x, Vector256<T> y, Vector256<byte> spec)
            where T : unmanaged
                => vblend_u(x, y, spec);

        /// <summary>
        /// Forms a vector z[i] = testbit(spec,i) ? x[i] : y[i] where i = 0,...15
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> vblend<T>(Vector128<T> x, Vector128<T> y, ushort spec)
            where T : unmanaged
                => vblend(x,y, BitMasks.vmask128x8u(spec));

        /// <summary>
        /// Forms a vector z[i] = testbit(spec,i) ? x[i] : y[i] where i = 0,...31
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector256<T> vblend<T>(Vector256<T> x, Vector256<T> y, uint spec)
            where T : unmanaged
                => vblend(x,y, BitMasks.vmask256x8u(spec));

        [MethodImpl(Inline)]
        static Vector256<T> vblend_u<T>(Vector256<T> x, Vector256<T> y, Vector256<byte> spec)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(vcpu.vblendv(v8u(x), v8u(y), spec));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(vcpu.vblendv(v16u(x), v16u(y), spec));
            else if(typeof(T) == typeof(uint))
                return generic<T>(vcpu.vblendv(v32u(x), v32u(y), spec));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(vcpu.vblendv(v64u(x), v64u(y), spec));
            else
                return vblend_i(x,y,spec);
        }

        [MethodImpl(Inline)]
        static Vector256<T> vblend_i<T>(Vector256<T> x, Vector256<T> y, Vector256<byte> spec)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(vcpu.vblendv(v8i(x), v8i(y), spec));
            else if(typeof(T) == typeof(short))
                return generic<T>(vcpu.vblendv(v16i(x), v16i(y), spec));
            else if(typeof(T) == typeof(int))
                return generic<T>(vcpu.vblendv(v32i(x), v32i(y), spec));
            else if(typeof(T) == typeof(long))
                return generic<T>(vcpu.vblendv(v64i(x), v64i(y), spec));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static Vector128<T> vblend_u<T>(Vector128<T> x, Vector128<T> y, Vector128<byte> spec)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(vcpu.vblendv(v8u(x), v8u(y), spec));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(vcpu.vblendv(v16u(x), v16u(y), spec));
            else if(typeof(T) == typeof(uint))
                return generic<T>(vcpu.vblendv(v32u(x), v32u(y), spec));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(vcpu.vblendv(v64u(x), v64u(y), spec));
            else
                return vblend_i(x,y,spec);
        }

        [MethodImpl(Inline)]
        static Vector128<T> vblend_i<T>(Vector128<T> x, Vector128<T> y, Vector128<byte> spec)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(vcpu.vblendv(v8i(x), v8i(y), spec));
            else if(typeof(T) == typeof(short))
                return generic<T>(vcpu.vblendv(v16i(x), v16i(y), spec));
            else if(typeof(T) == typeof(int))
                return generic<T>(vcpu.vblendv(v32i(x), v32i(y), spec));
            else if(typeof(T) == typeof(long))
                return generic<T>(vcpu.vblendv(v64i(x), v64i(y), spec));
            else
                throw no<T>();
        }


        [MethodImpl(Inline)]
        static Vector128<T> vblend_u<T>(Vector128<T> x, Vector128<T> y, Vector128<T> spec)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(vcpu.vblendv(v8u(x), v8u(y), v8u(spec)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(vcpu.vblendv(v16u(x), v16u(y), v16u(spec)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(vcpu.vblendv(v32u(x), v32u(y), v32u(spec)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(vcpu.vblendv(v64u(x), v64u(y), v64u(spec)));
            else
                return vblend_i(x,y,spec);
        }

        [MethodImpl(Inline)]
        static Vector128<T> vblend_i<T>(Vector128<T> x, Vector128<T> y, Vector128<T> spec)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(vcpu.vblendv(v8i(x), v8i(y), v8i(spec)));
            else if(typeof(T) == typeof(short))
                return generic<T>(vcpu.vblendv(v16i(x), v16i(y), v16i(spec)));
            else if(typeof(T) == typeof(int))
                return generic<T>(vcpu.vblendv(v32i(x), v32i(y), v32i(spec)));
            else if(typeof(T) == typeof(long))
                return generic<T>(vcpu.vblendv(v64i(x), v64i(y), v64i(spec)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static Vector256<T> vblend_u<T>(Vector256<T> x, Vector256<T> y, Vector256<T> spec)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(vcpu.vblendv(v8u(x), v8u(y), v8u(spec)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(vcpu.vblendv(v16u(x), v16u(y), v16u(spec)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(vcpu.vblendv(v32u(x), v32u(y), v32u(spec)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(vcpu.vblendv(v64u(x), v64u(y), v64u(spec)));
            else
                return vblend_i(x,y,spec);
        }

        [MethodImpl(Inline)]
        static Vector256<T> vblend_i<T>(Vector256<T> x, Vector256<T> y, Vector256<T> spec)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(vcpu.vblendv(v8i(x), v8i(y), v8i(spec)));
            else if(typeof(T) == typeof(short))
                return generic<T>(vcpu.vblendv(v16i(x), v16i(y), v16i(spec)));
            else if(typeof(T) == typeof(int))
                return generic<T>(vcpu.vblendv(v32i(x), v32i(y), v32i(spec)));
            else if(typeof(T) == typeof(long))
                return generic<T>(vcpu.vblendv(v64i(x), v64i(y), v64i(spec)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static Vector512<T> vblend_u<T>(Vector512<T> x, Vector512<T> y, Vector512<T> spec)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(vcpu.vblendv(v8u(x), v8u(y), v8u(spec)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(vcpu.vblendv(v16u(x), v16u(y), v16u(spec)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(vcpu.vblendv(v32u(x), v32u(y), v32u(spec)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(vcpu.vblendv(v64u(x), v64u(y), v64u(spec)));
            else
                return vblend_i(x,y,spec);
        }

        [MethodImpl(Inline)]
        static Vector512<T> vblend_i<T>(Vector512<T> x, Vector512<T> y, Vector512<T> spec)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(vcpu.vblendv(v8i(x), v8i(y), v8i(spec)));
            else if(typeof(T) == typeof(short))
                return generic<T>(vcpu.vblendv(v16i(x), v16i(y), v16i(spec)));
            else if(typeof(T) == typeof(int))
                return generic<T>(vcpu.vblendv(v32i(x), v32i(y), v32i(spec)));
            else if(typeof(T) == typeof(long))
                return generic<T>(vcpu.vblendv(v64i(x), v64i(y), v64i(spec)));
            else
                throw no<T>();
        }

    }
}