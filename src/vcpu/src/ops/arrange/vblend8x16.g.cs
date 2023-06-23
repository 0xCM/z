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
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> vblend8x16<T>(Vector128<T> x, Vector128<T> y, [Imm] byte spec)
            where T : unmanaged
                => vblend8x16_u(x, y, spec);

        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector256<T> vblend8x16<T>(Vector256<T> x, Vector256<T> y, [Imm] byte spec)
            where T : unmanaged
                => vblend8x16_u(x, y, spec);

        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> vblend8x16<T>(Vector128<T> x, Vector128<T> y, [Imm] Blend8x16 spec)
            where T : unmanaged
                => vblend8x16_u(x, y, (byte)spec);

        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector256<T> vblend8x16<T>(Vector256<T> x, Vector256<T> y, [Imm] Blend8x16 spec)
            where T : unmanaged
                => vblend8x16_u(x, y, (byte)spec);

        [MethodImpl(Inline)]
        static Vector128<T> vblend8x16_u<T>(Vector128<T> x, Vector128<T> y, byte spec)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(v8u(vcpu.vblend8x16(v16u(x), v16u(y), spec)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(vcpu.vblend8x16(v16u(x), v16u(y), spec));
            else if(typeof(T) == typeof(uint))
                return generic<T>(v32u(vcpu.vblend8x16(v16u(x), v16u(y), spec)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(v64u(vcpu.vblend8x16(v16u(x), v16u(y), spec)));
            else
                return vblend8x16_i(x,y,spec);
        }

        [MethodImpl(Inline)]
        static Vector128<T> vblend8x16_i<T>(Vector128<T> x, Vector128<T> y, byte spec)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(v8i(vcpu.vblend8x16(v16u(x), v16u(y), spec)));
            else if(typeof(T) == typeof(short))
                return generic<T>(vcpu.vblend8x16(v16i(x), v16i(y), spec));
            else if(typeof(T) == typeof(int))
                return generic<T>(v32i(vcpu.vblend8x16(v16u(x), v16u(y), spec)));
            else if(typeof(T) == typeof(long))
                return generic<T>(v64i(vcpu.vblend8x16(v16u(x), v16u(y), spec)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static Vector256<T> vblend8x16_u<T>(Vector256<T> x, Vector256<T> y, byte spec)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(v8u(vcpu.vblend8x16(v16u(x), v16u(y), spec)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(vcpu.vblend8x16(v16u(x), v16u(y), spec));
            else if(typeof(T) == typeof(uint))
                return generic<T>(v32u(vcpu.vblend8x16(v16u(x), v16u(y), spec)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(v64u(vcpu.vblend8x16(v16u(x), v16u(y), spec)));
            else
                return vblend8x16_i(x,y,spec);
        }

        [MethodImpl(Inline)]
        static Vector256<T> vblend8x16_i<T>(Vector256<T> x, Vector256<T> y, byte spec)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(v8i(vcpu.vblend8x16(v16u(x), v16u(y), spec)));
            else if(typeof(T) == typeof(short))
                return generic<T>(vcpu.vblend8x16(v16i(x), v16i(y), spec));
            else if(typeof(T) == typeof(int))
                return generic<T>(v32i(vcpu.vblend8x16(v16u(x), v16u(y), spec)));
            else if(typeof(T) == typeof(long))
                return generic<T>(v64i(vcpu.vblend8x16(v16u(x), v16u(y), spec)));
            else
                throw no<T>();
        }
    }
}