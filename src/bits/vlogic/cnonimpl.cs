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
        [MethodImpl(Inline), CNonImpl, Closures(Closure)]
        public static void cnonimpl<T>(in T a, in T b, ref T dst)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
               BL.cnonimpl(u8(a), u8(b), ref u8(dst));
            else if(typeof(T) == typeof(ushort))
                cnonimpl(w, a, b, ref dst);
            else if(typeof(T) == typeof(uint))
                cnonimpl(w, 4, 8, a, b, ref dst);
            else if(typeof(T) == typeof(ulong))
                cnonimpl(w, 16, 4, a, b, ref dst);
            else
                throw no<T>();
        }

        [MethodImpl(Inline), CNonImpl, Closures(Closure)]
        public static Vector128<T> vcnonimpl<T>(W128 w, in T a, in T b)
            where T : unmanaged
                => gcpu.vcnonimpl(gcpu.vload(w, a), gcpu.vload(w, b));

        [MethodImpl(Inline), CNonImpl, Closures(Closure)]
        public static Vector256<T> vcnonimpl<T>(W256 w, in T a, in T b)
            where T : unmanaged
                => gcpu.vcnonimpl(gcpu.vload(w, a),gcpu.vload(w, b));

        [MethodImpl(Inline), CNonImpl, Closures(Closure)]
        public static void cnonimpl<T>(W128 w, in T a, in T b, ref T dst)
            where T : unmanaged
                => gcpu.vstore(vcnonimpl(w, a, b), ref dst);

        [MethodImpl(Inline), CNonImpl, Closures(Closure)]
        public static void cnonimpl<T>(W256 w, in T a, in T b, ref T dst)
            where T : unmanaged
                => gcpu.vstore(vcnonimpl(w, a, b), ref dst);

        [MethodImpl(Inline), CNonImpl, Closures(Closure)]
        public static void cnonimpl<T>(W128 w, int vcount, int blocklen, in T a, in T b, ref T dst)
            where T : unmanaged
        {
            for(int i=0, offset = 0; i < vcount; i++, offset += blocklen)
                cnonimpl(w, skip(a, offset), skip(b, offset), ref seek(dst, offset));
        }

        [MethodImpl(Inline), CNonImpl, Closures(Closure)]
        public static void cnonimpl<T>(W256 w, int vcount, int blocklen, in T a, in T b, ref T dst)
            where T : unmanaged
        {
            for(int i=0, offset = 0; i < vcount; i++, offset += blocklen)
                cnonimpl(w, skip(a, offset), skip(b, offset), ref seek(dst, offset));
        }
    }
}