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
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> vgather<T>(in T src, Vector128<T> vidx)
            where T : unmanaged
                => vgather_u(n128,src,vidx);

        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector256<T> vgather<T>(in T src, Vector256<T> vidx)
            where T : unmanaged
                => vgather_u(n256,src,vidx);

        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> vgather<T>(ReadOnlySpan<T> src, Vector128<T> vidx)
            where T : unmanaged
                => vgather_u(n128, first(src),vidx);

        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector256<T> vgather<T>(ReadOnlySpan<T> src, Vector256<T> vidx)
            where T : unmanaged
                => vgather_u(n256, first(src), vidx);

        [MethodImpl(Inline)]
        static Vector128<T> vgather_u<T>(N128 w, in T src, Vector128<T> vidx)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(cpu.vgather(w, u8(src), v8u(vidx)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.vgather(w, u16(src), v16u(vidx)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(cpu.vgather(w, u32(src), v32u(vidx)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(cpu.vgather(w, u64(src), v64u(vidx)));
            else
                return vgather_i(w,src,vidx);
        }

        [MethodImpl(Inline)]
        static Vector128<T> vgather_i<T>(N128 w, in T src, Vector128<T> vidx)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(cpu.vgather(w, i8(src), v8i(vidx)));
            else if(typeof(T) == typeof(short))
                return generic<T>(cpu.vgather(w, i16(src), v16i(vidx)));
            else if(typeof(T) == typeof(int))
                return generic<T>(cpu.vgather(w, i32(src), v32i(vidx)));
            else if(typeof(T) == typeof(long))
                return generic<T>(cpu.vgather(w, i64(src), v64i(vidx)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static Vector256<T> vgather_u<T>(N256 w, in T src, Vector256<T> vidx)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(cpu.vgather(w, u8(src), v8u(vidx)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.vgather(w, u16(src), v16u(vidx)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(cpu.vgather(w, u32(src), v32u(vidx)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(cpu.vgather(w, u64(src), v64u(vidx)));
            else
                return vgather_i(w,src,vidx);
        }

        [MethodImpl(Inline)]
        static Vector256<T> vgather_i<T>(N256 w, in T src, Vector256<T> vidx)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(cpu.vgather(w, i8(src), v8i(vidx)));
            else if(typeof(T) == typeof(short))
                return generic<T>(cpu.vgather(w, i16(src), v16i(vidx)));
            else if(typeof(T) == typeof(int))
                return generic<T>(cpu.vgather(w, i32(src), v32i(vidx)));
            else if(typeof(T) == typeof(long))
                return generic<T>(cpu.vgather(w, i64(src), v64i(vidx)));
            else
                throw no<T>();
        }
    }
}