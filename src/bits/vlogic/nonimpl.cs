//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static vgcpu;

    using BL = ByteLogic;

    partial class vlogic
    {
        [MethodImpl(Inline), NonImpl, Closures(Closure)]
        public static void nonimpl<T>(in T a, in T b, ref T dst)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
               BL.nonimpl(u8(a),u8(b), ref u8(dst));
            else if(typeof(T) == typeof(ushort))
                nonimpl(w, in a, in b, ref dst);
            else if(typeof(T) == typeof(uint))
                nonimpl(w, 4, 8, in a, in b, ref dst);
            else if(typeof(T) == typeof(ulong))
                nonimpl(w, 16, 4, in a, in b, ref dst);
            else
                throw no<T>();
        }

        [MethodImpl(Inline), NonImpl, Closures(Closure)]
        public static Vector128<T> vnonimpl<T>(W128 w, in T a, in T b)
            where T : unmanaged
                => gcpu.vnonimpl(gcpu.vload(w, a), gcpu.vload(w, b));

        [MethodImpl(Inline), NonImpl, Closures(Closure)]
        public static Vector256<T> vnonimpl<T>(W256 w, in T a, in T b)
            where T : unmanaged
                => gcpu.vnonimpl(gcpu.vload(w, a), gcpu.vload(w, b));

        [MethodImpl(Inline), NonImpl, Closures(Closure)]
        public static void nonimpl<T>(W128 w, in T a, in T b, ref T dst)
            where T : unmanaged
                => vstore(vnonimpl(w, in a, in b), ref dst);

        [MethodImpl(Inline), NonImpl, Closures(Closure)]
        public static void nonimpl<T>(W256 w, in T a, in T b, ref T dst)
            where T : unmanaged
                => vstore(vnonimpl(w, in a, in b), ref dst);

        [MethodImpl(Inline), NonImpl, Closures(Closure)]
        public static void nonimpl<T>(W128 w, int vcount, int blocklen, in T a, in T b, ref T dst)
            where T : unmanaged
        {
            for(int i=0, offset = 0; i < vcount; i++, offset += blocklen)
                nonimpl(w, in skip(in a, offset), in skip(in b, offset), ref seek(dst, offset));
        }

        [MethodImpl(Inline), NonImpl, Closures(Closure)]
        public static void nonimpl<T>(W256 w, int vcount, int blocklen, in T a, in T b, ref T dst)
            where T : unmanaged
        {
            for(int i=0, offset = 0; i < vcount; i++, offset += blocklen)
                nonimpl(vlogic.w, in skip(in a, offset), in skip(in b, offset), ref seek(dst, offset));
        }
    }
}