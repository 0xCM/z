//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using BL = ByteLogic;

    partial class vlogic
    {
        [MethodImpl(Inline), CImpl, Closures(Closure)]
        public static void cimpl<T>(in T a, in T b, ref T dst)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
               BL.cimpl(u8(a), u8(b), ref u8(dst));
            else if(typeof(T) == typeof(ushort))
                cimpl(w, in a, in b, ref dst);
            else if(typeof(T) == typeof(uint))
                cimpl(w, 4, 8, in a, in b, ref dst);
            else if(typeof(T) == typeof(ulong))
                cimpl(w, 16, 4, in a, in b, ref dst);
            else
                throw no<T>();
        }

        [MethodImpl(Inline), CImpl, Closures(Closure)]
        public static Vector128<T> vcimpl<T>(W128 w, in T a, in T b)
            where T : unmanaged
                => gcpu.vcimpl(gcpu.vload(w, a), gcpu.vload(w, b));

        [MethodImpl(Inline), CImpl, Closures(Closure)]
        public static Vector256<T> vcimpl<T>(W256 w, in T a, in T b)
            where T : unmanaged
                => gcpu.vcimpl(gcpu.vload(w, a), gcpu.vload(w, b));

        [MethodImpl(Inline), CImpl, Closures(Closure)]
        public static void cimpl<T>(W128 w, in T a, in T b, ref T dst)
            where T : unmanaged
                => gcpu.vstore(vcimpl(w, in a, in b), ref dst);

        [MethodImpl(Inline), CImpl, Closures(Closure)]
        public static void cimpl<T>(W256 w, in T a, in T b, ref T dst)
            where T : unmanaged
                => gcpu.vstore(vcimpl(w, a, b), ref dst);

        [MethodImpl(Inline), CImpl, Closures(Closure)]
        public static void cimpl<T>(W128 w, int vcount, int blocklen, in T a, in T b, ref T dst)
            where T : unmanaged
        {
            for(int i=0, offset = 0; i < vcount; i++, offset += blocklen)
                cimpl(w, skip(a, offset), skip(b, offset), ref seek(dst, offset));
        }

        [MethodImpl(Inline), CImpl, Closures(Closure)]
        public static void cimpl<T>(W256 w, int vcount, int blocklen, in T a, in T b, ref T dst)
            where T : unmanaged
        {
            for(int i=0, offset = 0; i < vcount; i++, offset += blocklen)
                cimpl(w, skip(a, offset), skip(b, offset), ref seek(dst, offset));
        }
    }
}