//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static gcpu;

    using BL = ByteLogic;

    partial class vlogic
    {
        [MethodImpl(Inline), XorNot, Closures(Closure)]
        public static void xornot<T>(in T A, in T B, ref T dst)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
               BL.xornot(u8(A), u8(B), ref u8(dst));
            else if(typeof(T) == typeof(ushort))
                xornot(w, in A, in B, ref dst);
            else if(typeof(T) == typeof(uint))
                xornot(w, 4, 8, in A, in B, ref dst);
            else if(typeof(T) == typeof(ulong))
                xornot(w, 16, 4, in A, in B, ref dst);
            else
                throw no<T>();
        }

        [MethodImpl(Inline), XorNot, Closures(Closure)]
        public static Vector128<T> vxornot<T>(W128 w, in T a, in T b)
            where T : unmanaged
                => gcpu.vxornot(vload(w, in a), vload(w, in b));

        [MethodImpl(Inline), XorNot, Closures(Closure)]
        public static Vector256<T> vxornot<T>(W256 w, in T a, in T b)
            where T : unmanaged
                => gcpu.vxornot(vload(w, in a),vload(w, in b));

        [MethodImpl(Inline), XorNot, Closures(Closure)]
        public static void xornot<T>(W128 w, in T a, in T b, ref T c)
            where T : unmanaged
                => gcpu.vstore(vxornot(w, in a, in b), ref c);

        [MethodImpl(Inline), XorNot, Closures(Closure)]
        public static void xornot<T>(W256 w, in T a, in T b, ref T c)
            where T : unmanaged
                => gcpu.vstore(vxornot(w, in a, in b), ref c);

        [MethodImpl(Inline), XorNot, Closures(Closure)]
        public static void xornot<T>(W128 w, int vcount, int blocklen, in T a, in T b, ref T c)
            where T : unmanaged
        {
            for(int i=0, offset = 0; i < vcount; i++, offset += blocklen)
                xornot(w, in skip(in a, offset), in skip(in b, offset), ref seek(c, offset));
        }

        [MethodImpl(Inline), XorNot, Closures(Closure)]
        public static void xornot<T>(W256 w, int vcount, int blocklen,  in T a, in T b, ref T c)
            where T : unmanaged
        {
            for(int i=0, offset = 0; i < vcount; i++, offset += blocklen)
                xornot(w, in skip(in a, offset), in skip(in b, offset), ref seek(c, offset));
        }
    }
}