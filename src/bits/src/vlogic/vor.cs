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
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void or<T>(in T A, in T B, ref T Z)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
               BL.or(u8(A), u8(B), ref u8(Z));
            else if(typeof(T) == typeof(ushort))
                or(w, A, B, ref Z);
            else if(typeof(T) == typeof(uint))
                or(w, 4, 8,A, B, ref Z);
            else if(typeof(T) == typeof(ulong))
                or(w, 16, 4, A, B, ref Z);
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Or, Closures(Closure)]
        public static Vector128<T> vor<T>(W128 w, in T a, in T b)
            where T : unmanaged
        {
            vgcpu.vload(in a, out Vector128<T> vA);
            vgcpu.vload(in b, out Vector128<T> vB);
            return vgcpu.vor(vA,vB);
        }

        [MethodImpl(Inline), Or, Closures(Closure)]
        public static Vector256<T> vor<T>(W256 w, in T a, in T b)
            where T : unmanaged
        {
            vgcpu.vload(in a, out Vector256<T> vA);
            vgcpu.vload(in b, out Vector256<T> vB);
            return vgcpu.vor(vA,vB);
        }

        [MethodImpl(Inline), Or, Closures(Closure)]
        public static void or<T>(W128 w, in T a, in T b, ref T z)
            where T : unmanaged
                => vstore(vor(w, a, b), ref z);

        [MethodImpl(Inline), Or, Closures(Closure)]
        public static void or<T>(W128 w, int vcount, int blocklen, in T a, in T b, ref T dst)
            where T : unmanaged
        {
            for(int i=0, offset = 0; i < vcount; i++, offset += blocklen)
                or(w, skip(a, offset), skip(b, offset), ref seek(dst, offset));
        }

        [MethodImpl(Inline), Or, Closures(Closure)]
        public static void or<T>(W256 w, in T a, in T b, ref T dst)
            where T : unmanaged
                => vgcpu.vstore(vor(w, a, b), ref dst);

        [MethodImpl(Inline), Or, Closures(Closure)]
        public static void or<T>(W256 w, int vcount, int blocklen, in T a, in T b, ref T dst)
            where T : unmanaged
        {
            for(int i=0, offset = 0; i < vcount; i++, offset += blocklen)
                or(w, skip(a, offset), skip(b, offset), ref seek(dst, offset));
        }
    }
}