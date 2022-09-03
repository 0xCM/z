//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using BL = ByteLogic;

    partial class vlogic
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bit testz<T>(in T a, in T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
               return BL.testz(u8(a), u8(b));
            else if(typeof(T) == typeof(ushort))
               return testz(w, a, b);
            else if(typeof(T) == typeof(uint))
               return testz(w, 4, 8, u32(a), u32(b));
            else if(typeof(T) == typeof(ulong))
               return testz(w, 16, 4, u64(a), u64(b));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), TestZ, Closures(Closure)]
        public static bit vtestz<T>(W128 w, in T a, in T b)
            where T : unmanaged
        {
            gcpu.vload(a, out Vector128<T> vA);
            gcpu.vload(b, out Vector128<T> vB);
            return gcpu.vtestz(vA,vB);
        }

        [MethodImpl(Inline), TestZ, Closures(Closure)]
        public static bit vtestz<T>(W256 w, in T a, in T b)
            where T : unmanaged
        {
            gcpu.vload(a, out Vector256<T> vA);
            gcpu.vload(b, out Vector256<T> vB);
            return gcpu.vtestz(vA,vB);
        }

        [MethodImpl(Inline), TestZ, Closures(Closure)]
        public static bit testz<T>(W128 n, in T a)
            where T : unmanaged
                => vtestz(n, a,a);

        [MethodImpl(Inline), TestZ, Closures(Closure)]
        public static bit testz<T>(W128 n, in T a, in T b)
            where T : unmanaged
                => vtestz(n, a, b);

        [MethodImpl(Inline), TestZ, Closures(Closure)]
        public static bit testz<T>(W256 n, in T a)
            where T : unmanaged
            => vtestz(n, a,a);

        [MethodImpl(Inline), TestZ, Closures(Closure)]
        public static bit testz<T>(W256 n, in T a, in T b)
            where T : unmanaged
                => vtestz(n, a, b);

        [MethodImpl(Inline), TestZ, Closures(Closure)]
        public static bit testz<T>(W128 n, int vcount, int blocklen, in T a)
            where T : unmanaged
        {
            var result = bit.On;
            for(int i=0, offset = 0; i < vcount; i++, offset += blocklen)
                result &= testz(n, skip(a, offset));
            return result;
        }

        [MethodImpl(Inline), TestZ, Closures(Closure)]
        public static bit testz<T>(W128 n, int vcount, int blocklen, in T a, in T b)
            where T : unmanaged
        {
            var result = bit.On;
            for(int i=0, offset = 0; i < vcount; i++, offset += blocklen)
                result &= vtestz(n, skip(a, offset), skip(b, offset));
            return result;
        }

        [MethodImpl(Inline), TestZ, Closures(Closure)]
        public static bit testz<T>(W256 n, int vcount, int blocklen, in T a)
            where T : unmanaged
        {
            var result = bit.On;
            for(int i=0, offset = 0; i < vcount; i++, offset += blocklen)
                result &= testz(n, skip(a, offset));
            return result;
        }

        [MethodImpl(Inline), TestZ, Closures(Closure)]
        public static bit testz<T>(W256 n, int vcount, int blocklen, in T a, in T b)
            where T : unmanaged
        {
            var result = bit.On;
            for(int i=0, offset = 0; i<vcount; i++, offset += blocklen)
                result &= vtestz(n, skip(a, offset), skip(b, offset));
            return result;
        }
    }
}