//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct gcpu
    {
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static void vmovnt<T>(Vector128<T> src, ref T dst)
            where T : unmanaged
                => vmovnt_u(src, ref dst);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static void vmovnt<T>(Vector256<T> src, ref T dst)
            where T : unmanaged
                => vmovnt_u(src, ref dst);

        [MethodImpl(Inline)]
        static unsafe void vmovnt_u<T>(Vector128<T> src, ref T dst)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                cpu.vmovnt(v8u(src), ref uint8(ref dst));
            else if(typeof(T) == typeof(ushort))
                cpu.vmovnt(v16u(src), ref uint16(ref dst));
            else if(typeof(T) == typeof(uint))
                cpu.vmovnt(v32u(src), ref uint32(ref dst));
            else if(typeof(T) == typeof(ulong))
                cpu.vmovnt(v64u(src), ref uint64(ref dst));
            else
                 vmovnt_i(src,ref dst);
        }

        [MethodImpl(Inline)]
        static unsafe void vmovnt_i<T>(Vector128<T> src, ref T dst)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                cpu.vmovnt(v8i(src), ref int8(ref dst));
            else if(typeof(T) == typeof(short))
                cpu.vmovntdq(v16i(src), ref int16(ref dst));
            else if(typeof(T) == typeof(int))
                cpu.vmovnt(v32i(src), ref int32(ref dst));
            else if(typeof(T) == typeof(long))
                cpu.vmovnt(v64i(src), ref int64(ref dst));
            else
                vmovnt_f(src, ref dst);
        }

        [MethodImpl(Inline)]
        static unsafe void vmovnt_f<T>(Vector128<T> src, ref T dst)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                cpu.vmovntps(v32f(src), ref float32(ref dst));
            else if(typeof(T) == typeof(double))
                cpu.vmovntpd(v64f(src), ref float64(ref dst));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static unsafe void vmovnt_u<T>(Vector256<T> src, ref T dst)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                cpu.vmovnt(v8u(src), ref uint8(ref dst));
            else if(typeof(T) == typeof(ushort))
                cpu.vmovnt(v16u(src), ref uint16(ref dst));
            else if(typeof(T) == typeof(uint))
                cpu.vmovnt(v32u(src), ref uint32(ref dst));
            else if(typeof(T) == typeof(ulong))
                cpu.vmovnt(v64u(src), ref uint64(ref dst));
            else
                 vmovnt_i(src,ref dst);
        }

        [MethodImpl(Inline)]
        static unsafe void vmovnt_i<T>(Vector256<T> src, ref T dst)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                cpu.vmovnt(v8i(src), ref int8(ref dst));
            else if(typeof(T) == typeof(short))
                cpu.vmovnt(v16i(src), ref int16(ref dst));
            else if(typeof(T) == typeof(int))
                cpu.vmovnt(v32i(src), ref int32(ref dst));
            else if(typeof(T) == typeof(long))
                cpu.vmovnt(v64i(src), ref int64(ref dst));
            else
                vmovnt_f(src, ref dst);
        }

        [MethodImpl(Inline)]
        static unsafe void vmovnt_f<T>(Vector256<T> src, ref T dst)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                cpu.vmovntps(v32f(src), ref float32(ref dst));
            else if(typeof(T) == typeof(double))
                cpu.vmovntpd(v64f(src), ref float64(ref dst));
            else
                throw no<T>();
        }
    }
}